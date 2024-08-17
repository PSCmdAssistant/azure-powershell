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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
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
            HelpMessage = "The priority for the virtual machine.