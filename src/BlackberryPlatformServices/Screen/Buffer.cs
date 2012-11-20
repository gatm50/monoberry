using System;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
	public class Buffer
	{
		#region DllImport
		///**
		//*   @brief Creates a buffer handle that can later be attached to a window or a
		//*   pixmap.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function creates a buffer object, which describes memory where pixels
		//*   can be drawn to or read from. Applications should use
		//*   screen_destroy_buffer() when a buffer is no longer used.
		//*
		//*   @param  pbuf An address where the function can store a handle for the native
		//*           buffer.
		//*
		//*   @return @c 0 upon the buffer being created,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_create_buffer(screen_buffer_t *pbuf);
		[DllImport("screen")]
		static extern int screen_create_buffer(out IntPtr pbuf);

		///**
		//*   @brief Destroys a buffer and frees associated resources.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function destroys the buffer object associated with the buffer handle.
		//*   Any resources created for this buffer will also be released. The buffer
		//*   handle can no longer be used as argument in subsequent screen calls. The
		//*   actual memory buffer described by this buffer handle is not released by this
		//*   operation. The application is responsible for freeing its own external
		//*   buffers. Only buffers created with screen_create_buffer() should be
		//*   destroyed with this function.
		//*
		//*   @param  buf The handle of the buffer you want to destroy. This buffer must
		//*           have been created with screen_create_buffer().
		//*
		//*   @return @c 0 upon the buffer being destroyed,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_destroy_buffer(screen_buffer_t buf);
		[DllImport("screen")]
		static extern int screen_destroy_buffer(IntPtr buf);

		///**
		//*   @brief Retrieves the current value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function stores the current value of a buffer property in a
		//*   user-provided array. No more than @c len bytes of the specified type will be
		//*   written.
		//*
		//*   Currently there are no buffer properties which can be retrieved using this
		//*   function.
		//*
		//*   @param  buf The handle of the buffer whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for query are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  len The maximum number of bytes that can be written to @c param
		//*   @param  param The buffer where the retrieved values will be stored. This
		//*           buffer should be of type char with a maximum length of @c len.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_buffer_property_cv(screen_buffer_t buf, int pname, int len, char *param);
		[DllImport("screen")]
		static extern int screen_get_buffer_property_cv(IntPtr buf, PropertyType pname, int len, [Out] char[] param);

		///**
		//*   @brief Retrieves the current value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function stores the current value of a buffer property in a
		//*   user-provided array.
		//*
		//*   The values of the following properties can be retrieved using this function:
		//*   - @c SCREEN_PROPERTY_BUFFER_SIZE
		//*   - @c SCREEN_PROPERTY_FORMAT
		//*   - @c SCREEN_PROPERTY_INTERLACED
		//*   - @c SCREEN_PROPERTY_PHYSICALLY_CONTIGUOUS
		//*   - @c SCREEN_PROPERTY_PLANAR_OFFSETS
		//*   - @c SCREEN_PROPERTY_PROTECTED
		//*   - @c SCREEN_PROPERTY_STRIDE
		//*
		//*   @param  buf The handle of the buffer whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for query are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param The buffer where the retrieved values will be stored. This
		//*           buffer should be of type integer.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_buffer_property_iv(screen_buffer_t buf, int pname, int *param);
		[DllImport("screen")]
		static extern int screen_get_buffer_property_iv(IntPtr buf, PropertyType pname, [Out] int[] param);

		///**
		//*   @brief Retrieves the current value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function stores the current value of a buffer property in a
		//*   user-provided array.
		//*
		//*   The values of the following properties can be retrieved using this function:
		//*   - @c SCREEN_PROPERTY_PHYSICAL_ADDRESS
		//*
		//*   @param  buf The handle of the buffer whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for query are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param The buffer where the retrieved values will be stored. This
		//*           buffer should be of type long long integer.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_buffer_property_llv(screen_buffer_t buf, int pname, long long *param);
		[DllImport("screen")]
		static extern int screen_get_buffer_property_llv(IntPtr buf, PropertyType pname, [Out] int[] param);

		///**
		//*   @brief Retrieves the current value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function stores the current value of a buffer property in a
		//*   user-provided array.
		//*
		//*   The values of the following properties can be retrieved using this function:
		//*   - @c SCREEN_PROPERTY_EGL_HANDLE
		//*   - @c SCREEN_PROPERTY_POINTER
		//*   - @c SCREEN_PROPERTY_NATIVE_IMAGE
		//*
		//*   @param  buf The handle of the buffer whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for query are of type
		//*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param The buffer where the retrieved values will be stored. This
		//*           buffer should be of type void.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_buffer_property_pv(screen_buffer_t buf, int pname, void **param);
		[DllImport("screen")]
		static extern int screen_get_buffer_property_pv(IntPtr buf, PropertyType pname, [Out] IntPtr[] param);

		///**
		//*   @brief Sets the value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function sets the value of a buffer property from a user-provided array.
		//*
		//*   Currently there are no buffer properties which can be set using this
		//*   function.
		//*
		//*   @param  buf The handle of the buffer whose property is to be set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  len The maximum number of bytes that can will be read from @c param
		//*   @param  param A pointer to a buffer containing the new value(s).  This
		//*           buffer should be of type char with a maximum length of @c len.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_buffer_property_cv(screen_buffer_t buf, int pname, int len, const char *param);
		[DllImport("screen")]
		static extern int screen_set_buffer_property_cv(IntPtr buf, PropertyType pname, int len, char[] param);

		///**
		//*   @brief Sets the value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function sets the value of a buffer property from a user-provided array.
		//*
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_BUFFER_SIZE
		//*   - @c SCREEN_PROPERTY_FORMAT
		//*   - @c SCREEN_PROPERTY_INTERLACED
		//*   - @c SCREEN_PROPERTY_PHYSICALLY_CONTIGUOUS
		//*   - @c SCREEN_PROPERTY_PLANAR_OFFSETS
		//*   - @c SCREEN_PROPERTY_PROTECTED
		//*   - @c SCREEN_PROPERTY_STRIDE
		//*
		//*   @param  buf The handle of the buffer whose property is to be set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s).  This
		//*           buffer should be of type integer.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_buffer_property_iv(screen_buffer_t buf, int pname, const int *param);
		[DllImport("screen")]
		static extern int screen_set_buffer_property_iv(IntPtr buf, PropertyType pname, int[] param);

		///**
		//*   @brief Sets the value of the specified buffer property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function sets the value of a buffer property from a user-provided array.
		//*
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_PHYSICAL_ADDRESS
		//*
		//*   @param  buf The handle of the buffer whose property is to be set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s).  This
		//*           buffer should be of type long long integer.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_buffer_property_llv(screen_buffer_t buf, int pname, const long long *param);
		[DllImport("screen")]
		static extern int screen_set_buffer_property_llv(IntPtr buf, PropertyType pname, int[] param);

		///**
		//*   @brief Sets the value of the specified buffer property.
		//*
		//*   <b>Function Type:</b> <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function sets the value of a buffer property from a user-provided array.
		//*
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_EGL_HANDLE
		//*   - @c SCREEN_PROPERTY_POINTER
		//*   - @c SCREEN_PROPERTY_NATIVE_IMAGE
		//*
		//*   @param  buf The handle of the buffer whose property is to be set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*            <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s).  This
		//*           buffer should be of type void.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_buffer_property_pv(screen_buffer_t buf, int pname, void **param);
		[DllImport("screen")]
		static extern int screen_set_buffer_property_pv(IntPtr buf, PropertyType pname, IntPtr[] param);

		#endregion

		private IntPtr _handle;
		internal IntPtr Handle
		{
			get { return _handle; }
			set { _handle = value; }
		}

		Context _context;

		public Buffer(Context ctx, IntPtr buf)
		{
			_context = ctx;
			_handle = buf;
		}

		public Buffer(Context ctx)
		{
			_context = ctx;
			if (screen_create_buffer(out _handle) != 0)
				throw new Exception("Unable to create buffer!!");
		}

		public void Dispose()
		{
			if (screen_destroy_buffer(_handle) != 0)
				throw new Exception("Unable to dispose buffer!!");
		}

		#region Get-Set Properties
		public int[] GetIntProperty(PropertyType p)
		{
			var result = new int[] { 0 };

			if (screen_get_buffer_property_iv(_handle, p, result) != 0)
				throw new Exception("Unable to read buffer property " + p);

			return result;
		}

		public void SetIntProperty(PropertyType p, int[] val)
		{
			if (screen_set_buffer_property_iv(_handle, p, val) != 0)
				throw new Exception("Unable to set buffer property " + p);
		}

		public char[] GetCharProperty(PropertyType p, int len)
		{
			var result = new char[len];

			if (screen_get_buffer_property_cv(_handle, p, len, result) != 0)
				throw new Exception("Unable to read buffer property " + p);

			return result;
		}

		public void SetCharProperty(PropertyType p, char[] val)
		{
			if (screen_set_buffer_property_cv(_handle, p, val.Length, val) != 0)
				throw new Exception("Unable to set buffer property " + p);
		}

		public int[] GetLongProperty(PropertyType p)
		{
			var result = new int[] { 0 };

			if (screen_get_buffer_property_llv(_handle, p, result) != 0)
				throw new Exception("Unable to read buffer property " + p);

			return result;
		}

		public void SetLongProperty(PropertyType p, int[] val)
		{
			if (screen_set_buffer_property_llv(_handle, p, val) != 0)
				throw new Exception("Unable to set buffer property " + p);
		}

		public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
		{
			if (screen_get_buffer_property_pv(_handle, p, val) != 0)
				throw new Exception("Unable to read buffer property " + p);
		}

		public void SetVoidProperty(PropertyType p, IntPtr[] val)
		{
			if (screen_set_buffer_property_pv(_handle, p, val) != 0)
				throw new Exception("Unable to set buffer property " + p);
		}
		#endregion
	}

}