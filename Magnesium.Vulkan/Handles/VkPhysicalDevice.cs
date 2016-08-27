using Magnesium;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Magnesium.Vulkan
{
	public class VkPhysicalDevice : IMgPhysicalDevice
	{
		internal IntPtr Handle { get; private set;}
		internal VkPhysicalDevice(IntPtr handle)
		{
			Handle = handle;
		}

		public void GetPhysicalDeviceProperties(out MgPhysicalDeviceProperties pProperties)
		{
			var pCreateInfo = default(VkPhysicalDeviceProperties);
			Interops.vkGetPhysicalDeviceProperties(Handle, pCreateInfo);
			pProperties = new MgPhysicalDeviceProperties
			{
				ApiVersion = pCreateInfo.apiVersion,
				DriverVersion = pCreateInfo.driverVersion,
				VendorID = pCreateInfo.vendorID,
				DeviceID = pCreateInfo.deviceID,
				DeviceType =  (MgPhysicalDeviceType) pCreateInfo.deviceType,
				DeviceName = pCreateInfo.deviceName,
				PipelineCacheUUID = new Guid(pCreateInfo.pipelineCacheUUID),
				Limits = new MgPhysicalDeviceLimits
				{
					MaxImageDimension1D = pCreateInfo.limits.maxImageDimension1D,
					MaxImageDimension2D = pCreateInfo.limits.maxImageDimension2D,
					MaxImageDimension3D = pCreateInfo.limits.maxImageDimension3D,
					MaxImageDimensionCube = pCreateInfo.limits.maxImageDimensionCube,
					MaxImageArrayLayers = pCreateInfo.limits.maxImageArrayLayers,
					MaxTexelBufferElements = pCreateInfo.limits.maxTexelBufferElements,
					MaxUniformBufferRange = pCreateInfo.limits.maxUniformBufferRange,
					MaxStorageBufferRange = pCreateInfo.limits.maxStorageBufferRange,
					MaxPushConstantsSize = pCreateInfo.limits.maxPushConstantsSize,
					MaxMemoryAllocationCount = pCreateInfo.limits.maxMemoryAllocationCount,
					MaxSamplerAllocationCount = pCreateInfo.limits.maxSamplerAllocationCount,
					BufferImageGranularity = pCreateInfo.limits.bufferImageGranularity,
					SparseAddressSpaceSize = pCreateInfo.limits.sparseAddressSpaceSize,
					MaxBoundDescriptorSets = pCreateInfo.limits.maxBoundDescriptorSets,
					MaxPerStageDescriptorSamplers = pCreateInfo.limits.maxPerStageDescriptorSamplers,
					MaxPerStageDescriptorUniformBuffers = pCreateInfo.limits.maxPerStageDescriptorUniformBuffers,
					MaxPerStageDescriptorStorageBuffers = pCreateInfo.limits.maxPerStageDescriptorStorageBuffers,
					MaxPerStageDescriptorSampledImages = pCreateInfo.limits.maxPerStageDescriptorSampledImages,
					MaxPerStageDescriptorStorageImages = pCreateInfo.limits.maxPerStageDescriptorStorageImages,
					MaxPerStageDescriptorInputAttachments = pCreateInfo.limits.maxPerStageDescriptorInputAttachments,
					MaxPerStageResources = pCreateInfo.limits.maxPerStageResources,
					MaxDescriptorSetSamplers = pCreateInfo.limits.maxDescriptorSetSamplers,
					MaxDescriptorSetUniformBuffers = pCreateInfo.limits.maxDescriptorSetUniformBuffers,
					MaxDescriptorSetUniformBuffersDynamic = pCreateInfo.limits.maxDescriptorSetUniformBuffersDynamic,
					MaxDescriptorSetStorageBuffers = pCreateInfo.limits.maxDescriptorSetStorageBuffers,
					MaxDescriptorSetStorageBuffersDynamic = pCreateInfo.limits.maxDescriptorSetStorageBuffersDynamic,
					MaxDescriptorSetSampledImages = pCreateInfo.limits.maxDescriptorSetSampledImages,
					MaxDescriptorSetStorageImages = pCreateInfo.limits.maxDescriptorSetStorageImages,
					MaxDescriptorSetInputAttachments = pCreateInfo.limits.maxDescriptorSetInputAttachments,
					MaxVertexInputAttributes = pCreateInfo.limits.maxVertexInputAttributes,
					MaxVertexInputBindings = pCreateInfo.limits.maxVertexInputBindings,
					MaxVertexInputAttributeOffset = pCreateInfo.limits.maxVertexInputAttributeOffset,
					MaxVertexInputBindingStride = pCreateInfo.limits.maxVertexInputBindingStride,
					MaxVertexOutputComponents = pCreateInfo.limits.maxVertexOutputComponents,
					MaxTessellationGenerationLevel = pCreateInfo.limits.maxTessellationGenerationLevel,
					MaxTessellationPatchSize = pCreateInfo.limits.maxTessellationPatchSize,
					MaxTessellationControlPerVertexInputComponents = pCreateInfo.limits.maxTessellationControlPerVertexInputComponents,
					MaxTessellationControlPerVertexOutputComponents = pCreateInfo.limits.maxTessellationControlPerVertexOutputComponents,
					MaxTessellationControlPerPatchOutputComponents = pCreateInfo.limits.maxTessellationControlPerPatchOutputComponents,
					MaxTessellationControlTotalOutputComponents = pCreateInfo.limits.maxTessellationControlTotalOutputComponents,
					MaxTessellationEvaluationInputComponents = pCreateInfo.limits.maxTessellationEvaluationInputComponents,
					MaxTessellationEvaluationOutputComponents = pCreateInfo.limits.maxTessellationEvaluationOutputComponents,
					MaxGeometryShaderInvocations = pCreateInfo.limits.maxGeometryShaderInvocations,
					MaxGeometryInputComponents = pCreateInfo.limits.maxGeometryInputComponents,
					MaxGeometryOutputComponents = pCreateInfo.limits.maxGeometryOutputComponents,
					MaxGeometryOutputVertices = pCreateInfo.limits.maxGeometryOutputVertices,
					MaxGeometryTotalOutputComponents = pCreateInfo.limits.maxGeometryTotalOutputComponents,
					MaxFragmentInputComponents = pCreateInfo.limits.maxFragmentInputComponents,
					MaxFragmentOutputAttachments = pCreateInfo.limits.maxFragmentOutputAttachments,
					MaxFragmentDualSrcAttachments = pCreateInfo.limits.maxFragmentDualSrcAttachments,
					MaxFragmentCombinedOutputResources = pCreateInfo.limits.maxFragmentCombinedOutputResources,
					MaxComputeSharedMemorySize = pCreateInfo.limits.maxComputeSharedMemorySize,
					MaxComputeWorkGroupCount = pCreateInfo.limits.maxComputeWorkGroupCount,
					MaxComputeWorkGroupInvocations = pCreateInfo.limits.maxComputeWorkGroupInvocations,
					MaxComputeWorkGroupSize = pCreateInfo.limits.maxComputeWorkGroupSize,
					SubPixelPrecisionBits = pCreateInfo.limits.subPixelPrecisionBits,
					SubTexelPrecisionBits = pCreateInfo.limits.subTexelPrecisionBits,
					MipmapPrecisionBits = pCreateInfo.limits.mipmapPrecisionBits,
					MaxDrawIndexedIndexValue = pCreateInfo.limits.maxDrawIndexedIndexValue,
					MaxDrawIndirectCount = pCreateInfo.limits.maxDrawIndirectCount,
					MaxSamplerLodBias = pCreateInfo.limits.maxSamplerLodBias,
					MaxSamplerAnisotropy = pCreateInfo.limits.maxSamplerAnisotropy,
					MaxViewports = pCreateInfo.limits.maxViewports,
					MaxViewportDimensions = pCreateInfo.limits.maxViewportDimensions,
					ViewportBoundsRange = pCreateInfo.limits.viewportBoundsRange,
					ViewportSubPixelBits = pCreateInfo.limits.viewportSubPixelBits,
					MinMemoryMapAlignment = pCreateInfo.limits.minMemoryMapAlignment,
					MinTexelBufferOffsetAlignment = pCreateInfo.limits.minTexelBufferOffsetAlignment,
					MinUniformBufferOffsetAlignment = pCreateInfo.limits.minUniformBufferOffsetAlignment,
					MinStorageBufferOffsetAlignment = pCreateInfo.limits.minStorageBufferOffsetAlignment,
					MinTexelOffset = pCreateInfo.limits.minTexelOffset,
					MaxTexelOffset = pCreateInfo.limits.maxTexelOffset,
					MinTexelGatherOffset = pCreateInfo.limits.minTexelGatherOffset,
					MaxTexelGatherOffset = pCreateInfo.limits.maxTexelGatherOffset,
					MinInterpolationOffset = pCreateInfo.limits.minInterpolationOffset,
					MaxInterpolationOffset = pCreateInfo.limits.maxInterpolationOffset,
					SubPixelInterpolationOffsetBits = pCreateInfo.limits.subPixelInterpolationOffsetBits,
					MaxFramebufferWidth = pCreateInfo.limits.maxFramebufferWidth,
					MaxFramebufferHeight = pCreateInfo.limits.maxFramebufferHeight,
					MaxFramebufferLayers = pCreateInfo.limits.maxFramebufferLayers,
					FramebufferColorSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.framebufferColorSampleCounts,
					FramebufferDepthSampleCounts = (MgSampleCountFlagBits)pCreateInfo.limits.framebufferDepthSampleCounts,
					FramebufferStencilSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.framebufferStencilSampleCounts,
					FramebufferNoAttachmentsSampleCounts = (MgSampleCountFlagBits)pCreateInfo.limits.framebufferNoAttachmentsSampleCounts,
					MaxColorAttachments = pCreateInfo.limits.maxColorAttachments,
					SampledImageColorSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.sampledImageColorSampleCounts,
					SampledImageIntegerSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.sampledImageIntegerSampleCounts,
					SampledImageDepthSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.sampledImageDepthSampleCounts,
					SampledImageStencilSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.sampledImageStencilSampleCounts,
					StorageImageSampleCounts = (MgSampleCountFlagBits) pCreateInfo.limits.storageImageSampleCounts,
					MaxSampleMaskWords = pCreateInfo.limits.maxSampleMaskWords,
					TimestampComputeAndGraphics = VkBool32.ConvertFrom(pCreateInfo.limits.timestampComputeAndGraphics),
					TimestampPeriod = pCreateInfo.limits.timestampPeriod,
					MaxClipDistances = pCreateInfo.limits.maxClipDistances,
					MaxCullDistances = pCreateInfo.limits.maxCullDistances,
					MaxCombinedClipAndCullDistances = pCreateInfo.limits.maxCombinedClipAndCullDistances,
					DiscreteQueuePriorities = pCreateInfo.limits.discreteQueuePriorities,
					PointSizeRange = pCreateInfo.limits.pointSizeRange,
					LineWidthRange = pCreateInfo.limits.lineWidthRange,
					PointSizeGranularity = pCreateInfo.limits.pointSizeGranularity,
					LineWidthGranularity = pCreateInfo.limits.lineWidthGranularity,
					StrictLines = VkBool32.ConvertFrom(pCreateInfo.limits.strictLines),
					StandardSampleLocations = VkBool32.ConvertFrom(pCreateInfo.limits.standardSampleLocations),
					OptimalBufferCopyOffsetAlignment = pCreateInfo.limits.optimalBufferCopyOffsetAlignment,
					OptimalBufferCopyRowPitchAlignment = pCreateInfo.limits.optimalBufferCopyRowPitchAlignment,
					NonCoherentAtomSize = pCreateInfo.limits.nonCoherentAtomSize,
				},
				SparseProperties = new MgPhysicalDeviceSparseProperties
				{
					ResidencyStandard2DBlockShape = VkBool32.ConvertFrom(pCreateInfo.sparseProperties.residencyStandard2DBlockShape),
					ResidencyStandard2DMultisampleBlockShape = VkBool32.ConvertFrom(pCreateInfo.sparseProperties.residencyStandard2DMultisampleBlockShape),
					ResidencyStandard3DBlockShape = VkBool32.ConvertFrom(pCreateInfo.sparseProperties.residencyStandard3DBlockShape),
					ResidencyAlignedMipSize = VkBool32.ConvertFrom(pCreateInfo.sparseProperties.residencyAlignedMipSize),
					ResidencyNonResidentStrict = VkBool32.ConvertFrom(pCreateInfo.sparseProperties.residencyNonResidentStrict),
				},
			};
		}

		public void GetPhysicalDeviceQueueFamilyProperties(out MgQueueFamilyProperties[] pQueueFamilyProperties)
		{
			unsafe
			{
				var count = stackalloc uint[1];
				Interops.vkGetPhysicalDeviceQueueFamilyProperties(Handle, count, null);

				var queueFamilyCount = (int) count[0];
				var familyProperties = stackalloc VkQueueFamilyProperties[queueFamilyCount];

				Interops.vkGetPhysicalDeviceQueueFamilyProperties(Handle, count, familyProperties);

				pQueueFamilyProperties = new MgQueueFamilyProperties[queueFamilyCount];
				for (var i = 0; i < queueFamilyCount; ++i)
				{
					pQueueFamilyProperties[i] = new MgQueueFamilyProperties
					{
						QueueFlags = (MgQueueFlagBits)familyProperties[i].queueFlags,
						QueueCount = familyProperties[i].queueCount,
						TimestampValidBits = familyProperties[i].timestampValidBits,
						MinImageTransferGranularity = familyProperties[i].minImageTransferGranularity,
					};
				}
			}
		}	

		public void GetPhysicalDeviceMemoryProperties(out MgPhysicalDeviceMemoryProperties pMemoryProperties)
		{
			var memoryProperties = default(VkPhysicalDeviceMemoryProperties);
			Interops.vkGetPhysicalDeviceMemoryProperties(Handle, memoryProperties);

			var memoryHeaps = new MgMemoryHeap[memoryProperties.memoryHeapCount];
			for (var i = 0; i < memoryProperties.memoryHeapCount; ++i)
			{
				memoryHeaps[i] = new MgMemoryHeap
				{
					Size = memoryProperties.memoryHeaps[i].size,
					Flags = (MgMemoryHeapFlagBits)memoryProperties.memoryHeaps[i].flags,
				};
			}

			var memoryTypes = new MgMemoryType[memoryProperties.memoryTypeCount];
			for (var i = 0; i < memoryProperties.memoryTypeCount; ++i)
			{
				memoryTypes[i] = new MgMemoryType
				{
					PropertyFlags = (uint)memoryProperties.memoryTypes[i].propertyFlags,
					HeapIndex = memoryProperties.memoryTypes[i].heapIndex, 
				};
			}

			pMemoryProperties = new MgPhysicalDeviceMemoryProperties
			{
				MemoryHeaps = memoryHeaps,
				MemoryTypes = memoryTypes,
			};
		}

		public void GetPhysicalDeviceFeatures(out MgPhysicalDeviceFeatures pFeatures)
		{
			var features = default(VkPhysicalDeviceFeatures);

			Interops.vkGetPhysicalDeviceFeatures(Handle, features);

			pFeatures = new MgPhysicalDeviceFeatures
			{
				RobustBufferAccess = VkBool32.ConvertFrom(features.robustBufferAccess),
				FullDrawIndexUint32 = VkBool32.ConvertFrom(features.fullDrawIndexUint32),
				ImageCubeArray = VkBool32.ConvertFrom(features.imageCubeArray),
				IndependentBlend = VkBool32.ConvertFrom(features.independentBlend),
				GeometryShader = VkBool32.ConvertFrom(features.geometryShader),
				TessellationShader = VkBool32.ConvertFrom(features.tessellationShader),
				SampleRateShading = VkBool32.ConvertFrom(features.sampleRateShading),
				DualSrcBlend = VkBool32.ConvertFrom(features.dualSrcBlend),
				LogicOp = VkBool32.ConvertFrom(features.logicOp),
				MultiDrawIndirect = VkBool32.ConvertFrom(features.multiDrawIndirect),
				DrawIndirectFirstInstance = VkBool32.ConvertFrom(features.drawIndirectFirstInstance),
				DepthClamp = VkBool32.ConvertFrom(features.depthClamp),
				DepthBiasClamp = VkBool32.ConvertFrom(features.depthBiasClamp),
				FillModeNonSolid = VkBool32.ConvertFrom(features.fillModeNonSolid),
				DepthBounds = VkBool32.ConvertFrom(features.depthBounds),
				WideLines = VkBool32.ConvertFrom(features.wideLines),
				LargePoints = VkBool32.ConvertFrom(features.largePoints),
				AlphaToOne = VkBool32.ConvertFrom(features.alphaToOne),
				MultiViewport = VkBool32.ConvertFrom(features.multiViewport),
				SamplerAnisotropy = VkBool32.ConvertFrom(features.samplerAnisotropy),
				TextureCompressionETC2 = VkBool32.ConvertFrom(features.textureCompressionETC2),
				TextureCompressionASTC_LDR = VkBool32.ConvertFrom(features.textureCompressionASTC_LDR),
				TextureCompressionBC = VkBool32.ConvertFrom(features.textureCompressionBC),
				OcclusionQueryPrecise = VkBool32.ConvertFrom(features.occlusionQueryPrecise),
				PipelineStatisticsQuery = VkBool32.ConvertFrom(features.pipelineStatisticsQuery),
				VertexPipelineStoresAndAtomics = VkBool32.ConvertFrom(features.vertexPipelineStoresAndAtomics),
				FragmentStoresAndAtomics = VkBool32.ConvertFrom(features.fragmentStoresAndAtomics),
				ShaderTessellationAndGeometryPointSize = VkBool32.ConvertFrom(features.shaderTessellationAndGeometryPointSize),
				ShaderImageGatherExtended = VkBool32.ConvertFrom(features.shaderImageGatherExtended),
				ShaderStorageImageExtendedFormats = VkBool32.ConvertFrom(features.shaderStorageImageExtendedFormats),
				ShaderStorageImageMultisample = VkBool32.ConvertFrom(features.shaderStorageImageMultisample),
				ShaderStorageImageReadWithoutFormat = VkBool32.ConvertFrom(features.shaderStorageImageReadWithoutFormat),
				ShaderStorageImageWriteWithoutFormat = VkBool32.ConvertFrom(features.shaderStorageImageWriteWithoutFormat),
				ShaderUniformBufferArrayDynamicIndexing = VkBool32.ConvertFrom(features.shaderUniformBufferArrayDynamicIndexing),
				ShaderSampledImageArrayDynamicIndexing = VkBool32.ConvertFrom(features.shaderSampledImageArrayDynamicIndexing),
				ShaderStorageBufferArrayDynamicIndexing = VkBool32.ConvertFrom(features.shaderStorageBufferArrayDynamicIndexing),
				ShaderStorageImageArrayDynamicIndexing = VkBool32.ConvertFrom(features.shaderStorageImageArrayDynamicIndexing),
				ShaderClipDistance = VkBool32.ConvertFrom(features.shaderClipDistance),
				ShaderCullDistance = VkBool32.ConvertFrom(features.shaderCullDistance),
				ShaderFloat64 = VkBool32.ConvertFrom(features.shaderFloat64),
				ShaderInt64 = VkBool32.ConvertFrom(features.shaderInt64),
				ShaderInt16 = VkBool32.ConvertFrom(features.shaderInt16),
				ShaderResourceResidency = VkBool32.ConvertFrom(features.shaderResourceResidency),
				ShaderResourceMinLod = VkBool32.ConvertFrom(features.shaderResourceMinLod),
				SparseBinding = VkBool32.ConvertFrom(features.sparseBinding),
				SparseResidencyBuffer = VkBool32.ConvertFrom(features.sparseResidencyBuffer),
				SparseResidencyImage2D = VkBool32.ConvertFrom(features.sparseResidencyImage2D),
				SparseResidencyImage3D = VkBool32.ConvertFrom(features.sparseResidencyImage3D),
				SparseResidency2Samples = VkBool32.ConvertFrom(features.sparseResidency2Samples),
				SparseResidency4Samples = VkBool32.ConvertFrom(features.sparseResidency4Samples),
				SparseResidency8Samples = VkBool32.ConvertFrom(features.sparseResidency8Samples),
				SparseResidency16Samples = VkBool32.ConvertFrom(features.sparseResidency16Samples),
				SparseResidencyAliased = VkBool32.ConvertFrom(features.sparseResidencyAliased),
				VariableMultisampleRate = VkBool32.ConvertFrom(features.variableMultisampleRate),
				InheritedQueries = VkBool32.ConvertFrom(features.inheritedQueries),
			};
		}

		public void GetPhysicalDeviceFormatProperties(MgFormat format, out MgFormatProperties pFormatProperties)
		{
			VkFormatProperties formatProperties = default(VkFormatProperties);
			Interops.vkGetPhysicalDeviceFormatProperties(Handle, (VkFormat)format, formatProperties);

			pFormatProperties = new MgFormatProperties
			{
				Format = format,
				LinearTilingFeatures = (MgFormatFeatureFlagBits)formatProperties.linearTilingFeatures,
				OptimalTilingFeatures = (MgFormatFeatureFlagBits)formatProperties.optimalTilingFeatures,
				BufferFeatures = (MgFormatFeatureFlagBits)formatProperties.bufferFeatures,
			};
		}

		public Result GetPhysicalDeviceImageFormatProperties(MgFormat format, MgImageType type, MgImageTiling tiling, MgImageUsageFlagBits usage, MgImageCreateFlagBits flags, out MgImageFormatProperties pImageFormatProperties)
		{
			throw new NotImplementedException();
		}

		public Result CreateDevice(MgDeviceCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgDevice pDevice)
		{
			if (pCreateInfo != null)
			{
				throw new ArgumentNullException(nameof(pCreateInfo));
			}

			var bAllocator = (MgVkAllocationCallbacks)allocator;
			IntPtr allocatorPtr = bAllocator != null ? bAllocator.Handle : IntPtr.Zero;

			var pQueueCreateInfos = IntPtr.Zero;

			var ppEnabledLayerNames = IntPtr.Zero;

			var ppEnabledExtensionNames = IntPtr.Zero;

			var pEnabledFeatures = IntPtr.Zero;

			try
			{
				var queueCreateInfoCount = 0U;
				if (pCreateInfo.QueueCreateInfos != null)
				{
					queueCreateInfoCount = (uint)pCreateInfo.QueueCreateInfos.Length;
					if (queueCreateInfoCount > 0)
					{
						pQueueCreateInfos = GenerateQueueCreateInfos();
					}
				}

				var enabledLayerCount = 0U;
				if (pCreateInfo.EnabledLayerNames != null)
				{
					enabledLayerCount = (uint)pCreateInfo.EnabledLayerNames.Length;
					if (enabledLayerCount > 0)
					{
						ppEnabledLayerNames = GenerateEnabledLayerNames();
					}
				}


				var enabledExtensionCount = 0U;
				if (pCreateInfo.EnabledExtensionNames != null)
				{
					enabledExtensionCount = (uint)pCreateInfo.EnabledExtensionNames.Length;
					if (enabledExtensionCount > 0)
					{
						ppEnabledLayerNames = GenerateExtensionNames();
					}
				}

				if (pCreateInfo.EnabledFeatures != null)
				{
					pEnabledFeatures = GenerateEnabledFeatures();
				}

				var internalHandle = IntPtr.Zero;
				var createInfo = new VkDeviceCreateInfo
				{
					sType = VkStructureType.StructureTypeDeviceCreateInfo,
					pNext = IntPtr.Zero,
					flags = pCreateInfo.Flags,
					queueCreateInfoCount = queueCreateInfoCount,
					pQueueCreateInfos = pQueueCreateInfos,
					enabledLayerCount = enabledLayerCount,
					ppEnabledLayerNames = ppEnabledLayerNames,
					enabledExtensionCount = enabledExtensionCount,
					ppEnabledExtensionNames = ppEnabledExtensionNames,
					pEnabledFeatures = pEnabledFeatures,
				};
				var result = Interops.vkCreateDevice(Handle, createInfo, allocatorPtr, ref internalHandle);
				pDevice = new VkDevice(internalHandle);
				return result;
			}
			finally
			{
				if (pEnabledFeatures != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pEnabledFeatures);
				}

				if (ppEnabledExtensionNames != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(ppEnabledExtensionNames);
				}

				if (ppEnabledLayerNames != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(ppEnabledLayerNames);
				}

				if (pQueueCreateInfos != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pQueueCreateInfos);
				}
			}
		}

		IntPtr GenerateEnabledFeatures()
		{
			throw new NotImplementedException();
		}

		IntPtr GenerateEnabledLayerNames()
		{
			throw new NotImplementedException();
		}

		IntPtr GenerateExtensionNames()
		{
			throw new NotImplementedException();
		}

		IntPtr GenerateQueueCreateInfos()
		{
			throw new NotImplementedException();
		}

		public Result EnumerateDeviceLayerProperties(out MgLayerProperties[] pProperties)
		{
			throw new NotImplementedException();
		}

		public Result EnumerateDeviceExtensionProperties(string layerName, out MgExtensionProperties[] pProperties)
		{
			throw new NotImplementedException();
		}

		public void GetPhysicalDeviceSparseImageFormatProperties(MgFormat format, MgImageType type, MgSampleCountFlagBits samples, MgImageUsageFlagBits usage, MgImageTiling tiling, out MgSparseImageFormatProperties[] pProperties)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceDisplayPropertiesKHR(out MgDisplayPropertiesKHR[] pProperties)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceDisplayPlanePropertiesKHR(out MgDisplayPlanePropertiesKHR[] pProperties)
		{
			throw new NotImplementedException();
		}

		public Result GetDisplayPlaneSupportedDisplaysKHR(UInt32 planeIndex, out IMgDisplayKHR[] pDisplays)
		{
			throw new NotImplementedException();
		}

		public Result GetDisplayModePropertiesKHR(IMgDisplayKHR display, out MgDisplayModePropertiesKHR[] pProperties)
		{
			throw new NotImplementedException();
		}

		public Result GetDisplayPlaneCapabilitiesKHR(IMgDisplayModeKHR mode, UInt32 planeIndex, out MgDisplayPlaneCapabilitiesKHR pCapabilities)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceSurfaceSupportKHR(UInt32 queueFamilyIndex, IMgSurfaceKHR surface, ref bool pSupported)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceSurfaceCapabilitiesKHR(IMgSurfaceKHR surface, out MgSurfaceCapabilitiesKHR pSurfaceCapabilities)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceSurfaceFormatsKHR(IMgSurfaceKHR surface, out MgSurfaceFormatKHR[] pSurfaceFormats)
		{
			throw new NotImplementedException();
		}

		public Result GetPhysicalDeviceSurfacePresentModesKHR(IMgSurfaceKHR surface, out MgPresentModeKHR[] pPresentModes)
		{
			throw new NotImplementedException();
		}

		public Boolean GetPhysicalDeviceWin32PresentationSupportKHR(UInt32 queueFamilyIndex)
		{
			throw new NotImplementedException();
		}

		public Result CreateDisplayModeKHR(IMgDisplayKHR display, MgDisplayModeCreateInfoKHR pCreateInfo, IMgAllocationCallbacks allocator, out IMgDisplayModeKHR pMode)
		{
			if (pCreateInfo != null)
			{
				throw new ArgumentNullException(nameof(pCreateInfo));
			}

			var bDisplay = (VkDisplayModeKHR)display;
			Debug.Assert(bDisplay != null);

			var bAllocator = (MgVkAllocationCallbacks)allocator;
			var allocatorPtr = bAllocator != null ? bAllocator.Handle : IntPtr.Zero;

			var createInfo = new VkDisplayModeCreateInfoKHR
			{
				sType = VkStructureType.StructureTypeDisplayModeCreateInfoKhr,
				pNext = IntPtr.Zero,
				flags = pCreateInfo.flags,
				parameters = new VkDisplayModeParametersKHR
				{
					refreshRate = pCreateInfo.parameters.RefreshRate,
					visibleRegion = pCreateInfo.parameters.VisibleRegion,
				}
			};

			ulong modeHandle = 0;
			var result = Interops.vkCreateDisplayModeKHR(this.Handle, bDisplay.Handle, createInfo, allocatorPtr, ref modeHandle);
			pMode = new VkDisplayModeKHR(modeHandle);

			return result;
		}
	}
}
