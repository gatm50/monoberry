using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices.Screen
{
    public class ScreenDebugging
    {
        //*   @brief Prints a screen packet to a specified file.
        //*
        //*   <b>Function Type:</b>  <a href="manual/rscreen_immediate_execution.xml">Immediate Execution</a>
        //*
        //*   This function prints out the information relevant to the specified packet
        //*   to a specified file.
        //*
        //*   @param  type The type of packet to be printed. The packet must be of type
        //*            Screen_Packet_Types.
        //*   @param  packet The address of the packet to be printed.
        //*   @param  fd The file object where the packet is to be printed to.
        //*
        //*   @return @c 0 upon a reference to the specified window being removed,
        //*           otherwise @c -1 and @c errno is set
        //*/
        //int screen_print_packet(int type, void *packet, FILE *fd);
        [DllImport("screen")]
        public static extern int screen_print_packet(int type, IntPtr packet, IntPtr fd);
    }
}