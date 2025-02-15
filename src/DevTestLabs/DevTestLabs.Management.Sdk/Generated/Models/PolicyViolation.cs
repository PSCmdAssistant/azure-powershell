// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DevTestLabs.Models
{
    using System.Linq;

    /// <summary>
    /// Policy violation.
    /// </summary>
    public partial class PolicyViolation
    {
        /// <summary>
        /// Initializes a new instance of the PolicyViolation class.
        /// </summary>
        public PolicyViolation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PolicyViolation class.
        /// </summary>

        /// <param name="code">The code of the policy violation.
        /// </param>

        /// <param name="message">The message of the policy violation.
        /// </param>
        public PolicyViolation(string code = default(string), string message = default(string))

        {
            this.Code = code;
            this.Message = message;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the code of the policy violation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code {get; set; }

        /// <summary>
        /// Gets or sets the message of the policy violation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "message")]
        public string Message {get; set; }
    }
}