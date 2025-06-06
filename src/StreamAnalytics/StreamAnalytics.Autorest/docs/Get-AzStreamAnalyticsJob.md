---
external help file:
Module Name: Az.StreamAnalytics
online version: https://learn.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsjob
schema: 2.0.0
---

# Get-AzStreamAnalyticsJob

## SYNOPSIS
Gets details about the specified streaming job.

## SYNTAX

### List1 (Default)
```
Get-AzStreamAnalyticsJob [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStreamAnalyticsJob -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStreamAnalyticsJob -InputObject <IStreamAnalyticsIdentity> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStreamAnalyticsJob -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets details about the specified streaming job.

## EXAMPLES

### Example 1: Get information about all jobs in a subscription
```powershell
Get-AzStreamAnalyticsJob
```

```output
Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

This command returns information about all the Stream Analytics jobs in the Azure subscription.

### Example 2: Get information about all jobs in a resource group
```powershell
Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test
```

```output
Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs
West Central US sajob-01-pwsh Microsoft.StreamAnalytics/streamingjobs
```

This command returns information about all the Stream Analytics jobs in the resource group.

### Example 3: Get information about a specific job in a resource group
```powershell
Get-AzStreamAnalyticsJob -ResourceGroupName azure-rg-test -Name sajob-02-pwsh
```

```output
Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

This command returns information about the Stream Analytics job StreamingJob in the resource group.

### Example 4: Get information about a specific job in a resource group by pipeline
```powershell
New-AzStreamAnalyticsJob -ResourceGroupName lucas-rg-test -Name sajob-02-pwsh -Location westcentralus -SkuName Standard | Get-AzStreamAnalyticsJob 
```

```output
Location        Name          Type                                    ETag
--------        ----          ----                                    ----
West Central US sajob-02-pwsh Microsoft.StreamAnalytics/streamingjobs ac26a506-a4cb-4a7d-9ec8-c3149b8589bd
```

This command returns information about the Stream Analytics job StreamingJob in the resource group.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Expand
The $expand OData query parameter.
This is a comma-separated list of additional streaming job properties to include in the response, beyond the default set returned when this parameter is absent.
The default set is all streaming job properties other than 'inputs', 'transformation', 'outputs', and 'functions'.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the streaming job.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob

## NOTES

## RELATED LINKS

