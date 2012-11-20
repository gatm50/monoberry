using System;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen.Types;

namespace BlackberryPlatformServices.Screen
{
	public class Blits
	{
		//*   @brief Copies pixel data from one buffer to another.
		//*   <b>Function Type:</b>  <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function requests pixels from one buffer be copied to another. The
		//*   operation is guaranteed not to be submitted until a flush is called, or
		//*   until the application posts changes to one of the context's windows.
		//*
		//*   The @c attribs argument is allowed to be @c NULL or empty (i.e. contains a
		//*   single element that is set to @c SCREEN_BLIT_END). If @c attribs is empty,
		//*   then the following defaults will be applied:
		//*   - the source rectangle's vertical and horizontal positions are 0
		//*   - the destination rectangle's vertical and horizontal positions are 0
		//*   - the source rectangle includes the entire source buffer
		//*   - the destination buffer includes the entire destination buffer
		//*   - the transparency is @c SCREEN_TRANSPARENCY_NONE
		//*   - the global alpha value is @c 255 (or opaque)
		//*   - the scale quality is @c SCREEN_QUALITY_NORMAL.
		//*
		//*   To change any of this default behavior, set @c attribs with pairings of the
		//*   following valid tokens and their desired values:
		//*   - @c SCREEN_BLIT_SOURCE_X
		//*   - @c SCREEN_BLIT_SOURCE_Y
		//*   - @c SCREEN_BLIT_SOURCE_WIDTH
		//*   - @c SCREEN_BLIT_SOURCE_HEIGHT
		//*   - @c SCREEN_BLIT_DESTINATION_X
		//*   - @c SCREEN_BLIT_DESTINATION_Y
		//*   - @c SCREEN_BLIT_DESTINATION_WIDTH
		//*   - @c SCREEN_BLIT_DESTINATION_HEIGHT
		//*   - @c SCREEN_BLIT_SCALE_QUALITY
		//*   - @c SCREEN_BLIT_GLOBAL_ALPHA
		//*   - @c SCREEN_BLIT_TRANSPARENCY (valid transparency values are:
		//*                                @c SCREEN_TRANSPARENCY_NONE,
		//                                 @c SCREEN_TRANSPARENCY_TEST, and
		//                                 @c SCREEN_TRANSPARENCY_SOURCE_OVER)
		//*
		//*   @param  ctx A connection to screen
		//*   @param  dst The buffer which data will be copied to.
		//*   @param  src The buffer which the pixels will be copied from.
		//*   @param  attribs A list that contains the attributes that define the
		//*           blit. This list must consist of a series of token-value pairs
		//*           terminated with a @c SCREEN_BLIT_END token. The tokens used in this
		//*           list must be of type <a href="group__screen__blits_1Screen_Blit_Types.xml">Screen blit types</a>.
		//*   @return @c 0 upon the blit operation being queued, otherwise @c -1 and @c errno is set
		//*/
		//int screen_blit(screen_context_t ctx, screen_buffer_t dst, screen_buffer_t src, const int *attribs);
		[DllImport("screen")]
		static extern int screen_blit(IntPtr ctx, IntPtr dst, IntPtr src, [In] int[] attribs);

		///**
		//*   @brief Fills an area of a specified buffer.
		//*
		//*   <b>Function Type:</b> <a href="manual/rscreen_delayed_execution.xml">Delayed Execution</a>
		//*
		//*   This function requests that a rectangular area of the destination buffer be
		//*   filled with a solid color.
		//*
		//*   The @c attribs argument is allowed to be @c NULL or empty (i.e. contains a
		//*   single element that is set to @c SCREEN_BLIT_END). If @c attribs is empty,
		//*   then the following defaults will be applied:
		//*   - the destination rectangle's vertical and horizontal positions are 0
		//*   - the destination buffer includes the entire destination buffer
		//*   - the transparency is @c SCREEN_TRANSPARENCY_NONE
		//*   - the global alpha value is @c 255 (or opaque)
		//*   - the scale quality is @c SCREEN_QUALITY_NORMAL.
		//*   - the color is \#ffffff (white)
		//*
		//*   To change any of this default behavior, set @c attribs with pairings of the
		//*   following valid tokens and their desired values:
		//*   - @c SCREEN_BLIT_DESTINATION_X
		//*   - @c SCREEN_BLIT_DESTINATION_Y
		//*   - @c SCREEN_BLIT_DESTINATION_WIDTH
		//*   - @c SCREEN_BLIT_DESTINATION_HEIGHT
		//*   - @c SCREEN_BLIT_GLOBAL_ALPHA
		//*   - @c SCREEN_BLIT_SCALE_QUALITY
		//*   - @c SCREEN_BLIT_COLOR
		//*   - @c SCREEN_BLIT_TRANSPARENCY (valid transparency values are:
		//*                                @c SCREEN_TRANSPARENCY_NONE,
		//*                                @c SCREEN_TRANSPARENCY_TEST, and
		//*                                @c SCREEN_TRANSPARENCY_SOURCE_OVER)
		//*
		//*   @param  ctx A connection to screen
		//*   @param  dst The buffer which data will be copied to.
		//*   @param  attribs A list that contains the attributes that define the
		//*           blit. This list must consist of a series of token-value pairs
		//*           terminated with a @c SCREEN_BLIT_END token. The tokens used in this
		//*           list must be of type <a href="group__screen__blits_1Screen_Blit_Types.xml">Screen blit types</a>.
		//*
		//*   @return @c 0 upon the blit operation being queued,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_fill(screen_context_t ctx, screen_buffer_t dst, const int *attribs);
		[DllImport("screen")]
		static extern int screen_fill(IntPtr ctx, IntPtr dst, [In] int[] attribs);

