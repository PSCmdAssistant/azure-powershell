None // ----------------------------------------------------------------------------------
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

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = true)]
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
        public string CapacityReservationGroupId { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.")]
        public string UserData { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            HelpMessage = "Specified the gallery image unique id for vm deployment. This can be fetched from gallery image GET call.")]
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

        [Parameter(
            Mandatory = false,
            HelpMessage = "EnableProxyAgent, value: true or false. If not specified by user, default is false.")]
        public bool EnableProxyAgent { get; set; } = false;

        [Parameter(
            Mandatory = false,
            HelpMessage = "ProxyAgentMode, value: Enforce or Audit. If not specified by user, default is Enforce.")]
        [ValidateSet("Enforce", "Audit")]
        public string ProxyAgentMode { get; set; } = "Enforce";

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.UserData))
            {
                if (!ValidateBase64EncodedString.ValidateStringIsBase64Encoded(this.UserData))
                {
                    this.UserData = ValidateBase64EncodedString.EncodeStringToBase64(this.UserData);
                    this.WriteInformation(ValidateBase64EncodedString.UserDataEncodeNotification, new string[] { "PSHOST" });
                }
            }

            switch (ParameterSetName)
            {
                case SimpleParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                case DiskFileParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                default:
                    DefaultExecuteCmdlet();
                    break;
            }
        }

        class Parameters : IParameters<VirtualMachine>
        {
            readonly NewAzureVMCommand _cmdlet;

            readonly Client _client;

            readonly IResourceManagementClient _resourceClient;

            public Parameters(NewAzureVMCommand cmdlet, Client client, IResourceManagementClient resourceClient)
            {
                _cmdlet = cmdlet;
                _client = client;
                _resourceClient = resourceClient;
                _cmdlet.validate();
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            string _defaultLocation = null;

            public string DefaultLocation
            {
                get
                {
                    if (_defaultLocation == null)
                    {
                        var vmResourceType = _resourceClient.Providers.GetAsync("Microsoft.Compute").ConfigureAwait(false).GetAwaiter().GetResult()
                        .ResourceTypes.Where(a => String.Equals(a.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase))
                                      .FirstOrDefault();
                        if (vmResourceType != null)
                        {
                            var availableLocations = vmResourceType.Locations.Select(a => a.ToLower().Replace(" ", ""));
                            if (availableLocations.Any(a => a.Equals("eastus")))
                            {
                                _defaultLocation = "eastus";
                            }
                            _defaultLocation = availableLocations.FirstOrDefault() ?? "eastus";
                        }
                        else
                        {
                            _defaultLocation = "eastus";
                        }
                    }
                    return _defaultLocation;
                }
            }

            public BlobUri DestinationUri;

            public string StorageAccountId;

            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {

                if (_cmdlet.DiskFile == null)
                {
                    ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);
                }

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                Dictionary<string, List<string>> auxAuthHeader = null;
                if (!string.IsNullOrEmpty(_cmdlet.ImageReferenceId))
                {
                    var resourceId = ResourceId.TryParse(_cmdlet.ImageReferenceId);

                    if (string.Equals(ComputeStrategy.Namespace, resourceId?.ResourceType?.Namespace, StringComparison.OrdinalIgnoreCase)
                     && string.Equals("galleries", resourceId?.ResourceType?.Provider, StringComparison.OrdinalIgnoreCase)
                     && !string.Equals(_cmdlet.ComputeClient?.ComputeManagementClient?.SubscriptionId, resourceId?.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                    {
                        List<string> resourceIds = new List<string>();
                        resourceIds.Add(_cmdlet.ImageReferenceId);
                        var auxHeaderDictionary = _cmdlet.GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                        if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                        {
                            auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                        }
                    }
                }

                //Override Zone logic if PublicIpSku is explicitly provided
                PublicIPAddressStrategy.Sku publicIpSku;
                if (_cmdlet.PublicIpSku != null) {
                    if (_cmdlet.PublicIpSku != "Basic" && _cmdlet.PublicIpSku != "Standard")
                    {
                        throw new InvalidDataException("Invalid PublicIpSku parameter entry. Acceptable values for PublicIpSku parameter are \"Basic\" or \"Standard\" only");
                    }
                    publicIpSku = _cmdlet.PublicIpSku == "Basic" ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                else {
                    publicIpSku = _cmdlet.Zone == null ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                
                if (_cmdlet.IsParameterBound(c => c.SecurityType))
                {
                    if (_cmdlet.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || _cmdlet.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                        _cmdlet.EnableVtpm = _cmdlet.EnableVtpm ?? true;
                        _cmdlet.EnableSecureBoot = _cmdlet.EnableSecureBoot ?? true;
                    }
                }

                // Standard security type removing value since API does not support it.
                if (_cmdlet.IsParameterBound(c => c.SecurityType)  
                    && _cmdlet.SecurityType != null
                    && _cmdlet.SecurityType.ToString().ToLower() == ConstantValues.StandardSecurityType)
                {
                    _cmdlet.SecurityType = null;
                }

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, edgeZone: _cmdlet.EdgeZone, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: publicIpSku,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPorts = ImageAndOsType.UpdatePorts(_cmdlet.OpenPorts);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPorts);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                ResourceConfig<NetworkInterface> networkInterface;
                if (string.IsNullOrEmpty(publicIpAddress.Name))
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfigNoPublicIP(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet,
                        networkSecurityGroup, enableAcceleratedNetwork);
                }
                else
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);
                }

                var ppgSubResourceFunc = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(
                        name: _cmdlet.AvailabilitySetName,
                        proximityPlacementGroup: ppgSubResourceFunc);


                List<SshPublicKey> sshPublicKeyList = null;
                if (!String.IsNullOrEmpty(_cmdlet.SshKeyName))
                {
                    SshPublicKey sshPublicKey = _cmdlet.createPublicKeyObject(_cmdlet.Credential.UserName);
                    sshPublicKeyList = new List<SshPublicKey>()
                    {
                        sshPublicKey
                    };
                }

                // AdditionalCapabilities
                var vAdditionalCapabilities = new AdditionalCapabilities();
                if (_cmdlet.IsParameterBound(c => c.HibernationEnabled))
                {
                    vAdditionalCapabilities.HibernationEnabled = _cmdlet.HibernationEnabled;
                }
                if (_cmdlet.IsParameterBound(c => c.EnableUltraSSD))
                {
                    vAdditionalCapabilities.UltraSSDEnabled = _cmdlet.EnableUltraSSD;
                }

                _cmdlet.ConfigAsyncVisited = true;

                // ExtendedLocation
                CM.ExtendedLocation extLoc = null;
                if (_cmdlet.EdgeZone != null)
                {
                    extLoc = new CM.ExtendedLocation { Name = _cmdlet.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
                }

                if (_cmdlet.DiskFile == null)
                { 
                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        imageAndOsType: ImageAndOsType,
                        adminUsername: _cmdlet.Credential.UserName,
                        adminPassword:
                            new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?) null ,
                        sshPublicKeys: sshPublicKeyList,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        imageReferenceId: _cmdlet.ImageReferenceId,
                        auxAuthHeader: auxAuthHeader,
                        diskControllerType: _cmdlet.DiskControllerType,
                        extendedLocation: extLoc,
                        sharedGalleryImageId: _cmdlet.SharedGalleryImageId,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        ifMatch: _cmdlet.IfMatch,
                        ifNoneMatch: _cmdlet.IfNoneMatch,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                        );
                }
                else  // does not get used. DiskFile parameter set is not supported.
                {
                    var disk = resourceGroup.CreateManagedDiskConfig(
                        name: _cmdlet.Name,
                        sourceUri: DestinationUri.Uri.ToString());

                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        osType: ImageAndOsType.OsType,
                        disk: disk,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        ultraSSDEnabled: _cmdlet.EnableUltraSSD,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?)null,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        extendedLocation: extLoc,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                    );
                }
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName;
            SecurityGroupName = SecurityGroupName ?? Name;

            // Check TrustedLaunch UEFI values defaulting
            if (this.IsParameterBound(c => c.SecurityType)
                && this.SecurityType != null)
            {
                if (this.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || this.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                    this.EnableVtpm = this.EnableVtpm ?? true;
                    this.EnableSecureBoot = this.EnableSecureBoot ?? true;
                }
                // Default in TL Image to ease later migration. 
                else if (this.SecurityType?.ToLower() == ConstantValues.StandardSecurityType)
                {
                    if (!this.IsParameterBound(c => c.Image)
                    && !this.IsParameterBound(c => c.ImageReferenceId)
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                    {
                        this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    }
                }
                
            }
            // Default TrustedLaunch values for SimpleParameterSet (no config)
            // imagerefid is specifically shared gallery id, so don't want it.
            else
            {
                if (!this.IsParameterBound(c => c.Image) 
                    && !this.IsParameterBound(c => c.ImageReferenceId) 
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                {
                    this.SecurityType = ConstantValues.TrustedLaunchSecurityType;
                    this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    if (!this.IsParameterBound(c => c.EnableSecureBoot))
                    {
                        this.EnableSecureBoot = true;
                    }
                    if (!this.IsParameterBound(c => c.EnableVtpm))
                    {
                        this.EnableVtpm = true;
                    }
                }
            } 

            var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);

            var parameters = new Parameters(this, client, resourceClient);
            
            // Information message if the default Size value is used. 
            if (!this.IsParameterBound(c => c.Size))
            {
                WriteInformation("No Size value has been provided. The VM will be created with the default size Standard_D2s_v3.", new string[] { "PSHOST" });
            }
            if (DiskFile != null)
            {
                if (!resourceClient.ResourceGroups.CheckExistence(ResourceGroupName))
                {
                    Location = Location ?? parameters.DefaultLocation;
                    var st0 = resourceClient.ResourceGroups.CreateOrUpdate(
                        ResourceGroupName,
                        new ResourceGroup
                        {
                            Location = Location,
                            Name = ResourceGroupName
                        });
                }
                parameters.ImageAndOsType = new ImageAndOsType(
                    Linux ? OperatingSystemTypes.Linux : OperatingSystemTypes.Windows,
                    null,
                    null);

                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                var st1 = storageClient.StorageAccounts.Create(
                    ResourceGroupName,
                    Name,
                    new StorageAccountCreateParameters
                    {
                        Kind = "StorageV2",
                        Sku = new Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.Sku
                        {
                            Name = Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.SkuName.PremiumLRS
                        },
                        Location = Location
                    });
                var filePath = new FileInfo(SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiskFile));
                using (var vds = new VirtualDiskStream(filePath.FullName))
                {
                    // 2 ^ 9 == 512
                    if (vds.DiskType == DiskType.Fixed && filePath.Length % 512 != 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "filePath",
                            string.Format("Given vhd file '{0}' is a corrupted fixed vhd", filePath));
                    }
                }
                var storageAccount = storageClient.StorageAccounts.GetProperties(ResourceGroupName, Name);
                parameters.StorageAccountId = storageAccount.Id;
                // BlobUri destinationUri = null;
                BlobUri.TryParseUri(
                    new Uri(string.Format(
                        "{0}{1}/{2}{3}",
                        storageAccount.PrimaryEndpoints.Blob,
                        ResourceGroupName.ToLower(),
                        Name.ToLower(),
                        ".vhd")),
                    out parameters.DestinationUri);
                if (parameters.DestinationUri?.Uri == null)
                {
                    throw new ArgumentNullException("destinationUri");
                }
                var storageCredentialsFactory = new StorageCredentialsFactory(
                    ResourceGroupName, storageClient, DefaultContext.Subscription);
                var uploadParameters = new UploadParameters(parameters.DestinationUri, null, filePath, true, 2)
                {
                    Cmdlet = this,
                    BlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1))
                };
                if (!string.Equals(
                    Environment.GetEnvironmentVariable("AZURE_TEST_MODE"), "Playback", StringComparison.OrdinalIgnoreCase))
                {
                    var st2 = VhdUploaderModel.Upload(uploadParameters);
                }
            }

            VirtualMachine result;
            try
            {
                result = await client.RunAsync(client.SubscriptionId, parameters, asyncCmdlet);
            }
            catch (Microsoft.Rest.Azure.CloudException ex)
            {
                cleanUp();
                throw ex;
            }

            
            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);
                var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(result);
                psResult.FullyQualifiedDomainName = fqdn;
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential?.UserName);
                asyncCmdlet.WriteVerbose(
                    Resources.VirtualMachineUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteObject(psResult);
            }
        }

        class Parameters : IParameters<VirtualMachine>
        {
            readonly NewAzureVMCommand _cmdlet;

            readonly Client _client;

            readonly IResourceManagementClient _resourceClient;

            public Parameters(NewAzureVMCommand cmdlet, Client client, IResourceManagementClient resourceClient)
            {
                _cmdlet = cmdlet;
                _client = client;
                _resourceClient = resourceClient;
                _cmdlet.validate();
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            string _defaultLocation = null;

            public string DefaultLocation
            {
                get
                {
                    if (_defaultLocation == null)
                    {
                        var vmResourceType = _resourceClient.Providers.GetAsync("Microsoft.Compute").ConfigureAwait(false).GetAwaiter().GetResult()
                        .ResourceTypes.Where(a => String.Equals(a.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase))
                                      .FirstOrDefault();
                        if (vmResourceType != null)
                        {
                            var availableLocations = vmResourceType.Locations.Select(a => a.ToLower().Replace(" ", ""));
                            if (availableLocations.Any(a => a.Equals("eastus")))
                            {
                                _defaultLocation = "eastus";
                            }
                            _defaultLocation = availableLocations.FirstOrDefault() ?? "eastus";
                        }
                        else
                        {
                            _defaultLocation = "eastus";
                        }
                    }
                    return _defaultLocation;
                }
            }

            public BlobUri DestinationUri;

            public string StorageAccountId;

            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {

                if (_cmdlet.DiskFile == null)
                {
                    ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);
                }

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                Dictionary<string, List<string>> auxAuthHeader = null;
                if (!string.IsNullOrEmpty(_cmdlet.ImageReferenceId))
                {
                    var resourceId = ResourceId.TryParse(_cmdlet.ImageReferenceId);

                    if (string.Equals(ComputeStrategy.Namespace, resourceId?.ResourceType?.Namespace, StringComparison.OrdinalIgnoreCase)
                     && string.Equals("galleries", resourceId?.ResourceType?.Provider, StringComparison.OrdinalIgnoreCase)
                     && !string.Equals(_cmdlet.ComputeClient?.ComputeManagementClient?.SubscriptionId, resourceId?.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                    {
                        List<string> resourceIds = new List<string>();
                        resourceIds.Add(_cmdlet.ImageReferenceId);
                        var auxHeaderDictionary = _cmdlet.GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                        if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                        {
                            auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                        }
                    }
                }

                //Override Zone logic if PublicIpSku is explicitly provided
                PublicIPAddressStrategy.Sku publicIpSku;
                if (_cmdlet.PublicIpSku != null) {
                    if (_cmdlet.PublicIpSku != "Basic" && _cmdlet.PublicIpSku != "Standard")
                    {
                        throw new InvalidDataException("Invalid PublicIpSku parameter entry. Acceptable values for PublicIpSku parameter are \"Basic\" or \"Standard\" only");
                    }
                    publicIpSku = _cmdlet.PublicIpSku == "Basic" ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                else {
                    publicIpSku = _cmdlet.Zone == null ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                
                if (_cmdlet.IsParameterBound(c => c.SecurityType))
                {
                    if (_cmdlet.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || _cmdlet.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                        _cmdlet.EnableVtpm = _cmdlet.EnableVtpm ?? true;
                        _cmdlet.EnableSecureBoot = _cmdlet.EnableSecureBoot ?? true;
                    }
                }

                // Standard security type removing value since API does not support it.
                if (_cmdlet.IsParameterBound(c => c.SecurityType)  
                    && _cmdlet.SecurityType != null
                    && _cmdlet.SecurityType.ToString().ToLower() == ConstantValues.StandardSecurityType)
                {
                    _cmdlet.SecurityType = null;
                }

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, edgeZone: _cmdlet.EdgeZone, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: publicIpSku,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPorts = ImageAndOsType.UpdatePorts(_cmdlet.OpenPorts);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPorts);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                ResourceConfig<NetworkInterface> networkInterface;
                if (string.IsNullOrEmpty(publicIpAddress.Name))
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfigNoPublicIP(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet,
                        networkSecurityGroup, enableAcceleratedNetwork);
                }
                else
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);
                }

                var ppgSubResourceFunc = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(
                        name: _cmdlet.AvailabilitySetName,
                        proximityPlacementGroup: ppgSubResourceFunc);


                List<SshPublicKey> sshPublicKeyList = null;
                if (!String.IsNullOrEmpty(_cmdlet.SshKeyName))
                {
                    SshPublicKey sshPublicKey = _cmdlet.createPublicKeyObject(_cmdlet.Credential.UserName);
                    sshPublicKeyList = new List<SshPublicKey>()
                    {
                        sshPublicKey
                    };
                }

                // AdditionalCapabilities
                var vAdditionalCapabilities = new AdditionalCapabilities();
                if (_cmdlet.IsParameterBound(c => c.HibernationEnabled))
                {
                    vAdditionalCapabilities.HibernationEnabled = _cmdlet.HibernationEnabled;
                }
                if (_cmdlet.IsParameterBound(c => c.EnableUltraSSD))
                {
                    vAdditionalCapabilities.UltraSSDEnabled = _cmdlet.EnableUltraSSD;
                }

                _cmdlet.ConfigAsyncVisited = true;

                // ExtendedLocation
                CM.ExtendedLocation extLoc = null;
                if (_cmdlet.EdgeZone != null)
                {
                    extLoc = new CM.ExtendedLocation { Name = _cmdlet.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
                }

                if (_cmdlet.DiskFile == null)
                { 
                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        imageAndOsType: ImageAndOsType,
                        adminUsername: _cmdlet.Credential.UserName,
                        adminPassword:
                            new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?) null ,
                        sshPublicKeys: sshPublicKeyList,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        imageReferenceId: _cmdlet.ImageReferenceId,
                        auxAuthHeader: auxAuthHeader,
                        diskControllerType: _cmdlet.DiskControllerType,
                        extendedLocation: extLoc,
                        sharedGalleryImageId: _cmdlet.SharedGalleryImageId,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        ifMatch: _cmdlet.IfMatch,
                        ifNoneMatch: _cmdlet.IfNoneMatch,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                        );
                }
                else  // does not get used. DiskFile parameter set is not supported.
                {
                    var disk = resourceGroup.CreateManagedDiskConfig(
                        name: _cmdlet.Name,
                        sourceUri: DestinationUri.Uri.ToString());

                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        osType: ImageAndOsType.OsType,
                        disk: disk,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        ultraSSDEnabled: _cmdlet.EnableUltraSSD,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?)null,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        extendedLocation: extLoc,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                    );
                }
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName;
            SecurityGroupName = SecurityGroupName ?? Name;

            // Check TrustedLaunch UEFI values defaulting
            if (this.IsParameterBound(c => c.SecurityType)
                && this.SecurityType != null)
            {
                if (this.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || this.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                    this.EnableVtpm = this.EnableVtpm ?? true;
                    this.EnableSecureBoot = this.EnableSecureBoot ?? true;
                }
                // Default in TL Image to ease later migration. 
                else if (this.SecurityType?.ToLower() == ConstantValues.StandardSecurityType)
                {
                    if (!this.IsParameterBound(c => c.Image)
                    && !this.IsParameterBound(c => c.ImageReferenceId)
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                    {
                        this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    }
                }
                
            }
            // Default TrustedLaunch values for SimpleParameterSet (no config)
            // imagerefid is specifically shared gallery id, so don't want it.
            else
            {
                if (!this.IsParameterBound(c => c.Image) 
                    && !this.IsParameterBound(c => c.ImageReferenceId) 
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                {
                    this.SecurityType = ConstantValues.TrustedLaunchSecurityType;
                    this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    if (!this.IsParameterBound(c => c.EnableSecureBoot))
                    {
                        this.EnableSecureBoot = true;
                    }
                    if (!this.IsParameterBound(c => c.EnableVtpm))
                    {
                        this.EnableVtpm = true;
                    }
                }
            } 

            var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);

            var parameters = new Parameters(this, client, resourceClient);
            
            // Information message if the default Size value is used. 
            if (!this.IsParameterBound(c => c.Size))
            {
                WriteInformation("No Size value has been provided. The VM will be created with the default size Standard_D2s_v3.", new string[] { "PSHOST" });
            }
            if (DiskFile != null)
            {
                if (!resourceClient.ResourceGroups.CheckExistence(ResourceGroupName))
                {
                    Location = Location ?? parameters.DefaultLocation;
                    var st0 = resourceClient.ResourceGroups.CreateOrUpdate(
                        ResourceGroupName,
                        new ResourceGroup
                        {
                            Location = Location,
                            Name = ResourceGroupName
                        });
                }
                parameters.ImageAndOsType = new ImageAndOsType(
                    Linux ? OperatingSystemTypes.Linux : OperatingSystemTypes.Windows,
                    null,
                    null);

                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                var st1 = storageClient.StorageAccounts.Create(
                    ResourceGroupName,
                    Name,
                    new StorageAccountCreateParameters
                    {
                        Kind = "StorageV2",
                        Sku = new Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.Sku
                        {
                            Name = Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.SkuName.PremiumLRS
                        },
                        Location = Location
                    });
                var filePath = new FileInfo(SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiskFile));
                using (var vds = new VirtualDiskStream(filePath.FullName))
                {
                    // 2 ^ 9 == 512
                    if (vds.DiskType == DiskType.Fixed && filePath.Length % 512 != 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "filePath",
                            string.Format("Given vhd file '{0}' is a corrupted fixed vhd", filePath));
                    }
                }
                var storageAccount = storageClient.StorageAccounts.GetProperties(ResourceGroupName, Name);
                parameters.StorageAccountId = storageAccount.Id;
                // BlobUri destinationUri = null;
                BlobUri.TryParseUri(
                    new Uri(string.Format(
                        "{0}{1}/{2}{3}",
                        storageAccount.PrimaryEndpoints.Blob,
                        ResourceGroupName.ToLower(),
                        Name.ToLower(),
                        ".vhd")),
                    out parameters.DestinationUri);
                if (parameters.DestinationUri?.Uri == null)
                {
                    throw new ArgumentNullException("destinationUri");
                }
                var storageCredentialsFactory = new StorageCredentialsFactory(
                    ResourceGroupName, storageClient, DefaultContext.Subscription);
                var uploadParameters = new UploadParameters(parameters.DestinationUri, null, filePath, true, 2)
                {
                    Cmdlet = this,
                    BlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1))
                };
                if (!string.Equals(
                    Environment.GetEnvironmentVariable("AZURE_TEST_MODE"), "Playback", StringComparison.OrdinalIgnoreCase))
                {
                    var st2 = VhdUploaderModel.Upload(uploadParameters);
                }
            }

            VirtualMachine result;
            try
            {
                result = await client.RunAsync(client.SubscriptionId, parameters, asyncCmdlet);
            }
            catch (Microsoft.Rest.Azure.CloudException ex)
            {
                cleanUp();
                throw ex;
            }

            
            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);
                var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(result);
                psResult.FullyQualifiedDomainName = fqdn;
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential?.UserName);
                asyncCmdlet.WriteVerbose(
                    Resources.VirtualMachineUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteObject(psResult);
            }
        }

        class Parameters : IParameters<VirtualMachine>
        {
            readonly NewAzureVMCommand _cmdlet;

            readonly Client _client;

            readonly IResourceManagementClient _resourceClient;

            public Parameters(NewAzureVMCommand cmdlet, Client client, IResourceManagementClient resourceClient)
            {
                _cmdlet = cmdlet;
                _client = client;
                _resourceClient = resourceClient;
                _cmdlet.validate();
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            string _defaultLocation = null;

            public string DefaultLocation
            {
                get
                {
                    if (_defaultLocation == null)
                    {
                        var vmResourceType = _resourceClient.Providers.GetAsync("Microsoft.Compute").ConfigureAwait(false).GetAwaiter().GetResult()
                        .ResourceTypes.Where(a => String.Equals(a.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase))
                                      .FirstOrDefault();
                        if (vmResourceType != null)
                        {
                            var availableLocations = vmResourceType.Locations.Select(a => a.ToLower().Replace(" ", ""));
                            if (availableLocations.Any(a => a.Equals("eastus")))
                            {
                                _defaultLocation = "eastus";
                            }
                            _defaultLocation = availableLocations.FirstOrDefault() ?? "eastus";
                        }
                        else
                        {
                            _defaultLocation = "eastus";
                        }
                    }
                    return _defaultLocation;
                }
            }

            public BlobUri DestinationUri;

            public string StorageAccountId;

            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {

                if (_cmdlet.DiskFile == null)
                {
                    ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);
                }

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                Dictionary<string, List<string>> auxAuthHeader = null;
                if (!string.IsNullOrEmpty(_cmdlet.ImageReferenceId))
                {
                    var resourceId = ResourceId.TryParse(_cmdlet.ImageReferenceId);

                    if (string.Equals(ComputeStrategy.Namespace, resourceId?.ResourceType?.Namespace, StringComparison.OrdinalIgnoreCase)
                     && string.Equals("galleries", resourceId?.ResourceType?.Provider, StringComparison.OrdinalIgnoreCase)
                     && !string.Equals(_cmdlet.ComputeClient?.ComputeManagementClient?.SubscriptionId, resourceId?.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                    {
                        List<string> resourceIds = new List<string>();
                        resourceIds.Add(_cmdlet.ImageReferenceId);
                        var auxHeaderDictionary = _cmdlet.GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                        if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                        {
                            auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                        }
                    }
                }

                //Override Zone logic if PublicIpSku is explicitly provided
                PublicIPAddressStrategy.Sku publicIpSku;
                if (_cmdlet.PublicIpSku != null) {
                    if (_cmdlet.PublicIpSku != "Basic" && _cmdlet.PublicIpSku != "Standard")
                    {
                        throw new InvalidDataException("Invalid PublicIpSku parameter entry. Acceptable values for PublicIpSku parameter are \"Basic\" or \"Standard\" only");
                    }
                    publicIpSku = _cmdlet.PublicIpSku == "Basic" ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                else {
                    publicIpSku = _cmdlet.Zone == null ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                
                if (_cmdlet.IsParameterBound(c => c.SecurityType))
                {
                    if (_cmdlet.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || _cmdlet.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                        _cmdlet.EnableVtpm = _cmdlet.EnableVtpm ?? true;
                        _cmdlet.EnableSecureBoot = _cmdlet.EnableSecureBoot ?? true;
                    }
                }

                // Standard security type removing value since API does not support it.
                if (_cmdlet.IsParameterBound(c => c.SecurityType)  
                    && _cmdlet.SecurityType != null
                    && _cmdlet.SecurityType.ToString().ToLower() == ConstantValues.StandardSecurityType)
                {
                    _cmdlet.SecurityType = null;
                }

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, edgeZone: _cmdlet.EdgeZone, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: publicIpSku,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPorts = ImageAndOsType.UpdatePorts(_cmdlet.OpenPorts);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPorts);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                ResourceConfig<NetworkInterface> networkInterface;
                if (string.IsNullOrEmpty(publicIpAddress.Name))
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfigNoPublicIP(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet,
                        networkSecurityGroup, enableAcceleratedNetwork);
                }
                else
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);
                }

                var ppgSubResourceFunc = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(
                        name: _cmdlet.AvailabilitySetName,
                        proximityPlacementGroup: ppgSubResourceFunc);


                List<SshPublicKey> sshPublicKeyList = null;
                if (!String.IsNullOrEmpty(_cmdlet.SshKeyName))
                {
                    SshPublicKey sshPublicKey = _cmdlet.createPublicKeyObject(_cmdlet.Credential.UserName);
                    sshPublicKeyList = new List<SshPublicKey>()
                    {
                        sshPublicKey
                    };
                }

                // AdditionalCapabilities
                var vAdditionalCapabilities = new AdditionalCapabilities();
                if (_cmdlet.IsParameterBound(c => c.HibernationEnabled))
                {
                    vAdditionalCapabilities.HibernationEnabled = _cmdlet.HibernationEnabled;
                }
                if (_cmdlet.IsParameterBound(c => c.EnableUltraSSD))
                {
                    vAdditionalCapabilities.UltraSSDEnabled = _cmdlet.EnableUltraSSD;
                }

                _cmdlet.ConfigAsyncVisited = true;

                // ExtendedLocation
                CM.ExtendedLocation extLoc = null;
                if (_cmdlet.EdgeZone != null)
                {
                    extLoc = new CM.ExtendedLocation { Name = _cmdlet.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
                }

                if (_cmdlet.DiskFile == null)
                { 
                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        imageAndOsType: ImageAndOsType,
                        adminUsername: _cmdlet.Credential.UserName,
                        adminPassword:
                            new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?) null ,
                        sshPublicKeys: sshPublicKeyList,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        imageReferenceId: _cmdlet.ImageReferenceId,
                        auxAuthHeader: auxAuthHeader,
                        diskControllerType: _cmdlet.DiskControllerType,
                        extendedLocation: extLoc,
                        sharedGalleryImageId: _cmdlet.SharedGalleryImageId,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        ifMatch: _cmdlet.IfMatch,
                        ifNoneMatch: _cmdlet.IfNoneMatch,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                        );
                }
                else  // does not get used. DiskFile parameter set is not supported.
                {
                    var disk = resourceGroup.CreateManagedDiskConfig(
                        name: _cmdlet.Name,
                        sourceUri: DestinationUri.Uri.ToString());

                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        osType: ImageAndOsType.OsType,
                        disk: disk,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        ultraSSDEnabled: _cmdlet.EnableUltraSSD,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: (_cmdlet.EncryptionAtHost.IsPresent == true) ? true : (bool?)null,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        extendedLocation: extLoc,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot,
                        enableProxyAgent: _cmdlet.EnableProxyAgent,
                        proxyAgentMode: _cmdlet.ProxyAgentMode
                    );
                }
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName;
            SecurityGroupName = SecurityGroupName ?? Name;

            // Check TrustedLaunch UEFI values defaulting
            if (this.IsParameterBound(c => c.SecurityType)
                && this.SecurityType != null)
            {
                if (this.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || this.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                    this.EnableVtpm = this.EnableVtpm ?? true;
                    this.EnableSecureBoot = this.EnableSecureBoot ?? true;
                }
                // Default in TL Image to ease later migration. 
                else if (this.SecurityType?.ToLower() == ConstantValues.StandardSecurityType)
                {
                    if (!this.IsParameterBound(c => c.Image)
                    && !this.IsParameterBound(c => c.ImageReferenceId)
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                    {
                        this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    }
                }
                
            }
            // Default TrustedLaunch values for SimpleParameterSet (no config)
            // imagerefid is specifically shared gallery id, so don't want it.
            else
            {
                if (!this.IsParameterBound(c => c.Image) 
                    && !this.IsParameterBound(c => c.ImageReferenceId) 
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                {
                    this.SecurityType = ConstantValues.TrustedLaunchSecurityType;
                    this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    if (!this.IsParameterBound(c => c.EnableSecureBoot))
                    {
                        this.EnableSecureBoot = true;
                    }
                    if (!this.IsParameterBound(c => c.EnableVtpm))
                    {
                        this.EnableVtpm = true;
                    }
                }
            } 

            var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);

            var parameters = new Parameters(this, client, resourceClient);
            
            // Information message if the default Size value is used. 
            if (!this.IsParameterBound(c => c.Size))
            {
                WriteInformation("No Size value has been provided. The VM will be created with the default size Standard_D2s_v3.", new string[] { "PSHOST" });
            }
            if (DiskFile != null)
            {
                if (!resourceClient.ResourceGroups.CheckExistence(ResourceGroupName))
                {
                    Location = Location ?? parameters.DefaultLocation;
                    var st0 = resourceClient.ResourceGroups.CreateOrUpdate(
                        ResourceGroupName,
                        new ResourceGroup
                        {
                            Location = Location,
                            Name = ResourceGroupName
                        });
                }
                parameters.ImageAndOsType = new ImageAndOsType(
                    Linux ? OperatingSystemTypes.Linux : OperatingSystemTypes.Windows,
                    null,
                    null);

                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                var st1 = storageClient.StorageAccounts.Create(
                    ResourceGroupName,
                    Name,
                    new StorageAccountCreateParameters
                    {
                        Kind = "StorageV2",
                        Sku = new Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.Sku
None