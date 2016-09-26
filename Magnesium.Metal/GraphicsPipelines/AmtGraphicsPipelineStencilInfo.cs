﻿using Metal;

namespace Magnesium.Metal
{
	public class AmtGraphicsPipelineStencilInfo
	{
		public MTLCompareFunction StencilCompareFunction { get; internal set; }
		public MTLStencilOperation DepthFailure { get; internal set; }
		public MTLStencilOperation DepthStencilPass { get; internal set; }
		public uint ReadMask { get; internal set; }
		public MTLStencilOperation StencilFailure { get; internal set; }
		public uint WriteMask { get; internal set; }
		public uint StencilReference { get; internal set; }

		public MTLStencilDescriptor GetDescriptor()
		{
			return new MTLStencilDescriptor
			{
				DepthFailureOperation = DepthFailure,
				DepthStencilPassOperation = DepthStencilPass,
				ReadMask = ReadMask,
				WriteMask = WriteMask,
				StencilCompareFunction = StencilCompareFunction,
				StencilFailureOperation = StencilFailure,
			};
		}
	}
}