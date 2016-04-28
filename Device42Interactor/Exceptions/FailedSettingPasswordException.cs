

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when an error occurs while creating/updating a password
    /// </summary>
    public class FailedSettingPasswordException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public FailedSettingPasswordException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public FailedSettingPasswordException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public FailedSettingPasswordException(string message, Exception inner):base(message, inner){}
    }
}
