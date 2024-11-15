using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAvailabilitySet : PSOperation
    {
        // Gets or sets the property of 'ResourceGroupName'
        public string ResourceGroupName
        {
            get
            {
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }

        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        // Gets or sets the property of 'Type'
        public string Type { get; set; }

        // Gets or sets the property of 'Location'
        public string Location { get; set; }

        // Gets or sets the property of 'Tags'
        public IDictionary<string, string> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(Tags, Formatting.Indented); }
        }

        // Gets or sets Fault Domain count.
        public int? PlatformFaultDomainCount { get; set; }

        // Gets or sets Update Domain count.
        public int? PlatformUpdateDomainCount { get; set; }

        // Gets or sets the resource status information.
        public IList<InstanceViewStatus> Statuses { get; set; }

        [JsonIgnore]
        public string StatusesText
        {
            get { return JsonConvert.SerializeObject(Statuses, Formatting.Indented); }
        }

        // Gets or sets a list containing references to all Virtual Machines created under this Availability Set.
        public IList<SubResource> VirtualMachinesReferences { get; set; }

        [JsonIgnore]
        public string VirtualMachinesReferencesText
        {
            get { return JsonConvert.SerializeObject(VirtualMachinesReferences, Formatting.Indented); }
        }

        public string Sku { get; set; }

        public SubResource ProximityPlacementGroup { get; set; }

        public bool? ScheduledEventsAdditionalEndpoints { get; set; }

        public bool? EnableUserRebootScheduledEvents { get; set; }

        public bool? EnableUserRedeployScheduledEvents { get; set; }
    }
}