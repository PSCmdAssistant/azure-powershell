// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataMigration.Models
{
    using System.Linq;

    /// <summary>
    /// Describes a database within a MongoDB data source
    /// </summary>
    public partial class MongoDbDatabaseInfo : MongoDbObjectInfo
    {
        /// <summary>
        /// Initializes a new instance of the MongoDbDatabaseInfo class.
        /// </summary>
        public MongoDbDatabaseInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MongoDbDatabaseInfo class.
        /// </summary>

        /// <param name="averageDocumentSize">The average document size, or -1 if the average size is unknown
        /// </param>

        /// <param name="dataSize">The estimated total data size, in bytes, or -1 if the size is unknown.
        /// </param>

        /// <param name="documentCount">The estimated total number of documents, or -1 if the document count is
        /// unknown
        /// </param>

        /// <param name="name">The unqualified name of the database or collection
        /// </param>

        /// <param name="qualifiedName">The qualified name of the database or collection. For a collection, this is
        /// the database-qualified name.
        /// </param>

        /// <param name="collections">A list of supported collections in a MongoDB database
        /// </param>

        /// <param name="supportsSharding">Whether the database has sharding enabled. Note that the migration task
        /// will enable sharding on the target if necessary.
        /// </param>
        public MongoDbDatabaseInfo(long averageDocumentSize, long dataSize, long documentCount, string name, string qualifiedName, System.Collections.Generic.IList<MongoDbCollectionInfo> collections, bool supportsSharding)

        : base(averageDocumentSize, dataSize, documentCount, name, qualifiedName)
        {
            this.Collections = collections;
            this.SupportsSharding = supportsSharding;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets a list of supported collections in a MongoDB database
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "collections")]
        public System.Collections.Generic.IList<MongoDbCollectionInfo> Collections {get; set; }

        /// <summary>
        /// Gets or sets whether the database has sharding enabled. Note that the
        /// migration task will enable sharding on the target if necessary.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "supportsSharding")]
        public bool SupportsSharding {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (this.Collections == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Collections");
            }
            if (this.Collections != null)
            {
                foreach (var element in this.Collections)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}