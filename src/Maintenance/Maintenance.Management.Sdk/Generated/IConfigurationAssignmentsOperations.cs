// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Maintenance
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// ConfigurationAssignmentsOperations operations.
    /// </summary>
    public partial interface IConfigurationAssignmentsOperations
    {
        /// <summary>
        /// Get configuration assignment for resource..
        /// </summary>
        /// <remarks>
        /// Get configuration assignment for resource..
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Configuration assignment name
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> GetParentWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Register configuration for resource.
        /// </summary>
        /// <remarks>
        /// Register configuration for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Configuration assignment name
        /// </param>
        /// <param name='configurationAssignment'>
        /// The configurationAssignment
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> CreateOrUpdateParentWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, ConfigurationAssignment configurationAssignment, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Unregister configuration for resource.
        /// </summary>
        /// <remarks>
        /// Unregister configuration for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Unique configuration assignment name
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> DeleteParentWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get configuration assignment for resource..
        /// </summary>
        /// <remarks>
        /// Get configuration assignment for resource..
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Configuration assignment name
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> GetWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Register configuration for resource.
        /// </summary>
        /// <remarks>
        /// Register configuration for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Configuration assignment name
        /// </param>
        /// <param name='configurationAssignment'>
        /// The configurationAssignment
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, string configurationAssignmentName, ConfigurationAssignment configurationAssignment, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Unregister configuration for resource.
        /// </summary>
        /// <remarks>
        /// Unregister configuration for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
        /// </param>
        /// <param name='configurationAssignmentName'>
        /// Unique configuration assignment name
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<ConfigurationAssignment>> DeleteWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List configurationAssignments for resource.
        /// </summary>
        /// <remarks>
        /// List configurationAssignments for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceParentType'>
        /// Resource parent type
        /// </param>
        /// <param name='resourceParentName'>
        /// Resource parent identifier
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<System.Collections.Generic.IEnumerable<ConfigurationAssignment>>> ListParentWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List configurationAssignments for resource.
        /// </summary>
        /// <remarks>
        /// List configurationAssignments for resource.
        /// </remarks>
        /// <param name='resourceGroupName'>
        /// Resource group name
        /// </param>
        /// <param name='providerName'>
        /// Resource provider name
        /// </param>
        /// <param name='resourceType'>
        /// Resource type
        /// </param>
        /// <param name='resourceName'>
        /// Resource identifier
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
        System.Threading.Tasks.Task<Microsoft.Rest.Azure.AzureOperationResponse<System.Collections.Generic.IEnumerable<ConfigurationAssignment>>> ListWithHttpMessagesAsync(string resourceGroupName, string providerName, string resourceType, string resourceName, System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> customHeaders = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

    }
}