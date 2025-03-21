---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdscalingplan
schema: 2.0.0
---

# Update-AzWvdScalingPlan

## SYNOPSIS
update a scaling plan.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdScalingPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Description <String>] [-ExclusionTag <String>] [-FriendlyName <String>]
 [-HostPoolReference <IScalingHostPoolReference[]>] [-Schedule <IScalingSchedule[]>] [-Tag <Hashtable>]
 [-TimeZone <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzWvdScalingPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzWvdScalingPlan -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdScalingPlan -InputObject <IDesktopVirtualizationIdentity> [-Description <String>]
 [-ExclusionTag <String>] [-FriendlyName <String>] [-HostPoolReference <IScalingHostPoolReference[]>]
 [-Schedule <IScalingSchedule[]>] [-Tag <Hashtable>] [-TimeZone <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
update a scaling plan.

## EXAMPLES

### Example 1: Update a Windows Virtual Desktop Scaling Plan by name
```powershell
Update-AzWvdScalingPlan `
            -ResourceGroupName ResourceGroupName `
            -Name 'ScalingPlan1' `
            -Description 'Description' `
            -FriendlyName 'Friendly Name' `
            -TimeZone 'Pacific Standard Time' `
            -Schedule @(
                @{
                    'Name'                           = 'Work Week';
                    'DaysOfWeek'                     = @('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday');
                    'RampUpStartTime'                = @{
                                                            'Hour' = 7
                                                            'Minute' = 0
                                                        };
                    'RampUpLoadBalancingAlgorithm'   = 'BreadthFirst';
                    'RampUpMinimumHostsPct'          = 20;
                    'RampUpCapacityThresholdPct'     = 20;

                    'PeakStartTime'                  = @{
                                                            'Hour' = 9
                                                            'Minute' = 30
                                                        };
                    'PeakLoadBalancingAlgorithm'     = 'DepthFirst';

                    'RampDownStartTime'              = @{
                                                            'Hour' = 16
                                                            'Minute' = 15
                                                        };
                    'RampDownLoadBalancingAlgorithm' = 'BreadthFirst';
                    'RampDownMinimumHostsPct'        = 20;
                    'RampDownCapacityThresholdPct'   = 20;
                    'RampDownForceLogoffUser'       = $true;
                    'RampDownWaitTimeMinute'        = 30;
                    'RampDownNotificationMessage'    = 'Log out now, please.';
                    'RampDownStopHostsWhen'          = 'ZeroSessions';

                    'OffPeakStartTime'               = @{
                                                            'Hour' = 18
                                                            'Minute' = 0
                                                        };
                    'OffPeakLoadBalancingAlgorithm'  = 'DepthFirst';
                }
            ) `
            -HostPoolReference @(
                @{
                    'HostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName1';
                    'ScalingPlanEnabled' = $false;
                },
                @{
                    'HostPoolArmPath' = '/subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.DesktopVirtualization/hostPools/HostPoolName2';
                    'ScalingPlanEnabled' = $false;
                }

            )
```

```output
Location      Name         Type
--------      ----         ----
westcentralus scalingPlan1 Microsoft.DesktopVirtualization/scalingplans
```

This command updates a Windows Virtual Desktop Scaling Plan in a Resource Group.

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

### -Description
Description of scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExclusionTag
Exclusion tag for scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
User friendly name of scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolReference
List of ScalingHostPoolReference definitions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingHostPoolReference[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: ScalingPlanName

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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schedule
List of ScalingSchedule definitions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingSchedule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
tags to be updated

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
Timezone of the scaling plan.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IScalingPlan

## NOTES

## RELATED LINKS
