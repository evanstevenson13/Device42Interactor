

namespace Device42Interactor{
    /// <summary>
    /// String enum of possible urls for accessing the Device42 api
    /// "https://ip:port/api/1.0/devices/"
    /// </summary>
    public sealed class D42URLs{
        /// <summary>
        /// Get All Devices
        /// </summary>
        public const string AllDevices = "/api/1.0/devices/";
        /// <summary>
        /// Post: Set a password
        /// </summary>
        public const string SetPassword = "/api/1.0/passwords/";
        /// <summary>
        /// Get: Get a password
        /// </summary>
        public const string GetPasswords = "/api/1.0/passwords/";
        /// <summary>
        /// Delete: Delete a password
        /// </summary>
        public const string DeletePassword = "/api/1.0/passwords/";
    }
}
