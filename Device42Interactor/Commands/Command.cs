

using HttpCommand;
using HttpCommands.Objects;
using System;


namespace Device42Interactor.Commands{

    /// <summary>
    /// General type for a command
    /// </summary>
    public abstract class Command{
        /// <summary>
        /// The response from Device42
        /// </summary>
        protected internal string responseText = string.Empty;
        /// <summary>
        /// The server address of Device42
        /// </summary>
        protected internal string serverAddress = string.Empty;
        /// <summary>
        /// Authentication values used to access Device42
        /// </summary>
        protected internal AuthenticationHeader authHeader = null;
        /// <summary>
        /// The message sent back from Device42 about the operation the was attempted
        /// </summary>
        public D42Message responseMessage = new D42Message();


        /// <summary>
        /// Constructor to setup server address and authentication to access it
        /// </summary>
        /// <param name="serverAddress">Base server address for Device42</param>
        /// <param name="authHeader">Authentication used to access Device42</param>
        public Command(string serverAddress, AuthenticationHeader authHeader){
            this.serverAddress = serverAddress;
            this.authHeader = authHeader;
        }


        /// <summary>
        /// Should be override with the code the command should do
        /// </summary>
        /// <returns>Response from Device42 as a string</returns>
        public virtual string Execute(){
            return string.Empty;
        }


        /// <summary>
        /// Gives the text that was returned from the server
        /// </summary>
        /// <returns>Text returned from http request</returns>
        public string GetResponseText(){
            return responseText;
        }


        /// <summary>
        /// Gives the response message provided by Device42
        /// </summary>
        /// <returns>String of the response from Device42</returns>
        public string GetResponseMessage(){
            try{
                if(!string.IsNullOrEmpty(responseText)){
                    responseMessage.JsonToObject<D42Message>(responseText);
                }
            }catch(DeserializeException){
                // This will occur when server errors are returned, Do not care about this exception
            }
            return responseMessage.ToString();
        }
    }
}
