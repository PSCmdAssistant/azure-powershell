namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets a value indicating whether events are delivered to additional endpoints.
        public bool? ScheduledEventsAdditionalEndpoints { get; set; }

        // Gets or sets a value indicating whether events for user-initiated reboots are delivered.
        public bool? EnableUserRebootScheduledEvents { get; set; }

        // Gets or sets a value indicating whether events for user-initiated redeploys are delivered.
        public bool? EnableUserRedeployScheduledEvents { get; set; }
    }
}