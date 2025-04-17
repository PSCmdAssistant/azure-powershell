```markdown
## Upcoming Release
* Added parameter `maxPatchPublishDate` to `Invoke-AzVMInstallPatch` for specifying a maximum patch publish date in the Windows parameter set(s).
* Added new cmdlets `Add-AzVmssSkuProfileVMSize` and `Remove-AzVmssSkuProfileVMSize` to add and remove VM sizes to and from the VMSS SkuProfile.
* Added new parameters `ZonePlacementPolicy`, `IncludeZone`, `ExcludeZone`, and `AlignRegionalDisksToVMZone` to cmdlets `New-AzVM` and `New-AzVmConfig`
* Added new parameter `AlignRegionalDisksToVMZone` to cmdlet `Update-AzVM`.
* VM/VMSS related cmdlets will now use 2024-11-01 ComputeRP API calls.

## Version 9.2.0
* Added new parameter `-ReplicationMode` to `New-AzGalleryImageVersion` cmdlet.
* Added new parameter `BlockDeletionBeforeEndOfLife` parameter to `New-AzGalleryImageVersion` and `Update-AzGalleryImageVersion` cmdlets.
* Updated `New-AzVM`, `New-AzVmss`, `Update-AzVM`, and `Update-AzVmss` to pass `Standard` as an input of `-SecurityType` parameter.
* Added breaking change message for `Get-AzVMSize`.

## Version 9.1.0
* Added new parameter `EncryptionIdentity` to cmdlet `Set-AzVmssDiskEncryptionExtension`
* Added new parameter `EncryptionIdentity` to cmdlet `New-VmssConfig`
* Added new parameter `EncryptionIdentity` to cmdlet `Set-AzVMDiskEncryptionExtension`
* Added new parameter `EncryptionIdentity` to cmdlet `New-AzVMConfig`

## Version 9.0.1
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.
* Compute gallery related cmdlets will now use 2024-03-03 GalleryRP API calls. 

## Version 9.0.0
* Made `-PublicIpSku` parameter Standard by default in `New-AzVM`

## Version 8.5.0
* Added optional parameters `-SecurityPostureId` and `-SecurityPostureExcludeExtension` to cmdlets `New-AzVmss` and `New-AzVmssConfig`.
* Updated image aliases to be up-to-date in the azure-powershell\src\Compute\Strategies\ComputeRp\Images.json file.
* Added `NvmeDisk` argument completer to `DiffDiskPlacement` parameter for `Set-AzVMOSDisk` and `Set-AzVmssStorageProfile` cmdlets, allowing options for disk placement as `CacheDisk`, `ResourceDisk`, or `NvmeDisk`.

## Version 8.4.0
* Added `SkuProfileVmSize` and `SkuProfileAllocationStrategy` parameters to `New-AzVmss`, `New-AzVmssConfig`, and `Update-AzVmss` cmdlets for VMSS Instance Mix operations.
* Added a new optional parameter `-GenerateSshKey-type` to the `New-AzVM` cmdlet, allowing users to specify the type of SSH key to generate (Ed25519 or RSA).
* Added cx waning to the `New-AzVM` cmdlet, The default value of `publicIpSku` parameter will be changed from Basic to Standard.
* Added `EnableResilientVMCreate` and `EnableResilientVMDelete` parameters to `Update-AzVmss` and `New-AzVmssConfig` cmdlets for enhanced VM resilience options.
* Added `IsVMInStandByPool` property to `PSVirtualMachineInstanceView` object. [#25736]

## Version 8.3.0
* Fixed secrets exposure in example documentation.
* References are updated to use 2024-07-01 ComputeRP and 2024-03-02 DiskRP REST API calls.
* Added information on how to find VM Images when using `New-AzVM` with `-Image` parameter.
* Added `TimeCreated` read-only field to `PSVirtualMachineScaleSetVMProfile` object.
* Added parameter `-ResourceIdsOnly` to `Get-AzCapacityReservationGroup` cmdlet.
* Changed the `Set-AzVMOperatingSystem` cmdlet when the `-VM` parameter is used without an OSProfile. Now it will not throw a null reference exception when `-Credential` is not provided.
* Added parameter `-ForceDetach` to `Remove-AzVMDataDisk` cmdlet.

## Version 8.2.0
* Renamed parameter `-VmId` to `-SourceId` and added `-VmId` as an alias to `New-AzRestorePointCollection` cmdlet.

## Version 8.1.0
* Added parameter `-SourceResourceId` to cmdlet `Add-AzVMDataDisk`.
* Added parameter `-IdentityType` to cmdlet `Update-AzDiskEncryptionSet`.
* Added `Invoke-AzSpotPlacementScore` cmdlet, which calls the latest Spot Placement Score API. Set the original `Invoke-AzSpotPlacementRecommender` as alias to avoid breaking changes.

## Version 8.0.0
* Added new optional parameter `SecureVMGuestStateSAS` to cmdlet `Grant-AzDiskAccess`.
* [Breaking Change] Added ValidateNotNullOrEmpty for `-ResourceGroupName` and `-VMScaleSetName` parameters to `Get-AzVmss` cmdlet. [#20095]
* Added `Etag` property to PSVirtualMachine and PSVirtualMachineScaleSet objects.   
* Added parameters `-IfMatch` and `-IfNoneMatch` to `Update-AzVM`, `Update-AzVmss`, `New-AzVM`, `New-AzVmss`, `New-AzVmConfig`, and `New-AzVmssConfig` cmdlets.
* [Breaking Change] Cmdlet `New-AzGalleryImageDefinition` will default parameter `-HyperVGeneration` to `V2` if it is not set as `V1` explicitly, and also default parameter `-Feature` by adding `@{Name='SecurityType';Value='TrustedLaunchSupported'}` if the `SecurityType` feature is not set explicitly. 
* Resolved the bug with `New-AzVMConfig` for `-CommunityGalleryImageId` and `-SharedGalleryImageId` parameters.
* [Breaking Change] Added ValidateNotNullOrEmpty for `-ResourceGroupName` and `-VMScaleSetName` parameters to `Get-AzVmss` cmdlet. [#20095]
* [Breaking Change] Added new business logic to `New-AzVmss` and `New-AzVM` cmdlets. When the user explicitly sets the `SecurityType` to `Standard`, the Image alias defaults to `Win2022AzureEdition` to make future migrations to Trusted Launch easier.

## Version 7.3.0
* Added cmdlet `Invoke-AzSpotPlacementRecommender`.
* Fixed `Update-AzCapacityReservationGroup` to remove Subscriptions from SharingProfile.

## Version 7.2.0
* Added parameters `-scriptUriManagedIdentity`, `-outputBlobManagedIdentity`, `-errorBlobMangedIdentity`, and `-TreatFailureAsDeploymentFailure` to cmdlets `Set-AzVmRunCommand` and `Set-AzVmssRunCommand`. 
* Added new parameter `-EnableAutomaticOSUpgrade` to `New-AzVmss` cmdlet.
* Renamed parameter `-AutoOSUpgrade` to `-EnableAutomaticOSUpgrade` in `New-AzVmssConfig` cmdlet for consistency. Using `-AutoOSUpgrade` as parameter name will continue to work as it is added as an alias.
* Upgraded Azure.Core to 1.37.0.
* Az.Compute is updated to use the 2023-07-03 GalleryRP, 2024-03-01 ComputeRP and 2023-10-02 DiskRP API.
* Added new parameter `-TierOption` to `New-AzSnapshotConfig`.
* Added breaking change warnings for the May 2024 release. The warnings are for:
  `New-AzGalleryImageVersion` defaulting to turn on TrustedLaunchSupported and HyperVGeneration to V2.
  `New-AzVM` and `New-AzVmss` will default to the image `Windows Server 2022 Azure Edition` instead of `Windows 2016 Datacenter` by default.
  `Get-AzVmss` will no longer allow empty values to `ResourceGroupName` and `VMScaleSetName` to avoid a bug where it will just return nothing.
* Added a new parameter `-SharingProfile` to `New-AzCapacityReservationGroup` and `Update-AzCapacityReservationGroup`.
* Added the new parameter `SourceImageVMId` to the `New-AzGalleryImageVersion` cmdlet. Also added some error messages for this new parameter and the existing parameter `SourceImageId`. 
* Updated parameter `-TargetRegion` in `New-AzGalleryImageVersion` and `Update-AzGalleryImageVersion` to accept `ExcludeFromLatest` field. 

## Version 7.1.2
* Fixed `New-AzVM` when a source image is specified to avoid an error on the `Version` value.

## Version 7.1.1
* Fixed `New-AzVmss` to correctly work when using `-EdgeZone` by creating the Load Balancer in the correct edge zone.
* Removed references to image aliases in `New-AzVM` and `New-AzVmss` to images that were removed.
* Az.Compute is updated to use the 2023-09-01 ComputeRP REST API calls. 

## Version 7.1.0
* Added new parameter `-ElasticSanResourceId` to `New-AzSnapshotConfig` cmdlet.
* Added new parameter `-OptimizedForFrequentAttach` to `New-AzDiskConfig` cmdlet.
* Added new examples in `New-AzVM` and `New-AzVmss` for TrustedLaunch default usage.
* Fixed the `New-AzVM` bug to avoid accessing the `EncryptionAtHost` property for subscriptions who cannot access it since it is behind a feature flag.
* Updated `Get-AzVmExtension` to return instanceView when used with `-Status`.
* Reverted SSH Private Key File permission changes in `New-AzVm`.

## Version 7.0.0
* Added update functionality in `Update-AzVmss` for parameters `SecurityType`, `EnableSecureBoot`, and `EnableVtpm` for the parameter set with the Put operation.
* Upgraded Azure.Core to 1.35.0.
* [Breaking change] Removed unversioned and outdated linux image aliases of `CentOS`, `RHEL`, `UbuntuLTS` and `Debian`.
* [Breaking change] `New-AzVmss` will default to `OrchestrationMode` set as  `Flexible` if it is not set as `Uniform` explicitly.
* `New-AzVmss` can now create VMSS with `OrchestrationMode` set to `Flexible` using `-SinglePlacementGroup` and `-UpgradePolicy`.
* Removed unversioned and outdated images from New-AzVmss `-ImageName` argument completers.
* [Breaking Change] Added defaulting logic for VM and VMSS creation to set SecurityType to TrustedLaunch and SecureBootEnabled and VTpmEnalbed to true when those are not set by the user.
* [Breaking Change] Added defaulting logic for Disk creation to default to TrustedLaunch when able. Allows the user to turn this off by setting the SecurityType to Standard.
* Added new parameter `-VirtualMachineScaleSetId` to `Update-AzVm` cmdlet.
* Fixed `New-AzVmss` and `New-Azvm` to use `SharedGalleryImageId` parameter.
* Reduced File Permissions from 0644 to 0600 for SSH Private Key File in `New-AzVm`.
* Removed GuestAttestaion vm extension installation for Vmss and Vm creation cmdlets. 
```
