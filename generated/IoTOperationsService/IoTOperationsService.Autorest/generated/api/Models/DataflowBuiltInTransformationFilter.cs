// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Extensions;

    /// <summary>Dataflow BuiltIn Transformation filter properties</summary>
    public partial class DataflowBuiltInTransformationFilter :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowBuiltInTransformationFilter,
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowBuiltInTransformationFilterInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>A user provided optional description of the filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Expression" /> property.</summary>
        private string _expression;

        /// <summary>
        /// Condition to filter data. Can reference input fields with {n} where n is the index of the input field starting from 1.
        /// Example: $1 < 0 || $1 > $2 (Assuming inputs section $1 and $2 are provided)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Expression { get => this._expression; set => this._expression = value; }

        /// <summary>Backing field for <see cref="Input" /> property.</summary>
        private System.Collections.Generic.List<string> _input;

        /// <summary>List of fields for filtering in JSON path expression.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Input { get => this._input; set => this._input = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of dataflow operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Origin(Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="DataflowBuiltInTransformationFilter" /> instance.</summary>
        public DataflowBuiltInTransformationFilter()
        {

        }
    }
    /// Dataflow BuiltIn Transformation filter properties
    public partial interface IDataflowBuiltInTransformationFilter :
        Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.IJsonSerializable
    {
        /// <summary>A user provided optional description of the filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A user provided optional description of the filter.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// Condition to filter data. Can reference input fields with {n} where n is the index of the input field starting from 1.
        /// Example: $1 < 0 || $1 > $2 (Assuming inputs section $1 and $2 are provided)
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Condition to filter data. Can reference input fields with {n} where n is the index of the input field starting from 1. Example: $1 < 0 || $1 > $2 (Assuming inputs section $1 and $2 are provided)",
        SerializedName = @"expression",
        PossibleTypes = new [] { typeof(string) })]
        string Expression { get; set; }
        /// <summary>List of fields for filtering in JSON path expression.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of fields for filtering in JSON path expression.",
        SerializedName = @"inputs",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Input { get; set; }
        /// <summary>The type of dataflow operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of dataflow operation.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Filter")]
        string Type { get; set; }

    }
    /// Dataflow BuiltIn Transformation filter properties
    internal partial interface IDataflowBuiltInTransformationFilterInternal

    {
        /// <summary>A user provided optional description of the filter.</summary>
        string Description { get; set; }
        /// <summary>
        /// Condition to filter data. Can reference input fields with {n} where n is the index of the input field starting from 1.
        /// Example: $1 < 0 || $1 > $2 (Assuming inputs section $1 and $2 are provided)
        /// </summary>
        string Expression { get; set; }
        /// <summary>List of fields for filtering in JSON path expression.</summary>
        System.Collections.Generic.List<string> Input { get; set; }
        /// <summary>The type of dataflow operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.PSArgumentCompleterAttribute("Filter")]
        string Type { get; set; }

    }
}