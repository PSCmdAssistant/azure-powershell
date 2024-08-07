 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsSecurity.Grant, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskAccess", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAccessUri))]
    public partial class GrantAzureRmDiskAccess : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.DiskName, VerbsSecurity.Grant))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string diskName = this.DiskName;
                    var grantAccessData = new GrantAccessData();
                    grantAccessData.Access = this.Access;
                    grantAccessData.DurationInSeconds = this.DurationInSecond;
                    grantAccessData.GetSecureVMGuestStateSAS = this.SecureVMGuestStateSAS;

                    var result = DisksClient.GrantAccess(resourceGroupName, diskName, grantAccessData);
                    var psObject = new PSAccessUri();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<AccessUri, PSAccessUri>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/disks", "ResourceGroupName")]
        [Alias("Name")]
        public string DiskName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true)]
        public string Access { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = false)]
        public int DurationInSecond { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Set this flag to true to get additional SAS for VM guest state.",
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public SwitchParameter SecureVMGuestStateSAS { get; set; }
    }
}

