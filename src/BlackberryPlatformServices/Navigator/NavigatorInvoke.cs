using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BlackberryPlatformServices
{
    public partial class Navigator
    {
        #region DllImport
        /**
         * @brief Create a @c navigator_invoke_invocation_t structure and allocate all
         *        necessary memory
         *
         * The @c navigator_invoke_invocation_create() function creates an instance of a
         * @c navigator_invoke_invocation_t structure called @c invocation to be used by
         * the invocation framework. Destroy all invocation instances created through
         * this function once they are no longer needed by using the @c
         * navigator_invoke_invocation_destroy() function to prevent memory leaks.
         *
         * @param invocation The @c navigator_invoke_invocation_t structure to populate.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_create(out IntPtr invocation);

        /**
         * @brief Deallocate the memory used by a @c navigator_invoke_invocation_t
         * structure
         *
         * The @c navigator_invoke_invocation_destroy() function deallocates any memory
         * set to a given @c invocation. Use this function to deallocate memory used by
         * a @c navigator_invoke_invocation_t structure (created by the @c
         * navigator_invoke_invocation_create() function) that's no longer in use.
         * Failing to do so will result in a memory leak.
         *
         * @param invocation The @c navigator_invoke_invocation_t structure to
         *                   deallocate.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_destroy(
                IntPtr invocation);

        /**
         * @brief Set the ID of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_id() function sets the invocation ID
         * of a given @c navigator_invoke_invocation_t structure. Assign an @c id member
         * to any invocation for which you would like to receive a delivery receipt
         * response. The @c id member you assign through a sender appears in its
         * corresponding delivery receipt. The receipt is returned once the invocation
         * is dispatched to a target, but does not imply that the target has processed
         * the invocation. If the sender terminates before receiving a receipt response
         * then it is forfeit.
         *
         * Assigning an @c id member to an invocation is not mandatory, but if you do
         * not assign one there is no way to determine the result of the invocation
         * request. Don't assign an invocation ID if you don't want to receive a
         * delivery receipt response.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c id you want to set.
         *
         * @param id The invocation ID you want to display on the delivery receipt
         *           response. This value must be in numerical format. For example, a
         *           valid @c id would be "42".
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_id(
                IntPtr invocation, char[] id);

        /**
         * @brief Set the target of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_target() function sets the target of a
         * given @c navigator_invoke_invocation_t structure. The @c target member is an
         * identifier to the target (as stated in its BAR manifest) handler to which the
         * invocation is sent.
         *
         * If you assign a @c target member to an invocation then brokering is bypassed
         * and an attempt is made to invoke the specified target. If you don't call this
         * function, the invocation framework uses brokering along with the @c action
         * and/or @c type member (assigned with the @c
         * navigator_invoke_invocation_set_action() and @c
         * navigator_invoke_invocation_set_type() functions respectively) to find the
         * corresponding handler(s).
         *
         * The format of a @c target member must conform to the following guidelines:
         *      - Maximum 50 characters
         *      - Target: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "com.example.invoke.target"
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c target you want to set.
         *
         * @param target The target you want the invocation to be sent to. The value
         *               must conform to the "[Domain][Sub-domain]" format (see
         *               description for further information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_target(
                IntPtr invocation, char[] target);

        /**
         * @brief Set the source of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_source() function sets the source of a
         * given @c navigator_invoke_invocation_t structure. The @c source member is an
         * identifier to a target (as stated in its BAR manifest) to which the results
         * of an invocation are sent. If you assign a @c source member to an invocation
         * then the receiving target may send a response with the corresponding results.
         *
         * Assigning a @c source member to an invocation is not mandatory, but if you do
         * not assign one then the invoked target won't be able to communicate with
         * the caller. Don't assign an invocation source if the sender doesn't support
         * results.
         *
         * The format of a @c target member must conform to the following guidelines:
         *      - Maximum 50 characters
         *      - Source: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "com.example.result.target"
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c source you want to set.
         *
         * @param source The target you want the invocation target to be send results
         *               to. The value must conform to the "[Domain][Sub-domain]" format
         *               (see description for further information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_source(
                IntPtr invocation, char[] source);

        /**
         * @brief Set the action of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_action() function sets the action of a
         * given @c navigator_invoke_invocation_t structure. The @c action member
         * identifies the action to be performed by the invocation target.
         *
         * If you assign an @c action member to an invocation but don't assign a @c
         * target (using the @c navigator_invoke_invocation_set_target() function), the
         * brokering system uses the @c action value to filter for target handlers that
         * support that action. If a @c type member is also assigned (using the @c
         * navigator_invoke_invocation_set_type() function), the brokering system uses
         * that information to filter for handler(s) that support both the given
         * action and type. If only a @c type member is assigned, the brokering system
         * doesn't filter for any specific action.
         *
         * The format of an @c action member must conform to the following guidelines:
         *      - Maximum 50 characters
         *      - Action: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "bb.action.SHARE"
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c action member you want to set.
         *
         * @param action The action you want the invocation target to perform. The value
         *               must conform to the "[Domain][Sub-domain]" format (see
         *               description for further information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_action(
                IntPtr invocation, char[] action);

        /**
         * @brief Set the type of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_type() function sets the @c type
         * member of a given @c navigator_invoke_invocation_t structure. The @c type
         * member identifies the MIME type of the data the invoked handler is to perform
         * an action on.
         *
         * If you assign a @c type member to an invocation but don't assign a @c target
         * (using the @c navigator_invoke_invocation_set_target() function), the
         * brokering system uses the @c type value to filter for target handlers that
         * support that MIME type. If an @c action member is also assigned (using the @c
         * navigator_invoke_invocation_set_action() function), the brokering system uses
         * that information to filter for handler(s) that support both the given type
         * and action. If only an @c action member is assigned, the brokering system
         * doesn't filter for any specific MIME type.
         *
         * The format of a @c type member must conform to the following guidelines:
         *      - MIME type: Type Subtype
         *      - Type: [a-zA-Z0-9-_\.]+
         *      - Subtype: NUL | / Type Subtype
         *
         * Example: "image/png"
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c type member you want to set.
         *
         * @param type The MIME type of the data being sent to the invocation handler.
         *               The value must conform to the "Type Subtype" format (see
         *               description for further information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_type(
                IntPtr invocation, char[] type);

        /**
         * @brief Set the URI of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_uri() function sets the URI pointing
         * to the data of a given @c navigator_invoke_invocation_t structure. The @c uri
         * member identifies the location of the data the invoked handler is to perform
         * an action on.
         *
         * If you don't call this function the URI is assumed to be "data://local",
         * indicating that the invocation data is provided through the @c data member
         * (using the @c navigator_invoke_invocation_set_data() function).
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c uri member you want to set.
         *
         * @param uri The URI to the data being sent to the invocation handler. The
         *            value of this member must conform to the standard directory format
         *            of "file://path/to/file".
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_uri(
                IntPtr invocation, char[] uri);

        /**
         * @brief Set the file transfer mode of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_file_transfer_mode() function sets the
         * file transfer mode.
         *
         * The transfer_mode identifies how the file transfer should be handled. By default,
         * private file transfer will be applied if the URI is a file:// URI that points
         * to a file that is not in the shared area. The file will be transfered by
         * creating a read-only copy in the target's private inbox.
         *
         * Setting the @c transfer_mode allows the sender to control the transfer by
         * specifying that no handling should be applied, or that the file should be
         * copied read/write, or should be hard-linked.
         *
         * If @c NAVIGATOR_INVOKE_FILE_TRANSFER_MODE_LINK is specified the file must
         * have o+r permissions. In addition, if the file is o+w then the sender must be
         * the owner of the file.
         *
         * @param invoke A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c transfer_mode member you want to set.
         *
         * @param transfer_mode The mode that should control the transfer of the data if
         *            the URI is a file:// that does not refer to a file in the shared
         *            area.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_file_transfer_mode(
                IntPtr invoke,
                FileTransferMode transfer_mode);

        /**
         * @brief Set the arbitrary data of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_data() function sets the @c data and
         * @c data_length of a given @c navigator_invoke_invocation_t structure. The @c
         * data member is the data the invoked handler is to perform an action on. Upon
         * sending the invocation, the data is delivered to the target in its unchanged
         * form.
         *
         * If you don't call this function the action and/or type information (which can
         * be set using the @c navigator_invoke_invocation_set_action() and @c
         * navigator_invoke_invocation_set_type() functions respectively) must be
         * sufficient to carry out the invocation.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c data you want to set.
         *
         * @param data The arbitrary data being sent to the invocation handler. The
         *            value of this member can take the form of any binary data.
         *
         * @param data_length The size of the @c data member in bytes.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_data(
                IntPtr invocation, IntPtr  data,
                int data_length);

        /**
         * @brief Set the perimeter of an @c invocation
         *
         * The @c navigator_invoke_invocation_set_perimeter() function sets the @c
         * perimeter member of a given @c navigator_invoke_invocation_t structure. The
         * @c perimeter member identifies the perimeter (either personal or enterprise)
         * in which the application should be invoked. Use this function in instances
         * where the target application is a "hybrid" that can run in both enterprise
         * and personal perimeters. For target applications that aren't hybrids, the
         * perimeter is mandated to be the same as the sender.
         *
         * If you don't call this function for a hybrid application, the @c perimeter is
         * set to @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL by default. If you don't
         * call this function for a non-hybrid application, the perimeter defaults to
         * the perimeter of the client.
         *
         * The possible values that you can set to this member are:
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE
         *
         * See the @c PerimeterType enumeration for details.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c perimeter member you want to set.
         *
         * @param perimeter The perimeter in which you want the application to be
         *                  invoked. This value must correspond to an entry in the @c
         *                  PerimeterType enumeration.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_perimeter(
                IntPtr invocation,
                PerimeterType perimeter);

        /**
         * @brief Set the metadata with which the application should be invoked
         *
         * The @c navigator_invoke_invocation_set_metadata() function sets the
         * metadata with which the application should be invoked.
         *
         * Mandatory: no
         *
         * @param invocation The invocation to update.
         * @param metadata The JSON string carrying optional metadata.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_set_metadata(
                IntPtr invocation, char[] metadata);

        /**
         * @brief Get the ID from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_id() function extracts the invocation
         * ID of a given @c navigator_invoke_invocation_t structure. The @c id member is
         * used by the invocation handler to create delivery receipt responses to be
         * returned when an invocation is sent (see the @c
         * navigator_invoke_invocation_set_id() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c id member you want to retrieve.
         *
         * @return The invocation ID if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_id(
                 IntPtr invocation);

        /**
         * @brief Get the target from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_target() function extracts the target
         * of a given @c navigator_invoke_invocation_t structure. The @c target member
         * is used by the invocation framework to identify the target application or
         * viewer meant to perform an action based on the invocation (see the @c
         * navigator_invoke_invocation_set_target() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c target member you want to retrieve.
         *
         * @return The invocation target if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_target(
                 IntPtr invocation);

        /**
         * @brief Get the source from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_source() function extracts the source
         * of a given @c navigator_invoke_invocation_t structure. The @c source member
         * is used by the invoked handler to direct resopnse messages to the invocator
         * (see the @c navigator_invoke_invocation_set_source() function for further
         * details). This function doesn't copy members and the returned values are
         * released once the @c navigator_invoke_invocation_t structure is destroyed
         * with the @c navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c source member you want to retrieve.
         *
         * @return The invocation source if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_source(
                 IntPtr invocation);

        /**
         * @brief Get the action from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_action() function extracts the @c
         * action member of a given @c navigator_invoke_invocation_t structure. The @c
         * action member is used by the brokering system and invocation framework to
         * identify what action an invoked handler is meant to perform (see the @c
         * navigator_invoke_invocation_set_action() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c action member you want to retrieve.
         *
         * @return The invocation action if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_action(
                 IntPtr invocation);

        /**
         * @brief Get the type from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_type() function extracts the MIME type
         * of a given @c navigator_invoke_invocation_t structure. The @c type member is
         * used by the brokering system and invocation framework to identify the MIME
         * type of the data an invoked handler is meant to perform an action on (see the
         * @c navigator_invoke_invocation_set_type() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c type member you want to retrieve.
         *
         * @return The invocation type if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_type(
                 IntPtr invocation);

        /**
         * @brief Get the URI from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_uri() function extracts the URI
         * pointing the data of a given @c navigator_invoke_invocation_t structure. The
         * @c uri member is used by the invocation handler to identify the location of
         * the data the invoked handler is to perform an action on (see the @c
         * navigator_invoke_invocation_set_uri() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c uri member you want to retrieve.
         *
         * @return The URI pointing to invocation data if one was provided by the
         *         sender, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_uri(
                 IntPtr invocation);

        /**
         * @brief Get the @c FileTransferMode transfer mode of an
         * @c invocation
         *
         * The @c navigator_invoke_invocation_get_file_transfer_mode() function extracts
         * the file transfer mode of a given @c navigator_invoke_invocation_t structure.
         *
         * The @c transfer mode member is used to control how files are passed between
         * sender and target (see the @c
         * navigator_invoke_invocation_set_file_transfer_mode() function for further
         * details).
         *
         * @param invoke A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose transfer mode member you want to retrieve.
         *
         * @return The file transfer mode that describes how the file will be transfered
         *         in the case that it points to a file:// that is not in the shared
         *         area, or @BPS_FAILURE with @c errno set if an error occurs.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_get_file_transfer_mode(
                 IntPtr  invoke);

        /**
         * @brief Get the data length from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_data_length() function extracts the
         * length in bytes of the data of a given @c
         * navigator_invoke_invocation_t structure. The @c data_length member is used by
         * the invocation handler to identify the size of the data the invoked handler
         * is to perform an action on (see the @c navigator_invoke_invocation_set_data()
         * function for further details). This function doesn't copy members and the
         * returned values are released once the @c navigator_invoke_invocation_t
         * structure is destroyed with the @c navigator_invoke_invocation_destroy()
         * function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c data_length member you want to retrieve.
         *
         * @return The size in bytes of the invocation data if one was provided by the
         *         sender, -1 otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_get_data_length(
                 IntPtr invocation);

        /**
         * @brief Get the data from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_data() function extracts the binary
         * data of a given @c navigator_invoke_invocation_t structure. The @c data
         * member is used by the invocation handler to perform an action (see the @c
         * navigator_invoke_invocation_set_data() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_invocation_t structure is destroyed with the @c
         * navigator_invoke_invocation_destroy() function.
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c data member you want to retrieve.
         *
         * @return The invocation data if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern IntPtr  navigator_invoke_invocation_get_data(
                 IntPtr invocation);

        /**
         * @brief Get the perimeter from an @c invocation
         *
         * The @c navigator_invoke_invocation_get_perimeter() function extracts the @c
         * perimeter member of a given @c navigator_invoke_invocation_t structure. The
         * @c perimeter member is used by the invocation framework to identify what
         * perimeter the target application is to be invoked (see the @c
         * navigator_invoke_invocation_set_perimeter() function for further details).
         *
         * @param invocation A pointer to the @c navigator_invoke_invocation_t structure
         *                   whose @c perimeter member you want to retrieve.
         *
         * @return The invocation perimeter if one was provided by the sender.
         */
        [DllImport("bps")]
        public static extern PerimeterType navigator_invoke_invocation_get_perimeter(
                 IntPtr invocation);

        /**
         * @brief Get the metadata with which the application should be invoked
         *
         * The @c navigator_invoke_invocation_get_metadata() function gets the
         * metadata with which the application should be invoked.
         *
         * Mandatory: no
         *
         * @param invocation The invocation to update.
         *
         * @return The metadata if it was provided by sender.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_invocation_get_metadata(
                 IntPtr invocation);

        /**
         * @brief Retrieve the @c navigator_invoke_invocation_t structure pointer from
         * the BPS event
         *
         * The @c navigator_invoke_event_get_invocation() function extracts the
         * invocation properties from a @c navigator_invoke_invocation_t structure sent
         * with the @c navigator_invoke_invocation_send() function. You should call this
         * function upon receiving the @c NAVIGATOR_INVOKE_TARGET event from the event
         * handler to perform the task defined by the invocation.
         *
         * We recommend that you use the @c navigator_event_get_err() function after
         * calling this function in case of an error in processing. The possible errors
         * for an invocation are:
         *      - @c INVOKE_NO_TARGET_ERROR: There is no target identified by the
         *                                   invocation.
         *      - @c INVOKE_BAD_REQUEST_ERROR: The invocation request specifications do
         *                                     not conform to the permitted parameters
         *                                     of the handler. For example, an image
         *                                     sharing invocation being sent to a
         *                                     target application that cannot share
         *                                     images would result in this error.
         *      - @c INVOKE_INTERNAL_ERROR: A generic error occured in the internal
         *                                  framework while attempting to retrieve the
         *                                  @c navigator_invoke_invocation_t structure.
         *      - @c INVOKE_TARGET_ERROR: A generic error occured with the target
         *                                handler.
         *
         * "Ownership" of an event is not transferred to a handler upon its invocation.
         * A handler must not call the @c navigator_invoke_invocation_destroy() function
         * on invocation pointers that are retrieved using the @c
         * navigator_invoke_event_get_invocation() function.  The pointer to the
         * @c navigator_invoke_invocation_t structure is valid until the @c
         * bps_get_event() function is called again.
         *
         * @param event The @c NAVIGATOR_INVOKE_TARGET event to extract the invocation
         * from.
         *
         * @return A pointer to the @c navigator_invoke_invocation_t structure on
         *         success, NULL on failure with @c errno set.
         */
        [DllImport("bps")]
        public static extern IntPtr navigator_invoke_event_get_invocation(
                IntPtr _event);

        /**
         * @brief Request an @c invocation to a target
         *
         * The @c navigator_invoke_invocation_send() function invokes a target handler
         * that is specified by the given @c navigator_invoke_invocation_t structure.
         * The target of an invocation can be determined in the following manners:
         *      - If you specified a @c target member (using the @c
         *        navigator_invoke_invocation_set_target() function, the target is
         *        invoked directly using the given information.
         *      - If you didn't specify a @c target member, the brokering system infers
         *        a target handler using the information from the @c action and/or @c
         *        type members, set with the @c navigator_invoke_invocation_set_action()
         *        and @c navigator_invoke_invocation_set_type() functions respectively.
         *
         * @param invocation The @c navigator_invoke_invocation_t structure to send.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_invocation_send(
                 IntPtr invocation);

        /**
         * @brief Create a @c navigator_invoke_query_t structure and allocate all
         *        necessary memory
         *
         * The @c navigator_invoke_query_create() function creates an instance of a @c
         * navigator_invoke_query_t structure called @c query to be used by the
         * invocation framework. Destroy all invocation query instances created through
         * this function once they are no longer needed by using the @c
         * navigator_invoke_query_destroy() function to prevent memory leaks.
         *
         * @param query The @c navigator_invoke_query_t structure to populate.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_create(out IntPtr query);

        /**
         * @brief Deallocate the memory used by a @c navigator_invoke_query_t
         * structure
         *
         * The @c navigator_invoke_invocation_destroy() function deallocates any memory
         * set to a given @c query. Use this function to deallocate memory used by
         * a @c navigator_invoke_query_t structure (created by the @c
         * navigator_invoke_query_create() function) that's no longer in use.
         * Failing to do so will result in a memory leak.
         *
         * @param query The @c navigator_invoke_query_t structure to deallocate.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_destroy(IntPtr query);

        /**
         * @brief Set the ID of a @c query
         *
         * The @c navigator_invoke_query_set_id() function sets the invocation query ID
         * of a given @c navigator_invoke_query_t structure. Assign an @c id member to
         * an invocation query to receive a delivery receipt response. The @c id member
         * you assign through a sender appears in its corresponding delivery receipt.
         *
         * Assigning an @c id member to an invocation is mandatory. If you don't assign
         * an @c id there is no way to determine the result of the invocation query
         * request.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              id you want to set.
         *
         * @param id The invocation query ID you want to display on the delivery receipt
         *           response. This value must be in numerical format. For example, a
         *           valid @c id would be "42".
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_id(IntPtr query,
                char[] id);

        /**
         * @brief Set the action of a @c query
         *
         * The @c navigator_invoke_query_set_action() function sets the @c action member
         * of a given @c navigator_invoke_query_t structure. The @c action member
         * identifies the action the invocation query results must be able to perform.
         *
         * If you don't assign an @c action member to an invocation query, the
         * brokering system doesn't filter for any specific action.
         *
         * The format of an @c action member must conform to the following guidelines:
         *      - Maximum 50 characters
         *      - Action: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "bb.action.SHARE"
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              action member you want to set.
         *
         * @param action The action you want to query for. The value must conform to the
         *               "[Domain][Sub-domain]" format (see description for further
         *               information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_action(IntPtr query,
                char[] action);

        /**
         * @brief Set the type of a @c query
         *
         * The @c navigator_invoke_query_set_type() function sets the MIME type of a
         * given @c navigator_invoke_query_t structure. The @c type member identifies
         * the MIME type the invocation query results must be able to parform an action
         * on.
         *
         * If you don't assign a @c type member to an invocation query, the brokering
         * system doesn't filter for any specific MIME type. You must assign this
         * member if you don't assign the @c file_uri member (using the @c
         * navigator_invoke_query_set_file_uri() function).
         *
         * The format of a @c type member must conform to the following guidelines:
         *      - MIME type: Type Subtype
         *      - Type: [a-zA-Z0-9-_\.]+
         *      - Subtype: NUL | / Type Subtype
         *
         * Example: "image/png"
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              type member you want to set.
         *
         * @param type The MIME type you want to query for. The value must conform to
         *             the "Type Subtype" format (see description for further
         *             information).
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_type(IntPtr query,
                char[] type);

        /**
         * @brief Set the file URI of a @c query
         *
         * The @c navigator_invoke_query_set_file_uri() function sets the file URI of a
         * given @c navigator_invoke_query_t structure. The @c file_uri member
         * identifies the type interface the invocation query results must be able to
         * perform an action on.
         *
         * You must assign this member if the @c type member (assinged wih the @c
         * navigator_invoke_query_set_type() function) is not provided.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              file_uri member you want to set.
         *
         * @param file_uri The file URI to the type interface you want to query for. The
         *            value of this member must conform to the standard directory format
         *            of "file://path/to/file.txt".
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_file_uri(IntPtr query,
                char[] file_uri);

        /**
         * @brief Set the target type mask of a @c query
         *
         * The @c navigator_invoke_query_set_target_type_mask() function sets the target type mask
         * of a given @c navigator_invoke_query_t structure. The @c target_type_mask member
         * indicates whether the invocation query should include results for targets
         * that are viewers, applications, cards, or all of the above.
         *
         * If you don't assign a @c target_type_mask member to an invocation query, the
         * brokering system doesn't filter for any specific target type mask.
         *
         * The possible values that you can set to this member are:
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_CARD
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE
         *     - @c bitwise-OR of the values above.
         *
         * See the @c TargetType enumeration for details.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              target_type_mask member you want to set.
         *
         * @param target_type_mask  A target type corresponding to an entry in the @c
         *                          TargetType enumeration. The  @c
         *                          NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE value is reserved for
         *                          future use.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_target_type_mask(
                IntPtr query,
                int target_type_mask);

        /**
         * @brief Set the action type of a @c query
         *
         * The @c navigator_invoke_query_set_action_type() function sets the action type
         * of a given @c navigator_invoke_query_t structure. The @c action_type member
         * indicates whether the invocation query returns only menu actions (actions
         * that have an icon and label) or both brokered and menu actions (which may not
         * all have an icon and label).
         *
         * If you don't assign an @c action_type member to an invocation query, the
         * brokering system doesn't filter for any specific action type.
         *
         * The possible values that you can set to this member are:
         *     - @c NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_MENU
         *     - @c NAVIGATOR_INVOKE_QUERY_ACTION_TYPE_ALL
         *
         * See the @c QueryActionType enumeration for details.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              action_type member you want to set.
         *
         * @param action_type An action type corresponding to an entry in the @c
         *                    QueryActionType enumeration.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_action_type(
                IntPtr query,
                QueryActionType action_type);

        /**
         * @brief Set the perimeter of a @c query
         *
         * The @c navigator_invoke_query_set_perimeter() function sets the @c perimeter
         * member of a given @c navigator_invoke_query_t structure. The @c perimeter
         * member indicates in which perimeter the resulting targets should reside. Use
         * this function in instances where the query results include "hybrid"
         * applications that can run in both enterprise and personal perimeters. For
         * target applications that aren't hybrids, the perimeter is mandated to be the
         * same as the sender.
         *
         * If you don't call this function, query results that are hybrid applications
         * set the @c perimeter value to @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL by
         * default, while results that are non-hybrid applications set the perimeter
         * to the perimeter of the client.
         *
         * The possible values that you can set to this member are:
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE
         *
         * See the @c PerimeterType enumeration for details.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              perimeter member you want to set.
         *
         * @param perimeter The perimeter in which you want the application to be
         *                  invoked. This value must correspond to an entry in the @c
         *                  PerimeterType enumeration.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_set_perimeter(
                IntPtr query,
                PerimeterType perimeter);

        /**
         * @brief Get the ID from a @c query
         *
         * The @c navigator_invoke_query_get_id() function extracts the invocation query
         * ID of a given @c navigator_invoke_query_t structure. The @c id member is
         * used by the query handler to create delivery receipt responses to be returned
         * when an invocation query is sent (see the @c navigator_invoke_query_set_id()
         * function for further details). This function doesn't copy members and the
         * returned values are released once the @c navigator_invoke_query_t structure
         * is destroyed with the @c navigator_invoke_query_destroy() function.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              id member you want to retrieve.
         *
         * @return The invocation query ID if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_get_id(
                 IntPtr query);

        /**
         * @brief Get the action from a @c query
         *
         * The @c navigator_invoke_query_get_action() function extracts the @c action
         * member of a given @c navigator_invoke_query_t structure. The @c action member
         * is used by the brokering system to identify what action the invocation query
         * results must be able to perform (see the @c
         * navigator_invoke_query_set_action() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_query_t structure is destroyed with the @c
         * navigator_invoke_query_destroy() function.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              action member you want to retrieve.
         *
         * @return The action to query for if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_get_action(
                 IntPtr query);

        /**
         * @brief Get the type from a @c query
         *
         * The @c navigator_invoke_query_get_type() function extracts the MIME type
         * of a given @c navigator_invoke_query_t structure. The @c type member is used
         * by the brokering system to identify what MIME type the invocation query
         * results must be able to perform an action on (see the @c
         * navigator_invoke_query_set_type() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_query_t structure is destroyed with the @c
         * navigator_invoke_query_destroy() function.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              type member you want to retrieve.
         *
         * @return The MIME type to query for if one was provided by the sender, @c NULL
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_get_type(
                 IntPtr query);

        /**
         * @brief Get the file URI from a @c query
         *
         * The @c navigator_invoke_query_get_file_uri() function extracts the file URI
         * of a given @c navigator_invoke_query_t structure. The @c file_uri member is
         * used by the brokering system to identify what type interface the invocation
         * query results must be able to perform an action on (see the @c
         * navigator_invoke_query_set_file_uri() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_query_t structure is destroyed with the @c
         * navigator_invoke_query_destroy() function.
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              file_uri member you want to retrieve.
         *
         * @return The file URI to the type interface to query for if one was provided
         *         by the sender, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_get_file_uri(
                 IntPtr query);

        /**
         * @brief Get the target type mask from a @c query
         *
         * The @c navigator_invoke_query_get_target_type_mask() function extracts the target
         * type of a given @c navigator_invoke_query_t structure. The @c target_type_mask
         * member is used by the brokering system to identify whether the invocation
         * query should include results for targets that are viewers, applications,
         * cards, or all three (see the @c navigator_invoke_query_set_target_type_mask()
         * function and the @c TargetType enumeration for further
         * details).
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              target_type_mask member you want to retrieve.
         *
         * @return The invocation query target type mask to query for if one was provided
         *         by the sender.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_get_target_type_mask(
                 IntPtr query);

        /**
         * @brief Get the action type from a @c query
         *
         * The @c navigator_invoke_query_get_action_type() function extracts the action
         * type of a given @c navigator_invoke_query_t structure. The @c action_type
         * member is used by the brokering system to identify whether the invocation
         * query should return only menu actions or both brokered and menu actions (see
         * the @c navigator_invoke_query_set_action_type() function and the @c
         * QueryActionType enumeration for further details).
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              action_type member you want to retrieve.
         *
         * @return The invocation query target type to query for if one was provided
         *         by the sender.
         */
        [DllImport("bps")]
        public static extern QueryActionType navigator_invoke_query_get_action_type(
                 IntPtr query);

        /**
         * @brief Get the perimeter from a @c query
         *
         * The @c navigator_invoke_query_get_perimeter() function extracts the @c
         * perimeter member of a given @c navigator_invoke_query_t structure. The @c
         * perimeter member is used by the invocation framework to identify in which
         * perimeter the resulting targets should reside (see the @c
         * navigator_invoke_query_set_perimeter() function and the @c
         * PerimeterType enumeration for further details).
         *
         * @param query A pointer to the @c navigator_invoke_query_t structure whose @c
         *              perimeter member you want to retrieve.
         *
         * @return The perimeter in which the query target should be invoked if one was
         *         provided by the sender, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern PerimeterType navigator_invoke_query_get_perimeter(
                 IntPtr query);

        /**
         * @brief Send a @c query request to the invocation framework
         *
         * The @c navigator_invoke_query_send() function deploys an invocation query
         * that is specified by the given @c navigator_invoke_query_t structure. Viable
         * candidates conforming to the specifications set through the various members
         * of the @c navigator_invoke_query_t structure (using the @c
         * navigator_invoke_query_set_*() functions) are returned as results of the
         * query.
         *
         * @param query The @c navigator_invoke_query_t structure to send.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_send( IntPtr query);

        /**
         * @brief Get the number of @c action values in an invocation query result
         *
         * The @c navigator_invoke_event_get_query_result_action_count() function
         * extracts the number of @c navigator_invoke_query_result_action_t structure
         * results that are returned from an invocation query. The @c
         * navigator_invoke_query_result_action_t action structures returned are
         * considered viable actions based on the information supplied through the @c
         * navigator_invoke_query_t structure that invoked the query. Call this function
         * from an event handler upon receiving the @c NAVIGATOR_INVOKE_QUERY_RESULT
         * event to determine how many viable actions were returned. You can use this
         * value to create a loop of the returned values.
         *
         * If you encounter an error in processing the query, we recommend that you call
         * the @c navigator_event_get_err() function to determine the nature of the
         * error. The possible errors are:
         *     - @c invalid_argument
         *     - @c response_too_large
         *     - @c server_error
         *
         * @param event The @c NAVIGATOR_INVOKE_QUERY_RESULT event targeted by the query
         *              result.
         *
         * @return The number of actions inside the invocation query result, -1
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_event_get_query_result_action_count(
                IntPtr _event);

        /**
         * @brief Get an @c action from an invocation query result
         *
         * The @c navigator_invoke_event_get_query_result_action() function extracts one
         * of the @c navigator_invoke_query_result_action_t structure results returned
         * from an invocation query, identified by a given @c index value. The @c
         * navigator_invoke_query_result_action_t action structures returned are
         * considered viable actions based on the information supplied through the @c
         * navigator_invoke_query_t structure that invoked the query. This function
         * doesn't copy members and the returned values are released once the @c
         * bps_get_event() function is called again.
         *
         * Please note that "ownership" of the event is not passed to the handler. For
         * this reason, don't call the free function on invocation query result action
         * pointers that are retrieved using this function.
         *
         * @param event The @c NAVIGATOR_INVOKE_QUERY_RESULT event targeted by the query
         *              result.
         *
         * @param index The numerical index value of the @c
         *              navigator_invoke_query_result_action_t structure inside the
         *              invocation query result.
         *
         * @return The pointer to the returned action, @c NULL if the query result is
         *         @c NULL or the @c index is out of bounds.
         */
        [DllImport("bps")]
        public static extern  IntPtr  navigator_invoke_event_get_query_result_action(
                IntPtr _event, int index);

        /**
         * @brief Get the name of an @c action from an invocation query result
         *
         * The @c navigator_invoke_query_result_action_get_name() function extracts the
         * action name of a given @c navigator_invoke_query_result_action_t structure.
         * The @c name member is used by the query result handler to identify a given @c
         * action that is supported for the specified query. This function doesn't copy
         * members and the returned values are released once the @c bps_get_event()
         * function is called again. You must call this function to display the returned
         * @c action value(s).
         *
         * Each @c action @c name conforms to the following guidelines:
         *      - Maximum 50 characters
         *      - Action: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "bb.action.SHARE"
         *
         * @param action The @c navigator_invoke_query_result_action_t structure whose
         *               @c name member you want to retrieve.
         *
         * @return The name of the given action, in the "[Domain][Sub-domain]" format
         *         (see description for further information), @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_action_get_name(
                 IntPtr action);

        /**
         * @brief Get the icon of an @c action from an invocation query result
         *
         * The @c navigator_invoke_query_result_action_get_icon() function extracts the
         * URI to an icon of a given @c navigator_invoke_query_result_action_t
         * structure. The @c icon member is a path to an icon to be identified with the
         * corresponding action. This function doesn't copy members and the returned
         * values are released once the @c bps_get_event() function is called again.
         *
         * @param action The @c navigator_invoke_query_result_action_t structure whose
         *               @c icon member you want to retrieve.
         *
         * @return The icon URI of the given @c action, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_action_get_icon(
                 IntPtr action);

        /**
         * @brief Get the label of an @c action from an invocation query result
         *
         * The @c navigator_invoke_query_result_action_get_label() function extracts the
         * label to an icon of a given @c navigator_invoke_query_result_action_t
         * structure. The @c label member allows the action to be identified with a
         * localized label name in UTF-8 format. For example, a suitable label for the
         * "bb.action.SHARE" action would be "Share". This function doesn't copy members
         * and the returned values are released once the @c bps_get_event() function is
         * called again.
         *
         * @param action The @c navigator_invoke_query_result_action_t structure whose
         *               @c label member you want to retrieve.
         *
         * @return The label of the given @c action, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_action_get_label(
                 IntPtr action);

        /**
         * @brief Get the default target of an @c action from an invocation query result
         *
         * The @c navigator_invoke_query_result_action_get_default_target() function
         * extracts the default target of a given @c
         * navigator_invoke_query_result_action_t structure. The @c default_target
         * member is the name of a target handler that is considered as the default
         * provider for the given @c action. This function doesn't copy members and the
         * returned values are released once the @c bps_get_event() function is called
         * again.
         *
         * Each @c action @c default_target conforms to the following guidelines:
         *      - Maximum 50 characters
         *      - Target: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "com.example.target"
         *
         * @param action The @c navigator_invoke_query_result_action_t structure whose
         *               @c default_target member you want to retrieve.
         *
         * @return The default target of the given @c action, in the
         *         "[Domain][Sub-domain]" format (see description for further
         *         information), @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_action_get_default_target(
                 IntPtr action);

        /**
         * @brief Get the number of @c target values in an @c action
         *
         * The @c invoke_get_query_result_target_count() function extracts the number of
         * @c navigator_invoke_query_result_target_t structures contained within a @c
         * navigator_invoke_query_result_action_t structure. The @c
         * navigator_invoke_query_result_target_t target structures contained are
         * considered viable targets to perform the given action.
         *
         * @param action The @c navigator_invoke_query_result_action_t structure holding
         *               the @c target values.
         *
         * @return The number of targets inside the @c action, -1 otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_query_result_action_get_target_count(
                 IntPtr action);

        /**
         * @brief Get a @c target from an @c action
         *
         * The @c navigator_invoke_query_result_action_get_target() function extracts
         * one of the @c navigator_invoke_query_result_target_t structures inside of a
         * @c navigator_invoke_query_result_action_t structure, identified by a given @c
         * index value. The @c navigator_invoke_query_result_target_t target structures
         * contained are considered viable targets to perform the given action. This
         * function doesn't copy members and the returned values are released once the
         * @c bps_get_event() function is called again.
         *
         * @param action The @c navigator_invoke_query_result_action_t structure holding
         *               the @c target values.
         *
         * @param index The numerical index value of the @c
         *              navigator_invoke_query_result_target_t structure inside the
         *              given @c navigator_invoke_query_result_action_t structure.
         *
         * @return The pointer to the returned target, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern  IntPtr  navigator_invoke_query_result_action_get_target(
                 IntPtr action, int index);

        /**
         * @brief Get the key of a @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_key() function extracts the
         * target key of a given @c navigator_invoke_query_result_target_t structure.
         * The @c key member is an identifier to a target (as stated in its BAR
         * manifest) that is capable of performing the specified action. This function
         * doesn't copy members and the returned values are released once the @c
         * bps_get_event() function is called again. You must call this function to
         * display returned @c target value(s).
         *
         * Each @c target @c key conforms to the following guidelines:
         *      - Maximum 50 characters
         *      - Target: [Domain][Sub-domain]
         *      - Sub-domain:  NUL | .[Domain][Sub-domain]
         *      - Domain: [a-zA-Z]([a-zA-Z0-9_])*
         *
         * Example: "com.example.invoke.target"
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c key member you want to retrieve.
         *
         * @return The location key of the given target, in the "[Domain][Sub-domain]"
         *         format (see description for further information), @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_target_get_key(
                 IntPtr target);

        /**
         * @brief Get the icon of an @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_icon() function extracts the
         * URI to an icon of a given @c navigator_invoke_query_result_target_t
         * structure. The @c icon member is a path to an icon to be identified with the
         * corresponding target. This function doesn't copy members and the returned
         * values are released once the @c bps_get_event() function is called again. You
         * must call this function to display returned @c target value(s).
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c icon member you want to retrieve.
         *
         * @return The icon URI of the given @c target, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_target_get_icon(
                 IntPtr target);

        /**
         * @brief Get the splash of an @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_splash() function extracts
         * the URI to a splash icon of a given @c navigator_invoke_query_result_target_t
         * structure. The @c splash member is a path to an icon to be displayed to
         * represent the given target while loading. This function doesn't copy members
         * and the returned values are released once the @c bps_get_event() function is
         * called again.
         *
         * You must call this function if the @c target @c type is a viewer. To test
         * this, call the @c navigator_invoke_query_result_target_get_type() function.
         * If the function returns @c NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER, the given
         * target is a viewer).
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c splash member you want to retrieve.
         *
         * @return The splash icon URI of the given @c target, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_target_get_splash(
                 IntPtr target);

        /**
         * @brief Get the label of a @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_label() function extracts the
         * label to an icon of a given @c navigator_invoke_query_result_target_t
         * structure. The @c label member allows the target to be identified with a
         * localized label name in UTF-8 format. For example, "Example Target" would be
         * a suitable label for a target. This function doesn't copy members and the
         * returned values are released once the @c bps_get_event() function is called
         * again. You must call this function to display returned @c target value(s).
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c label member you want to retrieve.
         *
         * @return The label of the given @c target, @c NULL otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_query_result_target_get_label(
                 IntPtr target);

        /**
         * @brief Get the type of a @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_type() function extracts the
         * target type of a given @c navigator_invoke_query_result_target_t structure.
         * The @c type member allows the target to be identified as a viewer,
         * aplication, service, or card. You must call this function to display returned
         * @c target value(s).
         *
         * The possible values that you can receive from this member are:
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_CARD
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c type member you want to retrieve.
         *
         * @return The type of the given @c target.
         */
        [DllImport("bps")]
        public static extern TargetType navigator_invoke_query_result_target_get_type(
                 IntPtr target);

        /**
         * @brief Get the perimeter of a @c target for an @c action
         *
         * The @c navigator_invoke_query_result_target_get_perimeter() function extracts
         * the @c perimeter member of a given @c navigator_invoke_query_result_target_t
         * structure. The @c perimeter member indicates in which perimeter the given
         * target should reside. You must call this function to display returned @c
         * target value(s).
         *
         * The possible values that you can receive from this member are:
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_PERSONAL
         *     - @c NAVIGATOR_INVOKE_PERIMETER_TYPE_ENTERPRISE
         *
         * @param target The @c navigator_invoke_query_result_target_t structure whose
         *               @c perimeter member you want to retrieve.
         *
         * @return The perimeter in which the given @c target should reside.
         */
        [DllImport("bps")]
        public static extern PerimeterType navigator_invoke_query_result_target_get_perimeter(
                 IntPtr target);

        /**
         * @brief Create a @c navigator_invoke_viewer_t structure and allocate all
         *        necessary memory
         *
         * The @c navigator_invoke_viewer_create() function creates an instance of a @c
         * navigator_invoke_viewer_t structure called @c viewer to be used by the
         * invocation framework, and associates it to a @c navigator_invoke_invocation_t
         * invocation structure. Destroy all viewer instances created through this
         * function once they are no longer needed by using the @c
         * navigator_invoke_viewer_destroy() function to prevent memory leaks.
         *
         * @param viewer The @c navigator_invoke_viewer_t structure to populate.
         *
         * @param invocation The @c navigator_invoke_invocation_t structure to associate
         *                   with the given @c viewer. The @c invocation member cannot
         *                   be @c NULL. When you call this function, ownership of the
         *                   @c navigator_invoke_invocation_t structure is passed to the
         *                   @c navigator_invoke_viewer_t structure, and is destroyed
         *                   once you call the @c navigator_invoke_viewer_destroy()
         *                   function. For this reason, don't call the @c
         *                   navigator_invoke_invocation_destroy() function once you
         *                   call the @c navigator_invoke_viewer_create() function.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_create(out IntPtr viewer,
                IntPtr invocation);

        /**
         * @brief Deallocate the memory used by a @c navigator_invoke_viewer_t
         * structure
         *
         * The @c navigator_invoke_viewer_destroy() function deallocates any memory set
         * to a given @c viewer. Use this function to deallocate memory used by a @c
         * navigator_invoke_viewer_t structure (created by the @c
         * navigator_invoke_viewer_create() function) that's no longer in use. Failing
         * to do so will result in a memory leak.
         *
         * Please note that calling this function will also destroy the @c
         * navigator_invoke_invocation_t structure associated with the given @c
         * navigator_invoke_viewer_t structure. For this reason, don't call the @c
         * navigator_invoke_invocation_destroy() function on a @c
         * navigator_invoke_invocation_t structure that has been associated with a
         * viewer using the @c navigator_invoke_viewer_create() function.
         *
         * @param viewer The @c navigator_invoke_viewer_t structure to deallocate.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_destroy(
                IntPtr viewer);

        /**
         * @brief Get the @c viewer from a BPS event
         *
         * The @c navigator_invoke_event_get_viewer() function extracts a pointer to the
         * @c navigator_invoke_viewer_t structure that has been sent to the handler
         * calling this function. Call this function from the event handler upon
         * receiving the @c NAVIGATOR_INVOKE_VIEWER event to extract the invocation
         * viewer properties (see the @c navigator_invoke_viewer_*() functions for
         * further details about the @c navigator_invoke_viewer_t structure). The
         * pointer to the @c navigator_invoke_viewer_t structure is valid until the @c
         * bps_get_event() function is called again.
         *
         * If you encounter an error in processing the viewer invocation, we recommend
         * that you call the @c navigator_event_get_err() function to determine the
         * nature of the error. The possible errors are:
         *     - INVOKE_NO_TARGET_ERROR
         *     - INVOKE_BAD_REQUEST_ERROR
         *     - INVOKE_INTERNAL_ERROR
         *     - INVOKE_TARGET_ERROR
         *
         * Please note that "ownership" of the event is not passed to the handler. For
         * this reason, don't call the @c navigator_invoke_viewer_destroy() function
         * from the handler on @c navigator_invoke_viewer_t structures that are
         * retrieved using this function.
         *
         * @param event The @c NAVIGATOR_INVOKE_VIEWER event targeted by the @c viewer.
         *
         * @return A pointer to the @c navigator_invoke_viewer_t structure upon success,
         *         @c NULL with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern  IntPtr  navigator_invoke_event_get_viewer(
                IntPtr _event);

        /**
         * @brief Get the @c invocation from a @c viewer
         *
         * The @c navigator_invoke_viewer_get_invocation() function extracts a pointer
         * to the @c navigator_invoke_invocation_t structure that has been assigned to
         * the given @c navigator_invoke_viewer_t structure. This can be used to
         * retrieve invocation members assigned to a given @c viewer. For example, call
         * this function from the event handler upon calling the @c
         * navigator_invoke_event_get_viewer() function to extract the invocation
         * properties of the viewer (see the @c navigator_invoke_invocation_set_*()
         * functions for further details about the @c navigator_invoke_invocation_t
         * structure parameters).
         *
         * If you retrieved the given @c viewer using the @c
         * navigator_invoke_event_get_viewer() function, the pointer to the @c
         * navigator_invoke_viewer_t structure remains valid until the @c
         * bps_get_event() function is called again. If you created the @c viewer using
         * @c navigator_invoke_viewer_create(), the pointer will be valid until the @c
         * navigator_invoke_viewer_destroy() function is called.
         *
         * Please note that "ownership" of the invocation is not passed to the handler.
         * For this reason, don't call the @c navigator_invoke_invocation_destroy()
         * function on @c navigator_invoke_invocation_t structures that are retrieved
         * using this function.
         *
         * @param viewer The @c navigator_invoke_viewer_t structure to extract the @c
         *               navigator_invoke_invocation_t structure from.
         *
         * @return A pointer to the @c navigator_invoke_invocation_t structure upon
         *         success, @c NULL with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern  IntPtr  navigator_invoke_viewer_get_invocation(
                 IntPtr viewer);

        /**
         * @brief Set the window ID of a @c viewer
         *
         * The @c navigator_invoke_viewer_set_window_id() function sets the window ID of
         * a given @c navigator_invoke_viewer_t structure. The @c window_id member
         * identifies a window created by the viewer. You may use this for application
         * to viewer communication. You must set a @c window_id to all @c
         * navigator_invoke_viewer_t structures.
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c window_id you want to set.
         *
         * @param window_id The window ID you want to associate with a window created by
         *                  the viewer. The value can be any string of characters. For
         *                  example, "window#123" is an acceptable window ID.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_set_window_id(
                IntPtr viewer, char[] window_id);

        /**
         * @brief Set the width of a @c viewer
         *
         * The @c navigator_invoke_viewer_set_width() function sets the window width of
         * a given @c navigator_invoke_viewer_t structure. The @c width member
         * identifies the width of a window created by the viewer. You must set a @c
         * width to all @c navigator_invoke_viewer_t structures.
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c width you want to set.
         *
         * @param width The width in pixels you want to set to a window created by the
         *              viewer. The value must be an integer. For example, "100" is an
         *              acceptable width.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_set_width(
                IntPtr viewer, int width);

        /**
         * @brief Set the height of a @c viewer
         *
         * The @c navigator_invoke_viewer_set_height() function sets the window height
         * of a given @c navigator_invoke_viewer_t structure. The @c height member
         * identifies the height of a window created by the viewer. You must set a @c
         * height to all @c navigator_invoke_viewer_t structures.
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c height you want to set.
         *
         * @param height The height in pixels you want to set to a window created by the
         *               viewer. The value must be an integer. For example, "100" is an
         *               acceptable height.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_set_height(
                IntPtr viewer, int height);

        /**
         * @brief Get the window ID from a @c viewer
         *
         * The @c navigator_invoke_viewer_get_window_id() function extracts the window
         * ID of a given @c navigator_invoke_viewer_t structure. The @c window_id member
         * is used to identify the window created by a viewer invocation (see the @c
         * navigator_invoke_viewer_set_window_id() function for further details). This
         * function doesn't copy members and the returned values are released once the
         * @c navigator_invoke_viewer_t structure is destroyed with the @c
         * navigator_invoke_viewer_destroy() function.
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c window_id member you want to retrieve.
         *
         * @return The invocation viewer window ID if was provided by the sender, @c
         *         NULL with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_viewer_get_window_id(
                 IntPtr viewer);

        /**
         * @brief Get the width of a @c viewer
         *
         * The @c navigator_invoke_viewer_get_width() function extracts the window width
         * of a given @c navigator_invoke_viewer_t structure. The @c width member is
         * used to set the width of the window created by a viewer invocation (see the
         * @c navigator_invoke_viewer_set_width() function for further details).
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c width member you want to retrieve.
         *
         * @return The invocation viewer width if was provided by the sender, -1 with @c
         *         errno set otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_get_width(
                 IntPtr viewer);

        /**
         * @brief Get the height of a @c viewer
         *
         * The @c navigator_invoke_viewer_get_height() function extracts the window
         * height of a given @c navigator_invoke_viewer_t structure. The @c height
         * member is used to set the height of the window created by a viewer invocation
         * (see the @c navigator_invoke_viewer_set_height() function for further
         * details).
         *
         * @param viewer A pointer to the @c navigator_invoke_viewer_t structure whose
         *               @c height member you want to retrieve.
         *
         * @return The invocation viewer height if was provided by the sender, -1 with
         *         @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_get_height(
                 IntPtr viewer);

        /**
         * @brief Send a @c viewer invocation request to the invocation framework
         *
         * The @c navigator_invoke_viewer_send() function invokes a target handler
         * that is specified by the given @c navigator_invoke_invocation_t structure
         * within the @c navigator_invoke_viewer_t structure (see the @c
         * navigator_invoke_invocation_send() function for more details regarding how
         * a target for an invocation is determined). The handler uses the information
         * provided in the the @c navigator_invoke_viewer_t structure to invoke an
         * instance of a viewer with the given parameters.
         *
         * @param viewer The @c navigator_invoke_viewer_t structure to send.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_send(
                 IntPtr viewer);

        /**
         * @brief Close a @c viewer that has been invoked by the invocation framework
         *
         * The @c navigator_invoke_close_viewer() function closes the viewer window of a
         * given @c navigator_invoke_viewer_t structure that was started with the
         * @c navigator_invoke_viewer_send() function.
         *
         * @param window_id The window ID associated with the viewer window you want to
         *        close. The @c window_id member cannot be @c NULL.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_close_viewer(char[]window_id);

        /**
         * @brief Send a message between an appilcation and an associated viewer
         *
         * The @c navigator_invoke_viewer_relay() function enables two way communication
         * between the parent application and the viewer in the form of request/response
         * messages. Both the viewer and the parent application use this function to
         * send the data to each other.
         *
         * If you call this function, the target application or viewer receives the @c
         * NAVIGATOR_INVOKE_VIEWER_RELAY request event, and can retrieve the sent data.
         * The sender gets a @c NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT response event as a
         * response to the sent message.
         *
         * If you encounter an error in processing the message delivery, we recommend
         * that you call the @c navigator_event_get_err() function to determine the
         * nature of the error. The possible errors are:
         *     - @c INVALID_WINDOW_ID
         *     - @c INVALID_MESSAGE
         *
         * @param window_id The window ID associated with the viewer. The @c window_id
         *                  member must not be NULL.
         * @param message_name The name or title of the message you want to send. The @c
         *                     message_name member must not be NULL.
         * @param data The data you want to send the viewer relay message target. The @c
         *             data member can be NULL.
         * @param id The ID of the message. This is used to correlate the request with
         *           the peer's response. If you don't set this member the sender
         *           doesn't receive a response to the sent message. Use the @c
         *           navigator_event_get_id() function to retrieve the @c id from the
         *           @c NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT response event.
         * @param is_response The request/response type of the message. If this member
         *                    is @c false, the message type is a request, otherwise it's
         *                    a response. The request messages are received by peer
         *                    through @c NAVIGATOR_INVOKE_VIEWER_RELAY events. The
         *                    responses from the peer are received through @c
         *                    NAVIGATOR_INVOKE_VIEWER_RELAY_RESULT events.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_viewer_relay(char[]window_id,
                char[]message_name, char[]data, char[]id,
                bool is_response);

        /**
         * @brief Get the window ID of a @c viewer from a viewer relay message
         *
         * The @c navigator_invoke_event_get_viewer_relay_window_id() function extracts
         * the window ID of a given viewer relay message (created and sent using the @c
         * navigator_invoke_viewer_relay() function). The @c window_id member is used by
         * the receiving target to identify the @c viewer that sent the message. Call
         * this function in the parent application upon receiving the @c
         * NAVIGATOR_INVOKE_VIEWER_RELAY event to identify the corresponding @c viewer.
         * This function doesn't copy data and the returned values are released once the
         * @c bps_get_event() function is called again.
         *
         * @param event The @c NAVIGATOR_INVOKE_VIEWER_RELAY event targeted by the @c
         *              viewer.
         *
         * @return The window ID of the viewer that sent the relay data, @c NULL with @c
         *         errno set otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_viewer_relay_window_id(
                IntPtr _event);

        /**
         * @brief Get the name of a viewer relay message
         *
         * The @c navigator_invoke_event_get_viewer_relay_message_name() function
         * extracts the name of a given viewer relay message (created and sent using the
         * @c navigator_invoke_viewer_relay() function). The @c name member is used by
         * the receiving target (either the viewer or parent application) to identify
         * the name of the message sent by the sender (if the receiver is the viewer,
         * then the sender is the parent application, and vice versa). Call this
         * function upon receiving the @c NAVIGATOR_INVOKE_VIEWER_RELAY event to
         * identify the message name. This function doesn't copy data and the returned
         * values are released once the @c bps_get_event() function is called again.
         *
         * @param event The @c NAVIGATOR_INVOKE_VIEWER_RELAY event targeted by the
         *              sender of the viewer relay message.
         *
         * @return The name of the message set by the viewer relay sender, @c NULL with
         *         @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_viewer_relay_message_name(
                IntPtr _event);

        /**
         * @brief Get the data of a viewer relay message
         *
         * The @c navigator_invoke_event_get_viewer_relay_data() function extracts the
         * data of a given viewer relay message (created and sent using the @c
         * navigator_invoke_viewer_relay() function). The @c data member is used by
         * the receiving target (either the viewer or parent application) to identify
         * the data content of the message sent by the sender (if the receiver is the
         * viewer, then the sender is the parent application, and vice versa). Call this
         * function upon receiving the @c NAVIGATOR_INVOKE_VIEWER_RELAY event to
         * identify the data of the message. This function doesn't copy data and the
         * returned values are released once the @c bps_get_event() function is called
         * again.
         *
         * @param event The @c NAVIGATOR_INVOKE_VIEWER_RELAY event targeted by the
         *              sender of the viewer relay message.
         *
         * @return The data of the message set by the viewer relay sender, @c NULL with
         *         @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_viewer_relay_data(
                IntPtr _event);

        /**
         * @brief Get the window ID of a terminated @c viewer
         *
         * The @c navigator_invoke_event_get_window_id() function extracts the window ID
         * of a given viewer that has been terminated. The @c window_id member is used
         * by the parent application to identify the @c viewer that was terminated. Call
         * this function in the parent application upon receiving a @c
         * NAVIGATOR_INVOKE_VIEWER_STOPPED event to identify the terminated @c viewer.
         * This function doesn't copy data and the returned values are released once the
         * @c bps_get_event() function is called again.
         *
         * @param event The @c NAVIGATOR_INVOKE_VIEWER_STOPPED event triggered by the
         *              terminated @c viewer.
         *
         * @return The window ID of the terminated @c viewer, @c NULL with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_window_id(IntPtr _event);

        /**
         * @brief Get the key of an invoked @c target from the BPS event
         *
         * The @c navigator_invoke_event_get_target() function extracts the target key
         * of an invoked target application. The target key is an identifier to a
         * target (as stated in its BAR manifest) that had been invoked. Call this
         * function in the application upon receiving a @c
         * NAVIGATOR_INVOKE_TARGET_RESULT event to identify the target that was invoked.
         * This function doesn't copy data and the returned value is released once the
         * @c bps_get_event() function is called again.
         *
         * @param event The @c NAVIGATOR_INVOKE_TARGET_RESULT event triggered by the
         *              invoked target.
         *
         * @return The key of the target that was invoked, NULL with @c errno set
         *         otherwise.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_target(IntPtr _event);

        /**
         * @brief Get the type of an invoked @c target from the BPS event
         *
         * The @c navigator_invoke_event_get_target() function extracts the target type
         * of an invoked target application. The @c type member allows the target to be
         * identified as a viewer, aplication, service, or card.
         *
         * The possible values that you can receive from this member are:
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_APPLICATION
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_CARD
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_VIEWER
         *     - @c NAVIGATOR_INVOKE_TARGET_TYPE_SERVICE
         *
         * @param event The @c NAVIGATOR_INVOKE_TARGET_RESULT event triggered by the
         *              invoked target.
         *
         * @return The type of the target that was invoked upon success, @c BPS_FAILURE
         *         with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_event_get_target_type(IntPtr _event);

        /**
         * @brief Get the group ID of an invocation source application from the BPS
         *        event
         *
         * The @c navigator_invoke_event_get_group_id() function extracts the group ID
         * of an
         * invocation source application. The group ID is an identifier to the client
         * application that sent the invocation. Call this function in the application
         * upon receiving a @c NAVIGATOR_INVOKE_TARGET or @c NAVIGATOR_INVOKE_VIEWER
         * events to identify the source of the invocation.
         *
         * @param event The The @c NAVIGATOR_INVOKE_TARGET or @c NAVIGATOR_INVOKE_VIEWER
         *              event triggered by the source application.
         *
         * @return The group ID of the invocation source application upon success, @c
         *         BPS_FAILURE with @c errno set otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_event_get_group_id(IntPtr _event);

        /**
         * @brief Get the dname of an invocation source application from the BPS event
         *
         * The @c navigator_invoke_event_get_dname() function extracts the dname of an
         * invocation source application. The dname is an identifier to a package, and
         * contains the package name and package ID attributes. Call this function in
         * the application upon receiving a @c NAVIGATOR_INVOKE_TARGET or @c
         * NAVIGATOR_INVOKE_VIEWER events to identify the source of the invocation.
         * This function doesn't copy data and the returned value is released once the
         * @c bps_get_event() function is called again.
         *
         * @param event The The @c NAVIGATOR_INVOKE_TARGET or @c NAVIGATOR_INVOKE_VIEWER
         *              event triggered by the source application.
         *
         * @return The dname of the invocation source application.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_dname(IntPtr _event);

        /**
         * @brief Sends the set target filters request to the invocation framework.
         *
         * The @c navigator_invoke_set_filters() function sends the set target filters
         * request to the invocation framework.
         *
         * @param id The ID you want to display on the delivery receipt response. This
         *           value must be in numerical format. For example, a valid @c id
         *           would be "42".
         *
         * @param target The target key of the target whose filters are to be set.
         *
         * @param filters The array of filters to be set.
         *
         * @param filters_count The size of the filters array.
         *
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        //public static extern int navigator_invoke_set_filters(char[]id, char[]target,
        //        char[]filters[], int filters_count);

        /**
         * @brief Sends the get target filters invocation request to the invocation
         * framework.
         *
         * The @c navigator_invoke_get_filters() function sends the get target filters
         * invocation request to the invocation framework.
         *
         * @param id The ID you want to display on the delivery receipt response. This
         *           value must be in numerical format. For example, a valid @c id
         *           would be "42".
         *
         * @param target The target key of the target whose filters are to be retrieved.
         *
         * @return @c BPS_SUCCESS upon success, @c BPS_FAILURE with @c errno set
         * otherwise.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_get_filters(char[]id, char[]target);

        /**
         * @brief Get the target of the get target filters invocation result
         *
         * The function doesn't copy the data and the returned value will be released
         * once the @c bps_get_event() function is called again.
         *
         * The @c navigator_invoke_event_get_filters_target()
         * function should be called by the application upon receiving the
         * @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT event to extract the
         * target of the get target filters invocation.
         *
         * @param event The @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT event.
         *
         * @return The the target of the get target filters invocation result.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_filters_target(
                IntPtr _event);

        /**
         * @brief Get the filters count of the get target filters invocation result
         *
         * The function doesn't copy the data and the returned value will be released
         * once the @c bps_get_event() function is called again.
         *
         * The
         * @c navigator_invoke_event_get_filters_count()
         * function should be called by the application upon receiving the
         * @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT event to extract the
         * filters count of the get target filters invocation.
         *
         * @param event The @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT
         * event.
         *
         * @return The the filters count of the get target filters invocation result.
         */
        [DllImport("bps")]
        public static extern int navigator_invoke_event_get_filters_count(IntPtr _event);

        /**
         * @brief Get the filter of the get target filters invocation result
         *
         * The function doesn't copy the data and the returned value will be released
         * once the @c bps_get_event() function is called again.
         *
         * The @c navigator_invoke_event_get_filter()
         * function should be called by the application upon receiving the
         * @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT event to extract the
         * filter of the get target filters invocation.
         *
         * @param event The @c NAVIGATOR_INVOKE_GET_FILTERS_RESULT event.
         *
         * @param index The index of the filter in the filters array
         *
         * @return The filter at the index from the get target filters invocation result.
         */
        [DllImport("bps")]
        public static extern char[] navigator_invoke_event_get_filter(IntPtr _event,
                int index);
        #endregion

        [DllImport("bps")]
        static extern int navigator_invoke(string uri,
            /*out*/ IntPtr err);

    }
}
