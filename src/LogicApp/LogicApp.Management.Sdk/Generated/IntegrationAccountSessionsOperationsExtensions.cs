// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.Logic
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for IntegrationAccountSessionsOperations
    /// </summary>
    public static partial class IntegrationAccountSessionsOperationsExtensions
    {
        /// <summary>
        /// Gets a list of integration account sessions.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='odataQuery'>
        /// 
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<IntegrationAccountSession> List(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, Microsoft.Rest.Azure.OData.ODataQuery<IntegrationAccountSessionFilter> odataQuery = default(Microsoft.Rest.Azure.OData.ODataQuery<IntegrationAccountSessionFilter>))
        {
                return ((IIntegrationAccountSessionsOperations)operations).ListAsync(resourceGroupName, integrationAccountName, odataQuery).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a list of integration account sessions.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='odataQuery'>
        /// 
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<IntegrationAccountSession>> ListAsync(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, Microsoft.Rest.Azure.OData.ODataQuery<IntegrationAccountSessionFilter> odataQuery = default(Microsoft.Rest.Azure.OData.ODataQuery<IntegrationAccountSessionFilter>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, integrationAccountName, odataQuery, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Gets an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        public static IntegrationAccountSession Get(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName)
        {
                return ((IIntegrationAccountSessionsOperations)operations).GetAsync(resourceGroupName, integrationAccountName, sessionName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<IntegrationAccountSession> GetAsync(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, integrationAccountName, sessionName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Creates or updates an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        public static IntegrationAccountSession CreateOrUpdate(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName, IntegrationAccountSession session)
        {
                return ((IIntegrationAccountSessionsOperations)operations).CreateOrUpdateAsync(resourceGroupName, integrationAccountName, sessionName, session).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates or updates an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<IntegrationAccountSession> CreateOrUpdateAsync(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName, IntegrationAccountSession session, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, integrationAccountName, sessionName, session, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Deletes an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        public static void Delete(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName)
        {
                ((IIntegrationAccountSessionsOperations)operations).DeleteAsync(resourceGroupName, integrationAccountName, sessionName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes an integration account session.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name.
        /// </param>
        /// <param name='integrationAccountName'>
        /// The integration account name.
        /// </param>
        /// <param name='sessionName'>
        /// The integration account session name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task DeleteAsync(this IIntegrationAccountSessionsOperations operations, string resourceGroupName, string integrationAccountName, string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, integrationAccountName, sessionName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Gets a list of integration account sessions.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<IntegrationAccountSession> ListNext(this IIntegrationAccountSessionsOperations operations, string nextPageLink)
        {
                return ((IIntegrationAccountSessionsOperations)operations).ListNextAsync(nextPageLink).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a list of integration account sessions.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<IntegrationAccountSession>> ListNextAsync(this IIntegrationAccountSessionsOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
