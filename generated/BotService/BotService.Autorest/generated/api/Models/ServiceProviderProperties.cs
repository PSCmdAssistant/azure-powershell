// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The Object used to describe a Service Provider supported by Bot Service</summary>
    public partial class ServiceProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DevPortalUrl" /> property.</summary>
        private string _devPortalUrl;

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DevPortalUrl { get => this._devPortalUrl; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="IconUrl" /> property.</summary>
        private string _iconUrl;

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string IconUrl { get => this._iconUrl; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id for Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for DevPortalUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal.DevPortalUrl { get => this._devPortalUrl; set { {_devPortalUrl = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for IconUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal.IconUrl { get => this._iconUrl; set { {_iconUrl = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for ServiceProviderName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderPropertiesInternal.ServiceProviderName { get => this._serviceProviderName; set { {_serviceProviderName = value;} } }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderParameter> _parameter;

        /// <summary>The list of parameters for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderParameter> Parameter { get => this._parameter; set => this._parameter = value; }

        /// <summary>Backing field for <see cref="ServiceProviderName" /> property.</summary>
        private string _serviceProviderName;

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ServiceProviderName { get => this._serviceProviderName; }

        /// <summary>Creates an new <see cref="ServiceProviderProperties" /> instance.</summary>
        public ServiceProviderProperties()
        {

        }
    }
    /// The Object used to describe a Service Provider supported by Bot Service
    public partial interface IServiceProviderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"devPortalUrl",
        PossibleTypes = new [] { typeof(string) })]
        string DevPortalUrl { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"iconUrl",
        PossibleTypes = new [] { typeof(string) })]
        string IconUrl { get;  }
        /// <summary>Id for Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Id for Service Provider",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The list of parameters for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of parameters for the Service Provider",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderParameter) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderParameter> Parameter { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"serviceProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderName { get;  }

    }
    /// The Object used to describe a Service Provider supported by Bot Service
    internal partial interface IServiceProviderPropertiesInternal

    {
        /// <summary>Display Name of the Service Provider</summary>
        string DevPortalUrl { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string DisplayName { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string IconUrl { get; set; }
        /// <summary>Id for Service Provider</summary>
        string Id { get; set; }
        /// <summary>The list of parameters for the Service Provider</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IServiceProviderParameter> Parameter { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string ServiceProviderName { get; set; }

    }
}