// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Settings for copy activity log.
    /// </summary>
    public partial class CopyActivityLogSettings
    {
        /// <summary>
        /// Initializes a new instance of the CopyActivityLogSettings class.
        /// </summary>
        public CopyActivityLogSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CopyActivityLogSettings class.
        /// </summary>

        /// <param name="logLevel">Gets or sets the log level, support: Info, Warning. Type: string (or
        /// Expression with resultType string).
        /// </param>

        /// <param name="enableReliableLogging">Specifies whether to enable reliable logging. Type: boolean (or Expression
        /// with resultType boolean).
        /// </param>
        public CopyActivityLogSettings(object logLevel = default(object), object enableReliableLogging = default(object))

        {
            this.LogLevel = logLevel;
            this.EnableReliableLogging = enableReliableLogging;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets gets or sets the log level, support: Info, Warning. Type:
        /// string (or Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "logLevel")]
        public object LogLevel {get; set; }

        /// <summary>
        /// Gets or sets specifies whether to enable reliable logging. Type: boolean
        /// (or Expression with resultType boolean).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableReliableLogging")]
        public object EnableReliableLogging {get; set; }
    }
}