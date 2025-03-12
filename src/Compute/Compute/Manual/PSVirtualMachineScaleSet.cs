namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets the EnableAutomaticZoneRebalancingPolicy.
        public bool? EnableAutomaticZoneRebalancingPolicy { get; set; }

        // Gets or sets the AutomaticZoneRebalanceStrategy.
        public string AutomaticZoneRebalanceStrategy { get; set; }

        // Gets or sets the AutomaticZoneRebalanceBehavior.
        public string AutomaticZoneRebalanceBehavior { get; set; }

        // Gets or sets the AutomaticZoneRebalanceTargetInstanceCount.
        public int? AutomaticZoneRebalanceTargetInstanceCount { get; set; }
    }
}