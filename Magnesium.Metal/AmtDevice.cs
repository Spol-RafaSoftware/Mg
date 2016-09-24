﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Metal;

namespace Magnesium.Metal
{
	public class AmtDevice : IMgDevice
	{
		private IMTLDevice mDevice; 
		private IAmtDeviceQuery mQuery;
		public AmtDevice(IMTLDevice systemDefault, IAmtDeviceQuery mQuery)
		{
			this.mDevice = systemDefault;
			this.mQuery = mQuery;
		}

		public Result AcquireNextImageKHR(IMgSwapchainKHR swapchain, ulong timeout, IMgSemaphore semaphore, IMgFence fence, out uint pImageIndex)
		{
			throw new NotImplementedException();
		}

		public Result AllocateCommandBuffers(MgCommandBufferAllocateInfo pAllocateInfo, IMgCommandBuffer[] pCommandBuffers)
		{
			if (pAllocateInfo == null)
				throw new ArgumentNullException(nameof(pAllocateInfo));

			if (pCommandBuffers == null)
				throw new ArgumentNullException(nameof(pCommandBuffers));

			if (pAllocateInfo.CommandBufferCount != pCommandBuffers.Length)
				throw new ArgumentOutOfRangeException(nameof(pAllocateInfo.CommandBufferCount) + " !=  " + nameof(pCommandBuffers.Length));

			var commandPool = (AmtCommandPool)pAllocateInfo.CommandPool;
			Debug.Assert(commandPool != null, nameof(pAllocateInfo.CommandPool) + " is null");

			var arraySize = pAllocateInfo.CommandBufferCount;

			for (var i = 0; i < arraySize; ++i)
			{
				var cmdBuf = commandPool.Queue.CommandBuffer();
				pCommandBuffers[i] = new AmtCommandBuffer(cmdBuf);
			}


			return Result.SUCCESS;
		}

		public Result AllocateDescriptorSets(MgDescriptorSetAllocateInfo pAllocateInfo, out IMgDescriptorSet[] pDescriptorSets)
		{
			throw new NotImplementedException();
		}

		public Result AllocateMemory(MgMemoryAllocateInfo pAllocateInfo, IMgAllocationCallbacks allocator, out IMgDeviceMemory pMemory)
		{
			throw new NotImplementedException();
		}

		public Result CreateBuffer(MgBufferCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgBuffer pBuffer)
		{
			nuint length = 0;
			var buffer = mDevice.CreateBuffer(length, MTLResourceOptions.CpuCacheModeDefault);
			throw new NotImplementedException();
		}

		public Result CreateBufferView(MgBufferViewCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgBufferView pView)
		{
			throw new NotImplementedException();
		}

		public Result CreateCommandPool(MgCommandPoolCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgCommandPool pCommandPool)
		{
			var queue = mDevice.CreateCommandQueue(mQuery.NoOfCommandBufferSlots);
			pCommandPool = new AmtCommandPool(queue);
			return Result.SUCCESS;
		}

		public Result CreateComputePipelines(IMgPipelineCache pipelineCache, MgComputePipelineCreateInfo[] pCreateInfos, IMgAllocationCallbacks allocator, out IMgPipeline[] pPipelines)
		{
			throw new NotImplementedException();
		}

		public Result CreateDescriptorPool(MgDescriptorPoolCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgDescriptorPool pDescriptorPool)
		{
			throw new NotImplementedException();
		}

		public Result CreateDescriptorSetLayout(MgDescriptorSetLayoutCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgDescriptorSetLayout pSetLayout)
		{
			throw new NotImplementedException();
		}

		public Result CreateEvent(MgEventCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgEvent @event)
		{
			throw new NotImplementedException();
		}

		public Result CreateFence(MgFenceCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgFence fence)
		{
			throw new NotImplementedException();
		}

		public Result CreateFramebuffer(MgFramebufferCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgFramebuffer pFramebuffer)
		{
			throw new NotImplementedException();
		}

		public Result CreateGraphicsPipelines(IMgPipelineCache pipelineCache, MgGraphicsPipelineCreateInfo[] pCreateInfos, IMgAllocationCallbacks allocator, out IMgPipeline[] pPipelines)
		{
			var output = new List<IMgPipeline>();

			foreach (var info in pCreateInfos)
			{
				var pipeline = new AmtGraphicsPipeline(mDevice, info);
				output.Add(pipeline);

			}
			pPipelines = output.ToArray();
			return Result.SUCCESS;
		}



