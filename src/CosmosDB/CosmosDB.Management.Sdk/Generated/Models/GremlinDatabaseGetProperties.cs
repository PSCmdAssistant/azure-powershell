// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    using System.Linq;

    /// <summary>
    /// The properties of an Azure Cosmos DB SQL database
    /// </summary>
    public partial class GremlinDatabaseGetProperties
    {
        /// <summary>
        /// Initializes a new instance of the GremlinDatabaseGetProperties class.
        /// </summary>
        public GremlinDatabaseGetProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GremlinDatabaseGetProperties class.
        /// </summary>

        /// <param name="resource">
        /// </param>

        /// <param name="options">
        /// </param>
        public GremlinDatabaseGetProperties(GremlinDatabaseGetPropertiesResource resource = default(GremlinDatabaseGetPropertiesResource), GremlinDatabaseGetPropertiesOptions options = default(GremlinDatabaseGetPropertiesOptions))

        {
            this.Resource = resource;
            this.Options = options;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "resource")]
        public GremlinDatabaseGetPropertiesResource Resource {get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "options")]
        public GremlinDatabaseGetPropertiesOptions Options {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Resource != null)
            {
                this.Resource.Validate();
            }

        }
    }
}