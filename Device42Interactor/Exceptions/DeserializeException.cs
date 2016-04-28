

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when a deserializing error occurs
    /// </summary>
    public class DeserializeException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public DeserializeException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public DeserializeException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public DeserializeException(string message, Exception inner):base(message, inner){}
    }
}
