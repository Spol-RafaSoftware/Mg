﻿using System.Collections.Generic;

namespace Magnesium.Metal
{
	public interface IAmtCmdBufferRepository
	{
		IList<AmtDescriptorSetRecordingState> DescriptorSets { get; set; }
		IList<AmtCmdIndexBufferParameter> IndexBuffers { get; set; }
		IList<AmtVertexBufferEncoderState> VertexBuffers { get; set; }

		void PushGraphicsPipeline(AmtGraphicsPipeline glPipeline);
		void PushViewports(uint firstViewport, MgViewport[] pViewports);
		void PushScissors(uint firstScissor, MgRect2D[] pScissors);
		void PushLineWidth(float lineWidth);
		void PushDepthBias(float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);
		void PushBlendConstants(MgColor4f blendConstants);
		void PushDepthBounds(float minDepthBounds, float maxDepthBounds);
		void SetCompareMask(MgStencilFaceFlagBits faceMask, uint compareMask);
		void SetWriteMask(MgStencilFaceFlagBits faceMask, uint writeMask);
		void SetStencilReference(MgStencilFaceFlagBits faceMask, uint reference);
		bool MapRepositoryFields(ref AmtDrawCommandEncoderState command);
		void Clear();
	}
}