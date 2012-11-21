using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
	public class ScreenPixmaps
	{
		#region DllImport
		///**
		//*   @brief Associates an externally allocated buffer with a pixmap.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function can be used to force a pixmap to use a buffer that was
		//*   allocated by the application. Since pixmaps can have only one buffer, it is
		//*   not possible to call This function or screen_create_pixmap_buffer() more
		//*   than once. Whoever allocates the buffer is required to meet all alignment
		//*   and granularity constraints required for the usage flags.
		//*
		//*   @param  pix The handle of a pixmap that does not already have a buffer
		//*           created or associated to it.
		//*   @param  buf A buffer that was allocated by the application.
		//*
		//*   @return @c 0 upon the buffer being used by the specified pixmap,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_attach_pixmap_buffer(screen_pixmap_t pix, screen_buffer_t buf);
		[DllImport("screen")]
		static extern int screen_attach_pixmap_buffer(IntPtr pix, IntPtr buf);

		///**
		//*   @brief Creates a pixmap that can be used to do off-screen rendering.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
		//*
		//*   This function creates a pixmap object, which is an off-screen rendering
		//*   target. The results of this rendering can later be copied to a window object.
		//*   Applications should use screen_destroy_pixmap() when a pixmap is no longer
		//*   used.
		//*
		//*   @param  ppix An address where the function can store the handle to the
		//*           newly created native pixmap.
		//*   @param  ctx The connection to the composition manager. This context should
		//*           have been created with screen_create_context().
		//*
		//*   @return @c 0 upon creation of a new pixmap,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_create_pixmap(screen_pixmap_t *ppix, screen_context_t ctx);
		[DllImport("screen")]
		static extern int screen_create_pixmap(out IntPtr ppix, IntPtr ctx);

		///**
		//*   @brief Sends a request to the composition manager to add a new buffer to a
		//*   pixmap.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function to adds a buffer to a pixmap. A buffer cannot be created if a
		//*   buffer was previously attached using screen_attach_pixmap_buffer().
		//*
		//*   @param  pix The handle of the pixmap for which a new buffer will be created.
		//*
		//*   @return @c 0 upon creation of a new pixmap buffer,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_create_pixmap_buffer(screen_pixmap_t pix);
		[DllImport("screen")]
		static extern int screen_create_pixmap_buffer(IntPtr pix);

		///**
		//*   @brief Destroys a pixmap and frees associated resources.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function destroys the pixmap associated with the specified pixmap. Any
		//*   resources and buffer created for this pixmap, whether locally or by the
		//*   composition manager, will be released. The pixmap handle can no longer be
		//*   used as argument in subsequent screen calls. Pixmap buffers that are not
		//*   created by composition manager but are registered with
		//*   screen_attach_pixmap_buffer() are not freed by this operation. The
		//*   application is responsible for freeing its own external buffers.
		//*
		//*   @param  pix The handle of the pixmap which is to be destroyed.
		//*
		//*   @return @c 0 upon the pixmap buffer being destroyed,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_destroy_pixmap(screen_pixmap_t pix);
		[DllImport("screen")]
		static extern int screen_destroy_pixmap(IntPtr pix);

		///**
		//*   @brief Sends a request to the composition manager to destory the buffer of
		//*   the specified pixmap.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function releases the buffer that was allocated for a pixmap, without
		//*   destroying the pixmap. If the buffer was created with
		//*   screen_create_pixmap_buffer(), the memory is released and can be used for
		//*   other window or pixmap buffers. If the buffer was attached using
		//*   screen_attach_pixmap_buffer(), the buffer is destroyed but no memory is
		//*   actually released. In this case the application is responsible for freeing
		//*   the memory after calling screen_destroy_pixmap_buffer(). Once a pixmap
		//*   buffer has been destroyed, you can change the format, usage and buffer size
		//*   before creating a new buffer again.
		//*   The memory that is released by this call is not reserved and can be used for
		//*   any subsequent buffer allocation by the windowing system.
		//*
		//*   @param  pix The handle of the pixmap whose buffer is to be destroyed.
		//*
		//*   @return @c 0 upon the memory used by the pixmap buffer being freed,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_destroy_pixmap_buffer(screen_pixmap_t pix);
		[DllImport("screen")]
		static extern int screen_destroy_pixmap_buffer(IntPtr pix);

		///**
		//*   @brief Retrieves the current value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function retrieves the value of pixmap property from a user-provided array.
		//*   The values of the following properties can be queried using this function:
		//*   - @c SCREEN_PROPERTY_GROUP
		//*   - @c SCREEN_PROPERTY_ID_STRING
		//*
		//*   @param  pix The handle of the pixmap whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for querying are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  len The maximum number of bytes that can be written to @c param
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type char with a maximum length of @c len.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_pixmap_property_cv(screen_pixmap_t pix, int pname, int len, char *param);
		[DllImport("screen")]
		static extern int screen_get_pixmap_property_cv(IntPtr pix, PropertyType pname, int len, [Out] char[] param);

		///**
		//*   @brief Retrieves the current value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function retrieves the value of pixmap property from a user-provided array.
		//*   The values of the following properties can be queried using this function:
		//*   - @c SCREEN_PROPERTY_ALPHA_MODE
		//*   - @c SCREEN_PROPERTY_COLOR_SPACE
		//*   - @c SCREEN_PROPERTY_FORMAT
		//*   - @c SCREEN_PROPERTY_USAGE
		//*   - @c SCREEN_PROPERTY_BUFFER_SIZE
		//*   - @c SCREEN_PROPERTY_METRIC_COUNT
		//*
		//*   @param  pix The handle of the pixmap whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for querying are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type integer.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_pixmap_property_iv(screen_pixmap_t pix, int pname, int *param);
		[DllImport("screen")]
		static extern int screen_get_pixmap_property_iv(IntPtr pix, PropertyType pname, [Out] int[] param);

		///**
		//*   @brief Retrieves the current value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function retrieves the value of pixmap property from a user-provided
		//*   array.
		//*   The values of the following properties can be queried using this function:
		//*    - @c SCREEN_PROPERTY_METRICS
		//*
		//*   @param  pix The handle of the pixmap whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for querying are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type long long integer.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_pixmap_property_llv(screen_pixmap_t pix, int pname, long long *param);
		[DllImport("screen")]
		static extern int screen_get_pixmap_property_llv(IntPtr pix, PropertyType pname, [Out] int[] param);

		///**
		//*   @brief Retrieves the current value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function retrieves the value of pixmap property from a user-provided array.
		//*   The values of the following properties can be queried using this function:
		//*   - @c SCREEN_PROPERTY_CONTEXT
		//*   - @c SCREEN_PROPERTY_GROUP
		//*   - @c SCREEN_PROPERTY_RENDER_BUFFERS
		//*
		//*   @param  pix The handle of the pixmap whose property is being queried.
		//*   @param  pname The name of the property whose value is being queried. The
		//*           properties available for querying are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type void.
		//*
		//*   @return @c 0 upon a successful query and the value(s) of the property are
		//*           stored in @c param, otherwise @c -1 and @c errno is set
		//*/
		//int screen_get_pixmap_property_pv(screen_pixmap_t pix, int pname, void **param);
		[DllImport("screen")]
		static extern int screen_get_pixmap_property_pv(IntPtr pix, PropertyType pname, [Out] IntPtr[] param);

		///**
		//*   @brief Causes a pixmap to join a group.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function is used to add a pixmap to a group.
		//*
		//*   @param  pix The handle of the pixmap that is to be joining the group.
		//*   @param  name A unique string that identifies the group.
		//*
		//*   @return @c 0 upon the request for the pixmap to join the group being
		//*           queued for processing, otherwise @c -1 and @c errno is set
		//*/
		//int screen_join_pixmap_group(screen_pixmap_t pix, const char *name);
		[DllImport("screen")]
		static extern int screen_join_pixmap_group(IntPtr pix, char[] name);

		///**
		//*   @brief Causes a pixmap to leave a group.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function is used to remove a pixmap from a group.
		//*
		//*   @param  pix The handle of the pixmap that is to be leaving the group.
		//*
		//*   @return @c 0 upon the request for the pixmap to leave the group being
		//*           queued for processing, otherwise @c -1 and @c errno is set
		//*/
		//int screen_leave_pixmap_group(screen_pixmap_t pix);
		[DllImport("screen")]
		static extern int screen_leave_pixmap_group(IntPtr pix);

		///**
		//*   @brief Sets the value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function sets the value of a pixmap property from a user-provided array.
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_ID_STRING
		//*
		//*   @param  pix handle of the pixmap whose property is being set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  len The maximum number of bytes that can be written to @c param
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type char with a maximum length of @c len.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_pixmap_property_cv(screen_pixmap_t pix, int pname, int len, const char *param);
		[DllImport("screen")]
		static extern int screen_set_pixmap_property_cv(IntPtr pix, PropertyType pname, int len, char[] param);

		///**
		//*   @brief Sets the value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function sets the value of a pixmap property from a user-provided array.
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_ALPHA_MODE
		//*   - @c SCREEN_PROPERTY_COLOR_SPACE
		//*   - @c SCREEN_PROPERTY_FORMAT
		//*   - @c SCREEN_PROPERTY_USAGE
		//*   - @c SCREEN_PROPERTY_BUFFER_SIZE
		//*
		//*   @param  pix handle of the pixmap whose property is being set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type integer.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_pixmap_property_iv(screen_pixmap_t pix, int pname, const int *param);
		[DllImport("screen")]
		static extern int screen_set_pixmap_property_iv(IntPtr pix, PropertyType pname, int[] param);

		///**
		//*   @brief Sets the value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function sets the value of a pixmap property from a user-provided array.
		//*   Currently, there are no pixmap properties that can be set using this
		//*   function.
		//*
		//*   @param  pix handle of the pixmap whose property is being set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type long long integer.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_pixmap_property_llv(screen_pixmap_t pix, int pname, const long long *param);
		[DllImport("screen")]
		static extern int screen_set_pixmap_property_llv(IntPtr pix, PropertyType pname, int[] param);

		///**
		//*   @brief Sets the value of the specified pixmap property.
		//*
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function sets the value of a pixmap property from a user-provided array.
		//*   The values of the following properties can be set using this function:
		//*   - @c SCREEN_PROPERTY_CONTEXT
		//*   - @c SCREEN_PROPERTY_GROUP
		//*   - @c SCREEN_PROPERTY_RENDER_BUFFERS
		//*
		//*   @param  pix handle of the pixmap whose property is being set.
		//*   @param  pname The name of the property whose value is being set. The
		//*           properties available for setting are of type
		//*           <a href="screen_8h_1Screen_Property_Types.xml">Screen property name types</a>.
		//*   @param  param A pointer to a buffer containing the new value(s). This
		//*           buffer should be of type void.
		//*
		//*   @return @c 0 upon the value(s) of the property being set to new value(s),
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_set_pixmap_property_pv(screen_pixmap_t pix, int pname, void **param);
		[DllImport("screen")]
		static extern int screen_set_pixmap_property_pv(IntPtr pix, PropertyType pname, IntPtr[] param);
		#endregion

		private IntPtr _handle;
		internal IntPtr Handle
		{
			get { return _handle; }
		}

		Context _context;

		public ScreenPixmaps(Context ctx, IntPtr buf)
		{
			_context = ctx;
			_handle = buf;
		}

		public ScreenPixmaps(Context ctx)
		{
			_context = ctx;
			if (screen_create_pixmap(out _handle, _context.Handle) != 0)
				throw new Exception("Unable to create pixmap!!");
		}

		public void CreatePixampBuffer()
		{
			if (screen_create_pixmap_buffer(_handle) != 0)
				throw new Exception("Unable to create pixmap buffer!!");
		}

		public void Dispose()
		{
			if (screen_destroy_pixmap(_handle) != 0)
				throw new Exception("Unable to dispose pixmap!!");
		}

		public void DisposePixmapBuffer()
		{
			if (screen_destroy_pixmap_buffer(_handle) != 0)
				throw new Exception("Unable to dispose pixmap buffer!!");
		}

		public void AttachBufferToPixmap(Buffer buf)
		{
			if (screen_attach_pixmap_buffer(_handle,buf.Handle) != 0)
				throw new Exception("Unable to attach buffer to pixmap.");
		}

		public void JoinPixmapToGroup(string groupName)
		{
			if (screen_join_pixmap_group(_handle, groupName.ToCharArray()) != 0)
				throw new Exception("Unable to join pixmap to group.");
		}

		public void LeavePixmapFromGroup()
		{
			if (screen_leave_pixmap_group(_handle) != 0)
				throw new Exception("Unable to leave pixmap from group.");
		}

		#region Get-Set Properties
		public int[] GetIntProperty(PropertyType p)
		{
			var result = new int[] { 0 };

			if (screen_get_pixmap_property_iv(_handle, p, result) != 0)
				throw new Exception("Unable to read pixmap property " + p);

			return result;
		}

		public void SetIntProperty(PropertyType p, int[] val)
		{
			if (screen_set_pixmap_property_iv(_handle, p, val) != 0)
				throw new Exception("Unable to set pixmap property " + p);
		}

		public char[] GetCharProperty(PropertyType p, int len)
		{
			var result = new char[len];

			if (screen_get_pixmap_property_cv(_handle, p, len, result) != 0)
				throw new Exception("Unable to read pixmap property " + p);

			return result;
		}

		public void SetCharProperty(PropertyType p, char[] val)
		{
			if (screen_set_pixmap_property_cv(_handle, p, val.Length, val) != 0)
				throw new Exception("Unable to set pixmap property " + p);
		}

		public int[] GetLongProperty(PropertyType p)
		{
			var result = new int[] { 0 };

			if (screen_get_pixmap_property_llv(_handle, p, result) != 0)
				throw new Exception("Unable to read pixmap property " + p);

			return result;
		}

		public void SetLongProperty(PropertyType p, int[] val)
		{
			if (screen_set_pixmap_property_llv(_handle, p, val) != 0)
				throw new Exception("Unable to set pixmap property " + p);
		}

		public void GetVoidProperty(PropertyType p, ref IntPtr[] val)
		{
			if (screen_get_pixmap_property_pv(_handle, p, val) != 0)
				throw new Exception("Unable to read pixmap property " + p);
		}

		public void SetVoidProperty(PropertyType p, IntPtr[] val)
		{
			if (screen_set_pixmap_property_pv(_handle, p, val) != 0)
				throw new Exception("Unable to set pixmap property " + p);
		}
		#endregion
	}
}