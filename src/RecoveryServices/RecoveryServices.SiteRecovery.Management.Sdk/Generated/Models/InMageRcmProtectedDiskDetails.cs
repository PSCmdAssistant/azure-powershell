// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// InMageRcm protected disk details.
    /// </summary>
    public partial class InMageRcmProtectedDiskDetails
    {
        /// <summary>
        /// Initializes a new instance of the InMageRcmProtectedDiskDetails class.
        /// </summary>
        public InMageRcmProtectedDiskDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the InMageRcmProtectedDiskDetails class.
        /// </summary>

        /// <param name="diskId">The disk Id.
        /// </param>

        /// <param name="diskName">The disk name.
        /// </param>

        /// <param name="isOSDisk">A value indicating whether the disk is the OS disk.
        /// </param>

        /// <param name="capacityInBytes">The disk capacity in bytes.
        /// </param>

        /// <param name="diskState">The disk state.
        /// Possible values include: &#39;Unavailable&#39;, &#39;InitialReplicationPending&#39;,
        /// &#39;InitialReplicationFailed&#39;, &#39;Protected&#39;</param>

        /// <param name="logStorageAccountId">The log storage account ARM Id.
        /// </param>

        /// <param name="diskEncryptionSetId">The DiskEncryptionSet ARM Id.
        /// </param>

        /// <param name="seedManagedDiskId">The ARM Id of the seed managed disk.
        /// </param>

        /// <param name="seedBlobUri">The uri of the seed blob.
        /// </param>

        /// <param name="targetManagedDiskId">The ARM Id of the target managed disk.
        /// </param>

        /// <param name="diskType">The disk type.
        /// Possible values include: &#39;Standard_LRS&#39;, &#39;Premium_LRS&#39;, &#39;StandardSSD_LRS&#39;,
        /// &#39;PremiumV2_LRS&#39;, &#39;UltraSSD_LRS&#39;, &#39;StandardSSD_ZRS&#39;, &#39;Premium_ZRS&#39;</param>

        /// <param name="dataPendingInLogDataStoreInMb">The data pending in log data store in MB.
        /// </param>

        /// <param name="dataPendingAtSourceAgentInMb">The data pending at source agent in MB.
        /// </param>

        /// <param name="isInitialReplicationComplete">A value indicating whether initial replication is complete or not.
        /// </param>

        /// <param name="irDetails">The initial replication details.
        /// </param>

        /// <param name="resyncDetails">The resync details.
        /// </param>

        /// <param name="customTargetDiskName">The custom target Azure disk name.
        /// </param>

        /// <param name="sectorSizeInBytes">The logical sector size (in bytes), 512 by default.
        /// </param>
        public InMageRcmProtectedDiskDetails(string diskId = default(string), string diskName = default(string), string isOSDisk = default(string), long? capacityInBytes = default(long?), string diskState = default(string), string logStorageAccountId = default(string), string diskEncryptionSetId = default(string), string seedManagedDiskId = default(string), string seedBlobUri = default(string), string targetManagedDiskId = default(string), string diskType = default(string), double? dataPendingInLogDataStoreInMb = default(double?), double? dataPendingAtSourceAgentInMb = default(double?), string isInitialReplicationComplete = default(string), InMageRcmSyncDetails irDetails = default(InMageRcmSyncDetails), InMageRcmSyncDetails resyncDetails = default(InMageRcmSyncDetails), string customTargetDiskName = default(string), int? sectorSizeInBytes = default(int?))

        {
            this.DiskId = diskId;
            this.DiskName = diskName;
            this.IsOSDisk = isOSDisk;
            this.CapacityInBytes = capacityInBytes;
            this.DiskState = diskState;
            this.LogStorageAccountId = logStorageAccountId;
            this.DiskEncryptionSetId = diskEncryptionSetId;
            this.SeedManagedDiskId = seedManagedDiskId;
            this.SeedBlobUri = seedBlobUri;
            this.TargetManagedDiskId = targetManagedDiskId;
            this.DiskType = diskType;
            this.DataPendingInLogDataStoreInMb = dataPendingInLogDataStoreInMb;
            this.DataPendingAtSourceAgentInMb = dataPendingAtSourceAgentInMb;
            this.IsInitialReplicationComplete = isInitialReplicationComplete;
            this.IrDetails = irDetails;
            this.ResyncDetails = resyncDetails;
            this.CustomTargetDiskName = customTargetDiskName;
            this.SectorSizeInBytes = sectorSizeInBytes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets the disk Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskId")]
        public string DiskId {get; private set; }

        /// <summary>
        /// Gets the disk name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskName")]
        public string DiskName {get; private set; }

        /// <summary>
        /// Gets a value indicating whether the disk is the OS disk.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isOSDisk")]
        public string IsOSDisk {get; private set; }

        /// <summary>
        /// Gets the disk capacity in bytes.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "capacityInBytes")]
        public long? CapacityInBytes {get; private set; }

        /// <summary>
        /// Gets the disk state. Possible values include: &#39;Unavailable&#39;, &#39;InitialReplicationPending&#39;, &#39;InitialReplicationFailed&#39;, &#39;Protected&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskState")]
        public string DiskState {get; private set; }

        /// <summary>
        /// Gets the log storage account ARM Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "logStorageAccountId")]
        public string LogStorageAccountId {get; private set; }

        /// <summary>
        /// Gets the DiskEncryptionSet ARM Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskEncryptionSetId")]
        public string DiskEncryptionSetId {get; private set; }

        /// <summary>
        /// Gets the ARM Id of the seed managed disk.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seedManagedDiskId")]
        public string SeedManagedDiskId {get; private set; }

        /// <summary>
        /// Gets the uri of the seed blob.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seedBlobUri")]
        public string SeedBlobUri {get; private set; }

        /// <summary>
        /// Gets the ARM Id of the target managed disk.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetManagedDiskId")]
        public string TargetManagedDiskId {get; private set; }

        /// <summary>
        /// Gets or sets the disk type. Possible values include: &#39;Standard_LRS&#39;, &#39;Premium_LRS&#39;, &#39;StandardSSD_LRS&#39;, &#39;PremiumV2_LRS&#39;, &#39;UltraSSD_LRS&#39;, &#39;StandardSSD_ZRS&#39;, &#39;Premium_ZRS&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diskType")]
        public string DiskType {get; set; }

        /// <summary>
        /// Gets the data pending in log data store in MB.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dataPendingInLogDataStoreInMB")]
        public double? DataPendingInLogDataStoreInMb {get; private set; }

        /// <summary>
        /// Gets the data pending at source agent in MB.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dataPendingAtSourceAgentInMB")]
        public double? DataPendingAtSourceAgentInMb {get; private set; }

        /// <summary>
        /// Gets a value indicating whether initial replication is complete or not.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isInitialReplicationComplete")]
        public string IsInitialReplicationComplete {get; private set; }

        /// <summary>
        /// Gets or sets the initial replication details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "irDetails")]
        public InMageRcmSyncDetails IrDetails {get; set; }

        /// <summary>
        /// Gets or sets the resync details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "resyncDetails")]
        public InMageRcmSyncDetails ResyncDetails {get; set; }

        /// <summary>
        /// Gets or sets the custom target Azure disk name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "customTargetDiskName")]
        public string CustomTargetDiskName {get; set; }

        /// <summary>
        /// Gets or sets the logical sector size (in bytes), 512 by default.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sectorSizeInBytes")]
        public int? SectorSizeInBytes {get; set; }
    }
}