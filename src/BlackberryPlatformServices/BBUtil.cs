//
//// Authors:
//   Gustavo Torrico (gatm50@gmail.com)
//// Licensed under the terms of the Microsoft Public License (MS-PL)
//// Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
//

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using BlackberryPlatformServices.Screen;

namespace BlackberryPlatformServices
{
    public class BBUtil
    {
        #region DllImport
        [DllImport("BBUtils10")]
        static extern int bbutil_get_disp_surf(out IntPtr disp, out IntPtr surf);
        // /**
        // * Initializes EGL
        // *
        // * @param libscreen context that will be used for EGL setup
        // * @return EXIT_SUCCESS if initialization succeeded otherwise EXIT_FAILURE
        // */
        //int bbutil_init_egl(screen_context_t ctx);
        [DllImport("BBUtils10")]
        static extern int bbutil_init_egl(IntPtr ctx);

        ///**
        // * Terminates EGL
        // */
        //void bbutil_terminate();
        [DllImport("BBUtils10")]
        static extern void bbutil_terminate();

        ///**
        // * Swaps default bbutil window surface to the screen
        // */
        //void bbutil_swap();
        [DllImport("BBUtils10")]
        static extern void bbutil_swap();

        ///**
        // * Loads the font from the specified font file.
        // * NOTE: should be called after a successful return from bbutil_init() or bbutil_init_egl() call
        // * @param font_file string indicating the absolute path of the font file
        // * @param point_size used for glyph generation
        // * @param dpi used for glyph generation
        // * @return pointer to font_t structure on success or NULL on failure
        // */
        //font_t* bbutil_load_font(const char* font_file, int point_size, int dpi);
        [DllImport("BBUtils10")]
        static extern IntPtr bbutil_load_font(char[] font_file, int point_size, int dpi);

        ///**
        // * Destroys the passed font
        // * @param font to be destroyed
        // */
        //void bbutil_destroy_font(font_t* font);
        [DllImport("BBUtils10")]
        static extern void bbutil_destroy_font(IntPtr font);

        ///**
        // * Renders the specified message using current font starting from the specified
        // * bottom left coordinates.
        // * NOTE: must be called after a successful return from bbutil_init() or bbutil_init_egl() call

        // *
        // * @param font to use for rendering
        // * @param msg the message to display
        // * @param x, y position of the bottom-left corner of text string in world coordinate space
        // * @param rgba color for the text to render with
        // */
        //void bbutil_render_text(font_t* font, const char* msg, float x, float y, float r, float g, float b, float a);
        [DllImport("BBUtils10")]
        static extern void bbutil_render_text(IntPtr font, char[] msg, float x, float y, float r, float g, float b, float a);

        ///**
        // * Returns the non-scaled width and height of a string
        // * NOTE: must be called after a successful return from bbutil_init() or bbutil_init_egl() call

        // *
        // * @param font to use for measurement of a string size
        // * @param msg the message to get the size of
        // * @param return pointer for width of a string
        // * @param return pointer for height of a string
        // */
        //void bbutil_measure_text(font_t* font, const  char* msg, float* width, float* height);
        [DllImport("BBUtils10")]
        static extern void bbutil_measure_text(IntPtr font, char[] msg, out float width, out float height);

        ///**
        // * Creates and loads a texture from a png file
        // * NOTE: must be called after a successful return from bbutil_init() or bbutil_init_egl() call

        // *
        // * @param filename path to texture png
        // * @param return width of texture
        // * @param return height of texture
        // * @param return gl texture handle
        // * @return EXIT_SUCCESS if texture loading succeeded otherwise EXIT_FAILURE
        // */

        //int bbutil_load_texture(const char* filename, int* width, int* height, float* tex_x, float* tex_y, unsigned int* tex);
        [DllImport("BBUtils10")]
        static extern int bbutil_load_texture(char[] filename, out int width, out int height, out float tex_x, out float tex_y, out IntPtr tex);

        ///**
        // * Returns dpi for a given screen

        // *
        // * @param ctx path libscreen context that corresponds to display of interest
        // * @return dpi for a given screen
        // */

        //int bbutil_calculate_dpi(screen_context_t ctx);
        [DllImport("BBUtils10")]
        static extern int bbutil_calculate_dpi(IntPtr ctx);

        ///**
        // * Rotates the screen to a given angle

        // *
        // * @param angle to rotate screen surface to, must by 0, 90, 180, or 270
        // * @return EXIT_SUCCESS if texture loading succeeded otherwise EXIT_FAILURE
        // */

        //int bbutil_rotate_screen_surface(int angle);
        [DllImport("BBUtils10")]
        static extern int bbutil_rotate_screen_surface(int angle);
        #endregion

        private IntPtr _font;
        private IntPtr _surface;
        public IntPtr Surface
        {
            get { bbutil_get_disp_surf(out _display, out _surface); return _surface; }
        }

        private IntPtr _display;
        public IntPtr Display
        {
            get { bbutil_get_disp_surf(out _display, out _surface); return _display; }
        }

        private Context _contex;
        public Context Context
        {
            get { return _contex; }
        }

        private int _dpi;
        public int DPI
        {
            get { _dpi = bbutil_calculate_dpi(_contex.Handle); return _dpi; }
        }

        public BBUtil(Context ctx)
        {
            _contex = ctx;
            if (bbutil_init_egl(ctx.Handle) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to initialize egl");
        }

        public void Dispose()
        {
            bbutil_terminate();
        }

        public void Swap()
        {
            bbutil_swap();
        }

        public void LoadFont(int size, int dpi, string fontName = "/usr/fonts/font_repository/monotype/arial.ttf")
        {
            _font = bbutil_load_font(fontName.ToCharArray(), size, dpi);
        }

        public void DisposeFont(string fontName = "/usr/fonts/font_repository/monotype/arial.ttf")
        {
            bbutil_destroy_font(_font);
        }

        public void DisplayText(string message, PointF position, Color color)
        {
            bbutil_render_text(_font, message.ToCharArray(), position.X, position.Y, color.R, color.G, color.B, color.A);
        }

        public SizeF MeasureText(string message)
        {
            var res = new SizeF();
            float width = 0;
            float height = 0;
            bbutil_measure_text(_font, message.ToCharArray(), out width, out height);
            res.Height = height;
            res.Width = width;
            return res;
        }

        public RectangleF LoadTexture(string fileName)
        {
            IntPtr handle;
            var res = new RectangleF();
            int height = 0;
            int width = 0;
            float x = 0;
            float y = 0;

            bbutil_load_texture(fileName.ToCharArray(), out width, out height, out x, out y, out handle);

            res.Height = (float)height;
            res.Width = (float)width;
            res.X = x;
            res.Y = y;

            return res;
        }

        public void RotateScreenSurface(int angle)
        {
            if (bbutil_rotate_screen_surface(angle) != (int)BPSResponse.BPS_SUCCESS)
                throw new Exception("Unable to rotate screen.");
        }
    }
}
