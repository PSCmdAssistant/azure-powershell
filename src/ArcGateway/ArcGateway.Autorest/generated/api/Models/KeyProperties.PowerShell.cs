// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.PowerShell;

    /// <summary>Public key information for client authentication</summary>
    [System.ComponentModel.TypeConverter(typeof(KeyPropertiesTypeConverter))]
    public partial class KeyProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new KeyProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new KeyProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="KeyProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="KeyProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal KeyProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ClientPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyDetails) content.GetValueForProperty("ClientPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKey, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CandidatePublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKey = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyDetails) content.GetValueForProperty("CandidatePublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKey, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClientPublicKeyPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyPublicKey = (string) content.GetValueForProperty("ClientPublicKeyPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyPublicKey, global::System.Convert.ToString);
            }
            if (content.Contains("ClientPublicKeyNotAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyNotAfter = (global::System.DateTime?) content.GetValueForProperty("ClientPublicKeyNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ClientPublicKeyRenewAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyRenewAfter = (global::System.DateTime?) content.GetValueForProperty("ClientPublicKeyRenewAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyRenewAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CandidatePublicKeyPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyPublicKey = (string) content.GetValueForProperty("CandidatePublicKeyPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyPublicKey, global::System.Convert.ToString);
            }
            if (content.Contains("CandidatePublicKeyNotAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyNotAfter = (global::System.DateTime?) content.GetValueForProperty("CandidatePublicKeyNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CandidatePublicKeyRenewAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyRenewAfter = (global::System.DateTime?) content.GetValueForProperty("CandidatePublicKeyRenewAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyRenewAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal KeyProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ClientPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyDetails) content.GetValueForProperty("ClientPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKey, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("CandidatePublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKey = (Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyDetails) content.GetValueForProperty("CandidatePublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKey, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.KeyDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClientPublicKeyPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyPublicKey = (string) content.GetValueForProperty("ClientPublicKeyPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyPublicKey, global::System.Convert.ToString);
            }
            if (content.Contains("ClientPublicKeyNotAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyNotAfter = (global::System.DateTime?) content.GetValueForProperty("ClientPublicKeyNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("ClientPublicKeyRenewAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyRenewAfter = (global::System.DateTime?) content.GetValueForProperty("ClientPublicKeyRenewAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).ClientPublicKeyRenewAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CandidatePublicKeyPublicKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyPublicKey = (string) content.GetValueForProperty("CandidatePublicKeyPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyPublicKey, global::System.Convert.ToString);
            }
            if (content.Contains("CandidatePublicKeyNotAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyNotAfter = (global::System.DateTime?) content.GetValueForProperty("CandidatePublicKeyNotAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyNotAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CandidatePublicKeyRenewAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyRenewAfter = (global::System.DateTime?) content.GetValueForProperty("CandidatePublicKeyRenewAfter",((Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Models.IKeyPropertiesInternal)this).CandidatePublicKeyRenewAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ArcGateway.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Public key information for client authentication
    [System.ComponentModel.TypeConverter(typeof(KeyPropertiesTypeConverter))]
    public partial interface IKeyProperties

    {

    }
}