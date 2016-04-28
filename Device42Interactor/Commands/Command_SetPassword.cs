

using HttpCommand;
using HttpCommands.Objects;
using System;
using System.Text;


namespace Device42Interactor.Commands{
    /// <summary>
    /// Command to set a password
    /// </summary>
    public class Command_SetPassword : Command{
        D42Password commandParameters = null;

        /// <summary>
        /// Sets the server address and authentication for the command to use
        /// </summary>
        /// <param name="serverAddress">Server to send command to</param>
        /// <param name="authHeader">Authentication to use when contacting server</param>
        public Command_SetPassword(string serverAddress, AuthenticationHeader authHeader) : base(serverAddress, authHeader){}

        
        /// <summary>
        /// Set the parameters for the get password command
        /// </summary>
        /// <param name="password">Parameters to add to the request</param>
        public void SetParameters(D42Password password){
            commandParameters = password;
        }


        /// <summary>
        /// Will try to create/update a password based on the provided password properties
        /// </summary>
        /// <returns>Response from Device42</returns>
        /// <exception cref="NoPasswordProvidedException">No password was provided to be created/updated</exception>
        /// <exception cref="RequestFailedException">The http request failed while trying to create/update the password</exception>
        public override string Execute(){
            if(commandParameters == null){
                throw new NoPasswordProvidedException("No password was given to be created/updated");
            }
            responseText = string.Empty;

            HttpRequestInfo requestData = new HttpRequestInfo(
                string.Concat(serverAddress, D42URLs.SetPassword)
                , RequestType.Post
                , new HttpContentToSend(commandParameters.ToPostString(), ContentType.PostForm)
                , authHeader
            );
            
                // Reset commandParameters so the aren't reused
            commandParameters = null;

            try{
                responseText = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new RequestFailedException("Request to set password failed", excep);
            }

            return responseText;
        }
    }
}
