

using HttpCommand;
using HttpCommands.Objects;
using System;
using System.Text;
using System.Web;


namespace Device42Interactor.Commands{
    /// <summary>
    /// Command to set a password
    /// </summary>
    public class Command_GetPassword : Command{
        private string commandParameters = string.Empty;

        /// <summary>
        /// Sets the server address and authentication for the command to use
        /// </summary>
        /// <param name="serverAddress">Server to send command to</param>
        /// <param name="authHeader">Authentication to use when contacting server</param>
        public Command_GetPassword(string serverAddress, AuthenticationHeader authHeader) : base(serverAddress, authHeader){}


        /// <summary>
        /// Set the parameters for the get password command
        /// </summary>
        /// <param name="parameters">Parameters to add to the request</param>
        public void SetParameters(string parameters){
            commandParameters = parameters;
        }


        /// <summary>
        /// Gets a list of all the passwords and their information from Device42
        /// </summary>
        /// <returns>Json string of all the passwords and their information</returns>
        /// <exception cref="RequestFailedException">The http request failed while trying to get the device list</exception>
        public override string Execute(){
            responseText = string.Empty;

            HttpRequestInfo requestData = new HttpRequestInfo(
                string.Concat(serverAddress, D42URLs.GetPasswords)
                , RequestType.Get
                , new HttpContentToSend(commandParameters, ContentType.GetForm)
                , authHeader
            );
            
                // Reset commandParameters so the aren't reused
            commandParameters = string.Empty;

            try{
                responseText = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new RequestFailedException("Request to get passwords failed", excep);
            }

            return responseText;
        }
    }// Class
}// Namespace
