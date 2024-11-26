namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets a value indicating whether scheduled events additional endpoints are enabled.
        public bool? ScheduledEventsAdditionalEndpoints { get; set; }

        // Gets or sets a value indicating whether user reboot scheduled events are enabled.
        public bool? EnableUserRebootScheduledEvents { get; set; }

        // Gets or sets a value indicating whether user redeploy scheduled events are enabled.
        public bool? EnableUserRedeployScheduledEvents { get; set; }
    }
}