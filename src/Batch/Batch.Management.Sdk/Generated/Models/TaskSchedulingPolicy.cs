// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Batch.Models
{
    using System.Linq;

    /// <summary>
    /// Specifies how tasks should be distributed across compute nodes.
    /// </summary>
    /// <remarks>
    /// Specifies how tasks should be distributed across compute nodes.
    /// </remarks>
    public partial class TaskSchedulingPolicy
    {
        /// <summary>
        /// Initializes a new instance of the TaskSchedulingPolicy class.
        /// </summary>
        public TaskSchedulingPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TaskSchedulingPolicy class.
        /// </summary>

        /// <param name="nodeFillType">How tasks should be distributed across compute nodes.
        /// Possible values include: &#39;Spread&#39;, &#39;Pack&#39;</param>
        public TaskSchedulingPolicy(ComputeNodeFillType nodeFillType)

        {
            this.NodeFillType = nodeFillType;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets how tasks should be distributed across compute nodes. Possible values include: &#39;Spread&#39;, &#39;Pack&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nodeFillType")]
        public ComputeNodeFillType NodeFillType {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {

        }
    }
}