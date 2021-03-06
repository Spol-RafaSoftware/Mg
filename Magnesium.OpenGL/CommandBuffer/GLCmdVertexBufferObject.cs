﻿using System;

namespace Magnesium.OpenGL.Internals
{
	public class GLCmdVertexBufferObject : IDisposable
	{
		public uint VBO { get; private set; }
		private readonly IGLCmdVBOEntrypoint mFactory;

		public GLCmdVertexBufferObject(uint vbo, IGLCmdVBOEntrypoint factory)
        {
			VBO = vbo;
			mFactory = factory;
		}

		#region IDisposable implementation

		~GLCmdVertexBufferObject()
		{
			Dispose (false);
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		private bool mDisposed = false;
		protected virtual void Dispose(bool isDisposing)
		{
			if (mDisposed)
				return;

			if (mFactory != null && VBO != 0)
				mFactory.DeleteVBO(VBO);

			mDisposed = true;
		}

		#endregion
	}
}

