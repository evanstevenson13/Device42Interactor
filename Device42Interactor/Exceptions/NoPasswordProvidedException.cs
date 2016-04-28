

using System;


namespace Device42Interactor{
    /// <summary>
    /// Exception thats thrown when no password is provided to the set password command
    /// </summary>
    public class NoPasswordProvidedException : Exception{
        /// <summary>
        /// Constructor
        /// </summary>
        public NoPasswordProvidedException(){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        public NoPasswordProvidedException(string message):base(message){}


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to explain exception</param>
        /// <param name="inner">Exception to add to this exception</param>
        public NoPasswordProvidedException(string message, Exception inner):base(message, inner){}
    }
}
