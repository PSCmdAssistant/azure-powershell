// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.StorageSync.Models
{
    using System.Linq;

    /// <summary>
    /// Cloud Endpoint object.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class CloudEndpoint : ProxyResource
    {
        /// <summary>
        /// Initializes a new instance of the CloudEndpoint class.
        /// </summary>
        public CloudEndpoint()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CloudEndpoint class.
        /// </summary>

        /// <param name="id">Fully qualified resource ID for the resource. E.g.
        /// &#34;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}&#34;
        /// </param>

        /// <param name="name">The name of the resource
        /// </param>

        /// <param name="type">The type of the resource. E.g. &#34;Microsoft.Compute/virtualMachines&#34; or
        /// &#34;Microsoft.Storage/storageAccounts&#34;
        /// </param>

        /// <param name="systemData">Azure Resource Manager metadata containing createdBy and modifiedBy
        /// information.
        /// </param>

        /// <param name="storageAccountResourceId">Storage Account Resource Id
        /// </param>

        /// <param name="azureFileShareName">Azure file share name
        /// </param>

        /// <param name="storageAccountTenantId">Storage Account Tenant Id
        /// </param>

        /// <param name="partnershipId">Partnership Id
        /// </param>

        /// <param name="friendlyName">Friendly Name
        /// </param>

        /// <param name="backupEnabled">Backup Enabled
        /// </param>

        /// <param name="provisioningState">CloudEndpoint Provisioning State
        /// </param>

        /// <param name="lastWorkflowId">CloudEndpoint lastWorkflowId
        /// </param>

        /// <param name="lastOperationName">Resource Last Operation Name
        /// </param>

        /// <param name="changeEnumerationStatus">Cloud endpoint change enumeration status
        /// </param>
        public CloudEndpoint(string id = default(string), string name = default(string), string type = default(string), SystemData systemData = default(SystemData), string storageAccountResourceId = default(string), string azureFileShareName = default(string), string storageAccountTenantId = default(string), string partnershipId = default(string), string friendlyName = default(string), string backupEnabled = default(string), string provisioningState = default(string), string lastWorkflowId = default(string), string lastOperationName = default(string), CloudEndpointChangeEnumerationStatus changeEnumerationStatus = default(CloudEndpointChangeEnumerationStatus))

        : base(id, name, type, systemData)
        {
            this.StorageAccountResourceId = storageAccountResourceId;
            this.AzureFileShareName = azureFileShareName;
            this.StorageAccountTenantId = storageAccountTenantId;
            this.PartnershipId = partnershipId;
            this.FriendlyName = friendlyName;
            this.BackupEnabled = backupEnabled;
            this.ProvisioningState = provisioningState;
            this.LastWorkflowId = lastWorkflowId;
            this.LastOperationName = lastOperationName;
            this.ChangeEnumerationStatus = changeEnumerationStatus;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets storage Account Resource Id
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.storageAccountResourceId")]
        public string StorageAccountResourceId {get; set; }

        /// <summary>
        /// Gets or sets azure file share name
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.azureFileShareName")]
        public string AzureFileShareName {get; set; }

        /// <summary>
        /// Gets or sets storage Account Tenant Id
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.storageAccountTenantId")]
        public string StorageAccountTenantId {get; set; }

        /// <summary>
        /// Gets or sets partnership Id
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.partnershipId")]
        public string PartnershipId {get; set; }

        /// <summary>
        /// Gets or sets friendly Name
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.friendlyName")]
        public string FriendlyName {get; set; }

        /// <summary>
        /// Gets backup Enabled
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.backupEnabled")]
        public string BackupEnabled {get; private set; }

        /// <summary>
        /// Gets or sets cloudEndpoint Provisioning State
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; set; }

        /// <summary>
        /// Gets or sets cloudEndpoint lastWorkflowId
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.lastWorkflowId")]
        public string LastWorkflowId {get; set; }

        /// <summary>
        /// Gets or sets resource Last Operation Name
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.lastOperationName")]
        public string LastOperationName {get; set; }

        /// <summary>
        /// Gets cloud endpoint change enumeration status
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.changeEnumerationStatus")]
        public CloudEndpointChangeEnumerationStatus ChangeEnumerationStatus {get; private set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {









            if (this.ChangeEnumerationStatus != null)
            {
                this.ChangeEnumerationStatus.Validate();
            }
        }
    }
}