// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Extensions;

    /// <summary>Describes the properties of a Virtual Machine Guest Agent.</summary>
    public partial class GuestAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Credentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredential _credentials;

        /// <summary>Username / Password Credentials to provision guest agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredential Credentials { get => (this._credentials = this._credentials ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.GuestCredential()); set => this._credentials = value; }

        /// <summary>Gets or sets the password to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Inlined)]
        public System.Security.SecureString CredentialsPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredentialInternal)Credentials).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredentialInternal)Credentials).Password = value ?? null; }

        /// <summary>Gets or sets username to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Inlined)]
        public string CredentialsUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredentialInternal)Credentials).Username; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredentialInternal)Credentials).Username = value ?? null; }

        /// <summary>Backing field for <see cref="CustomResourceName" /> property.</summary>
        private string _customResourceName;

        /// <summary>Gets the name of the corresponding resource in Kubernetes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string CustomResourceName { get => this._customResourceName; }

        /// <summary>Backing field for <see cref="HttpProxyConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfiguration _httpProxyConfig;

        /// <summary>HTTP Proxy configuration for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfiguration HttpProxyConfig { get => (this._httpProxyConfig = this._httpProxyConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.HttpProxyConfiguration()); set => this._httpProxyConfig = value; }

        /// <summary>Gets or sets httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Inlined)]
        public string HttpProxyConfigHttpsProxy { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfigurationInternal)HttpProxyConfig).HttpsProxy; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfigurationInternal)HttpProxyConfig).HttpsProxy = value ?? null; }

        /// <summary>Internal Acessors for Credentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredential Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.Credentials { get => (this._credentials = this._credentials ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.GuestCredential()); set { {_credentials = value;} } }

        /// <summary>Internal Acessors for CustomResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.CustomResourceName { get => this._customResourceName; set { {_customResourceName = value;} } }

        /// <summary>Internal Acessors for HttpProxyConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfiguration Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.HttpProxyConfig { get => (this._httpProxyConfig = this._httpProxyConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.HttpProxyConfiguration()); set { {_httpProxyConfig = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for Statuses</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.Statuses { get => this._statuses; set { {_statuses = value;} } }

        /// <summary>Internal Acessors for Uuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestAgentPropertiesInternal.Uuid { get => this._uuid; set { {_uuid = value;} } }

        /// <summary>Backing field for <see cref="PrivateLinkScopeResourceId" /> property.</summary>
        private string _privateLinkScopeResourceId;

        /// <summary>The resource id of the private link scope this machine is assigned to, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string PrivateLinkScopeResourceId { get => this._privateLinkScopeResourceId; set => this._privateLinkScopeResourceId = value; }

        /// <summary>Backing field for <see cref="ProvisioningAction" /> property.</summary>
        private string _provisioningAction;

        /// <summary>Gets or sets the guest agent provisioning action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string ProvisioningAction { get => this._provisioningAction; set => this._provisioningAction = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>Gets the provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Gets or sets the guest agent status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="Statuses" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> _statuses;

        /// <summary>The resource status information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Statuses { get => this._statuses; }

        /// <summary>Backing field for <see cref="Uuid" /> property.</summary>
        private string _uuid;

        /// <summary>Gets or sets a unique identifier for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PropertyOrigin.Owned)]
        public string Uuid { get => this._uuid; }

        /// <summary>Creates an new <see cref="GuestAgentProperties" /> instance.</summary>
        public GuestAgentProperties()
        {

        }
    }
    /// Describes the properties of a Virtual Machine Guest Agent.
    public partial interface IGuestAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the password to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the password to connect with the guest.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString CredentialsPassword { get; set; }
        /// <summary>Gets or sets username to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets username to connect with the guest.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string CredentialsUsername { get; set; }
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
        /// <summary>Gets or sets httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets httpsProxy url.",
        SerializedName = @"httpsProxy",
        PossibleTypes = new [] { typeof(string) })]
        string HttpProxyConfigHttpsProxy { get; set; }
        /// <summary>The resource id of the private link scope this machine is assigned to, if any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The resource id of the private link scope this machine is assigned to, if any.",
        SerializedName = @"privateLinkScopeResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkScopeResourceId { get; set; }
        /// <summary>Gets or sets the guest agent provisioning action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the guest agent provisioning action.",
        SerializedName = @"provisioningAction",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PSArgumentCompleterAttribute("install", "uninstall", "repair")]
        string ProvisioningAction { get; set; }
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
        /// <summary>Gets or sets the guest agent status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets or sets the guest agent status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
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

    }
    /// Describes the properties of a Virtual Machine Guest Agent.
    internal partial interface IGuestAgentPropertiesInternal

    {
        /// <summary>Username / Password Credentials to provision guest agent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IGuestCredential Credentials { get; set; }
        /// <summary>Gets or sets the password to connect with the guest.</summary>
        System.Security.SecureString CredentialsPassword { get; set; }
        /// <summary>Gets or sets username to connect with the guest.</summary>
        string CredentialsUsername { get; set; }
        /// <summary>Gets the name of the corresponding resource in Kubernetes.</summary>
        string CustomResourceName { get; set; }
        /// <summary>HTTP Proxy configuration for the VM.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IHttpProxyConfiguration HttpProxyConfig { get; set; }
        /// <summary>Gets or sets httpsProxy url.</summary>
        string HttpProxyConfigHttpsProxy { get; set; }
        /// <summary>The resource id of the private link scope this machine is assigned to, if any.</summary>
        string PrivateLinkScopeResourceId { get; set; }
        /// <summary>Gets or sets the guest agent provisioning action.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PSArgumentCompleterAttribute("install", "uninstall", "repair")]
        string ProvisioningAction { get; set; }
        /// <summary>Gets the provisioning state.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Provisioning", "Updating", "Deleting", "Accepted", "Created")]
        string ProvisioningState { get; set; }
        /// <summary>Gets or sets the guest agent status.</summary>
        string Status { get; set; }
        /// <summary>The resource status information.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IResourceStatus> Statuses { get; set; }
        /// <summary>Gets or sets a unique identifier for this resource.</summary>
        string Uuid { get; set; }

    }
}