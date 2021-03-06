﻿using System;

namespace Magnesium.OpenGL
{
	public interface IGLCmdShaderProgramEntrypoint
	{
		void BindProgram(int programID);

		void BindVAO(uint vao);

		void BindStorageBuffer(uint binding, uint bufferId, IntPtr offset, IntPtr size);

		void SetUniformBlock(int programID, int activeIndex, int bindingPoint);

		void BindUniformBuffers(int count, uint[] buffers, IntPtr[] offsets, IntPtr[] sizes);

		void BindCombinedImageSampler(int programID, int binding, long value);
	}
}