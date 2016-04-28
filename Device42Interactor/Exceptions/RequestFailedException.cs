

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when the http request to Device42 fails
    /// </summary>
    public class RequestFailedException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public RequestFailedException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public RequestFailedException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public RequestFailedException(string message, Exception inner):base(message, inner){}
    }
}
