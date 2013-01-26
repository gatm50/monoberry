using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public partial class Navigator : IDisposable
    {
        #region DllImport
        ///**
        // * @brief Start receiving navigator events
        // *
        // * The @c navigator_request_events() function starts to deliver navigator events
        // * to your application using BPS. Events will be posted to the currently
        // * active channel.
        // *
        // * @param flags The types of events to deliver. A value of zero indicates that
        // * all regular events are requested. A value of @c NAVIGATOR_EXTENDED_DATA
        // * indicates all regular events are requested with extended data being
        // * available and @c navigator_raw_write() being able to send data.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_request_events(int flags);
        [DllImport("bps")]
        static extern int navigator_request_events(int flags);

        ///**
        // * @brief Stop receiving navigator events
        // *
        // * The @c navigator_stop_events() function stops navigator events from being
        // * delivered to the application using BPS.
        // *
        // * @param flags The types of events to stop. A value of zero indicates that all
        // * events are stopped. The meaning of non-zero values is reserved for future
        // * use.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_stop_events(int flags);
        [DllImport("bps")]
        static extern int navigator_stop_events(int flags);

        ///**
        // * @brief Get the unique domain ID for the navigator service
        // *
        // * The @c navigator_get_domain() function gets the unique domain ID for the
        // * navigator service. You can use this function in your application to test
        // * whether an event that you retrieve using @c bps_get_event() is a navigator
        // * event, and respond accordingly.
        // *
        // * @return The domain ID for the navigator service.
        // */
        //BPS_API int navigator_get_domain();
        [DllImport("bps")]
        public static extern int navigator_get_domain();

        ///**
        // * @brief Open a URI in the navigator
        // *
        // * The @c navigator_invoke() function sends a navigator invoke request to
        // * display the contents of the specified URI in the navigator.
        // *
        // * When you specify an application URI, the URI also indicates the context that
        // * you want to open the application in. For example, to open the camera in photo
        // * mode, you can call @c navigator_invoke() with an argument of @c
        // * camera://photo. To open the camera in video mode, you can call @c
        // * navigator_invoke() with an argument of @c camera://video.
        // *
        // * The following sections list the application URIs that you can use when you
        // * call @c navigator_invoke(). @e Note: Spaces or line breaks have been
        // * inserted in the URIs before the & in query strings for readability purposes
        // * and should not be passed into @c navigator_invoke().
        // *
        // * <b>BlackBerry App World</b>
        // * - <tt>appworld://myworld</tt> - Opens BlackBerry App World and loads the My
        // *   World screen
        // * - <tt>appworld://content/12345</tt> - Opens BlackBerry App World and loads
        // *   the Application Details screen for the content with content ID 12345. This
        // *   is the preferred format to invoke BlackBerry App World content
        // * - <tt>appworld://content=12345</tt> - Same as above
        // *
        // * <b>Browser</b>
        // * - <tt>http://<em>URL</em></tt> - Opens the browser and displays the content
        // *   at the specified URL
        // * - <tt>https://<em>URL</em></tt> - Opens the browser and displays the content
        // *   at the specified URL
        // *
        // * <b>Camera</b>
        // * - <tt>camera://photo</tt> - Opens the camera in photo mode
        // * - <tt>camera://video</tt> - Opens the camera in video mode
        // *
        // * <b>Calendar</b>
        // * - <tt>calendar://</tt> - Opens the calendar
        // * - <tt>calendar://showEvent?accountId=<em>account_ID</em>
        // *   &eventId=<em>event_ID</em></tt> - Opens the calendar and displays the event
        // *   with the specified event ID
        // * - <tt>calendar://editEvent?accountId=<em>account_ID</em>
        // *   &eventId=<em>event_ID</em></tt> - Opens the calendar and displays the edit
        // *   screen for the event with the specified event ID
        // * - <tt>calendar://newEvent?accountId=<em>account_ID</em>
        // *   &dateStart=<em>YYYY-MM-DD HH:MM:SS</em>
        // *   &dateEnd=<em>YYYY-MM-DD HH:MM:SS</em>
        // *   &attd=<em>comma_delimited_list_of_email_addresses</em>
        // *   &subj=<em>subject</em>
        // *   &loc=<em>location</em>
        // *   &body=<em>body_of_message</em></tt> - Opens the calendar and displays the
        // *   new event screen with the specified event properties (for example, start
        // *   date, end date, and so on) pre-populated. All properties are optional and
        // *   must be URL encoded
        // *
        // * <b>Maps</b>
        // * - <tt>maps://?where1=<em>address</em></tt> - Opens Bing Maps and displays the
        // *   specified address. The address can include spaces and should not be URL
        // *   encoded
        // * - <tt>maps://?style=<em>style</em></tt> - Opens Bing Maps and changes the map
        // *   view to the specified style ("u": auto (default), this style switches views
        // *   automatically based on zoom level; "a": aerial; "r": road; "h": aerial with
        // *   labels turned on; "o": bird's eye; "b": bird's eye with labels turned on)
        // *
        // * @e Note: You can use these variables in succession by using an ampersand-
        // *   delimited query string (for example,
        // *   <tt>maps://?where1=waterloo ontario&style=h</tt>).
        // *
        // * <b>Messages</b>
        // * - <tt>messages://</tt> - Opens the messages application
        // * - <tt>messages://newMessage?accountId=<em>account_ID</em>
        // *   &to=<em>comma_delimited_list_of_email_addresses</em>
        // *   &cc=<em>comma_delimited_list_of_email_addresses</em>
        // *   &bcc=<em>comma_delimited_list_of_email_addresses</em>
        // *   &body=<em>body_of_message</em>
        // *   &subject=<em>subject_of_message</em></tt> - Opens the messages application
        // *   and displays the compose email screen with the specified message properties
        // *   pre-populated
        // * - <tt>messages://showAccount?accountId=<em>account_ID</em></tt> - Opens the
        // *   messages application and displays the specified account
        // * - <tt>messages://showMessage?accountId=<em>account_ID</em>
        // *   &conversationId=<em>conversation_ID</em>
        // *   &messageId=<em>message_ID</em></tt> - Opens the messages application and
        // *   displays the specified conversation or message
        // * - <tt>mailto:<em>comma_delimited_list_of_email_addresses</em>
        // *   ?to=<em>comma_delimited_list_of_email_addresses</em>
        // *   &cc=<em>comma_delimited_list_of_email_addresses</em>
        // *   &bcc=<em>comma_delimited_list_of_email_addresses</em>
        // *   &body=<em>body_of_message</em>
        // *   &subject=<em>subject_of_message</em></tt> - Creates and sends a message
        // *   with the specified properties
        // *
        // * <b>Music</b>
        // * - <tt>music://albums</tt> - Opens the music application and displays the
        // *   Albums screen
        // * - <tt>music://albums/album?id=<em>album_id</em></tt> - Opens the music
        // *   application and displays the track list that is associated with the
        // *   specified album ID (which maps to the audio_metadata.album_id field of
        // *   mmlibrary)
        // * - <tt>music://albums/album?id=<em>album_ID</em>
        // *   &play=<em>file_ID</em></tt> - Opens the music application, displays the
        // *   track list that is associated with the specified album ID, and begins
        // *   playback at the specified file ID (which maps to the audio_metadata.fid
        // *   field of mmlibrary). If the file ID does not correspond to a track in the
        // *   album, nothing is played
        // * - <tt>music://artists</tt> - Opens the music application and displays the
        // *   Artists screen
        // * - <tt>music://artists/artist?id=<em>artist_ID</em></tt> - Opens the music
        // *   application and displays the track list that is associated with the
        // *   specified artist ID (which maps to the audio_metadata.artist_id field of
        // *   mmlibrary)
        // * - <tt>music://artists/artist?id=<em>artist_ID</em>
        // *   &play=<em>file_ID</em></tt> - Opens the music application, displays the
        // *   track list that is associated with the specified artist ID, and begins
        // *   playback at the specified file ID. If the file ID does not correspond to a
        // *   track in the artist's albums, nothing is played
        // * - <tt>music://genres</tt> - Opens the music application and displays the
        // *   Genres screen
        // * - <tt>music://genres/genre?id=<em>genre_ID</em></tt> - Opens the music
        // *   application and displays the track list that is associated with the
        // *   specified genre ID (which maps to the audio_metadata.genre_id field of
        // *   mmlibrary)
        // * - <tt>music://genres/genre?id=<em>genre_ID</em>
        // *   &play=<em>file_ID</em></tt> - Opens the music application, diplays the
        // *   track list that is associated with the specified genre ID, and begins
        // *   playback at the specified file ID. If the file ID does not correspond to a
        // *   track in the genre, nothing is played
        // * - <tt>music://playlists</tt> - Opens the music application and displays the
        // *   Playlists screen
        // * - <tt>music://playlists/playlist?id=<em>playlist_ID</em></tt> - Opens the
        // *   music application and displays the track list that is associated with the
        // *   specified playlist ID (which maps to the playlist_entries.plid field of
        // *   mmlibrary)
        // * - <tt>music://playlists/playlist?id=<em>playlist_ID</em>
        // *   &play=<em>file_ID</em></tt> - Opens the music application, displays the
        // *   track list that is associated with the specified playlist ID, and begins
        // *   playback at the specified file ID. If the file ID does not correspond to a
        // *   track in the playlist, nothing is played
        // * - <tt>music://songs</tt> - Opens the music application and displays the All
        // *   Songs screen
        // * - <tt>music://songs?play=<em>file_ID</em></tt> - Opens the music application,
        // *   displays the All Songs screen, and begins playback at the specified file ID
        // * - <tt>file_URL</tt> - Opens the music application and begins playback of the
        // *   specified file (for example, /accounts/1000/shared/music/sample.mp3)
        // *
        // * <b>Photos</b>
        // * - <tt>photos://</tt> - Opens the pictures application in the default view.
        // *   The default view is device dependent
        // * - <tt>photos://<em>file_URL</em></tt> - Opens the pictures application and
        // *   displays the specified file in full screen view. If the file doesn't exist,
        // *   the default view is displayed. If the file is located in the Downloads,
        // *   Wallpapers, or Camera folder, or if the file is located in a subfolder in
        // *   the Photos folder, the user can continue navigating from this entry point
        // *   (for example, by swiping to the next or previous image)
        // * - <tt>photos://<em>album_name</em></tt> - Opens the pictures application and
        // *   displays the specified album. If the album doesn't exist, the default view
        // *   is displayed
        // *
        // * <b>Videos</b>
        // * - <tt>videos://recorded</tt> - Opens the videos application and displays the
        // *   Recorded Videos tab
        // * - <tt>videos://<em>file_URL</em></tt> - Opens the videos application and
        // *   plays the specified file
        // *
        // * <b>Music Store</b>
        // * - <tt>musicstore://search=<em>album_search_string</em></tt> - Opens the Music
        // *   Store and displays the album search results for the specified string
        // * - <tt>musicstore://search/song=<em>song_search_string</em></tt> - Opens the
        // *   Music Store and displays the song search results for the specified string
        // * - <tt>musicstore://search/artist=<em>artist_search_string</em></tt> - Opens
        // *   the Music Store and displays the artist search results for the specified
        // *   string
        // *
        // * <b>Settings</b>
        // * - <tt>settings://about</tt> - Displays the About screen
        // * - <tt>settings://airplane</tt> - Displays the Airplane Mode screen
        // * - <tt>settings://enterprise</tt> - Displays the Enterprise/Balance screen
        // * - <tt>settings://wifi</tt> - Displays the Wi-Fi screen
        // * - <tt>settings://softwareupdate</tt> - Displays the Software Updates screen
        // * - <tt>settings://bluetooth</tt> - Displays the Bluetooth screen
        // * - <tt>settings://bb_bridge</tt> - Displays the BlackBerry Bridge screen
        // * - <tt>settings://internettethering</tt> - Displays the Internet Tethering
        // *                                           screen
        // * - <tt>settings://screen</tt> - Displays the Screen screen
        // * - <tt>settings://hdmi</tt> - Displays the HDMI screen
        // * - <tt>settings://sounds</tt> - Displays the Sounds screen
        // * - <tt>settings://general</tt> - Displays the General screen
        // * - <tt>settings://storagesharing</tt> - Displays the Storage & Sharing screen
        // * - <tt>settings://security</tt> - Displays the Security screen
        // * - <tt>settings://language</tt> - Displays the Language screen
        // * - <tt>settings://keyboard</tt> - Displays the Keyboard screen
        // * - <tt>settings://date_time</tt> - Displays the Date & Time screen
        // * - <tt>settings://pim</tt> - Displays the PIM Account screen
        // * - <tt>settings://pim/listAccounts</tt> - Displays the PIM Account screen
        // * - <tt>settings://pim/defaultAccounts</tt> - Displays the PIM Default Accounts
        // *                                             screen
        // * - <tt>settings://pim/createAccount</tt> - Displays the PIM New Account screen
        // * - <tt>settings://pim/showAccount?id=<em>account_ID</em></tt> - Displays the
        // *   PIM Edit Account screen for the specified account ID
        // *
        // * <b>Video Chat</b>
        // * - <tt>vchat://URI?camera=<em>camera_param</em>
        // *   &displayname=<em>displayname_param</em>
        // *   &callingApplication=<em>callingApplication_param</em></tt> - Opens the
        // *   Video Chat application and places a call with the specified parameters. The
        // *   URI is the destination of the call, and is required. Possible optional
        // *   parameters include "camera": "on" to place a video call, "off" to place an
        // *   audio only call; "displayname": display name to associate with the contact;
        // *   "smallimage": path to a small image of the contact; "largeimage": path to a
        // *   large image of the contact; "originalImage": path to the original image of
        // *   the contact; "callingApplication": name of the application that's starting
        // *   the call (for example, BBM)
        // *
        // * @param url The URI to invoke.
        // * @param err If this function fails, and if @c err is not null, it will be set
        // * to a short description of the error. The caller must free this buffer using
        // * @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE upon failure with a short
        // * description of the error in @c err.
        // */
        //BPS_API int navigator_invoke(const char *url, char **err);
        [DllImport("bps")]
        static extern int navigator_invoke(char[] url, /*out*/ IntPtr err);

        ///**
        // * @brief Open a file in the navigator
        // *
        // * The @c navigator_open_file() function sends a navigator openFile request to
        // * open the specified file in the navigator.
        // *
        // * @param filepath The path of the file to open.
        // * @param err If this function fails, and if @c err is not null, it will be set
        // * to a short description of the error. The caller must free this buffer using
        // * @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE upon failure with a short
        // * description of the error in @c err.
        // */
        //BPS_API int navigator_open_file(const char *filepath, char **err);
        [DllImport("bps")]
        static extern int navigator_open_file(char[] filepath, /*out*/ IntPtr err);

        ///**
        // * @brief Create a navigator icon that starts an application using the URL field
        // *
        // * The @c navigator_add_uri() function create an icon in one of the navigator
        // * trays that starts an application using the URL field.
        // *
        // * @param icon_path The path to the icon image.
        // * @param icon_label The label to apply to the icon image.
        // * @param default_category The navigator tray that the icon should appear in.
        // * @param url The URL that the application should launch.
        // * @param err If this function fails, and if @c err is not null, it will be set
        // * to a short description of the error. The caller must free this buffer using
        // * @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE upon failure with a short
        // * description of the error in @c err.
        // */
        //BPS_API int navigator_add_uri(const char *icon_path, const char *icon_label, const char *default_category, const char *url, char **err);
        [DllImport("bps")]
        static extern int navigator_add_uri(string icon_path,
                                            string icon_label,
                                            string default_category,
                                            string url,
                                            /*out*/ IntPtr err);

        ///**
        // * @brief Extend the time allowed for the application to create its application
        // * window at application start
        // *
        // * The @c navigator_extend_timeout() function sends a navigator extendTimeout
        // * request to extend the time allowed for the application to create its
        // * application window at application start. Normally, the application gets 30
        // * seconds to create its application window. If the application is unable to
        // * create windows in this time frame due to initialization or loading issues, it
        // * must request an extension to the normal timeout, otherwise it will be
        // * terminated.
        // *
        // * @param extension The total time in milliseconds that the application expects
        // * to need before it can create its application window.
        // * @param err If this function fails, and if @c err is not null, it will be set
        // * to a short description of the error. The caller must free this buffer using
        // * @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE upon failure with a short
        // * description of the error in @c err.
        // */
        //BPS_API int navigator_extend_timeout(int extension, char **err);
        [DllImport("bps")]
        static extern int navigator_extend_timeout(int extension, /*out*/ IntPtr err);

        ///**
        // * @brief Extend the time allowed for the application to exit before it is
        // * forcibly terminated
        // *
        // * The @c navigator_extend_terminate() function sends a navigator
        // * extendTerminate request to extend the time allowed for the application to
        // * exit before it is forcibly terminated. Normally, the application gets 3
        // * seconds after receiving a @c NAVIGATOR_EXIT message to exit properly. If the
        // * application requires more than this amount of time, it should call this
        // * function to get additional time. Each time this function is called, the
        // * application will receive another 2 seconds before it is terminated. This
        // * function can be called in a loop during the exit cleanup procedure to prevent
        // * premature termination. It allows the application to save its state properly.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_extend_terminate(void);
        [DllImport("bps")]
        static extern int navigator_extend_terminate();

        ///**
        // * @brief Send a navigator SWIPE_START request
        // *
        // * The @c navigator_request_swipe_start() function sends a navigator SWIPE_START
        // * request. The navigator will send SWIPE_START events instead of SWIPE_DOWN
        // * events.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_request_swipe_start();
        [DllImport("bps")]
        static extern int navigator_request_swipe_start();

        ///**
        // * @brief Stop the navigator from sending SWIPE_START events
        // *
        // * The @c navigator_stop_swipe_start() function stops the navigator from sending
        // * SWIPE_START events. The navigator will return to sending SWIPE_DOWN events.
        // *
        // * @see @c navigator_request_swipe_start()
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_stop_swipe_start();
        [DllImport("bps")]
        static extern int navigator_stop_swipe_start();

        ///**
        // * @brief Specify the orientation of your application as locked or not locked
        // *
        // * The @c navigator_rotation_lock() function specifies to the navigator whether
        // * your application's orientation is locked or not locked.
        // *
        // * @param locked If @c true the orientation of your application is locked, if @c
        // * false the orientation of your application is not locked.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_rotation_lock(bool locked);
        [DllImport("bps")]
        static extern int navigator_rotation_lock(bool locked);

        ///**
        // * @brief Set the orientation in the navigator based on angle
        // *
        // * The @c navigator_set_orientation() function sends a navigator orientation
        // * request to set the orientation in the navigator.
        // *
        // * @param angle The angle of the orientation to set: @c NAVIGATOR_TOP_UP,
        // * @c NAVIGATOR_RIGHT_UP, @c NAVIGATOR_LEFT_UP, @c NAVIGATOR_BOTTOM_UP.
        // * @param id If not null, the ID used in the orientation request will be
        // * returned in @c id. The caller must free this buffer using @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_orientation(int angle, char **id);
        [DllImport("bps")]
        static extern int navigator_set_orientation(int angle, /*out*/ IntPtr id);

        ///**
        // * @brief Set the orientation in the navigator based on landscape or portrait
        // *
        // * The @c navigator_set_orientation_mode() function sends a navigator
        // * orientation request to set the orientation in the navigator to the chosen
        // * mode (@c NAVIGATOR_LANDSCAPE, or @c NAVIGATOR_PORTRAIT).
        // *
        // * @param mode @c NAVIGATOR_LANDSCAPE, @c NAVIGATOR_PORTRAIT.
        // * @param id If not null, the ID used in the orientation request will be
        // * returned in @c id. The caller must free this buffer using @c bps_free().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_orientation_mode(int mode, char **id);
        [DllImport("bps")]
        static extern int navigator_set_orientation_mode(int mode, /*out*/ IntPtr id);

        ///**
        // * @brief Set the window angle in the navigator
        // *
        // * The @c navigator_set_window_angle() function sends a navigator windowAngle
        // * request to set the angle of the application window in the navigator. When
        // * using this function, it is expected that the application does its rotation
        // * internally. In this case, the application should maintain a @c
        // * SCREEN_PROPERTY_ROTATION value of 0, do its rotations internally, and report
        // * back the angle of rotation to the navigator so that it remains in sync.
        // *
        // * @param angle The angle of the window to set.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_window_angle(int angle);
        [DllImport("bps")]
        static extern int navigator_set_window_angle(int angle);

        ///**
        // * @brief Set the close prompt in the navigator
        // *
        // * The @c navigator_set_close_prompt() function sends a navigator closePrompt
        // * request to set the contents of the close prompt dialog. This function allows
        // * an application to prevent the user from closing the application without
        // * warning. If the user tries to close the application, a dialog will be
        // * displayed with the title and message specified. The user will have 2 buttons:
        // * "Cancel" and "Close". If the user selects Close, the application will receive
        // * an "exit" message. If the user selects Cancel, the dialog will close and the
        // * application will continue running. This function can be called as many times
        // * as needed if the application's state changes.
        // *
        // * @param title The title of the close prompt dialog to set.
        // * @param message The message of the close prompt dialog to set.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_close_prompt(const char *title, const char *message);
        [DllImport("bps")]
        static extern int navigator_set_close_prompt(char[] title, char[] message);

        ///**
        // * @brief Clear the close prompt in the navigator
        // *
        // * The @c navigator_clear_close_prompt() function sends a navigator closePrompt
        // * request to clear the contents of the close prompt dialog. If the close
        // * prompt dialog has been cleared, no close prompt dialog will appear when the
        // * user tries to close the application.
        // *
        // * @see @c navigator_set_close_prompt()
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_clear_close_prompt();
        [DllImport("bps")]
        static extern int navigator_clear_close_prompt();

        ///**
        // * @brief Set a badge on the application's icon and window frame in the
        // * navigator
        // *
        // * The @c navigator_set_badge() function sends a navigator addBadge request to
        // * place a badge on the application's icon and window frame in the navigator.
        // *
        // * @param badge The badge to set.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_badge(navigator_badge_t badge);
        [DllImport("bps")]
        static extern int navigator_set_badge(BadgeType badge);

        ///**
        // * @brief Clears a badge from the application's icon and window frame in the
        // * navigator
        // *
        // * The @c navigator_clear_badge() function sends a navigator removeBadge request
        // * to remove a badge from the application's icon and window frame in the
        // * navigator.
        // *
        // * @see @c navigator_set_badge()
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_clear_badge();
        [DllImport("bps")]
        static extern int navigator_clear_badge();

        ///**
        // * @brief Turns keyboard tracking on or off.
        // *
        // * The @c navigator_set_keyboard_tracking() function turns keyboard tracking on
        // * or off. When keyboard tracking is on, the application will receive
        // * additional @c NAVIGATOR_KEYBOARD_POSITION events as the keyboard is sliding.
        // * These additional events are only sent if the application is currently
        // * full-screen.
        // *
        // * @param track Whether to turn tracking on or off.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_set_keyboard_tracking(bool track);
        [DllImport("bps")]
        static extern int navigator_set_keyboard_tracking(bool track);

        ///**
        // * @brief Get the severity of a NAVIGATOR_LOW_MEMORY event
        // *
        // * The @c navigator_event_get_severity() function extracts the current
        // * severity from a @c NAVIGATOR_LOW_MEMORY event.
        // *
        // * @param event The @c NAVIGATOR_LOW_MEMORY event to extract the severity
        // * from.
        // *
        // * @return The severity (increasing amounts indicates a higher level of
        // * severity) from the event.  BPS_FAILURE if the severity cannot be retrieved
        // * from the given event.
        // */
        //BPS_API int navigator_event_get_severity(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_severity(IntPtr _event);

        ///**
        // * @brief Get the current window state from an event
        // *
        // * The @c navigator_event_get_window_state() function extracts the current
        // * window state from a @c NAVIGATOR_WINDOW_STATE event.
        // *
        // * @param event The @c NAVIGATOR_WINDOW_STATE event to extract the window state
        // * from.
        // *
        // * @return The window state from the event.
        // */
        //BPS_API navigator_window_state_t navigator_event_get_window_state(bps_event_t *event);
        [DllImport("bps")]
        static extern WindowState navigator_event_get_window_state(IntPtr _event);

        ///**
        // * @brief Get the group ID from an event
        // *
        // * The @c navigator_event_get_groupid() function extracts the group ID from a @c
        // * NAVIGATOR_WINDOW_STATE, @c NAVIGATOR_WINDOW_ACTIVE, or @c
        // * NAVIGATOR_WINDOW_INACTIVE event.
        // *
        // * @param event The @c NAVIGATOR_WINDOW_STATE, @c NAVIGATOR_WINDOW_ACTIVE, or @c
        // * NAVIGATOR_WINDOW_INACTIVE event to extract the group ID from.
        // *
        // * @return The group ID from the event.
        // */
        //BPS_API const char *navigator_event_get_groupid(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_groupid(IntPtr _event);

        ///**
        // * @brief Get the orientation angle from a navigator event
        // *
        // * The @c navigator_event_get_orientation_angle() function extracts the
        // * orientation angle from a @c NAVIGATOR_ORIENTATION, @c
        // * NAVIGATOR_ORIENTATION_CHECK, @c NAVIGATOR_ORIENTATION_DONE, or @c
        // * NAVIGATOR_ORIENTATION_RESULT event.
        // *
        // * @param event The @c NAVIGATOR_ORIENTATION, @c NAVIGATOR_ORIENTATION_CHECK, @c
        // * NAVIGATOR_ORIENTATION_DONE, or @c NAVIGATOR_ORIENTATION_RESULT event to
        // * extract the orientation angle from.
        // *
        // * @return The orientation angle from the event.
        // */
        //BPS_API int navigator_event_get_orientation_angle(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_orientation_angle(IntPtr _event);
        
        ///**
        // * @brief Get the orientation mode from a navigator event
        // *
        // * The @c navigator_event_get_orientation_mode() functions extracts the
        // * orientation mode from a @c NAVIGATOR_ORIENTATION, or @c
        // * NAVIGATOR_ORIENTATION_CHECK event. The result is one of @c
        // * NAVIGATOR_LANDSCAPE or @c NAVIGATOR_PORTRAIT.
        // *
        // * @param event The @c NAVIGATOR_ORIENTATION, or @c NAVIGATOR_ORIENTATION_CHECK
        // * event.
        // *
        // * @return @c NAVIGATOR_LANDSCAPE, or @c NAVIGATOR_PORTRAIT
        // */
        //BPS_API int navigator_event_get_orientation_mode(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_orientation_mode(IntPtr _event);

        ///**
        // * @brief Get the keyboard state from a navigator event
        // *
        // * The @c navigator_event_get_keyboard_state() function extracts the keyboard
        // * state from a @c NAVIGATOR_KEYBOARD_STATE event. The result is one of the
        // * values of the @c navigator_keyboard_state enum.
        // *
        // * @param event The @c NAVIGATOR_KEYBOARD_STATE event.
        // *
        // * @return The state of the keyboard or @c BPS_FAILURE if there was an error.
        // */
        //BPS_API int navigator_event_get_keyboard_state(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_keyboard_state(IntPtr _event);

        ///**
        // * @brief Get the keyboard position from a navigator event
        // *
        // * The @c navigator_event_get_keyboard_position() function extracts the keyboard
        // * position from a @c NAVIGATOR_KEYBOARD_POSITION event. The keyboard position
        // * is the y offset in pixels of the top of the keyboard.
        // *
        // * @param event The @c NAVIGATOR_KEYBOARD_POSITION event.
        // *
        // * @return The y offset in pixels of the top of the keyboard or @c BPS_FAILURE
        // * if there was an error.
        // */
        //BPS_API int navigator_event_get_keyboard_position(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_keyboard_position(IntPtr _event);

        ///**
        // * @brief Get the height of the window cover
        // *
        // * The function @c navigator_event_get_window_cover_height() extracts the
        // * height of the window cover from a @c NAVIGATOR_WINDOW_COVER event.
        // *
        // * @param event The @c NAVIGATOR_WINDOW_COVER event.
        // * @return On success, the height of the window cover. Otherwise, @c
        // * BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_event_get_window_cover_height(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_window_cover_height(IntPtr _event);

        ///**
        // * @brief Get the width of the window cover
        // *
        // * The function @c navigator_event_get_window_cover_width() extract the width
        // * of the window cover from a @c NAVIGATOR_WINDOW_COVER event.
        // *
        // * @param event The @c NAVIGATOR_WINDOW_COVER event.
        // * @return On success, the width of the window cover. Otherwise, @c
        // * BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_event_get_window_cover_width(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_window_cover_width(IntPtr _event);

        ///**
        // * @brief Get the data from a navigator invoke event
        // *
        // * The @c navigator_event_get_data() function extracts the data from a @c
        // * NAVIGATOR_INVOKE event.
        // *
        // * @param event The @c NAVIGATOR_INVOKE event to extract the data from.
        // *
        // * @return The data field from the event.
        // */
        //BPS_API const char *navigator_event_get_data(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_data(IntPtr _event);

        ///**
        // * @brief Get the ID from a navigator event
        // *
        // * The @c navigator_event_get_id() function extracts the ID from the
        // * following events:
        // * - @c NAVIGATOR_ORIENTATION
        // * - @c NAVIGATOR_ORIENTATION_CHECK
        // * - @c NAVIGATOR_ORIENTATION_RESULT
        // * - @c NAVIGATOR_INVOKE_TARGET_RESULT
        // * - @c NAVIGATOR_INVOKE_QUERY_RESULT
        // * - @c NAVIGATOR_INVOKE_VIEWER_RESULT
        // * - @c NAVIGATOR_INVOKE_VIEWER_RELAY
        // * - @c NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT
        // * - @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT
        // * - @c NAVIGATOR_INVOKE_SET_FILTERS_RESULT
        // *
        // * @param event The event to extract the ID from.
        // *
        // * @return The ID field from the event.
        // */
        //BPS_API const char *navigator_event_get_id(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_id(IntPtr _event);

        ///**
        // * @brief Get the error message from a navigator event
        // *
        // * The @c navigator_event_get_err() function extracts the error message from the
        // * the following events:
        // * - @c NAVIGATOR_ORIENTATION_RESULT
        // * - @c NAVIGATOR_INVOKE_TARGET_RESULT
        // * - @c NAVIGATOR_INVOKE_QUERY_RESULT
        // * - @c NAVIGATOR_INVOKE_VIEWER_RESULT
        // * - @c NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT
        // * - @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT
        // * - @c NAVIGATOR_INVOKE_SET_FILTERS_RESULT
        // *
        // * @param event The event to extract the error message from.
        // *
        // * @return The error message from the event, or @c NULL if there is no
        // * error message.
        // */
        //BPS_API const char *navigator_event_get_err(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_err(IntPtr _event);

        ///**
        // * @brief Specify whether your application intends to rotate
        // *
        // * The @c navigator_orientation_check_response() function specifies to the
        // * navigator whether or not your application intends to rotate. If you respond
        // * with @c true (that your application intends to rotate) then the navigator
        // * will send you a follow-up @c NAVIGATOR_ORIENTATION event when it is time for
        // * your application to resize its screen.
        // *
        // * @param event The @c NAVIGATOR_ORIENTATION_CHECK event.
        // * @param will_rotate If @c true your application intends to rotate, if @c false
        // * your application does not intend to rotate.
        // */
        //BPS_API void navigator_orientation_check_response(bps_event_t *event, bool will_rotate);
        [DllImport("bps")]
        static extern void navigator_orientation_check_response(IntPtr _event, bool will_rotate);

        ///**
        // * @brief Specify whether your application intends to rotate
        // *
        // * The @c navigator_orientation_check_response_id() function specifies to the
        // * navigator whether or not your application intends to rotate. If you respond
        // * with @c true (that your application intends to rotate) then the navigator
        // * will send you a follow-up @c NAVIGATOR_ORIENTATION event when it is time for
        // * your application to resize its screen.
        // *
        // * This function provides an alternative to the
        // * @c navigator_orientation_check_response() function, which requires the
        // * @c NAVIGATOR_ORIENTATION_CHECK event to be passed in. In the case where the
        // * @c NAVIGATOR_ORIENTATION_CHECK event will no longer be available to be passed
        // * in, the @c id can be retrieved from it, stored, and used in this function.
        // *
        // * @param id The ID, as retrieved from the @c NAVIGATOR_ORIENTATION_CHECK event
        // * using @c navigator_event_get_id().
        // * @param will_rotate If @c true your application intends to rotate, if @c false
        // * your application does not intend to rotate.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_orientation_check_response_id(const char *id, bool will_rotate);
        [DllImport("bps")]
        static extern int navigator_orientation_check_response_id(char[] id, bool will_rotate);

        ///**
        // * @brief Indicate that your application is finished rotating
        // *
        // * The @c navigator_done_orientation() function indicates to the navigator that
        // * your application is finished rotating. After receiving a @c
        // * NAVIGATOR_ORIENTATION event, and after your application has resized its
        // * screen, this function lets the navigator know that you are finished your
        // * rotation.
        // *
        // * @param event The original @c NAVIGATOR_ORIENTATION event.
        // */
        //BPS_API void navigator_done_orientation(bps_event_t *event);
        [DllImport("bps")]
        static extern void navigator_done_orientation(IntPtr _event);

        ///**
        // * @brief Indicate that your application is finished rotating
        // *
        // * The @c navigator_done_orientation_id() function indicates to the navigator
        // * that your application is finished rotating. After receiving a @c
        // * NAVIGATOR_ORIENTATION event, and after your application has resized its
        // * screen, this function lets the navigator know that you are finished your
        // * rotation.
        // *
        // * This function provides an alternative to the @c navigator_done_orientation()
        // * function, which requires the @c NAVIGATOR_ORIENTATION event to be
        // * passed in. In the case where the @c NAVIGATOR_ORIENTATION event will no
        // * longer be available to be passed in, the @c id can be retrieved from it,
        // * stored, and used in this function.
        // *
        // * @param id The ID, as retrieved from the original @c NAVIGATOR_ORIENTATION
        // * event using @c navigator_event_get_id().
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_done_orientation_id(const char *id);
        [DllImport("bps")]
        static extern int navigator_done_orientation_id(char[] id);

        ///**
        // * @brief Inform navigator that the app wishes to exit
        // *
        // * An application should call this function when it is ready to terminate.
        // * The application should then wait until it receives a @c NAVIGATOR_EXIT
        // * event before shutting down.
        // *
        // * @return @c BPS_SUCCESS upon succes, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_close_window(void);
        [DllImport("bps")]
        static extern int navigator_close_window();

        ///**
        // * @brief Query the navigator to determine the lock state
        // *
        // * An application can call this function to determine if the device is
        // * currently @c NAVIGATOR_DEVICE_LOCK_STATE_UNLOCKED, @c
        // * NAVIGATOR_DEVICE_LOCK_STATE_SCREEN_LOCKED, or @c
        // * NAVIGATOR_DEVICE_LOCK_STATE_PASSWORD_LOCKED. An application can also
        // * monitor @c NAVIGATOR_DEVICE_LOCK_STATE events.
        // *
        // * @return On success, one of @c NAVIGATOR_DEVICE_LOCK_STATE_UNLOCKED, @c
        // * NAVIGATOR_DEVICE_LOCK_STATE_SCREEN_LOCKED, or @c
        // * NAVIGATOR_DEVICE_LOCK_STATE_PASSWORD_LOCKED. Otherwise, return @c
        // * BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_get_device_lock_state(void);
        [DllImport("bps")]
        static extern int navigator_get_device_lock_state();

        ///**
        // * @brief Sends data to the navigator service
        // *
        // * The data will only be sent if @c navigator_request_events() was called
        // * with @c NAVIGATOR_EXTENDED_DATA.
        // *
        // * @param data The data to be sent.
        // * @param length The length of the data.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // * otherwise.
        // */
        //BPS_API int navigator_raw_write(const char * data, unsigned int length);
        [DllImport("bps")]
        static extern int navigator_raw_write(char[] data, int length);

        ///**
        // * @brief Gets extended data from the event if it is available
        // *
        // * @param event The original event.
        // *
        // * @return A buffer of extended data, @c NULL if no data was available and
        // * with @c errno set if there was some other error. The BPS library holds
        // * ownership of the returned buffer and will destroy it upon destruction
        // * of the event.
        // */
        //BPS_API const char * navigator_event_get_extended_data(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_extended_data(IntPtr _event);

        ///**
        // * @brief Gets the extended data's length from the event if it is available
        // *
        // * @param event The original event.
        // *
        // * @return The number of bytes of extended data that is available, 0 if no
        // * data is available. Note that if you wish to allocate a buffer and copy
        // * the extended data with a null terminator, you should add 1 to the
        // * value returned.
        // */
        //BPS_API unsigned int navigator_event_get_extended_data_length(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_extended_data_length(IntPtr _event);

        ///**
        // * @brief Get the device lock state from a @c NAVIGATOR_DEVICE_LOCK_STATE
        // * event.
        // *
        // * @param event A @c NAVIGATOR_DEVICE_LOCK_STATE event
        // * @return On success, one of @c navigator_device_lock_state_t, otherwise @c
        // * BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_event_get_device_lock_state(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_device_lock_state(IntPtr _event);

        ///**
        // * @brief Get the app state from a NAVIGATOR_APP_STATE event.
        // *
        // * This function can be called when a @c NAVIGATOR_APP_STATE event occurs.  The
        // * result tells the caller which run partition the application is in (for the
        // * case of @c NAVIGATOR_APP_BACKGROUND, or @c NAVIGATOR_APP_FOREGROUND) or which
        // * partititon the application will be put into shortly (in the case of
        // * @c NAVIGATOR_APP_STOPPING).
        // *
        // * @param event The @c NAVIGATOR_APP_STATE event.
        // * @return One of @c navigator_app_state_t, or @c BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_event_get_app_state(bps_event_t *event);
        [DllImport("bps")]
        static extern int navigator_event_get_app_state(IntPtr _event);

        ///**
        // * @brief Create a @c navigator_window_cover_attribute_t
        // *
        // * Create a handle to be used with @c navigator_window_cover_update().
        // *
        // * @param attribute To be filled with the attribute handle
        // * @return On success returns @c BPS_SUCCESS with the attribute set.
        // * Otherwise, @c BPS_FAILURE with errno set.
        // */
        //BPS_API int navigator_window_cover_attribute_create(navigator_window_cover_attribute_t **attribute);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_create(out IntPtr attribute);

        ///**
        // * @brief Destroy a window cover attribute handle
        // *
        // * The attribute handle is not needed after a call to @c
        // * navigator_window_cover_update() so it can be safely destroyed. If any label
        // * handles exist, they should be destroyed by calling @c
        // * navigator_window_cover_label_destroy() before calling this function.
        // *
        // * @param attribute The window cover attribute handle.
        // * @return On success, @c BPS_SUCCESS. On failure, @c BPS_FAILURE with errno set
        // *         and attribute will still be valid.
        // */
        //BPS_API int navigator_window_cover_attribute_destroy(navigator_window_cover_attribute_t *attribute);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_destroy(IntPtr attribute);

        ///**
        // * @brief Set the window cover to live
        // *
        // * There are 4 modes for covers. Live, file, capture, or alternate window.
        // * If live is set, file and capture attributes are disabled. Note, special
        // * permission is required to be able to set the window cover to live.
        // *
        // * @param attribute The window cover attribute handle.
        // * @return On success, return @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with
        // *         errno set, and the attribute will not be changed.
        // */
        //BPS_API int navigator_window_cover_attribute_set_live(navigator_window_cover_attribute_t *attribute);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_live(IntPtr attribute);

        ///**
        // * @brief Set the window cover to use an alternate window
        // *
        // * There are 4 modes for covers. Live, file, capture, or alternate window.
        // * If alternate window is set, capture and file path attributes are discarded.
        // * The alternate window is specified by using the
        // * SCREEN_PROPERTY_ALTERNATE_WINDOW property.
        // *
        // * @param attribute The window cover attribute handle.
        // * @return On success, return @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with
        // *         errno set, and the attribute will not be changed.
        // */
        //BPS_API int navigator_window_cover_attribute_set_alternate_window(navigator_window_cover_attribute_t *attribute);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_alternate_window(IntPtr attribute);

        ///**
        // * @brief Set the window cover image using a file
        // *
        // * There are 4 modes for covers: live, file, capture, or alternate window. If
        // * an image file is being used, live and capture will be disabled.
        // *
        // * @param attribute The window cover attribute handle.
        // * @param file Path to an image file that will be used as the cover.
        // * @return On success return @c BPS_SUCCESS. Otherwise, return @c BPS_FAILURE
        // *         with errno set, the file will not be changed.
        // */
        //BPS_API int navigator_window_cover_attribute_set_file(navigator_window_cover_attribute_t *attribute, const char *file);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_file(IntPtr attribute, char[] file);

        ///**
        // * @brief Set the window cover capture size
        // *
        // * There are 4 modes for covers: live, file, capture, or alternate window. If
        // * a capture is being used, live and image file will be disabled. When using a
        // * capture, the portion of the screen to use is provided by x, y, width, and
        // * height parameters. Navigator will scale the image appropriately if it
        // * doesn't correspond to the proper window cover width and height.
        // *
        // * @param attribute The window cover attribute handle.
        // * @param x The X-axis origin
        // * @param y The Y-axis origin
        // * @param width The capture width
        // * @param height The capture height
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and attribute will be unchanged.
        // */
        //BPS_API int navigator_window_cover_attribute_set_capture(navigator_window_cover_attribute_t *attribute, int x, int y, int width, int height);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_capture(IntPtr attribute, int x, int y, int width, int height);

        ///**
        // * @brief Set whether badges will be allowed on the window cover
        // *
        // * Choose whether to allow badges on the window cover.
        // *
        // * @param attribute The window cover attribute handle.
        // * @param is_allowed True if badges are to be allowed. False if no badges are
        // * allowed.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and the attribute will be unchanged.
        // */
        //BPS_API int navigator_window_cover_attribute_set_allow_badges(navigator_window_cover_attribute_t *attribute, bool is_allowed);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_allow_badges(IntPtr attribute, bool is_allowed);

        ///**
        // * @brief Set the type of transition to use when displaying a new window cover
        // *
        // * Determines which transition to use when displaying a new window cover. The
        // * transition will only occur when an application already has a window cover
        // * being displayed, and it is being replaced by this new window cover. The new
        // * cover is displayed on a call to @c navigator_window_cover_update().
        // *
        // * @param attribute The window cover attribute handle.
        // * @param transition One of @c navigator_window_cover_transition_t. The
        // * transition is applied when the existing cover is updated with this cover
        // * through @c navigator_window_cover_update().
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and the attribute will be unchanged.
        // */
        //BPS_API int navigator_window_cover_attribute_set_transition(navigator_window_cover_attribute_t *attribute, int transition);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_set_transition(IntPtr attribute, int transition);

        ///**
        // * @brief Add a label to the window cover
        // *
        // * Add a label to the window cover. This function will set a handle to the
        // * newly added label. With the label handle, the user can change various label
        // * settings.
        // *
        // * @param attribute The window cover attribute handle.
        // * @param text The text for the label.
        // * @param label The window cover label handle.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         the attribute will be unchanged, and the label will be invalid.
        // */
        //BPS_API int navigator_window_cover_attribute_add_label(navigator_window_cover_attribute_t *attribute, const char *text, navigator_window_cover_label_t **label);
        [DllImport("bps")]
        static extern int navigator_window_cover_attribute_add_label(IntPtr attribute, char[] text, out IntPtr label);

        ///**
        // * @brief Destroy the window cover label handle
        // *
        // * Destroys the label handle that was created by @c
        // * navigator_window_cover_attribute_add_label()
        // *
        // * @param label The window cover label handle.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and label will still be valid.
        // */
        //BPS_API int navigator_window_cover_label_destroy(navigator_window_cover_label_t *label);
        [DllImport("bps")]
        static extern int navigator_window_cover_label_destroy(IntPtr label);

        ///**
        // * @brief Set the label text color
        // *
        // * Sets the color to use for the label text.
        // *
        // * @param label The window cover label handle.
        // * @param red Red color component.
        // * @param green Green color component.
        // * @param blue Blue color component.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set
        // *         and the label will not be changed.
        // */
        //BPS_API int navigator_window_cover_label_set_color(navigator_window_cover_label_t *label, uint8_t red, uint8_t green, uint8_t blue);
        [DllImport("bps")]
        static extern int navigator_window_cover_label_set_color(IntPtr label, int red, int green, int blue);

        ///**
        // * @brief Set the label text
        // *
        // * Changes the text for the label.
        // *
        // * @param label The window cover label handle.
        // * @param text The window cover text to use.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and the label will remain unchanged.
        // */
        //BPS_API int navigator_window_cover_label_set_text(navigator_window_cover_label_t *label, const char *text);
        [DllImport("bps")]
        static extern int navigator_window_cover_label_set_text(IntPtr label, char[] text);

        ///**
        // * @brief Set the size of the label's text
        // *
        // * Set the font size for the label's text. Must be a value larger than 0.
        // *
        // * @param label The window cover label handle.
        // * @param size The size of the text.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and the label will remain unchanged.
        // */
        //BPS_API int navigator_window_cover_label_set_size(navigator_window_cover_label_t *label, int size);
        [DllImport("bps")]
        static extern int navigator_window_cover_label_set_size(IntPtr label, int size);

        ///**
        // * @brief Set whether text will wrap
        // *
        // * If true, long text will wrap. If false, long text will be truncated.
        // *
        // * @param label The window cover label handle.
        // * @param wrap_text True for text to wrap. False for text not to wrap.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set,
        // *         and the label will remain unchanged.
        // */
        //BPS_API int navigator_window_cover_label_set_wrap_text(navigator_window_cover_label_t *label, bool wrap_text);
        [DllImport("bps")]
        static extern int navigator_window_cover_label_set_wrap_text(IntPtr label, bool wrap_text);

        ///**
        // * @brief Update the window cover used by the navigator
        // *
        // * When a @c NAVIGATOR_WINDOW_COVER_ENTER event occurs the app has a window
        // * cover being displayed. By default, this is a scaled down version of the
        // * application's screen. An application can call this function to change
        // * what is used for the app's window cover.
        // *
        // * @param attribute A window cover attribute handle.
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno set
        // *         and the window cover will not be changed.
        // */
        //BPS_API int navigator_window_cover_update(navigator_window_cover_attribute_t *attribute);
        [DllImport("bps")]
        static extern int navigator_window_cover_update(IntPtr attribute);

        ///**
        // * @brief Reset the window cover to the system default
        // *
        // * This will reset the window to the system default. Any changes that were
        // * applied using calls to navigator_window_cover_update() will be reset.
        // *
        // * @return On success, @c BPS_SUCCESS. Otherwise, @c BPS_FAILURE with errno
        // * set and the window cover will not be reset.
        // */
        //BPS_API int navigator_window_cover_reset(void);
        [DllImport("bps")]
        static extern int navigator_window_cover_reset();

        ///**
        // * @brief Request the Navigator to perform the card peek action
        // *
        // * The @c navigator_card_peek() function sends a request to the Navigator to
        // * perform a card peek action of a given type. Peeking is the ability to see
        // * behind a card using a gesture to drag the card off screen and expose the
        // * card's parent or root (depending on the type of peek action). Call this
        // * function from the card application to trigger a @c
        // * NAVIGATOR_CARD_PEEK_STARTED event.
        // *
        // * @param peek_type The type of peek to perform. The choices are @c
        // *                  NAVIGATOR_PEEK_ROOT to peek to the bottom root of the card
        // *                  stack or @c NAVIGATOR_PEEK_PARENT to peek to only the
        // *                  parent of the selected card.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_peek(navigator_peek_type_t peek_type);
        [DllImport("bps")]
        static extern int navigator_card_peek(PeekType peek_type);

        ///**
        // * @brief Request the Navigator to notify the card when its window is ready
        // *
        // * The @c navigator_card_request_card_ready_check() function sends a request
        // * to the Navigator so that when the navigator is ready to show the card's
        // * window, e.g., after being brought back from pooling, it will send a
        // * @ NAVIGATOR_CARD_READY_CHECK event. This allows the card to delay its
        // * window being shown until it sends a @c navigator_card_send_card_ready()
        // * message.
        // *
        // * Note that the Navigator will show the window after some timeout regardless
        // * of whether @c navigator_card_send_card_ready() is called.
        // *
        // * The request can be made at any time during the card's lifecycle, and applies to
        // * all subsequent times that the card's window is shown. If requesting for the
        // * first run of the card, this request must proceed the posting of a window.
        // *
        // * @param check Whether to be notified by navigator before the card's window
        // *              is shown.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_request_card_ready_check(bool check);
        [DllImport("bps")]
        static extern int navigator_card_request_card_ready_check(bool check);

        ///**
        // * @brief Notify the Navigator to display the card's window
        // *
        // * The @c navigator_card_send_card_ready() function notifies the navigator
        // * that the card is ready to be shown. If this function is called without
        // * first requesting for Navigator to notify the card when its window is about
        // * to be shown (via @c navigator_card_request_card_ready_check()), then the
        // * behaviour is undefined.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_send_card_ready(void);
        [DllImport("bps")]
        static extern int navigator_card_send_card_ready();

        ///**
        // * @brief Retrieve the type of the card peek action
        // *
        // * The @c navigator_event_get_card_peek_type() function retrieves the type of
        // * peek action that a card stack should perform. The choices are @c
        // * NAVIGATOR_PEEK_ROOT to peek to the bottom root of the card stack or @c
        // * NAVIGATOR_PEEK_PARENT to peek to only the parent of the selected card. Call
        // * this function from the card application upon receiving the @c
        // * NAVIGATOR_CARD_PEEK_STARTED event to extract the peek type.
        // *
        // * @param event The @c NAVIGATOR_CARD_PEEK_STARTED event.
        // *
        // * @return The peek type upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_peek_type(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_card_peek_type(IntPtr _event);

        ///**
        // * @brief Retrieve the type of the peek action initiated on this card
        // *
        // * The @c navigator_event_get_peek_type() function retrieves the type of
        // * peek action intiated on this card's stack. The choices are @c
        // * NAVIGATOR_PEEK_ROOT to peek to the bottom root of the card stack or @c
        // * NAVIGATOR_PEEK_PARENT to peek to only the parent of the selected card. Call
        // * this function from the card application upon receiving the @c
        // * NAVIGATOR_PEEK_STARTED event to extract the peek type.
        // *
        // * @param event The @c NAVIGATOR_PEEK_STARTED event.
        // *
        // * @return The peek type upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_peek_type(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_peek_type(IntPtr _event);

        ///**
        // * @brief Retrieve whether a card peek stopped due to a swipe away gesture
        // *
        // * The @c navigator_event_get_card_peek_stopped_swipe_away() function determines
        // * whether a card peek action stopped due to the user swiping away the card to
        // * navigate to the content being peeked at, or whether the card peek action
        // * stopped due to the user returning the card to the stack, resuming the
        // * activity on the current card. Call this function from the card application
        // * upon receiving the @c NAVIGATOR_CARD_PEEK_STOPPED event to extract the
        // * manner in which the peek was stopped.
        // *
        // * @param event The @c NAVIGATOR_CARD_PEEK_STOPPED event.
        // * @param is_swipe_away If @c true the card peek action stopped due to a swipe
        // *                      away gesture, if @c false the card peek was stopped
        // *                      normally.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_peek_stopped_swipe_away(bps_event_t* event, bool* is_swipe_away);
        [DllImport("bps")]
        static extern int navigator_event_get_card_peek_stopped_swipe_away(IntPtr _event, out bool is_swipe_away);

        ///**
        // * @brief Retrieve whether this card's peek stopped due to a swipe away gesture
        // *
        // * The @c navigator_event_get_peek_stopped_swipe_away() function determines
        // * whether a peek action of this card stopped due to the user swiping away the card
        // * to navigate to the content being peeked at, or whether the peek action of this
        // * card stopped due to the user returning the card to the stack, resuming the
        // * activity on the current card. Call this function from the card application
        // * upon receiving the @c NAVIGATOR_PEEK_STOPPED event to extract the
        // * manner in which the peek was stopped.
        // *
        // * @param event The @c NAVIGATOR_PEEK_STOPPED event.
        // * @param is_swipe_away If @c true the peek action of the card stopped due to a
        // *                      swipe away gesture, if @c false the card peek was stopped
        // *                      normally.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_peek_stopped_swipe_away(bps_event_t* event, bool* is_swipe_away);
        [DllImport("bps")]
        static extern int navigator_event_get_peek_stopped_swipe_away(IntPtr _event, out bool is_swipe_away);

        ///**
        // * @brief Retrieve the card width from the card resize event
        // *
        // * The @c navigator_event_get_card_width() function retrieves the width of a
        // * card that has been targeted by a card resize event. Call this function from
        // * the card application upon receiving the @c NAVIGATOR_CARD_RESIZE event to
        // * extract the card's width.
        // *
        // * @param event The @c NAVIGATOR_CARD_RESIZE event.
        // *
        // * @return The card width upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_width(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_card_width(IntPtr _event);

        ///**
        // * @brief Retrieve the card height from the card resize event
        // *
        // * The @c navigator_event_get_card_height() function retrieves the height of a
        // * card that has been targeted by a card resize event. Call this function from
        // * the card application upon receiving the @c NAVIGATOR_CARD_RESIZE event to
        // * extract the card's height.
        // *
        // * @param event The @c NAVIGATOR_CARD_RESIZE event.
        // *
        // * @return The card height upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_height(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_card_height(IntPtr _event);

        ///**
        // * @brief Retrieve the card edge type from the card resize event
        // *
        // * The @c navigator_event_get_card_edge() function retrieves the edge type of a
        // * card that has been targeted by a card resize event. Call this function from
        // * the card application upon receiving the @c NAVIGATOR_CARD_RESIZE event to
        // * extract the card's edge type. The possible return values are:
        // *     - @c NAVIGATOR_TOP_UP
        // *     - @c NAVIGATOR_BOTTOM_UP
        // *     - @c NAVIGATOR_LEFT_UP
        // *     - @c NAVIGATOR_RIGHT_UP
        // *
        // * @param event The @c NAVIGATOR_CARD_RESIZE event.
        // *
        // * @return The card edge type upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_edge(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_card_edge(IntPtr _event);

        ///**
        // * @brief Retrieve the orientation type from the card resize event
        // *
        // * The @c navigator_event_get_card_orientation() function retrieves the
        // * resize type of a card that has been targeted by a card resize event. Call
        // * this function from the card application upon receiving the @c
        // * NAVIGATOR_CARD_RESIZE event to extract the card's resize type. The possible
        // * return values are:
        // *     - @c NAVIGATOR_PORTRAIT
        // *     - @c NAVIGATOR_LANDSCAPE
        // *
        // * @param event The @c NAVIGATOR_CARD_RESIZE event.
        // *
        // * @return The card resize type upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_event_get_card_orientation(bps_event_t* event);
        [DllImport("bps")]
        static extern int navigator_event_get_card_orientation(IntPtr _event);

        ///**
        // * @brief Close the card
        // *
        // * The @c navigator_card_close() function sends a request to the Navigator to
        // * perform a card close action, along with response data to return to the
        // * parent. Call this function from the card application to close the card and
        // * have the Navigator notify the parent with a @c NAVIGATOR_CHILD_CARD_CLOSED
        // * event. The closed card may also be pooled instead for later use, at which
        // * point the Navigator will send a @c NAVIGATOR_CARD_CLOSED event to the card
        // * application.
        // *
        // * @param reason The application level description of why the card was closed.
        // *               The @c reason member can be NULL.
        // * @param type The type and encoding of the closed card's response data. The @c
        // *             type member can't be NULL if the @c data member isn't NULL.
        // * @param data The data being returned to the parent from the closed card. The
        // *             @c data member can be NULL.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_close(const char *reason, const char *type,
        //        const char *data);
        [DllImport("bps")]
        static extern int navigator_card_close(char[] reason, char[] type, char[] data);

        ///**
        // * @brief Retrieve the reason for a card closure
        // *
        // * The @c navigator_event_get_card_closed_reason() function extracts the reason
        // * for which a card has been closed using the @c navigator_card_close()
        // * function. Call this function in the application upon receiving a @c
        // * NAVIGATOR_CHILD_CARD_CLOSED event to identify why the child card was closed,
        // * or upon receiving a @c NAVIGATOR_CARD_CLOSED event to identify why the card
        // * itself was closed. This function doesn't copy data and the returned value is
        // * released once the @c bps_get_event() function is called again.
        // *
        // * @param event The @c NAVIGATOR_CHILD_CARD_CLOSED or @c NAVIGATOR_CARD_CLOSED
        // *              event that informed the application of the card closure.
        // *
        // * @return The reason why the card was closed upon success, NULL with @c errno
        // *         set otherwise.
        // */
        //BPS_API const char* navigator_event_get_card_closed_reason(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_card_closed_reason(IntPtr _event);

        ///**
        // * @brief Retrieve the type of data passed by the child card upon closure
        // *
        // * The @c navigator_event_get_card_closed_data_type() function extracts the type
        // * of data sent by the child card upon calling the @c navigator_card_close()
        // * function. Call this function in the parent application upon receiving a @c
        // * NAVIGATOR_CHILD_CARD_CLOSED event to identify the type of data in the child
        // * card's response message. This function doesn't copy data and the returned
        // * value is released once the @c bps_get_event() function is called again.
        // *
        // * @param event The @c NAVIGATOR_CHILD_CARD_CLOSED event that informed the
        // *              parent application of the child card closure.
        // *
        // * @return The type of the data passed from the child card upon success, NULL
        // *         with @c errno set otherwise.
        // */
        //BPS_API const char* navigator_event_get_card_closed_data_type(
        //        bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_card_closed_data_type(IntPtr _event);

        ///**
        // * @brief Retrieve the data passed by the child card upon closure
        // *
        // * The @c navigator_event_get_card_closed_data() function extracts the data sent
        // * by the child card upon calling the @c navigator_card_close() function. Call
        // * this function in the parent application upon receiving a @c
        // * NAVIGATOR_CHILD_CARD_CLOSED event to retrieve the data in the child card's
        // * response message. This function doesn't copy data and the returned value is
        // * released once the @c bps_get_event() function is called again.
        // *
        // * @param event The @c NAVIGATOR_CHILD_CARD_CLOSED event that informed the
        // *              parent application of the child card closure.
        // *
        // * @return The data passed from the child card upon success, NULL with @c errno
        // *         set otherwise.
        // */
        //BPS_API const char* navigator_event_get_card_closed_data(bps_event_t *event);
        [DllImport("bps")]
        static extern char[] navigator_event_get_card_closed_data(IntPtr _event);

        ///**
        // * @brief Close the card
        // *
        // * The @c navigator_card_close_child() function sends a request to the Navigator
        // * to perform a card close action on the child card of the application. Call
        // * this function from the parent application to close the child card and have
        // * the Navigator notify the child with a @c NAVIGATOR_CARD_CLOSED event.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_close_child(void);
        [DllImport("bps")]
        static extern int navigator_card_close_child();

        ///**
        // * @brief Inform the Navigator that the card has been resized
        // *
        // * The @c navigator_card_resized() function sends a notification to the
        // * Navigator to indicate that the given card application has resized its screen
        // * buffer.
        // *
        // * @param id The ID retrieved from the @c NAVIGATOR_CARD_RESIZE event
        // *           corresponding to the card resize instance.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_resized(const char *id);
        [DllImport("bps")]
        static extern int navigator_card_resized(char[] id);

        ///**
        // * @brief Inform the Navigator that a swipe away gesture has been performed
        // *
        // * The @c navigator_card_swipe_away() function sends a notification to the
        // * Navigator to indicate that the given card application has detected a "swipe
        // * away" gesture (performed by swiping from the card application outwards). This
        // * informs the Navigator that it should dismiss the application (by means of a
        // * transition out past the left side of the screen). This function is exclusive
        // * to the Universal Inbox application.
        // *
        // * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
        // *         otherwise.
        // */
        //BPS_API int navigator_card_swipe_away(void);
        [DllImport("bps")]
        static extern int navigator_card_swipe_away();

        ///**
        // * @brief Change the device's wallpaper
        // *
        // * Set the device's wallpaper using the image file provided in filepath.
        // *
        // * @param filepath Path to an image file that will be used as the wallpaper.
        // * @return On success return @c BPS_SUCCESS.  Otherwise, return @c BPS_FAILURE
        // *         with errno set, the wallpaper will not be changed.
        // */
        //BPS_API int navigator_set_wallpaper(const char *filepath);
        [DllImport("bps")]
        static extern int navigator_set_wallpaper(char[] filepath);
        #endregion

        private int eventDomain;

        public Action OnExit;
        public Action OnSwipeDown;

        private bool _rotationLock;
        public bool RotationLock
        {
            set { _rotationLock = value; navigator_rotation_lock(value); }
        }

        private int _domain;
        public int Domain
        {
            get { _domain = navigator_get_domain(); return _domain; }
        }
        
        
        public Navigator()
        {
            PlatformServices.Initialize();
            navigator_request_events(0);
            eventDomain = navigator_get_domain();
            PlatformServices.AddEventHandler(eventDomain, HandleEvent);
        }

        public void AddUri(string iconPath, string iconLabel, string defaultCategory, string url)
        {
            navigator_add_uri(iconPath, iconLabel, defaultCategory, url, IntPtr.Zero);
        }

        public void Invoke(string uri)
        {
            navigator_invoke(uri, IntPtr.Zero);
        }

        public bool HasBadge
        {
            set
            {
                if (value)
                {
                    navigator_set_badge(BadgeType.Splat);
                }
                else
                {
                    navigator_clear_badge();
                }
            }
        }

        void HandleEvent(IntPtr eventHandle)
        {
            var type = (EventType)new Event(eventHandle).Code;

            switch (type)
            {
                case EventType.NAVIGATOR_EXIT:
                    if (OnExit != null)
                    {
                        OnExit();
                    }
                    break;
                case EventType.NAVIGATOR_SWIPE_DOWN:
                    if (OnSwipeDown != null)
                    {
                        OnSwipeDown();
                    }
                    break;
                default:
                    Console.WriteLine("UNHANDLED NAVIGATOR EVENT, TYPE: {0}", type);
                    break;
            }

        }

        public void Dispose()
        {
            PlatformServices.RemoveEventHandler(eventDomain);
        }
    }
}

