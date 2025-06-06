// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Synapse.Models
{
    using System.Linq;

    /// <summary>
    /// The compute resource properties for managed integration runtime.
    /// </summary>
    public partial class IntegrationRuntimeComputeProperties
    {
        /// <summary>
        /// Initializes a new instance of the IntegrationRuntimeComputeProperties class.
        /// </summary>
        public IntegrationRuntimeComputeProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IntegrationRuntimeComputeProperties class.
        /// </summary>

        /// <param name="additionalProperties">The compute resource properties for managed integration runtime.
        /// </param>

        /// <param name="location">The location for managed integration runtime. The supported regions could
        /// be found on
        /// https://docs.microsoft.com/en-us/azure/data-factory/data-factory-data-movement-activities
        /// </param>

        /// <param name="nodeSize">The node size requirement to managed integration runtime.
        /// </param>

        /// <param name="numberOfNodes">The required number of nodes for managed integration runtime.
        /// </param>

        /// <param name="maxParallelExecutionsPerNode">Maximum parallel executions count per node for managed integration runtime.
        /// </param>

        /// <param name="dataFlowProperties">Data flow properties for managed integration runtime.
        /// </param>

        /// <param name="vNetProperties">VNet properties for managed integration runtime.
        /// </param>

        /// <param name="copyComputeScaleProperties">CopyComputeScale properties for managed integration runtime.
        /// </param>

        /// <param name="pipelineExternalComputeScaleProperties">PipelineExternalComputeScale properties for managed integration runtime.
        /// </param>
        public IntegrationRuntimeComputeProperties(System.Collections.Generic.IDictionary<string, object> additionalProperties = default(System.Collections.Generic.IDictionary<string, object>), string location = default(string), string nodeSize = default(string), int? numberOfNodes = default(int?), int? maxParallelExecutionsPerNode = default(int?), IntegrationRuntimeDataFlowProperties dataFlowProperties = default(IntegrationRuntimeDataFlowProperties), IntegrationRuntimeVNetProperties vNetProperties = default(IntegrationRuntimeVNetProperties), CopyComputeScaleProperties copyComputeScaleProperties = default(CopyComputeScaleProperties), PipelineExternalComputeScaleProperties pipelineExternalComputeScaleProperties = default(PipelineExternalComputeScaleProperties))

        {
            this.AdditionalProperties = additionalProperties;
            this.Location = location;
            this.NodeSize = nodeSize;
            this.NumberOfNodes = numberOfNodes;
            this.MaxParallelExecutionsPerNode = maxParallelExecutionsPerNode;
            this.DataFlowProperties = dataFlowProperties;
            this.VNetProperties = vNetProperties;
            this.CopyComputeScaleProperties = copyComputeScaleProperties;
            this.PipelineExternalComputeScaleProperties = pipelineExternalComputeScaleProperties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the compute resource properties for managed integration
        /// runtime.
        /// </summary>
        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties {get; set; }

        /// <summary>
        /// Gets or sets the location for managed integration runtime. The supported
        /// regions could be found on
        /// https://docs.microsoft.com/en-us/azure/data-factory/data-factory-data-movement-activities
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "location")]
        public string Location {get; set; }

        /// <summary>
        /// Gets or sets the node size requirement to managed integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nodeSize")]
        public string NodeSize {get; set; }

        /// <summary>
        /// Gets or sets the required number of nodes for managed integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "numberOfNodes")]
        public int? NumberOfNodes {get; set; }

        /// <summary>
        /// Gets or sets maximum parallel executions count per node for managed
        /// integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxParallelExecutionsPerNode")]
        public int? MaxParallelExecutionsPerNode {get; set; }

        /// <summary>
        /// Gets or sets data flow properties for managed integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dataFlowProperties")]
        public IntegrationRuntimeDataFlowProperties DataFlowProperties {get; set; }

        /// <summary>
        /// Gets or sets vNet properties for managed integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vNetProperties")]
        public IntegrationRuntimeVNetProperties VNetProperties {get; set; }

        /// <summary>
        /// Gets or sets copyComputeScale properties for managed integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "copyComputeScaleProperties")]
        public CopyComputeScaleProperties CopyComputeScaleProperties {get; set; }

        /// <summary>
        /// Gets or sets pipelineExternalComputeScale properties for managed
        /// integration runtime.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "pipelineExternalComputeScaleProperties")]
        public PipelineExternalComputeScaleProperties PipelineExternalComputeScaleProperties {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {



            if (this.NumberOfNodes != null)
            {
                if (this.NumberOfNodes < 1)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMinimum, "NumberOfNodes", 1);
                }
            }
            if (this.MaxParallelExecutionsPerNode != null)
            {
                if (this.MaxParallelExecutionsPerNode < 1)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.InclusiveMinimum, "MaxParallelExecutionsPerNode", 1);
                }
            }
            if (this.DataFlowProperties != null)
            {
                this.DataFlowProperties.Validate();
            }

            if (this.CopyComputeScaleProperties != null)
            {
                this.CopyComputeScaleProperties.Validate();
            }
            if (this.PipelineExternalComputeScaleProperties != null)
            {
                this.PipelineExternalComputeScaleProperties.Validate();
            }
        }
    }
}