// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.Extensions;

    /// <summary>Gets or sets the plans details</summary>
    public partial class QueryRequestApprovalPlansDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IQueryRequestApprovalPlansDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IQueryRequestApprovalPlansDetailsInternal
    {

        /// <summary>Creates an new <see cref="QueryRequestApprovalPlansDetails" /> instance.</summary>
        public QueryRequestApprovalPlansDetails()
        {

        }
    }
    /// Gets or sets the plans details
    public partial interface IQueryRequestApprovalPlansDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Marketplace.Models.IPlanDetails>
    {

    }
    /// Gets or sets the plans details
    internal partial interface IQueryRequestApprovalPlansDetailsInternal

    {

    }
}