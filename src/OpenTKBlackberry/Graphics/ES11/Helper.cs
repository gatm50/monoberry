﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OpenTKBlackberry.Graphics.ES11
{
    /// <summary>
    /// Provides access to OpenGL ES 1.1 methods.
    /// </summary>

    public sealed partial class GL //: GraphicsBindingsBase
    {
        const string Library = "libGLESv1_CM";
        static readonly object sync_root = new object();

        #region --- Protected Members ---

        /// <summary>
        /// Returns a synchronization token unique for the GL class.
        /// </summary>
        protected object SyncRoot
        {
            get { return sync_root; }
        }

        #endregion

    }
}
