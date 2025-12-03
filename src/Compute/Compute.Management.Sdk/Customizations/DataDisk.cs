// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Describes a data disk.
    /// </summary>
    public partial class DataDisk
    {
        /// <summary>
        /// Gets or sets specifies the Read-Write IOPS for the managed disk when
        /// StorageAccountType is UltraSSD_LRS or PremiumV2_LRS.
        /// </summary>
        [JsonProperty(PropertyName = "diskIOPSReadWrite")]
        public new long? DiskIOPSReadWrite { get; set; }

        /// <summary>
        /// Gets or sets specifies the bandwidth in MB per second for the managed disk
        /// when StorageAccountType is UltraSSD_LRS or PremiumV2_LRS.
        /// </summary>
        [JsonProperty(PropertyName = "diskMBpsReadWrite")]
        public new long? DiskMBpsReadWrite { get; set; }
    }
}
