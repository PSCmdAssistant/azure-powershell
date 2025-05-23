---
Module Name: Az.ContainerInstance
Module Guid: ddf74844-4a25-4263-8a5c-f27979292e4e
Download Help Link: https://learn.microsoft.com/powershell/module/az.containerinstance
Help Version: 1.0.0.0
Locale: en-US
---

# Az.ContainerInstance Module
## Description
Microsoft Azure PowerShell: ContainerInstance cmdlets

## Az.ContainerInstance Cmdlets
### [Add-AzContainerInstanceOutput](Add-AzContainerInstanceOutput.md)
Attach to the output stream of a specific container instance in a specified resource group and container group.

### [Get-AzContainerGroup](Get-AzContainerGroup.md)
Gets the properties of the specified container group in the specified subscription and resource group.
The operation returns the properties of each container group including containers, image registry credentials, restart policy, IP address type, OS type, state, and volumes.

### [Get-AzContainerInstanceCachedImage](Get-AzContainerInstanceCachedImage.md)
Get the list of cached images on specific OS type for a subscription in a region.

### [Get-AzContainerInstanceCapability](Get-AzContainerInstanceCapability.md)
Get the list of CPU/memory/GPU capabilities of a region.

### [Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint](Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint.md)
Gets all the network dependencies for this container group to allow complete control of network setting and configuration.
For container groups, this will always be an empty list.

### [Get-AzContainerInstanceContainerGroupProfile](Get-AzContainerInstanceContainerGroupProfile.md)
Gets the properties of the specified container group profile in the specified subscription and resource group.
The operation returns the properties of container group profile including containers, image registry credentials, restart policy, IP address type, OS type, volumes, current revision number, etc.

### [Get-AzContainerInstanceContainerGroupProfileRevision](Get-AzContainerInstanceContainerGroupProfileRevision.md)
Get a list of all the revisions of the specified container group profile in the given subscription and resource group.
This operation returns properties of each revision of the specified container group profile including containers, image registry credentials, restart policy, IP address type, OS type volumes, revision number, etc.

### [Get-AzContainerInstanceLog](Get-AzContainerInstanceLog.md)
Get the logs for a specified container instance in a specified resource group and container group.

### [Get-AzContainerInstanceUsage](Get-AzContainerInstanceUsage.md)
Get the usage for a subscription

### [Invoke-AzContainerInstanceCommand](Invoke-AzContainerInstanceCommand.md)
Executes a command for a specific container instance in a specified resource group and container group.

### [New-AzContainerGroup](New-AzContainerGroup.md)
Create or update container groups with specified configurations.

### [New-AzContainerGroupImageRegistryCredentialObject](New-AzContainerGroupImageRegistryCredentialObject.md)
Create a in-memory object for ImageRegistryCredential

### [New-AzContainerGroupPortObject](New-AzContainerGroupPortObject.md)
Create a in-memory object for Port

### [New-AzContainerGroupVolumeObject](New-AzContainerGroupVolumeObject.md)
Create an in-memory object for Volume.

### [New-AzContainerInstanceContainerGroupProfile](New-AzContainerInstanceContainerGroupProfile.md)
Create or update container group profiles with specified configurations.

### [New-AzContainerInstanceEnvironmentVariableObject](New-AzContainerInstanceEnvironmentVariableObject.md)
Create a in-memory object for EnvironmentVariable

### [New-AzContainerInstanceHttpHeaderObject](New-AzContainerInstanceHttpHeaderObject.md)
Create a in-memory object for HttpHeader

### [New-AzContainerInstanceInitDefinitionObject](New-AzContainerInstanceInitDefinitionObject.md)
Create a in-memory object for InitContainerDefinition

### [New-AzContainerInstanceNoDefaultObject](New-AzContainerInstanceNoDefaultObject.md)
Create a in-memory object for Container with no default values

### [New-AzContainerInstanceObject](New-AzContainerInstanceObject.md)
Create a in-memory object for Container

### [New-AzContainerInstancePortObject](New-AzContainerInstancePortObject.md)
Create a in-memory object for ContainerPort

### [New-AzContainerInstanceVolumeMountObject](New-AzContainerInstanceVolumeMountObject.md)
Create a in-memory object for VolumeMount

### [Remove-AzContainerGroup](Remove-AzContainerGroup.md)
Delete the specified container group in the specified subscription and resource group.
The operation does not delete other resources provided by the user, such as volumes.

### [Remove-AzContainerInstanceContainerGroupProfile](Remove-AzContainerInstanceContainerGroupProfile.md)
Delete the specified container group profile in the specified subscription and resource group.
The operation does not delete other resources provided by the user, such as volumes.

### [Remove-AzContainerInstanceSubnetServiceAssociationLink](Remove-AzContainerInstanceSubnetServiceAssociationLink.md)
Delete container group virtual network association links.
The operation does not delete other resources provided by the user.

### [Restart-AzContainerGroup](Restart-AzContainerGroup.md)
Restarts all containers in a container group in place.
If container image has updates, new image will be downloaded.

### [Start-AzContainerGroup](Start-AzContainerGroup.md)
Starts all containers in a container group.
Compute resources will be allocated and billing will start.

### [Stop-AzContainerGroup](Stop-AzContainerGroup.md)
Stops all containers in a container group.
Compute resources will be deallocated and billing will stop.

### [Update-AzContainerGroup](Update-AzContainerGroup.md)
Updates container group tags with specified values.

### [Update-AzContainerInstanceContainerGroupProfile](Update-AzContainerInstanceContainerGroupProfile.md)
Patches container group profile with specified properties.

