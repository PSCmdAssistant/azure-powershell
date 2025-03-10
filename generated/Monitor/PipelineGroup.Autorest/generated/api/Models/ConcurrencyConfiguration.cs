// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Runtime.Extensions;

    /// <summary>Concurrent publishing configuration.</summary>
    public partial class ConcurrencyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IConcurrencyConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Models.IConcurrencyConfigurationInternal
    {

        /// <summary>Backing field for <see cref="BatchQueueSize" /> property.</summary>
        private int? _batchQueueSize;

        /// <summary>Size of the queue for log batches.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.PropertyOrigin.Owned)]
        public int? BatchQueueSize { get => this._batchQueueSize; set => this._batchQueueSize = value; }

        /// <summary>Backing field for <see cref="WorkerCount" /> property.</summary>
        private int? _workerCount;

        /// <summary>Number of parallel workers processing the log queues.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Origin(Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.PropertyOrigin.Owned)]
        public int? WorkerCount { get => this._workerCount; set => this._workerCount = value; }

        /// <summary>Creates an new <see cref="ConcurrencyConfiguration" /> instance.</summary>
        public ConcurrencyConfiguration()
        {

        }
    }
    /// Concurrent publishing configuration.
    public partial interface IConcurrencyConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Runtime.IJsonSerializable
    {
        /// <summary>Size of the queue for log batches.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Size of the queue for log batches.",
        SerializedName = @"batchQueueSize",
        PossibleTypes = new [] { typeof(int) })]
        int? BatchQueueSize { get; set; }
        /// <summary>Number of parallel workers processing the log queues.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Monitor.PipelineGroup.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of parallel workers processing the log queues.",
        SerializedName = @"workerCount",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerCount { get; set; }

    }
    /// Concurrent publishing configuration.
    internal partial interface IConcurrencyConfigurationInternal

    {
        /// <summary>Size of the queue for log batches.</summary>
        int? BatchQueueSize { get; set; }
        /// <summary>Number of parallel workers processing the log queues.</summary>
        int? WorkerCount { get; set; }

    }
}