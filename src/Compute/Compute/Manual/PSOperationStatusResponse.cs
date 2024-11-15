using System;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSOperationStatusResponse
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status  { get; set; }
        public ApiError Error { get; set; }
        
        public bool? ScheduledEventsAdditionalEndpoints { get; set; }
        public bool? EnableUserRebootScheduledEvents { get; set; }
        public bool? EnableUserRedeployScheduledEvents { get; set; }
		
		public PSOperationStatusResponse()
		{
			this.Status = "Succeeded";
		}
    }
}