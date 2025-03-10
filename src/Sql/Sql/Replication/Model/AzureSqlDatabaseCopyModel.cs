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

using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Replication.Model
{
    /// <summary>
    /// Represents an Azure SQL Database Copy
    /// </summary>
    public class AzureSqlDatabaseCopyModel : AzureSqlDatabaseReplicationModelBase
    {
        /// <summary>
        /// Gets or sets the name of the target Resource Group for the copy
        /// </summary>
        public string CopyResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target Azure SQL Server for the copy
        /// </summary>
        public string CopyServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the target Azure SQL Database for the copy
        /// </summary>
        public string CopyDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the requested service objective name
        /// </summary>
        public string ServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool the database is in
        /// </summary>
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the copy
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the location of the partner database
        /// </summary>
        public string CopyLocation { get; set; }

        /// <summary>
        /// Gets or sets the SkuName of the database
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the edition of the database
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the Family of the database
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the Capacity of the database
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Gets or sets the license type of the database
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the current backup storage redundancy for the database
        /// </summary>
        public string CurrentBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the requested backup storage redundancy for the database
        /// </summary>
        public string RequestedBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option of the database.
        /// </summary>
        public bool? ZoneRedundant { get; set; }
    }
}
