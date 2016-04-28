

using System;


namespace Device42Interactor{
    /// <summary>
    /// Object to hold messages return from Device42
    /// </summary>
    [Serializable]
    public class D42Message : D42Object{
        /// <summary>
        /// Status code from Device42
        /// </summary>
        public int? code = 0;
        /// <summary>
        /// Message from Device42
        /// </summary>
        public string msg = string.Empty;


        /// <summary>
        /// Empty constructor because this object is only binded to
        /// </summary>
        public D42Message(){}


        /// <summary>
        /// String representation of this object
        /// </summary>
        /// <returns></returns>
        public override string ToString(){
            return string.Concat("Message returned a code of ", code, "and a message of \"", msg, "\"");
        }
    }
}
