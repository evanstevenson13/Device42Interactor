

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when an error occurs while get the list of passwords
    /// </summary>
    public class FailedGettingPasswordListException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public FailedGettingPasswordListException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public FailedGettingPasswordListException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public FailedGettingPasswordListException(string message, Exception inner):base(message, inner){}
    }
}
