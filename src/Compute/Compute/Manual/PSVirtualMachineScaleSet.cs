namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        public bool? ScheduledEventsAdditionalEndpoints { get; set; }
        public bool? EnableUserRebootScheduledEvents { get; set; }
        public bool? EnableUserRedeployScheduledEvents { get; set; }
    }
}