

using HttpCommand;
using HttpCommands.Objects;
using System;
using System.Text;


namespace Device42Interactor.Commands{

    public class Command_SetDeviceCustomField : Command{
        D42DeviceCustomField commandParameters = null;

        /// <summary>
        /// Sets the server address and authentication for the command to use
        /// </summary>
        /// <param name="serverAddress">Server to send command to</param>
        /// <param name="authHeader">Authentication to use when contacting server</param>
        public Command_SetDeviceCustomField(string serverAddress, AuthenticationHeader authHeader) : base(serverAddress, authHeader) { }

        
        /// <summary>
        /// Set the parameters for the get password command
        /// </summary>
        /// <param name="password">Parameters to add to the request</param>
        public void SetParameters(D42DeviceCustomField customField){
            commandParameters = customField;
        }


        
        public override string Execute(){
            if (commandParameters == null || string.IsNullOrEmpty(commandParameters.name) || string.IsNullOrEmpty(commandParameters.key) || string.IsNullOrEmpty(commandParameters.value)){
                //throw new NoPasswordProvidedException("No password was given to be created/updated");
                //TODO: Add exception for this
            }
            responseText = string.Empty;

            HttpRequestInfo requestData = new HttpRequestInfo(
                string.Concat(serverAddress, D42URLs.CustomField)
                , RequestType.Put
                , new HttpContentToSend(commandParameters.ToPostString(), ContentType.PostForm)
                , authHeader
            );
            
                // Reset commandParameters so the aren't reused
            commandParameters = null;

            try{
                responseText = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new RequestFailedException("Request to update custom field failed", excep);
            }

            return responseText;
        }
    }
}