		///**
		//*   @brief Flushes all the blits issued since the last call to this function, or
		//*   screen_post_window().
		//*
		//*   <b>Function Type:</b> <a href="manual/rscreen_flushing_execution.xml">Flushing Execution</a>
		//*
		//*   This function flushes all delayed blits and fills since the last call to this
		//*   function, or since the last call to screen_post_window(). Note that this is a
		//*   flush of delayed blits and does not imply a flush of the command buffer.
		//*   The blits will start executing shortly after you call the function. The blits
		//*   may not be complete when the function returns, unless the @c SCREEN_WAIT_IDLE
		//*   flag is set. This function has no effect on other non-blit delayed calls. The
		//*   screen_post_window() function performs an implicit flush of any pending blits.
		//*   The content that is to be presented via the call to screen_post_window()
		//*   is most likely the result of any pending blit operations completing.
		//*
		//*   The connection to screen should have been acquired with the function
		//*   @c screen_create_context().
		//*
		//*   @param  ctx A connection to screen
		//*   @param  flags A flag used by the mutex. Specify @c SCREEN_WAIT_IDLE if the
		//*   function should block until all the blits have been completed.
		//*
		//*   @return @c 0 upon the blit buffer being flushed,
		//*           otherwise @c -1 and @c errno is set
		//*/
		//int screen_flush_blits(screen_context_t ctx, int flags);
		[DllImport("screen")]
		static extern int screen_flush_blits(IntPtr ctx, int flags);

		public static void Blit(Context ctx, Buffer src, Buffer dst, int width, int height, int srcX = 0, int srcY = 0, int dstX = 0, int dstY = 0, int transparency = (int)TransparencyTypes.SCREEN_TRANSPARENCY_NONE, int globalAlpha = 255, int scaleQuality = (int)ScaleQualityType.SCREEN_QUALITY_NORMAL)
		{
			var attribs = new int[] {
				(int)BlitAttribute.SCREEN_BLIT_SOURCE_X,
				srcX,
				(int)BlitAttribute.SCREEN_BLIT_SOURCE_Y,
				srcY,
				(int)BlitAttribute.SCREEN_BLIT_SOURCE_WIDTH,
				width,
				(int)BlitAttribute.SCREEN_BLIT_SOURCE_HEIGHT,
				height,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_X,
				dstX,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_Y,
				dstY,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_WIDTH,
				width,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_HEIGHT,
				height,
				(int)BlitAttribute.SCREEN_BLIT_TRANSPARENCY,
				transparency,
				(int)BlitAttribute.SCREEN_BLIT_GLOBAL_ALPHA,
				globalAlpha,
				(int)BlitAttribute.SCREEN_BLIT_SCALE_QUALITY,
				scaleQuality,
				(int)BlitAttribute.SCREEN_BLIT_END
			};

			if (src == null)
				throw new Exception("Error blitting. The Buffer source cannot be null.");

			if (screen_blit(ctx.Handle, dst.Handle, src.Handle, attribs) != 0)
				throw new Exception("Error blitting.");
		}

		public static void Fill(Context ctx, Buffer src, UInt32 color, int dstX = 0, int dstY = 0, int transparency = (int)TransparencyTypes.SCREEN_TRANSPARENCY_NONE, int globalAlpha = 255, int scaleQuality = (int)ScaleQualityType.SCREEN_QUALITY_NORMAL)
		{
			var attribs = new int[] {
				(int)BlitAttribute.SCREEN_BLIT_COLOR,
				(int)color,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_X,
				dstX,
				(int)BlitAttribute.SCREEN_BLIT_DESTINATION_Y,
				dstY,
				//(int)BlitAttribute.SCREEN_BLIT_TRANSPARENCY, //Error
				//transparency,
				(int)BlitAttribute.SCREEN_BLIT_GLOBAL_ALPHA,
				globalAlpha,
				//(int)BlitAttribute.SCREEN_BLIT_SCALE_QUALITY, //Error
				//scaleQuality,
				(int)BlitAttribute.SCREEN_BLIT_END
			};

			if (src == null)
				throw new Exception("Error blitting. The CurrentBuffer is null.");

			int res = screen_fill(ctx.Handle, src.Handle, attribs);
			if (res != 0)
				throw new Exception("Error blitting. Error: " + res);
		}

		public static void FlushBlits(Context ctx, int flushingType = (int)FlushingType.SCREEN_WAIT_IDLE)
		{
			if (screen_flush_blits(ctx.Handle, flushingType) != 0)
				throw new Exception("Error blitting.");
		}
	}
}