﻿

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when the command controller was initialized incorrectly
    /// </summary>
    public class InvalidInitializeException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public InvalidInitializeException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public InvalidInitializeException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public InvalidInitializeException(string message, Exception inner):base(message, inner){}
    }
}
