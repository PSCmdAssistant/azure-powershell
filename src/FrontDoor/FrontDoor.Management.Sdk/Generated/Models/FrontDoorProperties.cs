// Code generated by Microsoft (R) AutoRest Code Generator (autorest: 3.10.4, generator: @autorest/powershell@4.0.737)
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.FrontDoor.Models
{
    using System.Linq;

    /// <summary>
    /// The JSON object that contains the properties required to create an
    /// endpoint.
    /// </summary>
    public partial class FrontDoorProperties : FrontDoorUpdateParameters
    {
        /// <summary>
        /// Initializes a new instance of the FrontDoorProperties class.
        /// </summary>
        public FrontDoorProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FrontDoorProperties class.
        /// </summary>

        /// <param name="friendlyName">A friendly name for the frontDoor
        /// </param>

        /// <param name="routingRules">Routing rules associated with this Front Door.
        /// </param>

        /// <param name="loadBalancingSettings">Load balancing settings associated with this Front Door instance.
        /// </param>

        /// <param name="healthProbeSettings">Health probe settings associated with this Front Door instance.
        /// </param>

        /// <param name="backendPools">Backend pools available to routing rules.
        /// </param>

        /// <param name="frontendEndpoints">Frontend endpoints available to routing rules.
        /// </param>

        /// <param name="backendPoolsSettings">Settings for all backendPools
        /// </param>

        /// <param name="enabledState">Operational status of the Front Door load balancer. Permitted values are
        /// &#39;Enabled&#39; or &#39;Disabled&#39;
        /// Possible values include: &#39;Enabled&#39;, &#39;Disabled&#39;</param>

        /// <param name="resourceState">Resource status of the Front Door.
        /// Possible values include: &#39;Creating&#39;, &#39;Enabling&#39;, &#39;Enabled&#39;, &#39;Disabling&#39;,
        /// &#39;Disabled&#39;, &#39;Deleting&#39;, &#39;Migrating&#39;, &#39;Migrated&#39;</param>

        /// <param name="provisioningState">Provisioning state of the Front Door.
        /// </param>

        /// <param name="cname">The host that each frontendEndpoint must CNAME to.
        /// </param>

        /// <param name="frontdoorId">The Id of the frontdoor.
        /// </param>

        /// <param name="rulesEngines">Rules Engine Configurations available to routing rules.
        /// </param>

        /// <param name="extendedProperties">Key-Value pair representing additional properties for frontdoor.
        /// </param>
        public FrontDoorProperties(string friendlyName = default(string), System.Collections.Generic.IList<RoutingRule> routingRules = default(System.Collections.Generic.IList<RoutingRule>), System.Collections.Generic.IList<LoadBalancingSettingsModel> loadBalancingSettings = default(System.Collections.Generic.IList<LoadBalancingSettingsModel>), System.Collections.Generic.IList<HealthProbeSettingsModel> healthProbeSettings = default(System.Collections.Generic.IList<HealthProbeSettingsModel>), System.Collections.Generic.IList<BackendPool> backendPools = default(System.Collections.Generic.IList<BackendPool>), System.Collections.Generic.IList<FrontendEndpoint> frontendEndpoints = default(System.Collections.Generic.IList<FrontendEndpoint>), BackendPoolsSettings backendPoolsSettings = default(BackendPoolsSettings), string enabledState = default(string), string resourceState = default(string), string provisioningState = default(string), string cname = default(string), string frontdoorId = default(string), System.Collections.Generic.IList<RulesEngine> rulesEngines = default(System.Collections.Generic.IList<RulesEngine>), System.Collections.Generic.IDictionary<string, string> extendedProperties = default(System.Collections.Generic.IDictionary<string, string>))

        : base(friendlyName, routingRules, loadBalancingSettings, healthProbeSettings, backendPools, frontendEndpoints, backendPoolsSettings, enabledState)
        {
            this.ResourceState = resourceState;
            this.ProvisioningState = provisioningState;
            this.Cname = cname;
            this.FrontdoorId = frontdoorId;
            this.RulesEngines = rulesEngines;
            this.ExtendedProperties = extendedProperties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets resource status of the Front Door. Possible values include: &#39;Creating&#39;, &#39;Enabling&#39;, &#39;Enabled&#39;, &#39;Disabling&#39;, &#39;Disabled&#39;, &#39;Deleting&#39;, &#39;Migrating&#39;, &#39;Migrated&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "resourceState")]
        public string ResourceState {get; private set; }

        /// <summary>
        /// Gets provisioning state of the Front Door.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets the host that each frontendEndpoint must CNAME to.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "cname")]
        public string Cname {get; private set; }

        /// <summary>
        /// Gets the Id of the frontdoor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "frontdoorId")]
        public string FrontdoorId {get; private set; }

        /// <summary>
        /// Gets rules Engine Configurations available to routing rules.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "rulesEngines")]
        public System.Collections.Generic.IList<RulesEngine> RulesEngines {get; private set; }

        /// <summary>
        /// Gets key-Value pair representing additional properties for frontdoor.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "extendedProperties")]
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties {get; private set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();






        }
    }
}