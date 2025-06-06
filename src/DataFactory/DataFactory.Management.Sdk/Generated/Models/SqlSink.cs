// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// A copy activity SQL sink.
    /// </summary>
    [Newtonsoft.Json.JsonObject("SqlSink")]
    public partial class SqlSink : CopySink
    {
        /// <summary>
        /// Initializes a new instance of the SqlSink class.
        /// </summary>
        public SqlSink()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SqlSink class.
        /// </summary>

        /// <param name="additionalProperties">A copy activity sink.
        /// </param>

        /// <param name="writeBatchSize">Write batch size. Type: integer (or Expression with resultType integer),
        /// minimum: 0.
        /// </param>

        /// <param name="writeBatchTimeout">Write batch timeout. Type: string (or Expression with resultType string),
        /// pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])).
        /// </param>

        /// <param name="sinkRetryCount">Sink retry count. Type: integer (or Expression with resultType integer).
        /// </param>

        /// <param name="sinkRetryWait">Sink retry wait. Type: string (or Expression with resultType string),
        /// pattern: ((\d+)\.)?(\d\d):(60|([0-5][0-9])):(60|([0-5][0-9])).
        /// </param>

        /// <param name="maxConcurrentConnections">The maximum concurrent connection count for the sink data store. Type:
        /// integer (or Expression with resultType integer).
        /// </param>

        /// <param name="disableMetricsCollection">If true, disable data store metrics collection. Default is false. Type:
        /// boolean (or Expression with resultType boolean).
        /// </param>

        /// <param name="sqlWriterStoredProcedureName">SQL writer stored procedure name. Type: string (or Expression with
        /// resultType string).
        /// </param>

        /// <param name="sqlWriterTableType">SQL writer table type. Type: string (or Expression with resultType string).
        /// </param>

        /// <param name="preCopyScript">SQL pre-copy script. Type: string (or Expression with resultType string).
        /// </param>

        /// <param name="storedProcedureParameters">SQL stored procedure parameters.
        /// </param>

        /// <param name="storedProcedureTableTypeParameterName">The stored procedure parameter name of the table type. Type: string (or
        /// Expression with resultType string).
        /// </param>

        /// <param name="tableOption">The option to handle sink table, such as autoCreate. For now only
        /// &#39;autoCreate&#39; value is supported. Type: string (or Expression with
        /// resultType string).
        /// </param>

        /// <param name="sqlWriterUseTableLock">Whether to use table lock during bulk copy. Type: boolean (or Expression
        /// with resultType boolean).
        /// </param>

        /// <param name="writeBehavior">Write behavior when copying data into sql. Type: string (or Expression with
        /// resultType string).
        /// </param>

        /// <param name="upsertSettings">SQL upsert settings.
        /// </param>
        public SqlSink(System.Collections.Generic.IDictionary<string, object> additionalProperties = default(System.Collections.Generic.IDictionary<string, object>), object writeBatchSize = default(object), object writeBatchTimeout = default(object), object sinkRetryCount = default(object), object sinkRetryWait = default(object), object maxConcurrentConnections = default(object), object disableMetricsCollection = default(object), object sqlWriterStoredProcedureName = default(object), object sqlWriterTableType = default(object), object preCopyScript = default(object), object storedProcedureParameters = default(object), object storedProcedureTableTypeParameterName = default(object), object tableOption = default(object), object sqlWriterUseTableLock = default(object), object writeBehavior = default(object), SqlUpsertSettings upsertSettings = default(SqlUpsertSettings))

        : base(additionalProperties, writeBatchSize, writeBatchTimeout, sinkRetryCount, sinkRetryWait, maxConcurrentConnections, disableMetricsCollection)
        {
            this.SqlWriterStoredProcedureName = sqlWriterStoredProcedureName;
            this.SqlWriterTableType = sqlWriterTableType;
            this.PreCopyScript = preCopyScript;
            this.StoredProcedureParameters = storedProcedureParameters;
            this.StoredProcedureTableTypeParameterName = storedProcedureTableTypeParameterName;
            this.TableOption = tableOption;
            this.SqlWriterUseTableLock = sqlWriterUseTableLock;
            this.WriteBehavior = writeBehavior;
            this.UpsertSettings = upsertSettings;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets sQL writer stored procedure name. Type: string (or Expression
        /// with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sqlWriterStoredProcedureName")]
        public object SqlWriterStoredProcedureName {get; set; }

        /// <summary>
        /// Gets or sets sQL writer table type. Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sqlWriterTableType")]
        public object SqlWriterTableType {get; set; }

        /// <summary>
        /// Gets or sets sQL pre-copy script. Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "preCopyScript")]
        public object PreCopyScript {get; set; }

        /// <summary>
        /// Gets or sets sQL stored procedure parameters.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "storedProcedureParameters")]
        public object StoredProcedureParameters {get; set; }

        /// <summary>
        /// Gets or sets the stored procedure parameter name of the table type. Type:
        /// string (or Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "storedProcedureTableTypeParameterName")]
        public object StoredProcedureTableTypeParameterName {get; set; }

        /// <summary>
        /// Gets or sets the option to handle sink table, such as autoCreate. For now
        /// only &#39;autoCreate&#39; value is supported. Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "tableOption")]
        public object TableOption {get; set; }

        /// <summary>
        /// Gets or sets whether to use table lock during bulk copy. Type: boolean (or
        /// Expression with resultType boolean).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sqlWriterUseTableLock")]
        public object SqlWriterUseTableLock {get; set; }

        /// <summary>
        /// Gets or sets write behavior when copying data into sql. Type: string (or
        /// Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "writeBehavior")]
        public object WriteBehavior {get; set; }

        /// <summary>
        /// Gets or sets sQL upsert settings.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "upsertSettings")]
        public SqlUpsertSettings UpsertSettings {get; set; }
    }
}