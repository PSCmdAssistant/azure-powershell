---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/invoke-azkustodataconnectionvalidation
schema: 2.0.0
---

# Invoke-AzKustoDataConnectionValidation

## SYNOPSIS
Checks that the data connection parameters are valid.

## SYNTAX

### DataExpandedEventHub (Default)
```
Invoke-AzKustoDataConnectionValidation -ClusterName <String> -DatabaseName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Kind <Kind> -DataConnectionName <String> -ConsumerGroup <String>
 -Location <String> -EventHubResourceId <String> [-DataFormat <String>] [-EventSystemProperty <String[]>]
 [-MappingRuleName <String>] [-TableName <String>] [-Compression <Compression>]
 [-ManagedIdentityResourceId <String>] [-DatabaseRouting <DatabaseRouting>] [-RetrievalStartDate <DateTime>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DataExpandedEventGrid
```
Invoke-AzKustoDataConnectionValidation -ClusterName <String> -DatabaseName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Kind <Kind> -DataConnectionName <String> -ConsumerGroup <String>
 -Location <String> -EventHubResourceId <String> [-DataFormat <String>] [-MappingRuleName <String>]
 [-TableName <String>] [-ManagedIdentityResourceId <String>] [-DatabaseRouting <DatabaseRouting>]
 -StorageAccountResourceId <String> [-EventGridResourceId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DataExpandedIotHub
```
Invoke-AzKustoDataConnectionValidation -ClusterName <String> -DatabaseName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Kind <Kind> -DataConnectionName <String> -ConsumerGroup <String>
 -Location <String> [-DataFormat <String>] [-EventSystemProperty <String[]>] [-MappingRuleName <String>]
 [-TableName <String>] [-DatabaseRouting <DatabaseRouting>] [-RetrievalStartDate <DateTime>]
 -IotHubResourceId <String> -SharedAccessPolicyName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DataViaIdentityExpandedEventHub
```
Invoke-AzKustoDataConnectionValidation -InputObject <IKustoIdentity> -Kind <Kind> -DataConnectionName <String>
 -ConsumerGroup <String> -Location <String> -EventHubResourceId <String> [-DataFormat <String>]
 [-EventSystemProperty <String[]>] [-MappingRuleName <String>] [-TableName <String>]
 [-Compression <Compression>] [-ManagedIdentityResourceId <String>] [-DatabaseRouting <DatabaseRouting>]
 [-RetrievalStartDate <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DataViaIdentityExpandedEventGrid
```
Invoke-AzKustoDataConnectionValidation -InputObject <IKustoIdentity> -Kind <Kind> -DataConnectionName <String>
 -ConsumerGroup <String> -Location <String> -EventHubResourceId <String> [-DataFormat <String>]
 [-MappingRuleName <String>] [-TableName <String>] [-ManagedIdentityResourceId <String>]
 [-DatabaseRouting <DatabaseRouting>] -StorageAccountResourceId <String> [-EventGridResourceId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DataViaIdentityExpandedIotHub
```
Invoke-AzKustoDataConnectionValidation -InputObject <IKustoIdentity> -Kind <Kind> -DataConnectionName <String>
 -ConsumerGroup <String> -Location <String> [-DataFormat <String>] [-EventSystemProperty <String[]>]
 [-MappingRuleName <String>] [-TableName <String>] [-DatabaseRouting <DatabaseRouting>]
 [-RetrievalStartDate <DateTime>] -IotHubResourceId <String> -SharedAccessPolicyName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpandedEventGrid
```
Invoke-AzKustoDataConnectionValidation -Kind <Kind> -DataConnectionName <String> -ConsumerGroup <String>
 -Location <String> [-DataFormat <String>] [-MappingRuleName <String>] [-TableName <String>]
 [-BlobStorageEventType <BlobStorageEventType>] [-IgnoreFirstRecord] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpandedEventGrid
```
Invoke-AzKustoDataConnectionValidation -Kind <Kind> -DataConnectionName <String> -ConsumerGroup <String>
 -Location <String> [-DataFormat <String>] [-MappingRuleName <String>] [-TableName <String>]
 [-BlobStorageEventType <BlobStorageEventType>] [-IgnoreFirstRecord] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks that the data connection parameters are valid.

## EXAMPLES

### Example 1: Validate EventHub data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 2: Validate EventGrid data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -StorageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 3: Validate IotHub data connection parameters
```powershell
Invoke-AzKustoDataConnectionValidation -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 4: Validate EventHub data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" 
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myeventhubdc" -Location "East US" -Kind "EventHub" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -Compression "None" -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventHub data connection named "myeventhubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 5: Validate EventGrid data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase"
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myeventgriddc" -Location "East US" -Kind "EventGrid" -EventHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.EventHub/namespaces/myeventhubns/eventhubs/myeventhub" -StorageAccountResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Storage/storageAccounts/mystorage" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates EventGrid data connection named "myeventgriddc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

### Example 6: Validate IotHub data connection parameters via identity
```powershell
$database = Get-AzKustoDatabase -ResourceGroupName "testrg" -ClusterName "testnewkustocluster" -DatabaseName "mykustodatabase" 
Invoke-AzKustoDataConnectionValidation -InputObject $database -DataConnectionName "myiothubdc" -Location "East US" -Kind "IotHub" -IotHubResourceId "/subscriptions/$subscriptionId/resourcegroups/testrg/providers/Microsoft.Devices/IotHubs/myiothub" -SharedAccessPolicyName "myiothubpolicy" -DataFormat "MULTIJSON" -ConsumerGroup 'Default' -TableName "Events" -MappingRuleName "NewEventsMapping"
```

```output
ErrorMessage
------------
event hub resource id and consumer group tuple provided are already used
```

The above command validates IotHub data connection named "myiothubdc" for the database "mykustodatabase" in the cluster "testnewkustocluster".

## PARAMETERS

### -BlobStorageEventType
The name of blob storage event type to process.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType
Parameter Sets: UpdateExpandedEventGrid, UpdateViaIdentityExpandedEventGrid
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Compression
The event hub messages compression type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression
Parameter Sets: DataExpandedEventHub, DataViaIdentityExpandedEventHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConsumerGroup
The event/iot hub consumer group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the database in the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseRouting
Indication for database routing information from the data connection, by default only database routing information is allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabaseRouting
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataExpandedIotHub, DataViaIdentityExpandedEventHub, DataViaIdentityExpandedEventGrid, DataViaIdentityExpandedIotHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataConnectionName
The name of the data connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataFormat
The data format of the message.
Optionally the data format can be added to each message.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventGridResourceId
The resource ID of the event grid that is subscribed to the storage account events.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventGrid, DataViaIdentityExpandedEventGrid
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubResourceId
The resource ID of the event hub to be used to create a data connection / event grid is configured to send events.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataViaIdentityExpandedEventHub, DataViaIdentityExpandedEventGrid
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSystemProperty
System properties of the event/iot hub.

```yaml
Type: System.String[]
Parameter Sets: DataExpandedEventHub, DataExpandedIotHub, DataViaIdentityExpandedEventHub, DataViaIdentityExpandedIotHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IgnoreFirstRecord
If set to true, indicates that ingestion should ignore the first record of every file.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpandedEventGrid, UpdateViaIdentityExpandedEventGrid
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: DataViaIdentityExpandedEventHub, DataViaIdentityExpandedEventGrid, DataViaIdentityExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IotHubResourceId
The resource ID of the Iot hub to be used to create a data connection.

```yaml
Type: System.String
Parameter Sets: DataExpandedIotHub, DataViaIdentityExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of the endpoint for the data connection

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedIdentityResourceId
The resource ID of a managed identity (system or user assigned) to be used to authenticate with external resources.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataViaIdentityExpandedEventHub, DataViaIdentityExpandedEventGrid
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MappingRuleName
The mapping rule to be used to ingest the data.
Optionally the mapping information can be added to each message.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group containing the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetrievalStartDate
When defined, the data connection retrieves existing Event hub events created since the Retrieval start date.
It can only retrieve events retained by the Event hub, based on its retention period.

```yaml
Type: System.DateTime
Parameter Sets: DataExpandedEventHub, DataExpandedIotHub, DataViaIdentityExpandedEventHub, DataViaIdentityExpandedIotHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedAccessPolicyName
The name of the share access policy.

```yaml
Type: System.String
Parameter Sets: DataExpandedIotHub, DataViaIdentityExpandedIotHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
The resource ID of the storage account where the data resides.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventGrid, DataViaIdentityExpandedEventGrid
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: DataExpandedEventHub, DataExpandedEventGrid, DataExpandedIotHub
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableName
The table where the data should be ingested.
Optionally the table information can be added to each message.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDataConnectionValidationResult

## NOTES

## RELATED LINKS
