// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Security.Models
{
    using System.Linq;

    /// <summary>
    /// The aws connector environment data
    /// </summary>
    [Newtonsoft.Json.JsonObject("AwsAccount")]
    public partial class AwsEnvironmentData : EnvironmentData
    {
        /// <summary>
        /// Initializes a new instance of the AwsEnvironmentData class.
        /// </summary>
        public AwsEnvironmentData()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AwsEnvironmentData class.
        /// </summary>

        /// <param name="organizationalData">The AWS account&#39;s organizational data
        /// </param>
        public AwsEnvironmentData(AwsOrganizationalData organizationalData = default(AwsOrganizationalData))

        {
            this.OrganizationalData = organizationalData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the AWS account&#39;s organizational data
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organizationalData")]
        public AwsOrganizationalData OrganizationalData {get; set; }
    }
}