// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>Storage SKU and its properties</summary>
    public partial class SkuInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformation,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability> _capability;

        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability> Capability { get => this._capability; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private System.Collections.Generic.List<string> _location;

        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Location { get => this._location; }

        /// <summary>Internal Acessors for Capability</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability> Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal.Capability { get => this._capability; set { {_capability = value;} } }

        /// <summary>Internal Acessors for Kind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal.Kind { get => this._kind; set { {_kind = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for Tier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInformationInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="Restriction" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IRestriction> _restriction;

        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IRestriction> Restriction { get => this._restriction; set => this._restriction = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>The SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="SkuInformation" /> instance.</summary>
        public SkuInformation()
        {

        }
    }
    /// Storage SKU and its properties
    public partial interface ISkuInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability> Capability { get;  }
        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates the type of storage account.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Storage", "StorageV2", "BlobStorage", "FileStorage", "BlockBlobStorage")]
        string Kind { get;  }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.).",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Location { get;  }
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard_LRS", "Standard_GRS", "Standard_RAGRS", "Standard_ZRS", "Premium_LRS", "Premium_ZRS", "Standard_GZRS", "Standard_RAGZRS", "StandardV2_LRS", "StandardV2_GRS", "StandardV2_ZRS", "StandardV2_GZRS", "PremiumV2_LRS", "PremiumV2_ZRS")]
        string Name { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the resource, usually it is 'storageAccounts'.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IRestriction) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IRestriction> Restriction { get; set; }
        /// <summary>The SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The SKU tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard", "Premium")]
        string Tier { get;  }

    }
    /// Storage SKU and its properties
    internal partial interface ISkuInformationInternal

    {
        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability> Capability { get; set; }
        /// <summary>Indicates the type of storage account.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Storage", "StorageV2", "BlobStorage", "FileStorage", "BlockBlobStorage")]
        string Kind { get; set; }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        System.Collections.Generic.List<string> Location { get; set; }
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard_LRS", "Standard_GRS", "Standard_RAGRS", "Standard_ZRS", "Premium_LRS", "Premium_ZRS", "Standard_GZRS", "Standard_RAGZRS", "StandardV2_LRS", "StandardV2_GRS", "StandardV2_ZRS", "StandardV2_GZRS", "PremiumV2_LRS", "PremiumV2_ZRS")]
        string Name { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        string ResourceType { get; set; }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IRestriction> Restriction { get; set; }
        /// <summary>The SKU tier. This is based on the SKU name.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard", "Premium")]
        string Tier { get; set; }

    }
}