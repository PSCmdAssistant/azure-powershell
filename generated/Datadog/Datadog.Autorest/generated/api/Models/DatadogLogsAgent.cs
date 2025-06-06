// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogLogsAgent :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogLogsAgent,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.IDatadogLogsAgentInternal
    {

        /// <summary>Backing field for <see cref="Transport" /> property.</summary>
        private string _transport;

        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Transport { get => this._transport; set => this._transport = value; }

        /// <summary>Creates an new <see cref="DatadogLogsAgent" /> instance.</summary>
        public DatadogLogsAgent()
        {

        }
    }
    public partial interface IDatadogLogsAgent :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The transport.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The transport.",
        SerializedName = @"transport",
        PossibleTypes = new [] { typeof(string) })]
        string Transport { get; set; }

    }
    internal partial interface IDatadogLogsAgentInternal

    {
        /// <summary>The transport.</summary>
        string Transport { get; set; }

    }
}