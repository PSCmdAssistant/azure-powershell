// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DeviceProvisioningServices
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// IotDpsResourceOperations operations.
    /// </summary>
    public partial interface IIotDpsResourceOperations
    {
        /// <summary>
        /// Get the metadata of the provisioning service without SAS keys.
        /// </summary>
        /// <remarks>
        /// Get the metadata of the provisioning service without SAS keys.
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// Name of the provisioning service to retrieve.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Resource group name.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ProvisioningServiceDescription>> GetWithHttpMessagesAsync(string provisioningServiceName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create or update the metadata of the provisioning service. The usual
        /// pattern to modify a property is to retrieve the provisioning service
        /// metadata and security metadata, and then combine them with the modified
        /// values in a new body to update the provisioning service.
        /// </summary>
        /// <remarks>
        /// Create or update the metadata of the provisioning service. The usual
        /// pattern to modify a property is to retrieve the provisioning service
        /// metadata and security metadata, and then combine them with the modified
        /// values in a new body to update the provisioning service.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to create or update.
        /// </param>
        /// <param name='iotDpsDescription'>
        /// Description of the provisioning service to create or update.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ProvisioningServiceDescription>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string provisioningServiceName, ProvisioningServiceDescription iotDpsDescription, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update an existing provisioning service&#39;s tags. to update other fields use
        /// the CreateOrUpdate method
        /// </summary>
        /// <remarks>
        /// Update an existing provisioning service&#39;s tags. to update other fields use
        /// the CreateOrUpdate method
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to create or update.
        /// </param>
        /// <param name='provisioningServiceTags'>
        /// Updated tag information to set into the provisioning service instance.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ProvisioningServiceDescription>> UpdateWithHttpMessagesAsync(string resourceGroupName, string provisioningServiceName, TagsResource provisioningServiceTags, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Deletes the Provisioning Service.
        /// </summary>
        /// <remarks>
        /// Deletes the Provisioning Service.
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to delete.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse> DeleteWithHttpMessagesAsync(string provisioningServiceName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List all the provisioning services for a given subscription id.
        /// </summary>
        /// <remarks>
        /// List all the provisioning services for a given subscription id.
        /// </remarks>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ProvisioningServiceDescription>>> ListBySubscriptionWithHttpMessagesAsync(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a list of all provisioning services in the given resource group.
        /// </summary>
        /// <remarks>
        /// Get a list of all provisioning services in the given resource group.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ProvisioningServiceDescription>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the status of a long running operation, such as create, update or
        /// delete a provisioning service.
        /// </summary>
        /// <remarks>
        /// Gets the status of a long running operation, such as create, update or
        /// delete a provisioning service.
        /// </remarks>
        /// <param name='operationId'>
        /// Operation id corresponding to long running operation. Use this to poll for
        /// the status.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service that the operation is running on.
        /// </param>
        /// <param name='asyncinfo'>
        /// Async header used to poll on the status of the operation, obtained while
        /// creating the long running operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<AsyncOperationResult>> GetOperationResultWithHttpMessagesAsync(string operationId, string resourceGroupName, string provisioningServiceName, string asyncinfo, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the list of valid SKUs and tiers for a provisioning service.
        /// </summary>
        /// <remarks>
        /// Gets the list of valid SKUs and tiers for a provisioning service.
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Name of resource group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<IotDpsSkuDefinition>>> ListValidSkusWithHttpMessagesAsync(string provisioningServiceName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Check if a provisioning service name is available. This will validate if
        /// the name is syntactically valid and if the name is usable
        /// </summary>
        /// <remarks>
        /// Check if a provisioning service name is available. This will validate if
        /// the name is syntactically valid and if the name is usable
        /// </remarks>
        /// <param name='arguments'>
        /// Set the name parameter in the OperationInputs structure to the name of the
        /// provisioning service to check.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<NameAvailabilityInfo>> CheckProvisioningServiceNameAvailabilityWithHttpMessagesAsync(OperationInputs arguments, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List the primary and secondary keys for a provisioning service.
        /// </summary>
        /// <remarks>
        /// List the primary and secondary keys for a provisioning service.
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// The provisioning service name to get the shared access keys for.
        /// </param>
        /// <param name='resourceGroupName'>
        /// resource group name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>>> ListKeysWithHttpMessagesAsync(string provisioningServiceName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List primary and secondary keys for a specific key name
        /// </summary>
        /// <remarks>
        /// List primary and secondary keys for a specific key name
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// Name of the provisioning service.
        /// </param>
        /// <param name='keyName'>
        /// Logical key name to get key-values for.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the provisioning service.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>> ListKeysForKeyNameWithHttpMessagesAsync(string provisioningServiceName, string keyName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create or update the metadata of the provisioning service. The usual
        /// pattern to modify a property is to retrieve the provisioning service
        /// metadata and security metadata, and then combine them with the modified
        /// values in a new body to update the provisioning service.
        /// </summary>
        /// <remarks>
        /// Create or update the metadata of the provisioning service. The usual
        /// pattern to modify a property is to retrieve the provisioning service
        /// metadata and security metadata, and then combine them with the modified
        /// values in a new body to update the provisioning service.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to create or update.
        /// </param>
        /// <param name='iotDpsDescription'>
        /// Description of the provisioning service to create or update.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ProvisioningServiceDescription>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string provisioningServiceName, ProvisioningServiceDescription iotDpsDescription, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update an existing provisioning service&#39;s tags. to update other fields use
        /// the CreateOrUpdate method
        /// </summary>
        /// <remarks>
        /// Update an existing provisioning service&#39;s tags. to update other fields use
        /// the CreateOrUpdate method
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to create or update.
        /// </param>
        /// <param name='provisioningServiceTags'>
        /// Updated tag information to set into the provisioning service instance.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ProvisioningServiceDescription>> BeginUpdateWithHttpMessagesAsync(string resourceGroupName, string provisioningServiceName, TagsResource provisioningServiceTags, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Deletes the Provisioning Service.
        /// </summary>
        /// <remarks>
        /// Deletes the Provisioning Service.
        /// </remarks>
        /// <param name='provisioningServiceName'>
        /// Name of provisioning service to delete.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Resource group identifier.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string provisioningServiceName, string resourceGroupName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List all the provisioning services for a given subscription id.
        /// </summary>
        /// <remarks>
        /// List all the provisioning services for a given subscription id.
        /// </remarks>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ProvisioningServiceDescription>>> ListBySubscriptionNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a list of all provisioning services in the given resource group.
        /// </summary>
        /// <remarks>
        /// Get a list of all provisioning services in the given resource group.
        /// </remarks>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<ProvisioningServiceDescription>>> ListByResourceGroupNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets the list of valid SKUs and tiers for a provisioning service.
        /// </summary>
        /// <remarks>
        /// Gets the list of valid SKUs and tiers for a provisioning service.
        /// </remarks>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<IotDpsSkuDefinition>>> ListValidSkusNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List the primary and secondary keys for a provisioning service.
        /// </summary>
        /// <remarks>
        /// List the primary and secondary keys for a provisioning service.
        /// </remarks>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<Microsoft.Rest.Azure.IPage<SharedAccessSignatureAuthorizationRuleAccessRightsDescription>>> ListKeysNextWithHttpMessagesAsync(string nextPageLink, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

    }
}