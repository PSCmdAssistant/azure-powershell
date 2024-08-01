csharp
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMAccessExtension",SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMAccessExtensionCommand : SetAzureVMExtensionBaseCmdlet
    {
        private const string userNameKey = "UserName";
        private const string passwordKey = "Password";
        private const string checkDiskKey = "check_disk";
        private const string repairDiskKey = "repair_disk";
        private const string sshKey = "ssh_key";
        private const string resetSSHKey = "reset_ssh";
        private const string removeUserKey = "remove_user";
        private const string accountExpirationKey = "expiration";

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Credential")]
        [ValidateNotNullOrEmpty]
        public PSCredential Credential { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Check Disk")]
        public SwitchParameter CheckDisk { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Repair Disk")]
        public SwitchParameter RepairDisk { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "SSH Key")]
        public string SSHKey { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Reset SSH")]
        public SwitchParameter ResetSSH { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Remove User")]
        public string RemoveUser { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Account Expiration")]
        public string AccountExpiration { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(VirtualMachineAccessExtensionContext.ExtensionDefaultName, VerbsCommon.Set))
            {
                ExecuteClientAction(() =>
                {
                    Hashtable publicSettings = new Hashtable();
                    Hashtable privateSettings = new Hashtable();

                    if (Credential != null)
                    {
                        publicSettings.Add(userNameKey, Credential.UserName ?? "");
                        privateSettings.Add(passwordKey, ConversionUtilities.SecureStringToString(Credential.Password));
                    }

                    if (CheckDisk.IsPresent)
                    {
                        publicSettings.Add(checkDiskKey, true);
                    }

                    if (RepairDisk.IsPresent)
                    {
                        publicSettings.Add(repairDiskKey, true);
                    }

                    if (!string.IsNullOrEmpty(SSHKey))
                    {
                        privateSettings.Add(sshKey, SSHKey);
                    }

                    if (ResetSSH.IsPresent)
                    {
                        privateSettings.Add(resetSSHKey, true);
                    }

                    if (!string.IsNullOrEmpty(RemoveUser))
                    {
                        privateSettings.Add(removeUserKey, RemoveUser);
                    }

                    if (!string.IsNullOrEmpty(AccountExpiration))
                    {
                        privateSettings.Add(accountExpirationKey, AccountExpiration);
                    }

                    if (string.IsNullOrEmpty(this.Location))
                    {
                        this.Location = GetLocationFromVm(this.ResourceGroupName, this.VMName);
                    }

                    var parameters = new VirtualMachineExtension
                    {
                        Location = this.Location,
                        VirtualMachineExtensionType = VirtualMachineAccessExtensionContext.ExtensionDefaultName,
                        Publisher = VirtualMachineAccessExtensionContext.ExtensionDefaultPublisher,
                        TypeHandlerVersion = (this.TypeHandlerVersion) ?? VirtualMachineAccessExtensionContext.ExtensionDefaultVersion,
                        Settings = publicSettings,
                        ProtectedSettings = privateSettings,
                        AutoUpgradeMinorVersion = !this.DisableAutoUpgradeMinorVersion.IsPresent,
                        ForceUpdateTag = this.ForceRerun
                    };

                    if (NoWait.IsPresent)
                    {
                        var op = this.VirtualMachineExtensionClient.BeginCreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.VMName,
                            this.Name,
                            parameters).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                    else
                    {
                        var op = this.VirtualMachineExtensionClient.CreateOrUpdateWithHttpMessagesAsync(
                            this.ResourceGroupName,
                            this.VMName,
                            this.Name,
                            parameters).GetAwaiter().GetResult();
                        var result = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op);
                        WriteObject(result);
                    }
                });
            }
        }
    }
}
