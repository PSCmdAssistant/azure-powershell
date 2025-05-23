// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// Recovery plan InMageAzureV2 failover input.
    /// </summary>
    [Newtonsoft.Json.JsonObject("InMageAzureV2")]
    public partial class RecoveryPlanInMageAzureV2FailoverInput : RecoveryPlanProviderSpecificFailoverInput
    {
        /// <summary>
        /// Initializes a new instance of the RecoveryPlanInMageAzureV2FailoverInput class.
        /// </summary>
        public RecoveryPlanInMageAzureV2FailoverInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RecoveryPlanInMageAzureV2FailoverInput class.
        /// </summary>

        /// <param name="recoveryPointType">The recovery point type.
        /// Possible values include: &#39;Latest&#39;, &#39;LatestApplicationConsistent&#39;,
        /// &#39;LatestCrashConsistent&#39;, &#39;LatestProcessed&#39;</param>

        /// <param name="useMultiVMSyncPoint">A value indicating whether multi VM sync enabled VMs should use multi VM
        /// sync points for failover.
        /// </param>
        public RecoveryPlanInMageAzureV2FailoverInput(string recoveryPointType, string useMultiVMSyncPoint = default(string))

        {
            this.RecoveryPointType = recoveryPointType;
            this.UseMultiVMSyncPoint = useMultiVMSyncPoint;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the recovery point type. Possible values include: &#39;Latest&#39;, &#39;LatestApplicationConsistent&#39;, &#39;LatestCrashConsistent&#39;, &#39;LatestProcessed&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryPointType")]
        public string RecoveryPointType {get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether multi VM sync enabled VMs should
        /// use multi VM sync points for failover.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "useMultiVmSyncPoint")]
        public string UseMultiVMSyncPoint {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.RecoveryPointType == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "RecoveryPointType");
            }


        }
    }
}