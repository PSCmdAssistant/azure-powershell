// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    public partial class RecurrenceTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceTrigger,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceTriggerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBase __triggerBase = new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.TriggerBase();

        /// <summary>
        /// Specifies end time of schedule in ISO 8601, but without a UTC offset. Refer https://en.wikipedia.org/wiki/ISO_8601.
        /// Recommented format would be "2022-06-01T00:00:01"
        /// If not present, the schedule will run indefinitely
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).EndTime = value ?? null; }

        /// <summary>Backing field for <see cref="Frequency" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RecurrenceFrequency _frequency;

        /// <summary>[Required] The frequency to trigger schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RecurrenceFrequency Frequency { get => this._frequency; set => this._frequency = value; }

        /// <summary>Backing field for <see cref="Interval" /> property.</summary>
        private int _interval;

        /// <summary>[Required] Specifies schedule interval in conjunction with frequency</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public int Interval { get => this._interval; set => this._interval = value; }

        /// <summary>Internal Acessors for Schedule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceSchedule Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceTriggerInternal.Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.RecurrenceSchedule()); set { {_schedule = value;} } }

        /// <summary>Backing field for <see cref="Schedule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceSchedule _schedule;

        /// <summary>The recurrence schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceSchedule Schedule { get => (this._schedule = this._schedule ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.RecurrenceSchedule()); set => this._schedule = value; }

        /// <summary>[Required] List of hours for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public int[] ScheduleHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).Hour; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).Hour = value ?? null /* arrayOf */; }

        /// <summary>[Required] List of minutes for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public int[] ScheduleMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).Minute; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).Minute = value ?? null /* arrayOf */; }

        /// <summary>List of month days for the schedule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public int[] ScheduleMonthDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).MonthDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).MonthDay = value ?? null /* arrayOf */; }

        /// <summary>List of days for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.WeekDay[] ScheduleWeekDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).WeekDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceScheduleInternal)Schedule).WeekDay = value ?? null /* arrayOf */; }

        /// <summary>Specifies start time of schedule in ISO 8601 format, but without a UTC offset.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).StartTime = value ?? null; }

        /// <summary>
        /// Specifies time zone in which the schedule runs.
        /// TimeZone should follow Windows time zone format. Refer: https://docs.microsoft.com/en-us/windows-hardware/manufacture/desktop/default-time-zones?view=windows-11
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string TimeZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).TimeZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).TimeZone = value ?? null; }

        /// <summary>[Required]</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.TriggerType TriggerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).TriggerType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal)__triggerBase).TriggerType = value ; }

        /// <summary>Creates an new <see cref="RecurrenceTrigger" /> instance.</summary>
        public RecurrenceTrigger()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__triggerBase), __triggerBase);
            await eventListener.AssertObjectIsValid(nameof(__triggerBase), __triggerBase);
        }
    }
    public partial interface IRecurrenceTrigger :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBase
    {
        /// <summary>[Required] The frequency to trigger schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"[Required] The frequency to trigger schedule.",
        SerializedName = @"frequency",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RecurrenceFrequency) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RecurrenceFrequency Frequency { get; set; }
        /// <summary>[Required] Specifies schedule interval in conjunction with frequency</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"[Required] Specifies schedule interval in conjunction with frequency",
        SerializedName = @"interval",
        PossibleTypes = new [] { typeof(int) })]
        int Interval { get; set; }
        /// <summary>[Required] List of hours for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"[Required] List of hours for the schedule.",
        SerializedName = @"hours",
        PossibleTypes = new [] { typeof(int) })]
        int[] ScheduleHour { get; set; }
        /// <summary>[Required] List of minutes for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"[Required] List of minutes for the schedule.",
        SerializedName = @"minutes",
        PossibleTypes = new [] { typeof(int) })]
        int[] ScheduleMinute { get; set; }
        /// <summary>List of month days for the schedule</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of month days for the schedule",
        SerializedName = @"monthDays",
        PossibleTypes = new [] { typeof(int) })]
        int[] ScheduleMonthDay { get; set; }
        /// <summary>List of days for the schedule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of days for the schedule.",
        SerializedName = @"weekDays",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.WeekDay) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.WeekDay[] ScheduleWeekDay { get; set; }

    }
    internal partial interface IRecurrenceTriggerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ITriggerBaseInternal
    {
        /// <summary>[Required] The frequency to trigger schedule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.RecurrenceFrequency Frequency { get; set; }
        /// <summary>[Required] Specifies schedule interval in conjunction with frequency</summary>
        int Interval { get; set; }
        /// <summary>The recurrence schedule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IRecurrenceSchedule Schedule { get; set; }
        /// <summary>[Required] List of hours for the schedule.</summary>
        int[] ScheduleHour { get; set; }
        /// <summary>[Required] List of minutes for the schedule.</summary>
        int[] ScheduleMinute { get; set; }
        /// <summary>List of month days for the schedule</summary>
        int[] ScheduleMonthDay { get; set; }
        /// <summary>List of days for the schedule.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.WeekDay[] ScheduleWeekDay { get; set; }

    }
}