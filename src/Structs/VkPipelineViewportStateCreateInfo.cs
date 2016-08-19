using Magnesium;
using System;
using System.Runtime.InteropServices;

namespace Magnesium.Vulkan
{
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
	internal struct VkPipelineViewportStateCreateInfo
	{
		public VkStructureType sType { get; set; }
		public IntPtr pNext { get; set; }
		public UInt32 flags { get; set; }
		public UInt32 viewportCount { get; set; }
		public VkViewport pViewports { get; set; }
		public UInt32 scissorCount { get; set; }
		public VkRect2D pScissors { get; set; }
	}
}
