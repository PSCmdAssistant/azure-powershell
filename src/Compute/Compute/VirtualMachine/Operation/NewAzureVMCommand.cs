 // ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using CM = Microsoft.Azure.Management.Compute.Models;
using SM = Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models;
using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.Azure.Commands.Common.Strategies.Compute;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", SupportsShouldProcess = true, DefaultParameterSetName = "SimpleParameterSet")]
    [OutputType(typeof(PSAzureOperationResponse), typeof(PSVirtualMachine))]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        public const string DefaultParameterSet = "DefaultParameterSet";
        public const string SimpleParameterSet = "SimpleParameterSet";
        public const string DiskFileParameterSet = "DiskFileParameterSet";
        public bool ConfigAsyncVisited = false;
        
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [LocationCompleter("Microsoft.Compute/virtualMachines")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string EdgeZone { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] Zone { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet, 
            Mandatory = false,
            HelpMessage = "Specify public IP sku name")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            HelpMessage = "Specify public IP sku name")]
        [PSArgumentCompleter("Basic","Standard")]
        public string PublicIpSku { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Disable BG Info Extension")]
        public SwitchParameter DisableBginfoExtension { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string LicenseType { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specifies Network Interface delete option after VM deletion. Options are Detach or Delete.",
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "Specifies Network Interface delete option after VM deletion. Options are Detach or Delete.",
            Mandatory = false)]
        public string NetworkInterfaceDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AddressPrefix { get; set; } = "192.168.0.0/16";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetAddressPrefix { get; set; } = "192.168.1.0/24";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string PublicIpAddressName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string DomainNameLabel { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        [ValidateSet("Static", "Dynamic")]
        public string AllocationMethod { get; set; } = "Static";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        [PSArgumentCompleter(
            "CentOS85Gen2",
            "Debian11",
            "OpenSuseLeap154Gen2",
            "RHELRaw8LVMGen2",
            "SuseSles15SP3",
            "Ubuntu2204",
            "FlatcarLinuxFreeGen2",
            "Win2022Datacenter",
            "Win2022AzureEditionCore",
            "Win2022AzureEdition",
            "Win2019Datacenter",
            "Win2016Datacenter",
            "Win2012R2Datacenter",
            "Win2012Datacenter",
            "Win10",
            "Win2016DataCenterGenSecond")]
        [Alias("ImageName")]
        public string Image { get; set; } = "Win2016Datacenter";

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DiskFile { get; set; }

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter Linux { get; set; } = false;

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string Size { get; set; } = "Standard_D2s_v3";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AvailabilitySetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public string OSDiskDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] DataDiskSizeInGb { get; set; }

        [Parameter(Mandatory = false)]
        public string DataDiskDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Alias("ProximityPlacementGroup")]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string ProximityPlacementGroupId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string HostId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string VmssId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The priority for the virtual machine. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The priority for the virtual machine. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [PSArgumentCompleter("Regular", "Spot")]
        public string Priority { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'.")]
        [PSArgumentCompleter("Deallocate", "Delete")]
        public string EvictionPolicy { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The max price of the billing of a low priority virtual machine.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The max price of the billing of a low priority virtual machine.")]
        public double MaxPrice { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        public SwitchParameter EncryptionAtHost { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The resource id of the dedicated host group, on which the customer wants their VM placed using automatic placement.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The resource id of the dedicated host group, on which the customer wants their VM placed using automatic placement.",
            ValueFromPipelineByPropertyName = true)]
        public string HostGroupId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter EnableVtpm { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter EnableSecureBoot { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the SSH Public Key resource.",
            ParameterSetName = DefaultParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the SSH Public Key resource.",
            ParameterSetName = SimpleParameterSet)]
        public string SshKeyName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate a SSH Public/Private key pair and create a SSH Public Key resource on Azure.",
            ParameterSetName = DefaultParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate a SSH Public/Private key pair and create a SSH Public Key resource on Azure.",
            ParameterSetName = SimpleParameterSet)]
        public SwitchParameter GenerateSshKey { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string CapacityReservationGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        public string UserData { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specified the gallery image unique id for vm deployment. This can be fetched from gallery image GET call.")]
        [ResourceIdCompleter("Microsoft.Compute galleries/images/versions")]
        public string ImageReferenceId { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the fault domain of the virtual machine.")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the fault domain of the virtual machine.")]
        public int PlatformFaultDomain { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        public SwitchParameter HibernationEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).")]
        public int vCPUCountAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.")]
        public int vCPUCountPerCore { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specifies the disk controller type configured for the VM and VirtualMachineScaleSet. This property is only supported for virtual machines whose operating system disk and VM sku supports Generation 2 (https://learn.microsoft.com/en-us/azure/virtual-machines/generation-2), please check the HyperVGenerations capability returned as part of VM sku capabilities in the response of Microsoft.Compute SKUs api for the region contains V2 (https://learn.microsoft.com/rest/api/compute/resourceskus/list) . <br> For more information about Disk Controller Types supported please refer to https://aka.ms/azure-diskcontrollertypes.")]
        [PSArgumentCompleter("SCSI", "NVMe")]
        public string DiskControllerType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specified the shared gallery image unique id for vm deployment. This can be fetched from shared gallery image GET call.")]
        public string SharedGalleryImageId { get; set; }
        
        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        [ValidateSet(ValidateSetValues.TrustedLaunch, ValidateSetValues.ConfidentialVM, ValidateSetValues.Standard, IgnoreCase = true)]
        [PSArgumentCompleter("TrustedLaunch", "ConfidentialVM", "Standard")]
        public string SecurityType { get; set; }

        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies whether vTPM should be enabled on the virtual machine.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        public bool? EnableVtpm { get; set; } = null;

        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies whether secure boot should be enabled on the virtual machine.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        public bool? EnableSecureBoot { get; set; } = null;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "used to make a request conditional for the PUT and other non-safe methods. The server will only return the requested resources if the resource matches one of the listed ETag values. Omit this value to always overwrite the current resource. Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.")]
        public string IfMatch { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Used to make a request conditional for the GET and HEAD methods. The server will only return the requested resources if none of the listed ETag values match the current entity. Used to make a request conditional for the GET and HEAD methods. The server will only return the requested resources if none of the listed ETag values match the current entity. Set to '*' to allow a new record set to be created, but to prevent updating an existing record set. Other values will result in error from server as they are not supported.")]
        public string IfNoneMatch { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            if (this.IsParameterBound(c => c.VM))
            {
                this.ResourceGroupName = this.VM.ResourceGroupName;
                this.VMName = this.VM.Name;
            }
            var vVirtualMachine = new PSVirtualMachine();

            vVirtualMachine.Location = this.Location;
            vVirtualMachine.Zone = this.MyInvocation.BoundParameters.ContainsKey("Zone") ? this.Zone : null;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Tags = this.MyInvocation.BoundParameters.ContainsKey("Tag") ? this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value) : null;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup = this.ProximityPlacementGroup;
            vVirtualMachine.ProximityPlacementGroupReference = this.ProximityPlacementGroupReference;
            vVirtualMachine.AdditionalCapabilities = this.AdditionalCapabilities;
            vVirtualMachine.AdditionalCapabilitiesReference = this.AdditionalCapabilitiesReference;
            vVirtualMachine.UltraSSDEnabled = this.UltraSSDEnabled;
            vVirtualMachine.UltraSSDEnabledReference = this.UltraSSDEnabledReference;
            vVirtualMachine.Priority = this.Priority;
            vVirtualMachine.PriorityReference = this.PriorityReference;
            vVirtualMachine.MaxPrice = this.MaxPrice;
            vVirtualMachine.MaxPriceReference = this.MaxPriceReference;
            vVirtualMachine.ScaleSet = this.ScaleSet;
            vVirtualMachine.ScaleSetReference = this.ScaleSetReference;
            vVirtualMachine.LicenseType = this.LicenseType;
            vVirtualMachine.LicenseTypeReference = this.LicenseTypeReference;
            vVirtualMachine.CapacityReservation = this.CapacityReservation;
            vVirtualMachine.CapacityReservationReference = this.CapacityReservationReference;
            vVirtualMachine.ExtendedLocation = this.ExtendedLocation;
            vVirtualMachine.ExtendedLocationReference = this.ExtendedLocationReference;
            vVirtualMachine.PlatformFaultDomain = this.PlatformFaultDomain;
            vVirtualMachine.PlatformFaultDomainReference = this.PlatformFaultDomainReference;
            vVirtualMachine.UserData = this.UserData;
            vVirtualMachine.UserDataReference = this.UserDataReference;
            vVirtualMachine.PowerState = this.PowerState;
            vVirtualMachine.PowerStateReference = this.PowerStateReference;
            vVirtualMachine.ProvisioningState = this.ProvisioningState;
            vVirtualMachine.ProvisioningStateReference = this.ProvisioningStateReference;
            vVirtualMachine.LicenseState = this.LicenseState;
            vVirtualMachine.LicenseStateReference = this.LicenseStateReference;
            vVirtualMachine.DisplayName = this.DisplayName;
            vVirtualMachine.DisplayNameReference = this.DisplayNameReference;
            vVirtualMachine.LastModelApplied = this.LastModelApplied;
            vVirtualMachine.LastModelAppliedReference = this.LastModelAppliedReference;
            vVirtualMachine.LatestOperationResult = this.LatestOperationResult;
            vVirtualMachine.LatestOperationResultReference = this.LatestOperationResultReference;
            vVirtualMachine.LatestOperationMessage = this.LatestOperationMessage;
            vVirtualMachine.LatestOperationMessageReference = this.LatestOperationMessageReference;
            vVirtualMachine.LatestOperationName = this.LatestOperationName;
            vVirtualMachine.LatestOperationNameReference = this.LatestOperationNameReference;
            vVirtualMachine.VMAgent = this.VMAgent;
            vVirtualMachine.VMAgentReference = this.VMAgentReference;
            vVirtualMachine.Disks = this.Disks;
            vVirtualMachine.DisksReference = this.DisksReference;
            vVirtualMachine.Statuses = this.Statuses;
            vVirtualMachine.StatusesReference = this.StatusesReference;
            vVirtualMachine.BootDiagnostics = this.BootDiagnostics;
            vVirtualMachine.BootDiagnosticsReference = this.BootDiagnosticsReference;
            vVirtualMachine.ScheduledEventsProfile = this.ScheduledEventsProfile;
            vVirtualMachine.ScheduledEventsProfileReference = this.ScheduledEventsProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.SecurityType = this.SecurityType;
            vVirtualMachine.SecurityTypeReference = this.SecurityTypeReference;
            vVirtualMachine.EnableVtpm = this.EnableVtpm;
            vVirtualMachine.EnableVtpmReference = this.EnableVtpmReference;
            vVirtualMachine.EnableSecureBoot = this.EnableSecureBoot;
            vVirtualMachine.EnableSecureBootReference = this.EnableSecureBootReference;
            vVirtualMachine.Id = this.Id;
            vVirtualMachine.IdReference = this.IdReference;
            vVirtualMachine.Name = this.Name;
            vVirtualMachine.NameReference = this.NameReference;
            vVirtualMachine.Type = this.Type;
            vVirtualMachine.TypeReference = this.TypeReference;
            vVirtualMachine.ResourceGroupName = this.ResourceGroupName;
            vVirtualMachine.ResourceGroupNameReference = this.ResourceGroupNameReference;
            vVirtualMachine.ETag = this.ETag;
            vVirtualMachine.ETagReference = this.ETagReference;
            vVirtualMachine.Tags = this.Tags;
            vVirtualMachine.TagsReference = this.TagsReference;
            vVirtualMachine.Zone = this.Zone;
            vVirtualMachine.ZoneReference = this.ZoneReference;
            vVirtualMachine.Plan = this.Plan;
            vVirtualMachine.PlanReference = this.PlanReference;
            vVirtualMachine.AvailabilitySet = this.AvailabilitySet;
            vVirtualMachine.AvailabilitySetReference = this.AvailabilitySetReference;
            vVirtualMachine.HardwareProfile = this.HardwareProfile;
            vVirtualMachine.HardwareProfileReference = this.HardwareProfileReference;
            vVirtualMachine.StorageProfile = this.StorageProfile;
            vVirtualMachine.StorageProfileReference = this.StorageProfileReference;
            vVirtualMachine.OSProfile = this.OSProfile;
            vVirtualMachine.OSProfileReference = this.OSProfileReference;
            vVirtualMachine.NetworkProfile = this.NetworkProfile;
            vVirtualMachine.NetworkProfileReference = this.NetworkProfileReference;
            vVirtualMachine.DiagnosticsProfile = this.DiagnosticsProfile;
            vVirtualMachine.DiagnosticsProfileReference = this.DiagnosticsProfileReference;
            vVirtualMachine.Extensions = this.Extensions;
            vVirtualMachine.ExtensionReferences = this.ExtensionReferences;
            vVirtualMachine.VMSize = this.VMSize;
            vVirtualMachine.VMSizeReference = this.VMSizeReference;
            vVirtualMachine.Identity = this.Identity;
            vVirtualMachine.IdentityReference = this.IdentityReference;
            vVirtualMachine.ZoneSettings = this.ZoneSettings;
            vVirtualMachine.ZoneSettingsReference = this.ZoneSettingsReference;
            vVirtualMachine.Host = this.Host;
            vVirtualMachine.HostReference = this.HostReference;
            vVirtualMachine.EvictionPolicy = this.EvictionPolicy;
            vVirtualMachine.EvictionPolicyReference = this.EvictionPolicyReference;
            vVirtualMachine.BillingProfile = this.BillingProfile;
            vVirtualMachine.BillingProfileReference = this.BillingProfileReference;
            vVirtualMachine.SecurityProfile = this.SecurityProfile;
            vVirtualMachine.SecurityProfileReference = this.SecurityProfileReference;
            vVirtualMachine.HostGroup = this.HostGroup;
            vVirtualMachine.HostGroupReference = this.HostGroupReference;
            vVirtualMachine.ProximityPlacementGroup =

public override void ExecuteCmdlet()
{
    base.ExecuteCmdlet();

    if (ShouldProcess(target: VMName, action: string.Format("Create VM '{0}' in resource group '{1}'", VMName, ResourceGroupName)))
    {
        Run();
    }
}

protected override void Run()
{
    // Existing code...

    // Check for image capabilities
    var imageCapabilities = GetImageCapabilities(Image);

    // If no size specified, default VM Size taken as Standard_D2s_v3 for New-AzVM and Standard_DS1_v2 for New-AzVMSS
    if (string.IsNullOrEmpty(Size))
    {
        Size = this is NewAzVMCommand ? "Standard_D2s_v3" : "Standard_DS1_v2";
    }

    // If the hyperVGeneration of image specified is v2
    if (imageCapabilities.hyperVGeneration == "v2")
    {
        // Enable Trusted Launch as Default for New-AzVM parameters
        SecurityType = "TrustedLaunch";
        EnableSecureBoot = $true;
        EnablevTPM = $true;
    }
    // If the hyperVGeneration of image specified is v1
    else if (imageCapabilities.hyperVGeneration == "v1")
    {
        // SecurityType will be set to Standard
        SecurityType = "Standard";

        // VM will get deployed as Generation 1 VM - along with Notification message should be printed for user
        WriteWarning("Consider upgrading security for your workloads using Azure Trusted Launch VMs. To know more about Trusted Launch, please visit https://aka.ms/TrustedLaunch");
    }

    // Existing code...
}

private dynamic GetImageCapabilities(string image)
{
    // Call Virtual Machines Images GET API and return the capabilities
    // This is a placeholder, replace with actual API call
    return new { hyperVGeneration = "v2" };
}
