// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.Resources.Models
{
    using System.Linq;

    /// <summary>
    /// Deployment properties with additional details.
    /// </summary>
    public partial class DeploymentPropertiesExtended
    {
        /// <summary>
        /// Initializes a new instance of the DeploymentPropertiesExtended class.
        /// </summary>
        public DeploymentPropertiesExtended()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeploymentPropertiesExtended class.
        /// </summary>

        /// <param name="provisioningState">Denotes the state of provisioning.
        /// Possible values include: &#39;NotSpecified&#39;, &#39;Accepted&#39;, &#39;Running&#39;, &#39;Ready&#39;,
        /// &#39;Creating&#39;, &#39;Created&#39;, &#39;Deleting&#39;, &#39;Deleted&#39;, &#39;Canceled&#39;, &#39;Failed&#39;,
        /// &#39;Succeeded&#39;, &#39;Updating&#39;</param>

        /// <param name="correlationId">The correlation ID of the deployment.
        /// </param>

        /// <param name="timestamp">The timestamp of the template deployment.
        /// </param>

        /// <param name="duration">The duration of the template deployment.
        /// </param>

        /// <param name="outputs">Key/value pairs that represent deployment output.
        /// </param>

        /// <param name="providers">The list of resource providers needed for the deployment.
        /// </param>

        /// <param name="dependencies">The list of deployment dependencies.
        /// </param>

        /// <param name="templateLink">The URI referencing the template.
        /// </param>

        /// <param name="parameters">Deployment parameters.
        /// </param>

        /// <param name="parametersLink">The URI referencing the parameters.
        /// </param>

        /// <param name="mode">The deployment mode. Possible values are Incremental and Complete.
        /// Possible values include: &#39;Incremental&#39;, &#39;Complete&#39;</param>

        /// <param name="debugSetting">The debug setting of the deployment.
        /// </param>

        /// <param name="onErrorDeployment">The deployment on error behavior.
        /// </param>

        /// <param name="templateHash">The hash produced for the template.
        /// </param>

        /// <param name="outputResources">Array of provisioned resources.
        /// </param>

        /// <param name="validatedResources">Array of validated resources.
        /// </param>

        /// <param name="error">The deployment error.
        /// </param>

        /// <param name="diagnostics">Contains diagnostic information collected during validation process.
        /// </param>

        /// <param name="validationLevel">The validation level of the deployment
        /// Possible values include: &#39;Template&#39;, &#39;Provider&#39;, &#39;ProviderNoRbac&#39;</param>
        public DeploymentPropertiesExtended(string provisioningState = default(string), string correlationId = default(string), System.DateTime? timestamp = default(System.DateTime?), string duration = default(string), object outputs = default(object), System.Collections.Generic.IList<Provider> providers = default(System.Collections.Generic.IList<Provider>), System.Collections.Generic.IList<Dependency> dependencies = default(System.Collections.Generic.IList<Dependency>), TemplateLink templateLink = default(TemplateLink), object parameters = default(object), ParametersLink parametersLink = default(ParametersLink), DeploymentMode? mode = default(DeploymentMode?), DebugSetting debugSetting = default(DebugSetting), OnErrorDeploymentExtended onErrorDeployment = default(OnErrorDeploymentExtended), string templateHash = default(string), System.Collections.Generic.IList<ResourceReference> outputResources = default(System.Collections.Generic.IList<ResourceReference>), System.Collections.Generic.IList<ResourceReference> validatedResources = default(System.Collections.Generic.IList<ResourceReference>), ErrorResponse error = default(ErrorResponse), System.Collections.Generic.IList<DeploymentDiagnosticsDefinition> diagnostics = default(System.Collections.Generic.IList<DeploymentDiagnosticsDefinition>), string validationLevel = default(string))

        {
            this.ProvisioningState = provisioningState;
            this.CorrelationId = correlationId;
            this.Timestamp = timestamp;
            this.Duration = duration;
            this.Outputs = outputs;
            this.Providers = providers;
            this.Dependencies = dependencies;
            this.TemplateLink = templateLink;
            this.Parameters = parameters;
            this.ParametersLink = parametersLink;
            this.Mode = mode;
            this.DebugSetting = debugSetting;
            this.OnErrorDeployment = onErrorDeployment;
            this.TemplateHash = templateHash;
            this.OutputResources = outputResources;
            this.ValidatedResources = validatedResources;
            this.Error = error;
            this.Diagnostics = diagnostics;
            this.ValidationLevel = validationLevel;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets denotes the state of provisioning. Possible values include: &#39;NotSpecified&#39;, &#39;Accepted&#39;, &#39;Running&#39;, &#39;Ready&#39;, &#39;Creating&#39;, &#39;Created&#39;, &#39;Deleting&#39;, &#39;Deleted&#39;, &#39;Canceled&#39;, &#39;Failed&#39;, &#39;Succeeded&#39;, &#39;Updating&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets the correlation ID of the deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "correlationId")]
        public string CorrelationId {get; private set; }

        /// <summary>
        /// Gets the timestamp of the template deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "timestamp")]
        public System.DateTime? Timestamp {get; private set; }

        /// <summary>
        /// Gets the duration of the template deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "duration")]
        public string Duration {get; private set; }

        /// <summary>
        /// Gets key/value pairs that represent deployment output.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "outputs")]
        public object Outputs {get; private set; }

        /// <summary>
        /// Gets the list of resource providers needed for the deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "providers")]
        public System.Collections.Generic.IList<Provider> Providers {get; private set; }

        /// <summary>
        /// Gets the list of deployment dependencies.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "dependencies")]
        public System.Collections.Generic.IList<Dependency> Dependencies {get; private set; }

        /// <summary>
        /// Gets the URI referencing the template.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "templateLink")]
        public TemplateLink TemplateLink {get; private set; }

        /// <summary>
        /// Gets deployment parameters.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "parameters")]
        public object Parameters {get; private set; }

        /// <summary>
        /// Gets the URI referencing the parameters.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "parametersLink")]
        public ParametersLink ParametersLink {get; private set; }

        /// <summary>
        /// Gets the deployment mode. Possible values are Incremental and Complete. Possible values include: &#39;Incremental&#39;, &#39;Complete&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "mode")]
        public DeploymentMode? Mode {get; private set; }

        /// <summary>
        /// Gets the debug setting of the deployment.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "debugSetting")]
        public DebugSetting DebugSetting {get; private set; }

        /// <summary>
        /// Gets the deployment on error behavior.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "onErrorDeployment")]
        public OnErrorDeploymentExtended OnErrorDeployment {get; private set; }

        /// <summary>
        /// Gets the hash produced for the template.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "templateHash")]
        public string TemplateHash {get; private set; }

        /// <summary>
        /// Gets array of provisioned resources.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "outputResources")]
        public System.Collections.Generic.IList<ResourceReference> OutputResources {get; private set; }

        /// <summary>
        /// Gets array of validated resources.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "validatedResources")]
        public System.Collections.Generic.IList<ResourceReference> ValidatedResources {get; private set; }

        /// <summary>
        /// Gets the deployment error.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "error")]
        public ErrorResponse Error {get; private set; }

        /// <summary>
        /// Gets contains diagnostic information collected during validation process.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "diagnostics")]
        public System.Collections.Generic.IList<DeploymentDiagnosticsDefinition> Diagnostics {get; private set; }

        /// <summary>
        /// Gets or sets the validation level of the deployment Possible values include: &#39;Template&#39;, &#39;Provider&#39;, &#39;ProviderNoRbac&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "validationLevel")]
        public string ValidationLevel {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {








            if (this.ParametersLink != null)
            {
                this.ParametersLink.Validate();
            }







            if (this.Diagnostics != null)
            {
                foreach (var element in this.Diagnostics)
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