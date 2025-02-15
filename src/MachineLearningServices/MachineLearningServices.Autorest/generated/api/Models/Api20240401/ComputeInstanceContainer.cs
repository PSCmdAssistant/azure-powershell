// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    /// <summary>Defines an Aml Instance container.</summary>
    public partial class ComputeInstanceContainer :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceContainer,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceContainerInternal
    {

        /// <summary>Backing field for <see cref="Autosave" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Autosave? _autosave;

        /// <summary>Auto save settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Autosave? Autosave { get => this._autosave; set => this._autosave = value; }

        /// <summary>Backing field for <see cref="Environment" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfo _environment;

        /// <summary>Environment information of this container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfo Environment { get => (this._environment = this._environment ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ComputeInstanceEnvironmentInfo()); set => this._environment = value; }

        /// <summary>name of environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public string EnvironmentName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfoInternal)Environment).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfoInternal)Environment).Name = value ?? null; }

        /// <summary>version of environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public string EnvironmentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfoInternal)Environment).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfoInternal)Environment).Version = value ?? null; }

        /// <summary>Backing field for <see cref="Gpu" /> property.</summary>
        private string _gpu;

        /// <summary>Information of GPU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string Gpu { get => this._gpu; set => this._gpu = value; }

        /// <summary>Internal Acessors for Environment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfo Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceContainerInternal.Environment { get => (this._environment = this._environment ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ComputeInstanceEnvironmentInfo()); set { {_environment = value;} } }

        /// <summary>Internal Acessors for Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny[] Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceContainerInternal.Service { get => this._service; set { {_service = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the ComputeInstance container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Network" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Network? _network;

        /// <summary>network of this container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Network? Network { get => this._network; set => this._network = value; }

        /// <summary>Backing field for <see cref="Service" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny[] _service;

        /// <summary>services of this containers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny[] Service { get => this._service; }

        /// <summary>Creates an new <see cref="ComputeInstanceContainer" /> instance.</summary>
        public ComputeInstanceContainer()
        {

        }
    }
    /// Defines an Aml Instance container.
    public partial interface IComputeInstanceContainer :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IJsonSerializable
    {
        /// <summary>Auto save settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Auto save settings.",
        SerializedName = @"autosave",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Autosave) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Autosave? Autosave { get; set; }
        /// <summary>name of environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string EnvironmentName { get; set; }
        /// <summary>version of environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"version of environment.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string EnvironmentVersion { get; set; }
        /// <summary>Information of GPU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Information of GPU.",
        SerializedName = @"gpu",
        PossibleTypes = new [] { typeof(string) })]
        string Gpu { get; set; }
        /// <summary>Name of the ComputeInstance container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the ComputeInstance container.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>network of this container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"network of this container.",
        SerializedName = @"network",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Network) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Network? Network { get; set; }
        /// <summary>services of this containers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"services of this containers.",
        SerializedName = @"services",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny[] Service { get;  }

    }
    /// Defines an Aml Instance container.
    internal partial interface IComputeInstanceContainerInternal

    {
        /// <summary>Auto save settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Autosave? Autosave { get; set; }
        /// <summary>Environment information of this container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IComputeInstanceEnvironmentInfo Environment { get; set; }
        /// <summary>name of environment.</summary>
        string EnvironmentName { get; set; }
        /// <summary>version of environment.</summary>
        string EnvironmentVersion { get; set; }
        /// <summary>Information of GPU.</summary>
        string Gpu { get; set; }
        /// <summary>Name of the ComputeInstance container.</summary>
        string Name { get; set; }
        /// <summary>network of this container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.Network? Network { get; set; }
        /// <summary>services of this containers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IAny[] Service { get; set; }

    }
}