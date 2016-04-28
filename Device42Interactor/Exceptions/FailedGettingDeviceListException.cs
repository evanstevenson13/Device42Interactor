

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when an error occurs while get the list of devices
    /// </summary>
    public class FailedGettingDeviceListException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public FailedGettingDeviceListException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public FailedGettingDeviceListException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public FailedGettingDeviceListException(string message, Exception inner):base(message, inner){}
    }
}
