// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Lookup activity.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Lookup")]
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class LookupActivity : ExecutionActivity
    {
        /// <summary>
        /// Initializes a new instance of the LookupActivity class.
        /// </summary>
        public LookupActivity()
        {
            this.Dataset = new DatasetReference();
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LookupActivity class.
        /// </summary>

        /// <param name="additionalProperties">A pipeline activity.
        /// </param>

        /// <param name="name">Activity name.
        /// </param>

        /// <param name="description">Activity description.
        /// </param>

        /// <param name="state">Activity state. This is an optional property and if not provided, the state
        /// will be Active by default.
        /// Possible values include: &#39;Active&#39;, &#39;Inactive&#39;</param>

        /// <param name="onInactiveMarkAs">Status result of the activity when the state is set to Inactive. This is an
        /// optional property and if not provided when the activity is inactive, the
        /// status will be Succeeded by default.
        /// Possible values include: &#39;Succeeded&#39;, &#39;Failed&#39;, &#39;Skipped&#39;</param>

        /// <param name="dependsOn">Activity depends on condition.
        /// </param>

        /// <param name="userProperties">Activity user properties.
        /// </param>

        /// <param name="linkedServiceName">Linked service reference.
        /// </param>

        /// <param name="policy">Activity policy.
        /// </param>

        /// <param name="source">Dataset-specific source properties, same as copy activity source.
        /// </param>

        /// <param name="dataset">Lookup activity dataset reference.
        /// </param>

        /// <param name="firstRowOnly">Whether to return first row or all rows. Default value is true. Type:
        /// boolean (or Expression with resultType boolean).
        /// </param>
        public LookupActivity(string name, CopySource source, DatasetReference dataset, System.Collections.Generic.IDictionary<string, object> additionalProperties = default(System.Collections.Generic.IDictionary<string, object>), string description = default(string), string state = default(string), string onInactiveMarkAs = default(string), System.Collections.Generic.IList<ActivityDependency> dependsOn = default(System.Collections.Generic.IList<ActivityDependency>), System.Collections.Generic.IList<UserProperty> userProperties = default(System.Collections.Generic.IList<UserProperty>), LinkedServiceReference linkedServiceName = default(LinkedServiceReference), ActivityPolicy policy = default(ActivityPolicy), object firstRowOnly = default(object))

        : base(name, additionalProperties, description, state, onInactiveMarkAs, dependsOn, userProperties, linkedServiceName, policy)
        {
            this.Source = source;
            this.Dataset = dataset;
            this.FirstRowOnly = firstRowOnly;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets dataset-specific source properties, same as copy activity
        /// source.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "typeProperties.source")]
        public CopySource Source {get; set; }

        /// <summary>
        /// Gets or sets lookup activity dataset reference.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "typeProperties.dataset")]
        public DatasetReference Dataset {get; set; }

        /// <summary>
        /// Gets or sets whether to return first row or all rows. Default value is
        /// true. Type: boolean (or Expression with resultType boolean).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "typeProperties.firstRowOnly")]
        public object FirstRowOnly {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
            if (this.Source == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Source");
            }
            if (this.Dataset == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Dataset");
            }

            if (this.Dataset != null)
            {
                this.Dataset.Validate();
            }

        }
    }
}