		private static nuint TranslateSampleCount(MgSampleCountFlagBits count)
		{
			switch (count)
			{
				case MgSampleCountFlagBits.COUNT_1_BIT:
					return 1;
				case MgSampleCountFlagBits.COUNT_4_BIT:
					return 4;
				case MgSampleCountFlagBits.COUNT_2_BIT:
					return 2;
				case MgSampleCountFlagBits.COUNT_8_BIT:
					return 8;
				case MgSampleCountFlagBits.COUNT_16_BIT:
					return 16;
				case MgSampleCountFlagBits.COUNT_32_BIT:
					return 32;
				case MgSampleCountFlagBits.COUNT_64_BIT:
					return 64;
				default:
					throw new NotSupportedException();
			}
		}

		private static MTLTextureType TranslateTextureType(MgImageType imageType)
		{
			switch (imageType)
			{
				case MgImageType.TYPE_1D:
					return MTLTextureType.k1D;
				case MgImageType.TYPE_2D:
					return MTLTextureType.k2D;
				case MgImageType.TYPE_3D:
					return MTLTextureType.k3D;
				default:
					throw new NotSupportedException();
			}
		}

		private MTLTextureUsage TranslateUsage(MgImageUsageFlagBits flags)
		{
			MTLTextureUsage output = 0;
			if ((flags & MgImageUsageFlagBits.COLOR_ATTACHMENT_BIT) == MgImageUsageFlagBits.COLOR_ATTACHMENT_BIT)
			{
				output |= MTLTextureUsage.RenderTarget;
			}
			if ((flags & MgImageUsageFlagBits.DEPTH_STENCIL_ATTACHMENT_BIT) == MgImageUsageFlagBits.DEPTH_STENCIL_ATTACHMENT_BIT)
			{
				output |= MTLTextureUsage.RenderTarget;
			}

			if ((flags & MgImageUsageFlagBits.TRANSFER_DST_BIT) == MgImageUsageFlagBits.TRANSFER_DST_BIT)
			{
				output |= MTLTextureUsage.Blit;
			}

			if ((flags & MgImageUsageFlagBits.TRANSFER_SRC_BIT) == MgImageUsageFlagBits.TRANSFER_SRC_BIT)
			{
				output |= MTLTextureUsage.PixelFormatView;
			}

			if ((flags & MgImageUsageFlagBits.SAMPLED_BIT) == MgImageUsageFlagBits.SAMPLED_BIT)
			{
				output |= MTLTextureUsage.ShaderRead;
			}

			if ((flags & MgImageUsageFlagBits.STORAGE_BIT) == MgImageUsageFlagBits.STORAGE_BIT)
			{
				output |= MTLTextureUsage.ShaderWrite;
			}

			return output;
		}

		public Result CreateImage(MgImageCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgImage pImage)
		{
			Debug.Assert(pCreateInfo != null);

			var depth = (nuint)pCreateInfo.Extent.Depth;
			var height = (nuint)pCreateInfo.Extent.Height;
			var width = (nuint) pCreateInfo.Extent.Width;
			var arrayLayers = (nuint)pCreateInfo.ArrayLayers;
			var mipLevels = (nuint) pCreateInfo.MipLevels;

			//TODO : Figure this out
			var storageMode = MTLStorageMode.Shared;
			var resourceOptions = MTLResourceOptions.CpuCacheModeDefault;
			var cpuCacheMode = MTLCpuCacheMode.DefaultCache;

			var descriptor = new MTLTextureDescriptor
			{ 
				ArrayLength = arrayLayers,
				PixelFormat = AmtFormatExtensions.GetPixelFormat(pCreateInfo.Format),
				SampleCount = TranslateSampleCount(pCreateInfo.Samples),
				TextureType = TranslateTextureType(pCreateInfo.ImageType),
				StorageMode = storageMode,
				Width = width,
				Height = height,
				Depth = depth,
				MipmapLevelCount = mipLevels,
				Usage = TranslateUsage(pCreateInfo.Usage),
				ResourceOptions =resourceOptions,
				CpuCacheMode = cpuCacheMode,
			};
			
			var texture = mDevice.CreateTexture(descriptor);
			pImage = new AmtImage(texture);
			return Result.SUCCESS;
		}

		public Result CreateImageView(MgImageViewCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgImageView pView)
		{
			throw new NotImplementedException();
		}

		public Result CreatePipelineCache(MgPipelineCacheCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgPipelineCache pPipelineCache)
		{
			throw new NotImplementedException();
		}

		public Result CreatePipelineLayout(MgPipelineLayoutCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgPipelineLayout pPipelineLayout)
		{
			throw new NotImplementedException();
		}

		public Result CreateQueryPool(MgQueryPoolCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgQueryPool queryPool)
		{
			throw new NotImplementedException();
		}

