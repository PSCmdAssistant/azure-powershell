// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.PowerShell;

    /// <summary>Properties under the marketplace gallery image resource</summary>
    [System.ComponentModel.TypeConverter(typeof(MarketplaceGalleryImagePropertiesTypeConverter))]
    public partial class MarketplaceGalleryImageProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MarketplaceGalleryImageProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MarketplaceGalleryImageProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MarketplaceGalleryImageProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="MarketplaceGalleryImageProperties" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MarketplaceGalleryImageProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identifier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageIdentifierTypeConverter.ConvertFrom);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersion) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("ContainerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ContainerId = (string) content.GetValueForProperty("ContainerId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ContainerId, global::System.Convert.ToString);
            }
            if (content.Contains("OSType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSType, global::System.Convert.ToString);
            }
            if (content.Contains("CloudInitDataSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).CloudInitDataSource = (string) content.GetValueForProperty("CloudInitDataSource",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).CloudInitDataSource, global::System.Convert.ToString);
            }
            if (content.Contains("HyperVGeneration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).HyperVGeneration = (string) content.GetValueForProperty("HyperVGeneration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).HyperVGeneration, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierPublisher"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierPublisher = (string) content.GetValueForProperty("IdentifierPublisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierPublisher, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierOffer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierOffer = (string) content.GetValueForProperty("IdentifierOffer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierOffer, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierSku = (string) content.GetValueForProperty("IdentifierSku",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierSku, global::System.Convert.ToString);
            }
            if (content.Contains("VersionProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionProperty = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersionProperties) content.GetValueForProperty("VersionProperty",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionProperty, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("VersionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionName = (string) content.GetValueForProperty("VersionName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionName, global::System.Convert.ToString);
            }
            if (content.Contains("StatusProvisioningStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusProvisioningStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusDownloadStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusDownloadStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatusDownloadStatus) content.GetValueForProperty("StatusDownloadStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusDownloadStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusDownloadStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("StatusErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("StatusProgressPercentage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProgressPercentage = (long?) content.GetValueForProperty("StatusProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProgressPercentage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ProvisioningStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatus = (string) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatus, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersionStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionStorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningStatusOperationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            }
            if (content.Contains("DownloadStatusDownloadSizeInMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).DownloadStatusDownloadSizeInMb = (long?) content.GetValueForProperty("DownloadStatusDownloadSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).DownloadStatusDownloadSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageProfileOSDiskImage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfileOSDiskImage = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryOSDiskImage) content.GetValueForProperty("StorageProfileOSDiskImage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfileOSDiskImage, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryOSDiskImageTypeConverter.ConvertFrom);
            }
            if (content.Contains("OSDiskImageSizeInMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSDiskImageSizeInMb = (long?) content.GetValueForProperty("OSDiskImageSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSDiskImageSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MarketplaceGalleryImageProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identifier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Identifier = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageIdentifier) content.GetValueForProperty("Identifier",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Identifier, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageIdentifierTypeConverter.ConvertFrom);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersion) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatus) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("ContainerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ContainerId = (string) content.GetValueForProperty("ContainerId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ContainerId, global::System.Convert.ToString);
            }
            if (content.Contains("OSType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSType, global::System.Convert.ToString);
            }
            if (content.Contains("CloudInitDataSource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).CloudInitDataSource = (string) content.GetValueForProperty("CloudInitDataSource",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).CloudInitDataSource, global::System.Convert.ToString);
            }
            if (content.Contains("HyperVGeneration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).HyperVGeneration = (string) content.GetValueForProperty("HyperVGeneration",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).HyperVGeneration, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierPublisher"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierPublisher = (string) content.GetValueForProperty("IdentifierPublisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierPublisher, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierOffer"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierOffer = (string) content.GetValueForProperty("IdentifierOffer",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierOffer, global::System.Convert.ToString);
            }
            if (content.Contains("IdentifierSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierSku = (string) content.GetValueForProperty("IdentifierSku",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).IdentifierSku, global::System.Convert.ToString);
            }
            if (content.Contains("VersionProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionProperty = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersionProperties) content.GetValueForProperty("VersionProperty",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionProperty, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("VersionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionName = (string) content.GetValueForProperty("VersionName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).VersionName, global::System.Convert.ToString);
            }
            if (content.Contains("StatusProvisioningStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProvisioningStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatusProvisioningStatus) content.GetValueForProperty("StatusProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProvisioningStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusProvisioningStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusDownloadStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusDownloadStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImageStatusDownloadStatus) content.GetValueForProperty("StatusDownloadStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusDownloadStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.MarketplaceGalleryImageStatusDownloadStatusTypeConverter.ConvertFrom);
            }
            if (content.Contains("StatusErrorCode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorCode = (string) content.GetValueForProperty("StatusErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorCode, global::System.Convert.ToString);
            }
            if (content.Contains("StatusErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorMessage = (string) content.GetValueForProperty("StatusErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("StatusProgressPercentage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProgressPercentage = (long?) content.GetValueForProperty("StatusProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StatusProgressPercentage, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("ProvisioningStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatus = (string) content.GetValueForProperty("ProvisioningStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatus, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImageVersionStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryImageVersionStorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningStatusOperationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatusOperationId = (string) content.GetValueForProperty("ProvisioningStatusOperationId",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).ProvisioningStatusOperationId, global::System.Convert.ToString);
            }
            if (content.Contains("DownloadStatusDownloadSizeInMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).DownloadStatusDownloadSizeInMb = (long?) content.GetValueForProperty("DownloadStatusDownloadSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).DownloadStatusDownloadSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("StorageProfileOSDiskImage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfileOSDiskImage = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryOSDiskImage) content.GetValueForProperty("StorageProfileOSDiskImage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).StorageProfileOSDiskImage, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.GalleryOSDiskImageTypeConverter.ConvertFrom);
            }
            if (content.Contains("OSDiskImageSizeInMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSDiskImageSizeInMb = (long?) content.GetValueForProperty("OSDiskImageSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImagePropertiesInternal)this).OSDiskImageSizeInMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Properties under the marketplace gallery image resource
    [System.ComponentModel.TypeConverter(typeof(MarketplaceGalleryImagePropertiesTypeConverter))]
    public partial interface IMarketplaceGalleryImageProperties

    {

    }
}