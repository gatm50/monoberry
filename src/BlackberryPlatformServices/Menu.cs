using System;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public class Menu
    {
        #region Enumerators
        /**
         * @brief This enumeration defines the possible menu service events.
         *
         * Currently, there is only one event.
         */
        public enum MenuEventType
        {
            /**
             * Indicates a get menu items response was received.
             */
            MENU_GET_MENU_ITEMS_RESULT = 0x01,
        };
        #endregion

        #region DllImport
        
        /**
         * @brief Start receiving menu service events
         *
         * The @c menu_request_events() function starts to deliver menu service
         * events to your application using BPS.  Events will be posted to the currently
         * active channel.
         *
         * @param flags The types of events to deliver.  A value of zero indicates that
         * all events are requested.  The meaning of non-zero values is reserved for
         * future use.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_events(int flags);

        /**
         * @brief Stop receiving menu service events
         *
         * The @c menu_stop_events() function stops menu service events from being
         * delivered to the application using BPS.
         *
         * @param flags The types of events to stop. A value of zero indicates that all
         * events are stopped. The meaning of non-zero values is reserved for future
         * use.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_stop_events(int flags);

        /**
         * @brief Get the unique domain ID for the menu service
         *
         * The @c menu_get_domain() function gets the unique domain ID for the menu
         * service.  You can use this function in your application to test whether an
         * event that you retrieve using @c bps_get_event() is an menu service event,
         * and respond accordingly.
         *
         * @return The domain ID for the menu service.
         */
        [DllImport("bps")]
        public static extern int menu_get_domain();

        /**
         * @brief Sends the get menu items request
         *
         * The @c menu_request_send() function sends the get menu items request to the
         * menu service.
         *
         * @param request The the get menu items to send. The request can not be NULL.
         * @param id The ID of the message used to correlate the request with the
         * response @c MENU_GET_MENU_ITEMS_RESULT. The ID can not be NULL.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_send(IntPtr request, char[] id);

        /**
         * @brief Create the get menu items request
         *
         * The @c menu_request_create() function creates a get menu items request
         * instance.  A request instance created through @c menu_request_create() must
         * be destroyed with @c menu_request_destroy() once not needed.
         *
         * @param request The pointer to the get menu items request.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_create(out IntPtr request);

        /**
         * @brief Destroy the get menu items request
         *
         * The @c menu_request_destroy() function cleans up resources for the specified
         * request.  Note that this function should be called only on the menu request
         * objects that were created through @c menu_request_create() function.
         *
         * @param request The get menu items request to destroy.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_destroy(IntPtr request);

        /**
         * @brief Set the action of the menu request
         *
         * The @c menu_request_set_action() function sets the action of the specified
         * menu request.
         *
         * Description:
         * The identifier of the action to be performed by the target. Omitting the
         * action implies brokering should apply to any action supported for the
         * specified type or that the target should infer the action.
         *
         * Mandatory: no
         *
         * Format:
         * Up to 50 characters based on the following grammar:
         * @code
         * action: [domain][sub-domain]
         * sub-domain:  NUL | .[domain][sub-domain]
         * domain: [a-zA-Z]([a-zA-Z0-9_])*
         * @endcode
         *
         * Example: "bb.action.SHARE"
         *
         * @param request The menu request.
         * @param action The action to set.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_action(IntPtr request,
                char[] action);

        /**
         * @brief Set the MIME type of the menu request
         *
         * The @c menu_request_set_mime_type() function sets the MIME type of the
         * specified menu request.
         *
         * Description:
         * The MIME type of the data to be acted on, this must be provided if the file
         * URI attribute is not provided.
         *
         * Mandatory: no
         *
         * Format:
         * @code
         * mimetype: type subtype
         * type: [a-zA-Z0-9-_\.]+
         * subtype: NUL | / type subtype
         * @endcode
         *
         * Example: "image/png"
         *
         * @param request The menu request.
         * @param mime_type The MIME type to set.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_mime_type(IntPtr request,
                char[] mime_type);

        /**
         * @brief Set the file URI of the menu request
         *
         * The @c menu_request_set_file_uri() function sets the file URI of the
         * specified menu request.  The file URI is used for the type interface
         * and it must be provided if the type is not specified.
         *
         * Description:
         * The file URI used for the type inference must be provided if the type is not
         * specified.
         *
         * Mandatory: no
         *
         * Format: STRING
         *
         * Example: "file://path/to/file.txt"
         *
         * @param request The request to update.
         * @param file_uri The file URI to set.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_file_uri(IntPtr request,
                char[] file_uri);

        /**
         * @brief Set the transfer mode for the specified file
         *
         * The @c menu_request_set_file_transfer_mode() function sets the transfer
         * mode for the associated file URI value. The file transfer mode allows the
         * sender to control how data file will be transfered between the sender and
         * the target. File transfer handling applies only to file:// URI values that
         * refer to files that are not in the share area.
         *
         * By default such files are copied as read-only into the target's private
         * inbox. Using a file transfer mode, senders can change this behavior to skip
         * private file transfer and deliver the specified file:// URI or copy the
         * file read-write, or create a link to the file.
         *
         * When creating a link to the file, it must have o+r permissions. In addition
         * if the file has o+w then the sender must be the file owner in order for
         * @c NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK mode to succeed.
         *
         * Description:
         * The file transfer mode used to transfer the file described by file_uri
         * between sender and target
         *
         * Mandatory: no, falls back to default behaviour
         *
         * @param request The request to update.
         * @param transfer_mode The file transfer mode that should be applied to
         *          the invocation
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_file_transfer_mode(IntPtr request,
                IntPtr transfer_mode);

        /**
         * @brief Set the target type mask of the menu request
         *
         * The @c menu_request_set_target_type_mask() function sets the target type mask
         * of the specified menu request.
         *
         * Description:
         * Indicates whether to include targets of type viewer, application, service or
         * card in the results set. If omitted the response should return all targets
         * regardless of type. @c NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE type mask is
         * reserved for the future use.
         *
         * Mandatory: yes
         *
         * Possible values:
         * - @c NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION or
         * - @c NAVIGATOR_INVOKE_TARGET_TYPE_CARD or
         * - @c NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER or
         * - @c NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE or combination of the above
         *
         * Example: @c NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION |
         * @c NAVIGATOR_INVOKE_TARGET_TYPE_CARD
         *
         * @param request The request to update.
         * @param target_type_mask The target type to set.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_target_type_mask(IntPtr request,
                int target_type_mask);

        /**
         * @brief Set the data of a menu request
         *
         * The @c menu_request_set_data() function sets the data and data length of
         * the specified menu request. The menu service correlates the data with the
         * invoke target information it receives so that the target invocation,
         * including the data to be acted upon, can be made if the menu item is
         * selected.
         * Omitting the data implies that the action and type are sufficient to carry
         * out the invocation.
         * The value of the data member can take the form of any binary data.
         *
         * Mandatory: no
         *
         * @param request The menu request to update.
         * @param data The data to set.
         * @param data_length The size of the @c data member in bytes.
         *
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern
        int menu_request_set_data(IntPtr request, IntPtr data,
            int data_length);

        /**
         * @brief Set the perimeter in which the resulting targets should reside
         *
         * The @c menu_request_set_perimeter() function sets the perimeter in which the
         * resulting targets should reside.  Setting the perimeter is only required for
         * the hybrid applications that can run in both the enterprise and the personal
         * perimeters.  For the non hybrid applications the perimeter is mandated to be
         * the same as the sender.
         *
         * Mandatory: no, for the hybrid applications defaults to
         * @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL, for the other applications
         * defaults to the perimeter of the client
         *
         * @param request The menu request to update.
         * @param perimeter The perimeter to set.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_set_perimeter(IntPtr request,
                IntPtr perimeter);

        /**
         * @brief Get the action from the menu request
         *
         * The @c menu_request_get_action() function extracts the action of
         * the specified menu request.  The function doesn't copy data and
         * the returned values will be released once the menu request is destroyed.
         *
         * @param request The menu request to retrieve the action from.
         *
         * @return The menu request action if was provided by the sender, NULL
         * otherwise.
         */
        [DllImport("bps")]
        public static extern char[] menu_request_get_action(IntPtr request);

        /**
         * @brief Get the MIME type from the menu request object
         *
         * The @c menu_request_get_mime_type() function extracts the MIME type of the
         * specified menu request object.  The function doesn't copy data and the
         * returned values will be released once the menu request is destroyed.
         *
         * @param request The menu request to retrieve the action from.
         *
         * @return The menu request type if was provided by the sender, NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] menu_request_get_mime_type(IntPtr request);

        /**
         * @brief Get the file URI from the menu request object
         *
         * The @c menu_request_get_file_uri() function extracts the file URI of the
         * specified menu request object.  The function doesn't copy data and
         * the returned values will be released once the menu request is destroyed.
         *
         * @param request The menu request to retrieve file URI from.
         *
         * @return The menu request file URI if was provided by the sender, NULL
         * otherwise.
         */
        [DllImport("bps")]
        public static extern char[] menu_request_get_file_uri(IntPtr request);

        /**
         * @brief Get the transfer mode of the menu @c request object
         *
         * The @c menu_request_get_file_transfer_mode() function extracts the
         * file transfer mode (@c navigator_invoke_file_transfer_mode_t) from the
         * specified menu request object.
         *
         * @param request The menu request to retrieve file transfer mode from.
         *
         * @return The menu request file transfer mode if it was provided by the sender,
         * @c NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_UNSPECIFIED otherwise. @c BPS_FAILURE
         * will be returned with @c errno set if an error occurs.
         */
        [DllImport("bps")]
        public static extern int menu_request_get_file_transfer_mode(
                IntPtr request);


        /**
         * @brief Get the target type mask from the menu request object
         *
         * The @c menu_request_get_target_type_mask() function extracts the target
         * type mask of the specified menu request object.
         *
         * @param request The menu request to retrieve the target type mask from.
         * @see @c menu_request_set_target_type_mask()
         *
         * @return The menu request target type mask.
         */
        [DllImport("bps")]
        public static extern int menu_request_get_target_type_mask(IntPtr request);

        /**
         * @brief Get the data from the menu request object
         *
         * The @c menu_request_get_data() function extracts the data of the specified
         * menu request object.
         *
         * @param request The menu request to retrieve the data from.
         * @see @c menu_request_set_data()
         *
         * @return The menu request data.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_request_get_data(IntPtr request);

        /**
         * @brief Get the data length from the menu request object
         *
         * The @c menu_request_get_data_length() function extracts the length
         * of the data of the specified menu request object.
         *
         * @param request The menu request to retrieve the data length from.
         * @see @c menu_request_set_data()
         *
         * @return The menu request data length.
         */
        [DllImport("bps")]
        public static extern int menu_request_get_data_length(IntPtr request);

        /**
         * @brief Get the perimeter from the menu request object
         *
         * The @c menu_request_get_perimeter() function extracts the perimeter of the
         * given menu request object.
         *
         * @param request The menu request to retrieve the perimeter from.
         * @see @c menu_request_set_perimeter()
         *
         * @return The perimeter upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_request_get_perimeter(IntPtr request);

        /**
         * @brief Get the ID from a menu event
         *
         * The @c menu_event_get_id() function extracts the ID from the
         * @c MENU_GET_MENU_ITEMS_RESULT event.
         *
         * @param event The event to extract the ID from.
         *
         * @return The ID field from the event.
         */
        [DllImport("bps")]
        public static extern char[] menu_event_get_id(IntPtr _event);

        /**
         * @brief Get the error message from a menu event
         *
         * The @c menu_event_get_err() function extracts the error message from the
         * @c MENU_GET_MENU_ITEMS_RESULT event.
         *
         * @param event The event to extract the error message from.
         *
         * @return The error message from the event, or @c NULL if there is no
         * error message.
         */
        [DllImport("bps")]
        public static extern char[] menu_event_get_err(IntPtr _event);

        /**
         * @brief Get the menu item
         *
         * The @c menu_event_get_menu_item() function extracts the menu item from the
         * @c MENU_GET_MENU_ITEMS_RESULT event.  The function doesn't copy data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * Note: The menu item "ownership" is not transferred to the application. An
         * application must not call the free function on the menu item pointers that
         * are retrieved using the @c menu_event_get_item() function.  The pointer to
         * the menu item is valid until the @c bps_get_event() function is called
         * again.
         *
         * @param event The event to extract the menu item from.
         *
         * @return The menu item from the event, or @c NULL if there is no menu item.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_event_get_item(IntPtr _event);

        /**
         * @brief Get the title from the menu item object
         *
         * The @c menu_item_get_title() function extracts the title of the given menu
         * item object.  The title is to be used at the top of the menu to describe the
         * items within it.  The function doesn't copy the data and the returned values
         * will be released once the @c bps_get_event() function is called again.
         *
         * @param item The menu item to retrieve the title from.
         *
         * @return The title from the menu item, or @c NULL if there is no title.
         */
        [DllImport("bps")]
        public static extern char[] menu_item_get_title(IntPtr item);

        /**
         * @brief Get the secondary title from the menu item object
         *
         * The @c menu_item_get_sub_title() function extracts the secondary title of the
         * given menu item object.  The secondary title if often presented as a
         * subscript to the main title.  The function doesn't copy the data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * @param item The menu item to retrieve the secondary title from.
         *
         * @return The secondary title from the menu item, or @c NULL if there is no
         * secondary title.
         */
        [DllImport("bps")]
        public static extern char[] menu_item_get_secondary_title(IntPtr item);

        /**
         * @brief Get the icon URI from the menu item object
         *
         * The @c menu_item_get_icon() function extracts the icon URI of the given menu
         * item object.  The function doesn't copy the data and the returned values will
         * be released once the @c bps_get_event() function is called again.
         *
         * Example: "file://path/to/icon"
         *
         * @param item The menu item to retrieve the icon URI from.
         *
         * @return The icon URI from the menu item, or @c NULL if there is no icon URI.
         */
        [DllImport("bps")]
        public static extern char[] menu_item_get_icon(IntPtr item);

        /**
         * @brief Get the secondary icon URI from the menu item object
         *
         * The @c menu_item_get_secondary_icon() function extracts the secondary icon
         * URI of the given menu item object.  The function doesn't copy the data and
         * the returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * Example: "file://path/to/icon"
         *
         * @param item The menu item to retrieve the icon URI from.
         *
         * @return The secondary icon URI from the menu item, or @c NULL if there is no
         * secondary icon URI.
         */
        [DllImport("bps")]
        public static extern char[] menu_item_get_secondary_icon(IntPtr item);

        /**
         * @brief Get the number of sub menu items inside the menu item
         *
         * The @c menu_item_get_sub_items_size() function  extracts the number of sub
         * menu items in the the menu item.
         *
         * @param item The menu item to retrieve the number of sub menu items from.
         *
         * @return The the number of sub menu items inside the menu item.
         */
        [DllImport("bps")]
        public static extern int menu_item_get_sub_items_size(IntPtr item);

        /**
         * @brief Get the sub menu item inside the menu item
         *
         * The @c menu_item_get_sub_item() function extracts the sub menu item at the
         * specific index inside the menu item.  The function doesn't copy data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * Note: The sub menu item "ownership" is not transferred to the application. An
         * application must not call the free function on sub menu item pointers that
         * are retrieved using the @c menu_item_get_sub_item() function.  The pointer to
         * the sub menu item is valid until the @c bps_get_event() function is called
         * again.
         *
         * @param item The menu item to retrieve the sub menu item from.
         * @param index The index of the sub menu item inside the menu item.
         *
         * @return The pointer to the returned sub menu item, NULL if @c item is NULL
         * or the @c index is out of bounds.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_item_get_sub_item(IntPtr item,
                int index);

        /**
         * @brief Get the icon URI from the sub menu item object
         *
         * The @c menu_sub_item_get_icon() function extracts the icon URI of the given
         * sub menu item object.  The function doesn't copy the data and the returned
         * values will be released once the @c bps_get_event() function is called again.
         *
         * Example: "file://path/to/icon"
         *
         * @param item The sub menu item to retrieve the icon URI from.
         *
         * @return The icon URI from the sub menu item, or @c NULL if there is no icon
         * URI.
         */
        [DllImport("bps")]
        public static extern char[] menu_sub_item_get_icon(IntPtr item);

        /**
         * @brief Get the localized label from the sub menu item object
         *
         * The @c menu_sub_item_get_label() function extracts the localized label of the
         * given sub menu item object.  The label describes the menu item.  The function
         * doesn't copy the data and the returned values will be released once the
         * @c bps_get_event() function is called again.
         *
         * Example: "Pictures"
         *
         * @param item The sub menu item to retrieve the label from.
         *
         * @return The label from the sub menu item.
         */
        [DllImport("bps")]
        public static extern char[] menu_sub_item_get_label(IntPtr item);

        /**
         * @brief Get the secondary localized label from the sub menu item object
         *
         * The @c menu_sub_item_get_secondary_label() function extracts the secondary
         * localized label of the given sub menu item object.  The optional secondary
         * label can be used for example to display associated account information
         * secondary. The function doesn't copy the data and the returned values will be
         * released once the @c bps_get_event() function is called again.
         *
         * Example: "account@example.com"
         *
         * @param item The sub menu item to retrieve the secondary label from.
         *
         * @return The secondary label from the sub menu item.
         */
        [DllImport("bps")]
        public static extern char[] menu_sub_item_get_secondary_label(
                IntPtr item);

        /**
         * @brief Get the tertiary localized label from the sub menu item object
         *
         * The @c menu_sub_item_get_tertiary_label() function extracts the tertiary
         * localized label of the given sub menu item object.  The optional tertiary
         * label can be used for example to display the associated phone number. The
         * function doesn't copy the data and the returned values will be released once
         * the @c bps_get_event() function is called again.
         *
         * Example: "+16131234678"
         *
         * @param item The sub menu item to retrieve the tertiary label from.
         *
         * @return The tertiary label from the sub menu item.
         */
        [DllImport("bps")]
        public static extern char[] menu_sub_item_get_tertiary_label(
                IntPtr item);

        /**
         * @brief Determines if the sub menu item object has another level of a menu
         * item
         *
         * The @c menu_sub_item_has_children() function determines if the sub menu item
         * object has another level of sub menus.  If there is no children
         * @c menu_sub_item_get_invocation() should be called to retrieve the invocation
         * object.  If there are children @c menu_sub_item_get_item() should be
         * called to retrieve another level of a menu item object.
         *
         * @param item The sub menu item.
         *
         * @return @c true if the sub menu item has another level of a menu item.
         */
        [DllImport("bps")]
        public static extern bool menu_sub_item_has_children(IntPtr item);

        /**
         * @brief Get the invocation from the sub menu item object
         *
         * The @c menu_sub_item_get_invocation() function extracts the invocation of the
         * given sub menu item object.  The function doesn't copy the data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * @param item The sub menu item to retrieve the invocation from.
         *
         * @return The invocation from the sub menu item, or @c NULL if there is no
         * invocation.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_sub_item_get_invocation(
                IntPtr item);

        /**
         * @brief Get the menu item from the sub menu item object
         *
         * The @c menu_sub_item_get_item() function extracts the menu item of the
         * given sub menu item object.  The function doesn't copy the data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * @param item The sub menu item to retrieve the invocation from.
         *
         * @return The menu item from the sub menu item, or @c NULL if there is no
         * menu item.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_sub_item_get_item(IntPtr item);

        /**
         * @brief Get the target type of the menu invocation
         *
         * The @c menu_invocation_get_target_type() function  extracts the target type
         * of the specified menu invocation object.  The possible return values are:
         * - c@ NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION or
         * - c@ NAVIGATOR_INVOKE_TARGET_TYPE_CARD or
         * - c@ NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER
         *
         * @param invocation The menu invocation to retrieve the target type from.
         *
         * @return The target type inside the menu invocation on success, @c BPS_FAILURE
         * with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_invocation_get_target_type(IntPtr invocation);

        /**
         * @brief Get the target of the menu invocation
         *
         * The @c menu_invocation_get_target() function extracts the target of the given
         * menu invocation object.  The function doesn't copy the data and the returned
         * values will be released once the @c bps_get_event() function is called again.
         *
         * Description:
         * The identifier of the target (as stated in its BAR manifest) to which
         * invocation should be delivered.  If the target is supplied then brokering is
         * bypassed and an attempt is made to invoke the specified target.
         *
         * @param invocation The menu invocation to retrieve the target from.
         *
         * @return The target inside the menu invocation, or @c NULL if there is no
         * target.
         */
        [DllImport("bps")]
        public static extern char[] menu_invocation_get_target(
                IntPtr invocation);

        /**
         * @brief Get the action of the menu invocation
         *
         * The @c menu_invocation_get_action() function extracts the action of the given
         * menu invocation object.  The function doesn't copy the data and the returned
         * values will be released once the @c bps_get_event() function is called again.
         *
         * Description:
         * The identifier of the action to be performed by the target. Omitting action
         * implies brokering should apply to any action supported for the specified type
         * or that the target should infer the action.
         *
         * @param invocation The menu invocation to retrieve the action from.
         *
         * @return The action inside the menu invocation, or @c NULL if there is no
         * action.
         */
        [DllImport("bps")]
        public static extern char[] menu_invocation_get_action(
                IntPtr invocation);

        /**
         * @brief Get the MIME type of the menu invocation
         *
         * The @c menu_invocation_get_mime_type() function extracts the MIME type of the
         * given menu invocation object.  The function doesn't copy the data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * Description:
         * The MIME type of the data to be acted on.
         *
         * @param invocation The menu invocation to retrieve the MIME type from.
         *
         * @return The MIME type inside the menu invocation, or @c NULL if there is no
         * MIME type.
         */
        [DllImport("bps")]
        public static extern char[] menu_invocation_get_mime_type(
                IntPtr invocation);

        /**
         * @brief Get the URI pointing to the invocation data
         *
         * The @c menu_invocation_get_uri() function extracts the URI pointing to the
         * invocation data.  If the URI is not provided then this implies the
         * "data://local" URI indicating that the invocation data is provided in-band
         * retrieved through @c menu_invocation_get_data() function.  The function
         * doesn't copy the data and the returned values will be released once the
         * @c bps_get_event() function is called again.
         *
         * @param invocation The menu invocation to retrieve the URI from.
         *
         * @return The URI inside the menu invocation, or @c NULL if there is no
         * URI.
         */
        [DllImport("bps")]
        public static extern char[] menu_invocation_get_uri(IntPtr invocation);

        /**
         * @brief Get the transfer mode of the menu @c invocation object
         *
         * The @c menu_invocation_get_file_transfer_mode() function extracts the file
         * transfer mode (@c navigator_invoke_file_transfer_mode_t) of the given menu
         * invocation object. The possible return values are:
         * - c@ NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_UNSPECIFIED
         * - c@ NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_PRESERVE
         * - c@ NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RO
         * - c@ NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_COPY_RW
         * - c@ NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK
         *
         * @param invocation The menu invocation to retrieve the data from.
         *
         * @return The menu request file transfer mode if was provided by the sender,
         * @c NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_UNSPECIFIED otherwise. @c BPS_FAILURE
         * will be returned with @c errno set if an error occurs.
         */
        [DllImport("bps")]
        public static extern int menu_invocation_get_file_transfer_mode(
                IntPtr invocation);

        /**
         * @brief Get the data of the menu invocation
         *
         * The @c menu_invocation_get_data() function extracts the data of the
         * given menu invocation object.  The function doesn't copy the data and the
         * returned values will be released once the @c bps_get_event() function is
         * called again.
         *
         * Description:
         * The data to be acted upon, encoded based on the specified type. Omitting the
         * data implies that the action-type are sufficient to carry out the invocation.
         *
         * @param invocation The menu invocation to retrieve the data from.
         *
         * @return The data inside the menu invocation, or @c NULL if there is no
         * data.
         */
        [DllImport("bps")]
        public static extern IntPtr menu_invocation_get_data(
                IntPtr invocation);

        /**
         * @brief Get the data length from a @c menu invocation
         *
         * The @c menu_invocation_get_data_length() function extracts the
         * length in bytes of the data of a given @c menu_invocation_t structure.
         * The @c data_length member is used by the invocation handler to identify
         * the size of the data the invoked handler is to perform an action on
         * (see the @c menu_invocation_get_data() function for further details).
         *
         * @param invocation A pointer to the @c menu_invocation_t structure
         *                   whose @c data_length member you want to retrieve.
         *
         * @return The size in bytes of the invocation data if one was provided by the
         *         sender, -1 otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_invocation_get_data_length(IntPtr invocation);

        /**
         * @brief Get the perimeter from the menu invocation object
         *
         * The @c menu_invocation_get_perimeter() function extracts the perimeter of the
         * given menu invocation object.  The possible return values are:
         * - c@ NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL
         * - c@ NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE
         *
         * @param invocation The menu invocation to retrieve the data from.
         *
         * @return The perimeter upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int menu_invocation_get_perimeter(IntPtr invocation);
        #endregion
    }
}