		public Result CreateRenderPass(MgRenderPassCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgRenderPass pRenderPass)
		{
			pRenderPass = new AmtRenderPass(pCreateInfo);
			return Result.SUCCESS;
		}

		public Result CreateSampler(MgSamplerCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgSampler pSampler)
		{
			throw new NotImplementedException();
		}

		public Result CreateSemaphore(MgSemaphoreCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgSemaphore pSemaphore)
		{
			throw new NotImplementedException();
		}

		public Result CreateShaderModule(MgShaderModuleCreateInfo pCreateInfo, IMgAllocationCallbacks allocator, out IMgShaderModule pShaderModule)
		{
			throw new NotImplementedException();
		}

		public Result CreateSharedSwapchainsKHR(MgSwapchainCreateInfoKHR[] pCreateInfos, IMgAllocationCallbacks allocator, out IMgSwapchainKHR[] pSwapchains)
		{
			throw new NotImplementedException();
		}

		public Result CreateSwapchainKHR(MgSwapchainCreateInfoKHR pCreateInfo, IMgAllocationCallbacks allocator, out IMgSwapchainKHR pSwapchain)
		{
			throw new NotImplementedException();
		}

		public void DestroyDevice(IMgAllocationCallbacks allocator)
		{
			throw new NotImplementedException();
		}

		public Result DeviceWaitIdle()
		{
			throw new NotImplementedException();
		}

		public Result FlushMappedMemoryRanges(MgMappedMemoryRange[] pMemoryRanges)
		{
			throw new NotImplementedException();
		}

		public void FreeCommandBuffers(IMgCommandPool commandPool, IMgCommandBuffer[] pCommandBuffers)
		{
			throw new NotImplementedException();
		}

		public Result FreeDescriptorSets(IMgDescriptorPool descriptorPool, IMgDescriptorSet[] pDescriptorSets)
		{
			throw new NotImplementedException();
		}

		public void GetBufferMemoryRequirements(IMgBuffer buffer, out MgMemoryRequirements pMemoryRequirements)
		{
			throw new NotImplementedException();
		}

		public void GetDeviceMemoryCommitment(IMgDeviceMemory memory, ref ulong pCommittedMemoryInBytes)
		{
			throw new NotImplementedException();
		}

		public PFN_vkVoidFunction GetDeviceProcAddr(string pName)
		{
			throw new NotImplementedException();
		}

		public void GetDeviceQueue(uint queueFamilyIndex, uint queueIndex, out IMgQueue pQueue)
		{
			throw new NotImplementedException();
		}

		public Result GetFenceStatus(IMgFence fence)
		{
			throw new NotImplementedException();
		}

		public void GetImageMemoryRequirements(IMgImage image, out MgMemoryRequirements memoryRequirements)
		{
			throw new NotImplementedException();
		}

		public void GetImageSparseMemoryRequirements(IMgImage image, out MgSparseImageMemoryRequirements[] sparseMemoryRequirements)
		{
			throw new NotImplementedException();
		}

		public void GetImageSubresourceLayout(IMgImage image, MgImageSubresource pSubresource, out MgSubresourceLayout pLayout)
		{
			throw new NotImplementedException();
		}

		public Result GetPipelineCacheData(IMgPipelineCache pipelineCache, out byte[] pData)
		{
			throw new NotImplementedException();
		}

		public Result GetQueryPoolResults(IMgQueryPool queryPool, uint firstQuery, uint queryCount, IntPtr dataSize, IntPtr pData, ulong stride, MgQueryResultFlagBits flags)
		{
			throw new NotImplementedException();
		}

		public void GetRenderAreaGranularity(IMgRenderPass renderPass, out MgExtent2D pGranularity)
		{
			throw new NotImplementedException();
		}

		public Result GetSwapchainImagesKHR(IMgSwapchainKHR swapchain, out IMgImage[] pSwapchainImages)
		{
			throw new NotImplementedException();
		}

		public Result InvalidateMappedMemoryRanges(MgMappedMemoryRange[] pMemoryRanges)
		{
			throw new NotImplementedException();
		}

		public Result MergePipelineCaches(IMgPipelineCache dstCache, IMgPipelineCache[] pSrcCaches)
		{
			throw new NotImplementedException();
		}

		public Result ResetFences(IMgFence[] pFences)
		{
			throw new NotImplementedException();
		}

		public void UpdateDescriptorSets(MgWriteDescriptorSet[] pDescriptorWrites, MgCopyDescriptorSet[] pDescriptorCopies)
		{
			throw new NotImplementedException();
		}

		public Result WaitForFences(IMgFence[] pFences, bool waitAll, ulong timeout)
		{
			throw new NotImplementedException();
		}
	}
}
