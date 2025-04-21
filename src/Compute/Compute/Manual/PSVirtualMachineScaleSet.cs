//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets a value indicating whether automatic zone rebalancing policy is enabled.
        public bool? EnableAutomaticZoneRebalancingPolicy { get; set; }

        // Gets or sets the strategy/actions taken to balance the scale set.
        public string AutomaticZoneRebalanceStrategy { get; set; }

        // Gets or sets detailed behavior for the rebalance strategy.
        public string AutomaticZoneRebalanceBehavior { get; set; }

        // Gets or sets the target instance count the zonal scale set aims to reach.
        public int? AutomaticZoneRebalanceTargetInstanceCount { get; set; }
    }
}