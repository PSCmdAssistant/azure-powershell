namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets whether Auto AZ Balance will be applied for this VMSS.
        public bool? EnableAutomaticZoneRebalancingPolicy { get; set; }

        // Specifies the strategy/actions taken to balance the scale set.
        public string AutomaticZoneRebalanceStrategy { get; set; }

        // Specifies detailed behavior for the rebalance strategy.
        public string AutomaticZoneRebalanceBehavior { get; set; }

        // The target instance count the zonal scale set aims to reach.
        public int? AutomaticZoneRebalanceTargetInstanceCount { get; set; }
    }
}