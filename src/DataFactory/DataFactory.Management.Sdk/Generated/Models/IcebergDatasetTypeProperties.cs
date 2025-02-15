// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Iceberg dataset properties.
    /// </summary>
    public partial class IcebergDatasetTypeProperties
    {
        /// <summary>
        /// Initializes a new instance of the IcebergDatasetTypeProperties class.
        /// </summary>
        public IcebergDatasetTypeProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IcebergDatasetTypeProperties class.
        /// </summary>

        /// <param name="location">The location of the iceberg storage. Setting a file name is not allowed for
        /// iceberg format.
        /// </param>
        public IcebergDatasetTypeProperties(DatasetLocation location)

        {
            this.Location = location;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the location of the iceberg storage. Setting a file name is
        /// not allowed for iceberg format.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "location")]
        public DatasetLocation Location {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Location == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Location");
            }

        }
    }
}