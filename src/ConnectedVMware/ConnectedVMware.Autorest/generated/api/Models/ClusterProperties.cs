// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Extensions;

    /// <summary>Describes the properties of a Cluster.</summary>
    public partial class ClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CustomResourceName" /> property.</summary>
        private string _customResourceName;

        /// <summary>Gets the name of the corresponding resource in Kubernetes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string CustomResourceName { get => this._customResourceName; }

        /// <summary>Backing field for <see cref="DatastoreId" /> property.</summary>
        private System.Collections.Generic.List<string> _datastoreId;

        /// <summary>Gets the datastore ARM ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DatastoreId { get => this._datastoreId; }

        /// <summary>Backing field for <see cref="InventoryItemId" /> property.</summary>
        private string _inventoryItemId;

        /// <summary>Gets or sets the inventory Item ID for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string InventoryItemId { get => this._inventoryItemId; set => this._inventoryItemId = value; }

        /// <summary>Internal Acessors for CustomResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.CustomResourceName { get => this._customResourceName; set { {_customResourceName = value;} } }

        /// <summary>Internal Acessors for DatastoreId</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.DatastoreId { get => this._datastoreId; set { {_datastoreId = value;} } }

        /// <summary>Internal Acessors for MoName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.MoName { get => this._moName; set { {_moName = value;} } }

        /// <summary>Internal Acessors for NetworkId</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.NetworkId { get => this._networkId; set { {_networkId = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Statuses</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.Statuses { get => this._statuses; set { {_statuses = value;} } }

        /// <summary>Internal Acessors for TotalCpuMHz</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.TotalCpuMHz { get => this._totalCpuMHz; set { {_totalCpuMHz = value;} } }

        /// <summary>Internal Acessors for TotalMemoryGb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.TotalMemoryGb { get => this._totalMemoryGb; set { {_totalMemoryGb = value;} } }

        /// <summary>Internal Acessors for UsedCpuMHz</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.UsedCpuMHz { get => this._usedCpuMHz; set { {_usedCpuMHz = value;} } }

        /// <summary>Internal Acessors for UsedMemoryGb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.UsedMemoryGb { get => this._usedMemoryGb; set { {_usedMemoryGb = value;} } }

        /// <summary>Internal Acessors for Uuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IClusterPropertiesInternal.Uuid { get => this._uuid; set { {_uuid = value;} } }

        /// <summary>Backing field for <see cref="MoName" /> property.</summary>
        private string _moName;

        /// <summary>Gets or sets the vCenter Managed Object name for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string MoName { get => this._moName; }

        /// <summary>Backing field for <see cref="MoRefId" /> property.</summary>
        private string _moRefId;

        /// <summary>Gets or sets the vCenter MoRef (Managed Object Reference) ID for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string MoRefId { get => this._moRefId; set => this._moRefId = value; }

        /// <summary>Backing field for <see cref="NetworkId" /> property.</summary>
        private System.Collections.Generic.List<string> _networkId;

        /// <summary>Gets the network ARM ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> NetworkId { get => this._networkId; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Gets the provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Statuses" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> _statuses;

        /// <summary>The resource status information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Statuses { get => this._statuses; }

        /// <summary>Backing field for <see cref="TotalCpuMHz" /> property.</summary>
        private long? _totalCpuMHz;

        /// <summary>Gets the max CPU usage across all cores on the cluster in MHz.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public long? TotalCpuMHz { get => this._totalCpuMHz; }

        /// <summary>Backing field for <see cref="TotalMemoryGb" /> property.</summary>
        private long? _totalMemoryGb;

        /// <summary>Gets the total amount of physical memory on the cluster in GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public long? TotalMemoryGb { get => this._totalMemoryGb; }

        /// <summary>Backing field for <see cref="UsedCpuMHz" /> property.</summary>
        private long? _usedCpuMHz;

        /// <summary>Gets the used CPU usage across all cores on the cluster in MHz.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public long? UsedCpuMHz { get => this._usedCpuMHz; }

        /// <summary>Backing field for <see cref="UsedMemoryGb" /> property.</summary>
        private long? _usedMemoryGb;

        /// <summary>Gets the used physical memory on the cluster in GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public long? UsedMemoryGb { get => this._usedMemoryGb; }

        /// <summary>Backing field for <see cref="Uuid" /> property.</summary>
        private string _uuid;

        /// <summary>Gets or sets a unique identifier for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string Uuid { get => this._uuid; }

        /// <summary>Backing field for <see cref="VCenterId" /> property.</summary>
        private string _vCenterId;

        /// <summary>Gets or sets the ARM Id of the vCenter resource in which this cluster resides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string VCenterId { get => this._vCenterId; set => this._vCenterId = value; }

        /// <summary>Creates an new <see cref="ClusterProperties" /> instance.</summary>
        public ClusterProperties()
        {

        }
    }
    /// Describes the properties of a Cluster.
    public partial interface IClusterProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.IJsonSerializable
    {
        /// <summary>Gets the name of the corresponding resource in Kubernetes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the name of the corresponding resource in Kubernetes.",
        SerializedName = @"customResourceName",
        PossibleTypes = new [] { typeof(string) })]
        string CustomResourceName { get;  }
        /// <summary>Gets the datastore ARM ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the datastore ARM ids.",
        SerializedName = @"datastoreIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DatastoreId { get;  }
        /// <summary>Gets or sets the inventory Item ID for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the inventory Item ID for the cluster.",
        SerializedName = @"inventoryItemId",
        PossibleTypes = new [] { typeof(string) })]
        string InventoryItemId { get; set; }
        /// <summary>Gets or sets the vCenter Managed Object name for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets or sets the vCenter Managed Object name for the cluster.",
        SerializedName = @"moName",
        PossibleTypes = new [] { typeof(string) })]
        string MoName { get;  }
        /// <summary>Gets or sets the vCenter MoRef (Managed Object Reference) ID for the cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the vCenter MoRef (Managed Object Reference) ID for the cluster.",
        SerializedName = @"moRefId",
        PossibleTypes = new [] { typeof(string) })]
        string MoRefId { get; set; }
        /// <summary>Gets the network ARM ids.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the network ARM ids.",
        SerializedName = @"networkIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> NetworkId { get;  }
        /// <summary>Gets the provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted", "Created")]
        string ProvisioningState { get;  }
        /// <summary>The resource status information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource status information.",
        SerializedName = @"statuses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Statuses { get;  }
        /// <summary>Gets the max CPU usage across all cores on the cluster in MHz.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the max CPU usage across all cores on the cluster in MHz.",
        SerializedName = @"totalCpuMHz",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalCpuMHz { get;  }
        /// <summary>Gets the total amount of physical memory on the cluster in GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the total amount of physical memory on the cluster in GB.",
        SerializedName = @"totalMemoryGB",
        PossibleTypes = new [] { typeof(long) })]
        long? TotalMemoryGb { get;  }
        /// <summary>Gets the used CPU usage across all cores on the cluster in MHz.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the used CPU usage across all cores on the cluster in MHz.",
        SerializedName = @"usedCpuMHz",
        PossibleTypes = new [] { typeof(long) })]
        long? UsedCpuMHz { get;  }
        /// <summary>Gets the used physical memory on the cluster in GB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the used physical memory on the cluster in GB.",
        SerializedName = @"usedMemoryGB",
        PossibleTypes = new [] { typeof(long) })]
        long? UsedMemoryGb { get;  }
        /// <summary>Gets or sets a unique identifier for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets or sets a unique identifier for this resource.",
        SerializedName = @"uuid",
        PossibleTypes = new [] { typeof(string) })]
        string Uuid { get;  }
        /// <summary>Gets or sets the ARM Id of the vCenter resource in which this cluster resides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the ARM Id of the vCenter resource in which this cluster resides.",
        SerializedName = @"vCenterId",
        PossibleTypes = new [] { typeof(string) })]
        string VCenterId { get; set; }

    }
    /// Describes the properties of a Cluster.
    internal partial interface IClusterPropertiesInternal

    {
        /// <summary>Gets the name of the corresponding resource in Kubernetes.</summary>
        string CustomResourceName { get; set; }
        /// <summary>Gets the datastore ARM ids.</summary>
        System.Collections.Generic.List<string> DatastoreId { get; set; }
        /// <summary>Gets or sets the inventory Item ID for the cluster.</summary>
        string InventoryItemId { get; set; }
        /// <summary>Gets or sets the vCenter Managed Object name for the cluster.</summary>
        string MoName { get; set; }
        /// <summary>Gets or sets the vCenter MoRef (Managed Object Reference) ID for the cluster.</summary>
        string MoRefId { get; set; }
        /// <summary>Gets the network ARM ids.</summary>
        System.Collections.Generic.List<string> NetworkId { get; set; }
        /// <summary>Gets the provisioning state.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted", "Created")]
        string ProvisioningState { get; set; }
        /// <summary>The resource status information.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Statuses { get; set; }
        /// <summary>Gets the max CPU usage across all cores on the cluster in MHz.</summary>
        long? TotalCpuMHz { get; set; }
        /// <summary>Gets the total amount of physical memory on the cluster in GB.</summary>
        long? TotalMemoryGb { get; set; }
        /// <summary>Gets the used CPU usage across all cores on the cluster in MHz.</summary>
        long? UsedCpuMHz { get; set; }
        /// <summary>Gets the used physical memory on the cluster in GB.</summary>
        long? UsedMemoryGb { get; set; }
        /// <summary>Gets or sets a unique identifier for this resource.</summary>
        string Uuid { get; set; }
        /// <summary>Gets or sets the ARM Id of the vCenter resource in which this cluster resides.</summary>
        string VCenterId { get; set; }

    }
}