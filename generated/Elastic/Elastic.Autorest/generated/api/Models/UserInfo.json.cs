// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Extensions;

    /// <summary>User Information to be passed to partners.</summary>
    public partial class UserInfo
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IUserInfo.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IUserInfo.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IUserInfo FromJson(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject json ? new UserInfo(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="UserInfo" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="UserInfo" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._companyInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode) this._companyInfo.ToJson(null,serializationMode) : null, "companyInfo" ,container.Add );
            AddIf( null != (((object)this._firstName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString(this._firstName.ToString()) : null, "firstName" ,container.Add );
            AddIf( null != (((object)this._lastName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString(this._lastName.ToString()) : null, "lastName" ,container.Add );
            AddIf( null != (((object)this._companyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString(this._companyName.ToString()) : null, "companyName" ,container.Add );
            AddIf( null != (((object)this._emailAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString(this._emailAddress.ToString()) : null, "emailAddress" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject into a new instance of <see cref="UserInfo" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal UserInfo(Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_companyInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonObject>("companyInfo"), out var __jsonCompanyInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.CompanyInfo.FromJson(__jsonCompanyInfo) : _companyInfo;}
            {_firstName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString>("firstName"), out var __jsonFirstName) ? (string)__jsonFirstName : (string)_firstName;}
            {_lastName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString>("lastName"), out var __jsonLastName) ? (string)__jsonLastName : (string)_lastName;}
            {_companyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString>("companyName"), out var __jsonCompanyName) ? (string)__jsonCompanyName : (string)_companyName;}
            {_emailAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Elastic.Runtime.Json.JsonString>("emailAddress"), out var __jsonEmailAddress) ? (string)__jsonEmailAddress : (string)_emailAddress;}
            AfterFromJson(json);
        }
    }
}