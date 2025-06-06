// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.PowerShell;

    /// <summary>The peering service prefix class.</summary>
    [System.ComponentModel.TypeConverter(typeof(PeeringServicePrefixTypeConverter))]
    public partial class PeeringServicePrefix
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefix" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefix DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PeeringServicePrefix(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefix" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefix DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PeeringServicePrefix(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PeeringServicePrefix" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PeeringServicePrefix" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefix FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PeeringServicePrefix(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefixPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("LearnedType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).LearnedType = (string) content.GetValueForProperty("LearnedType",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).LearnedType, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("Prefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Prefix = (string) content.GetValueForProperty("Prefix",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Prefix, global::System.Convert.ToString);
            }
            if (content.Contains("PrefixValidationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).PrefixValidationState = (string) content.GetValueForProperty("PrefixValidationState",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).PrefixValidationState, global::System.Convert.ToString);
            }
            if (content.Contains("ErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("Event"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Event = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixEvent>) content.GetValueForProperty("Event",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Event, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefixEventTypeConverter.ConvertFrom));
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Key, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefix"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PeeringServicePrefix(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefixPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("LearnedType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).LearnedType = (string) content.GetValueForProperty("LearnedType",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).LearnedType, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("Prefix"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Prefix = (string) content.GetValueForProperty("Prefix",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Prefix, global::System.Convert.ToString);
            }
            if (content.Contains("PrefixValidationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).PrefixValidationState = (string) content.GetValueForProperty("PrefixValidationState",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).PrefixValidationState, global::System.Convert.ToString);
            }
            if (content.Contains("ErrorMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).ErrorMessage, global::System.Convert.ToString);
            }
            if (content.Contains("Event"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Event = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixEvent>) content.GetValueForProperty("Event",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Event, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PeeringServicePrefixEventTypeConverter.ConvertFrom));
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringServicePrefixInternal)this).Key, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Peering.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The peering service prefix class.
    [System.ComponentModel.TypeConverter(typeof(PeeringServicePrefixTypeConverter))]
    public partial interface IPeeringServicePrefix

    {

    }
}