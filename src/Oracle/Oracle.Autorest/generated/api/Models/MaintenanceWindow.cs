// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Extensions;

    /// <summary>MaintenanceWindow resource properties</summary>
    public partial class MaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMaintenanceWindow,
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMaintenanceWindowInternal
    {

        /// <summary>Backing field for <see cref="CustomActionTimeoutInMin" /> property.</summary>
        private int? _customActionTimeoutInMin;

        /// <summary>
        /// Determines the amount of time the system will wait before the start of each database server patching operation. Custom
        /// action timeout is in minutes and valid value is between 15 to 120 (inclusive).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public int? CustomActionTimeoutInMin { get => this._customActionTimeoutInMin; set => this._customActionTimeoutInMin = value; }

        /// <summary>Backing field for <see cref="DaysOfWeek" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek> _daysOfWeek;

        /// <summary>Days during the week when maintenance should be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek> DaysOfWeek { get => this._daysOfWeek; set => this._daysOfWeek = value; }

        /// <summary>Backing field for <see cref="HoursOfDay" /> property.</summary>
        private System.Collections.Generic.List<int> _hoursOfDay;

        /// <summary>
        /// The window of hours during the day when maintenance should be performed. The window is a 4 hour slot. Valid values are
        /// - 0 - represents time slot 0:00 - 3:59 UTC - 4 - represents time slot 4:00 - 7:59 UTC - 8 - represents time slot 8:00
        /// - 11:59 UTC - 12 - represents time slot 12:00 - 15:59 UTC - 16 - represents time slot 16:00 - 19:59 UTC - 20 - represents
        /// time slot 20:00 - 23:59 UTC
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<int> HoursOfDay { get => this._hoursOfDay; set => this._hoursOfDay = value; }

        /// <summary>Backing field for <see cref="IsCustomActionTimeoutEnabled" /> property.</summary>
        private bool? _isCustomActionTimeoutEnabled;

        /// <summary>
        /// If true, enables the configuration of a custom action timeout (waiting period) between database server patching operations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public bool? IsCustomActionTimeoutEnabled { get => this._isCustomActionTimeoutEnabled; set => this._isCustomActionTimeoutEnabled = value; }

        /// <summary>Backing field for <see cref="IsMonthlyPatchingEnabled" /> property.</summary>
        private bool? _isMonthlyPatchingEnabled;

        /// <summary>is Monthly Patching Enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public bool? IsMonthlyPatchingEnabled { get => this._isMonthlyPatchingEnabled; set => this._isMonthlyPatchingEnabled = value; }

        /// <summary>Backing field for <see cref="LeadTimeInWeek" /> property.</summary>
        private int? _leadTimeInWeek;

        /// <summary>
        /// Lead time window allows user to set a lead time to prepare for a down time. The lead time is in weeks and valid value
        /// is between 1 to 4.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public int? LeadTimeInWeek { get => this._leadTimeInWeek; set => this._leadTimeInWeek = value; }

        /// <summary>Backing field for <see cref="Month" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth> _month;

        /// <summary>Months during the year when maintenance should be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth> Month { get => this._month; set => this._month = value; }

        /// <summary>Backing field for <see cref="PatchingMode" /> property.</summary>
        private string _patchingMode;

        /// <summary>Cloud Exadata infrastructure node patching method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public string PatchingMode { get => this._patchingMode; set => this._patchingMode = value; }

        /// <summary>Backing field for <see cref="Preference" /> property.</summary>
        private string _preference;

        /// <summary>The maintenance window scheduling preference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public string Preference { get => this._preference; set => this._preference = value; }

        /// <summary>Backing field for <see cref="WeeksOfMonth" /> property.</summary>
        private System.Collections.Generic.List<int> _weeksOfMonth;

        /// <summary>
        /// Weeks during the month when maintenance should be performed. Weeks start on the 1st, 8th, 15th, and 22nd days of the month,
        /// and have a duration of 7 days. Weeks start and end based on calendar dates, not days of the week. For example, to allow
        /// maintenance during the 2nd week of the month (from the 8th day to the 14th day of the month), use the value 2. Maintenance
        /// cannot be scheduled for the fifth week of months that contain more than 28 days. Note that this parameter works in conjunction
        /// with the daysOfWeek and hoursOfDay parameters to allow you to specify specific days of the week and hours that maintenance
        /// will be performed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Origin(Microsoft.Azure.PowerShell.Cmdlets.Oracle.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<int> WeeksOfMonth { get => this._weeksOfMonth; set => this._weeksOfMonth = value; }

        /// <summary>Creates an new <see cref="MaintenanceWindow" /> instance.</summary>
        public MaintenanceWindow()
        {

        }
    }
    /// MaintenanceWindow resource properties
    public partial interface IMaintenanceWindow :
        Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Determines the amount of time the system will wait before the start of each database server patching operation. Custom
        /// action timeout is in minutes and valid value is between 15 to 120 (inclusive).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Determines the amount of time the system will wait before the start of each database server patching operation. Custom action timeout is in minutes and valid value is between 15 to 120 (inclusive).",
        SerializedName = @"customActionTimeoutInMins",
        PossibleTypes = new [] { typeof(int) })]
        int? CustomActionTimeoutInMin { get; set; }
        /// <summary>Days during the week when maintenance should be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Days during the week when maintenance should be performed.",
        SerializedName = @"daysOfWeek",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek> DaysOfWeek { get; set; }
        /// <summary>
        /// The window of hours during the day when maintenance should be performed. The window is a 4 hour slot. Valid values are
        /// - 0 - represents time slot 0:00 - 3:59 UTC - 4 - represents time slot 4:00 - 7:59 UTC - 8 - represents time slot 8:00
        /// - 11:59 UTC - 12 - represents time slot 12:00 - 15:59 UTC - 16 - represents time slot 16:00 - 19:59 UTC - 20 - represents
        /// time slot 20:00 - 23:59 UTC
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The window of hours during the day when maintenance should be performed. The window is a 4 hour slot. Valid values are - 0 - represents time slot 0:00 - 3:59 UTC - 4 - represents time slot 4:00 - 7:59 UTC - 8 - represents time slot 8:00 - 11:59 UTC - 12 - represents time slot 12:00 - 15:59 UTC - 16 - represents time slot 16:00 - 19:59 UTC - 20 - represents time slot 20:00 - 23:59 UTC",
        SerializedName = @"hoursOfDay",
        PossibleTypes = new [] { typeof(int) })]
        System.Collections.Generic.List<int> HoursOfDay { get; set; }
        /// <summary>
        /// If true, enables the configuration of a custom action timeout (waiting period) between database server patching operations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"If true, enables the configuration of a custom action timeout (waiting period) between database server patching operations.",
        SerializedName = @"isCustomActionTimeoutEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsCustomActionTimeoutEnabled { get; set; }
        /// <summary>is Monthly Patching Enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"is Monthly Patching Enabled",
        SerializedName = @"isMonthlyPatchingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsMonthlyPatchingEnabled { get; set; }
        /// <summary>
        /// Lead time window allows user to set a lead time to prepare for a down time. The lead time is in weeks and valid value
        /// is between 1 to 4.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Lead time window allows user to set a lead time to prepare for a down time. The lead time is in weeks and valid value is between 1 to 4. ",
        SerializedName = @"leadTimeInWeeks",
        PossibleTypes = new [] { typeof(int) })]
        int? LeadTimeInWeek { get; set; }
        /// <summary>Months during the year when maintenance should be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Months during the year when maintenance should be performed.",
        SerializedName = @"months",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth> Month { get; set; }
        /// <summary>Cloud Exadata infrastructure node patching method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Cloud Exadata infrastructure node patching method.",
        SerializedName = @"patchingMode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Oracle.PSArgumentCompleterAttribute("Rolling", "NonRolling")]
        string PatchingMode { get; set; }
        /// <summary>The maintenance window scheduling preference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maintenance window scheduling preference.",
        SerializedName = @"preference",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Oracle.PSArgumentCompleterAttribute("NoPreference", "CustomPreference")]
        string Preference { get; set; }
        /// <summary>
        /// Weeks during the month when maintenance should be performed. Weeks start on the 1st, 8th, 15th, and 22nd days of the month,
        /// and have a duration of 7 days. Weeks start and end based on calendar dates, not days of the week. For example, to allow
        /// maintenance during the 2nd week of the month (from the 8th day to the 14th day of the month), use the value 2. Maintenance
        /// cannot be scheduled for the fifth week of months that contain more than 28 days. Note that this parameter works in conjunction
        /// with the daysOfWeek and hoursOfDay parameters to allow you to specify specific days of the week and hours that maintenance
        /// will be performed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Oracle.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Weeks during the month when maintenance should be performed. Weeks start on the 1st, 8th, 15th, and 22nd days of the month, and have a duration of 7 days. Weeks start and end based on calendar dates, not days of the week. For example, to allow maintenance during the 2nd week of the month (from the 8th day to the 14th day of the month), use the value 2. Maintenance cannot be scheduled for the fifth week of months that contain more than 28 days. Note that this parameter works in conjunction with the  daysOfWeek and hoursOfDay parameters to allow you to specify specific days of the week and hours that maintenance will be performed. ",
        SerializedName = @"weeksOfMonth",
        PossibleTypes = new [] { typeof(int) })]
        System.Collections.Generic.List<int> WeeksOfMonth { get; set; }

    }
    /// MaintenanceWindow resource properties
    internal partial interface IMaintenanceWindowInternal

    {
        /// <summary>
        /// Determines the amount of time the system will wait before the start of each database server patching operation. Custom
        /// action timeout is in minutes and valid value is between 15 to 120 (inclusive).
        /// </summary>
        int? CustomActionTimeoutInMin { get; set; }
        /// <summary>Days during the week when maintenance should be performed.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDayOfWeek> DaysOfWeek { get; set; }
        /// <summary>
        /// The window of hours during the day when maintenance should be performed. The window is a 4 hour slot. Valid values are
        /// - 0 - represents time slot 0:00 - 3:59 UTC - 4 - represents time slot 4:00 - 7:59 UTC - 8 - represents time slot 8:00
        /// - 11:59 UTC - 12 - represents time slot 12:00 - 15:59 UTC - 16 - represents time slot 16:00 - 19:59 UTC - 20 - represents
        /// time slot 20:00 - 23:59 UTC
        /// </summary>
        System.Collections.Generic.List<int> HoursOfDay { get; set; }
        /// <summary>
        /// If true, enables the configuration of a custom action timeout (waiting period) between database server patching operations.
        /// </summary>
        bool? IsCustomActionTimeoutEnabled { get; set; }
        /// <summary>is Monthly Patching Enabled</summary>
        bool? IsMonthlyPatchingEnabled { get; set; }
        /// <summary>
        /// Lead time window allows user to set a lead time to prepare for a down time. The lead time is in weeks and valid value
        /// is between 1 to 4.
        /// </summary>
        int? LeadTimeInWeek { get; set; }
        /// <summary>Months during the year when maintenance should be performed.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IMonth> Month { get; set; }
        /// <summary>Cloud Exadata infrastructure node patching method.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Oracle.PSArgumentCompleterAttribute("Rolling", "NonRolling")]
        string PatchingMode { get; set; }
        /// <summary>The maintenance window scheduling preference.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Oracle.PSArgumentCompleterAttribute("NoPreference", "CustomPreference")]
        string Preference { get; set; }
        /// <summary>
        /// Weeks during the month when maintenance should be performed. Weeks start on the 1st, 8th, 15th, and 22nd days of the month,
        /// and have a duration of 7 days. Weeks start and end based on calendar dates, not days of the week. For example, to allow
        /// maintenance during the 2nd week of the month (from the 8th day to the 14th day of the month), use the value 2. Maintenance
        /// cannot be scheduled for the fifth week of months that contain more than 28 days. Note that this parameter works in conjunction
        /// with the daysOfWeek and hoursOfDay parameters to allow you to specify specific days of the week and hours that maintenance
        /// will be performed.
        /// </summary>
        System.Collections.Generic.List<int> WeeksOfMonth { get; set; }

    }
}