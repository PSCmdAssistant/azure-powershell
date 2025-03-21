// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.IotCentral.Models
{
    using System.Linq;

    /// <summary>
    /// Managed service identity (either system assigned, or none)
    /// </summary>
    public partial class SystemAssignedServiceIdentity
    {
        /// <summary>
        /// Initializes a new instance of the SystemAssignedServiceIdentity class.
        /// </summary>
        public SystemAssignedServiceIdentity()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SystemAssignedServiceIdentity class.
        /// </summary>

        /// <param name="principalId">The service principal ID of the system assigned identity. This property
        /// will only be provided for a system assigned identity.
        /// </param>

        /// <param name="tenantId">The tenant ID of the system assigned identity. This property will only be
        /// provided for a system assigned identity.
        /// </param>

        /// <param name="type">Type of managed service identity (either system assigned, or none).
        /// Possible values include: &#39;None&#39;, &#39;SystemAssigned&#39;</param>
        public SystemAssignedServiceIdentity(string type, System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?))

        {
            this.PrincipalId = principalId;
            this.TenantId = tenantId;
            this.Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets the service principal ID of the system assigned identity. This
        /// property will only be provided for a system assigned identity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "principalId")]
        public System.Guid? PrincipalId {get; private set; }

        /// <summary>
        /// Gets the tenant ID of the system assigned identity. This property will only
        /// be provided for a system assigned identity.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "tenantId")]
        public System.Guid? TenantId {get; private set; }

        /// <summary>
        /// Gets or sets type of managed service identity (either system assigned, or
        /// none). Possible values include: &#39;None&#39;, &#39;SystemAssigned&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Type == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Type");
            }

        }
    }
}