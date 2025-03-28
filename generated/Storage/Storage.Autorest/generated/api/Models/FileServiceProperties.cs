// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>The properties of File services in storage account.</summary>
    public partial class FileServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Resource();

        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRule> CorCorsRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).CorCorsRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).CorCorsRule = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="FileServiceProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1 _fileServiceProperty;

        /// <summary>The properties of File services in storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1 FileServiceProperty { get => (this._fileServiceProperty = this._fileServiceProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.FileServiceProperties1()); set => this._fileServiceProperty = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for FileServiceProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1 Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.FileServiceProperty { get => (this._fileServiceProperty = this._fileServiceProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.FileServiceProperties1()); set { {_fileServiceProperty = value;} } }

        /// <summary>Internal Acessors for FileServicePropertyCor</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRules Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.FileServicePropertyCor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).Cor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).Cor = value; }

        /// <summary>Internal Acessors for FileServicePropertyProtocolSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IProtocolSettings Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.FileServicePropertyProtocolSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ProtocolSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ProtocolSetting = value; }

        /// <summary>Internal Acessors for FileServicePropertyShareDeleteRetentionPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IDeleteRetentionPolicy Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.FileServicePropertyShareDeleteRetentionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicy = value; }

        /// <summary>Internal Acessors for ProtocolSettingSmb</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISmbSetting Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.ProtocolSettingSmb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ProtocolSettingSmb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ProtocolSettingSmb = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISku Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for SmbMultichannel</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IMultichannel Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServicePropertiesInternal.SmbMultichannel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbMultichannel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbMultichannel = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Type = value; }

        /// <summary>Indicates whether multichannel is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public bool? MultichannelEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).MultichannelEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).MultichannelEnabled = value ?? default(bool); }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Name; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>
        /// This property when set to true allows deletion of the soft deleted blob versions and snapshots. This property cannot be
        /// used blob restore policy. This property only applies to blob service and does not apply to containers or file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public bool? ShareDeleteRetentionPolicyAllowPermanentDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyAllowPermanentDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyAllowPermanentDelete = value ?? default(bool); }

        /// <summary>
        /// Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public int? ShareDeleteRetentionPolicyDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyDay = value ?? default(int); }

        /// <summary>Indicates whether DeleteRetentionPolicy is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public bool? ShareDeleteRetentionPolicyEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).ShareDeleteRetentionPolicyEnabled = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISku _sku;

        /// <summary>Sku name and tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Sku()); }

        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInternal)Sku).Name = value ?? null; }

        /// <summary>The SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuInternal)Sku).Tier; }

        /// <summary>
        /// SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter
        /// ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SmbAuthenticationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbAuthenticationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbAuthenticationMethod = value ?? null; }

        /// <summary>
        /// SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as
        /// a string with delimiter ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SmbChannelEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbChannelEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbChannelEncryption = value ?? null; }

        /// <summary>
        /// Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with
        /// delimiter ';'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SmbKerberosTicketEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbKerberosTicketEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbKerberosTicketEncryption = value ?? null; }

        /// <summary>
        /// SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with
        /// delimiter ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inlined)]
        public string SmbVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1Internal)FileServiceProperty).SmbVersion = value ?? null; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="FileServiceProperties" /> instance.</summary>
        public FileServiceProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The properties of File services in storage account.
    public partial interface IFileServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResource
    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The List of CORS rules. You can include up to five CorsRule elements in the request. ",
        SerializedName = @"corsRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRule) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRule> CorCorsRule { get; set; }
        /// <summary>Indicates whether multichannel is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether multichannel is enabled",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? MultichannelEnabled { get; set; }
        /// <summary>
        /// This property when set to true allows deletion of the soft deleted blob versions and snapshots. This property cannot be
        /// used blob restore policy. This property only applies to blob service and does not apply to containers or file share.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This property when set to true allows deletion of the soft deleted blob versions and snapshots. This property cannot be used blob restore policy. This property only applies to blob service and does not apply to containers or file share.",
        SerializedName = @"allowPermanentDelete",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ShareDeleteRetentionPolicyAllowPermanentDelete { get; set; }
        /// <summary>
        /// Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum value can be 365.",
        SerializedName = @"days",
        PossibleTypes = new [] { typeof(int) })]
        int? ShareDeleteRetentionPolicyDay { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether DeleteRetentionPolicy is enabled.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ShareDeleteRetentionPolicyEnabled { get; set; }
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard_LRS", "Standard_GRS", "Standard_RAGRS", "Standard_ZRS", "Premium_LRS", "Premium_ZRS", "Standard_GZRS", "Standard_RAGZRS", "StandardV2_LRS", "StandardV2_GRS", "StandardV2_ZRS", "StandardV2_GZRS", "PremiumV2_LRS", "PremiumV2_ZRS")]
        string SkuName { get;  }
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
        string SkuTier { get;  }
        /// <summary>
        /// SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter
        /// ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter ';'.",
        SerializedName = @"authenticationMethods",
        PossibleTypes = new [] { typeof(string) })]
        string SmbAuthenticationMethod { get; set; }
        /// <summary>
        /// SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as
        /// a string with delimiter ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as a string with delimiter ';'.",
        SerializedName = @"channelEncryption",
        PossibleTypes = new [] { typeof(string) })]
        string SmbChannelEncryption { get; set; }
        /// <summary>
        /// Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with
        /// delimiter ';'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with delimiter ';'",
        SerializedName = @"kerberosTicketEncryption",
        PossibleTypes = new [] { typeof(string) })]
        string SmbKerberosTicketEncryption { get; set; }
        /// <summary>
        /// SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with
        /// delimiter ';'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with delimiter ';'.",
        SerializedName = @"versions",
        PossibleTypes = new [] { typeof(string) })]
        string SmbVersion { get; set; }

    }
    /// The properties of File services in storage account.
    internal partial interface IFileServicePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IResourceInternal
    {
        /// <summary>
        /// The List of CORS rules. You can include up to five CorsRule elements in the request.
        /// </summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRule> CorCorsRule { get; set; }
        /// <summary>The properties of File services in storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IFileServiceProperties1 FileServiceProperty { get; set; }
        /// <summary>
        /// Specifies CORS rules for the File service. You can include up to five CorsRule elements in the request. If no CorsRule
        /// elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the File service.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ICorsRules FileServicePropertyCor { get; set; }
        /// <summary>Protocol settings for file service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IProtocolSettings FileServicePropertyProtocolSetting { get; set; }
        /// <summary>The file service properties for share soft delete.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IDeleteRetentionPolicy FileServicePropertyShareDeleteRetentionPolicy { get; set; }
        /// <summary>Indicates whether multichannel is enabled</summary>
        bool? MultichannelEnabled { get; set; }
        /// <summary>Setting for SMB protocol</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISmbSetting ProtocolSettingSmb { get; set; }
        /// <summary>
        /// This property when set to true allows deletion of the soft deleted blob versions and snapshots. This property cannot be
        /// used blob restore policy. This property only applies to blob service and does not apply to containers or file share.
        /// </summary>
        bool? ShareDeleteRetentionPolicyAllowPermanentDelete { get; set; }
        /// <summary>
        /// Indicates the number of days that the deleted item should be retained. The minimum specified value can be 1 and the maximum
        /// value can be 365.
        /// </summary>
        int? ShareDeleteRetentionPolicyDay { get; set; }
        /// <summary>Indicates whether DeleteRetentionPolicy is enabled.</summary>
        bool? ShareDeleteRetentionPolicyEnabled { get; set; }
        /// <summary>Sku name and tier.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISku Sku { get; set; }
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard_LRS", "Standard_GRS", "Standard_RAGRS", "Standard_ZRS", "Premium_LRS", "Premium_ZRS", "Standard_GZRS", "Standard_RAGZRS", "StandardV2_LRS", "StandardV2_GRS", "StandardV2_ZRS", "StandardV2_GZRS", "PremiumV2_LRS", "PremiumV2_ZRS")]
        string SkuName { get; set; }
        /// <summary>The SKU tier. This is based on the SKU name.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Storage.PSArgumentCompleterAttribute("Standard", "Premium")]
        string SkuTier { get; set; }
        /// <summary>
        /// SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos. Should be passed as a string with delimiter
        /// ';'.
        /// </summary>
        string SmbAuthenticationMethod { get; set; }
        /// <summary>
        /// SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM. Should be passed as
        /// a string with delimiter ';'.
        /// </summary>
        string SmbChannelEncryption { get; set; }
        /// <summary>
        /// Kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256. Should be passed as a string with
        /// delimiter ';'
        /// </summary>
        string SmbKerberosTicketEncryption { get; set; }
        /// <summary>Multichannel setting. Applies to Premium FileStorage only.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IMultichannel SmbMultichannel { get; set; }
        /// <summary>
        /// SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1. Should be passed as a string with
        /// delimiter ';'.
        /// </summary>
        string SmbVersion { get; set; }

    }
}