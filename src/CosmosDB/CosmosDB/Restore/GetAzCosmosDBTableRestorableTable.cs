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

using System;
using System.Collections;
using System.Management.Automation;
using System.Web;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBTableRestorableTable", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSRestorableTableGetResult))]
    public class GetAzCosmosDBTableRestorableTable : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.LocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountInstanceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseAccountInstanceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.RestorableTableObjectHelpMessage)]
        [ValidateNotNull]
        public PSRestorableTableGetResult InputObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.RestorableTablesFeedStartTimeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StartTime { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.RestorableTablesFeedEndTimeHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string EndTime { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                // id is in the format: /subscriptions/<subscriptionId>/providers/Microsoft.DocumentDB/locations/<location>/restorableDatabaseAccounts/<DatabaseAccountInstanceId>/<Id>
                string[] idComponents = InputObject.Id.Split('/');
                Location = HttpUtility.UrlDecode(idComponents[6]);
                DatabaseAccountInstanceId = idComponents[8];
            }

            IEnumerable restorableTables = CosmosDBManagementClient.RestorableTables.ListWithHttpMessagesAsync(Location, DatabaseAccountInstanceId, StartTime, EndTime).GetAwaiter().GetResult().Body;
            foreach (RestorableTableGetResult restorableTable in restorableTables)
            {
                WriteObject(new PSRestorableTableGetResult(restorableTable));
            }
        }
    }
}
