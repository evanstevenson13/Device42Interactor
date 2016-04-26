

using HttpCommands.Objects;


namespace Device42Interactor.Commands{
    /// <summary>
    /// Command to set a password
    /// </summary>
    public class Command_SetPassword : Command{

        /// <summary>
        /// Sets the server address and authentication for the command to use
        /// </summary>
        /// <param name="serverAddress">Server to send command to</param>
        /// <param name="authHeader">Authentication to use when contacting server</param>
        public Command_SetPassword(string serverAddress, AuthenticationHeader authHeader) : base(serverAddress, authHeader){}

        
        public override string Execute(){
            return string.Empty;
        }


        /// <summary>
        /// Attempts to create/change the a device 42 password
        /// </summary>
        /// <param name="password">The password object(username, password, devices)</param>
        /// <returns>Indication if the opertion was successful</returns>
        /// <exception cref="FailedSettingPasswordException">Password was not set because of a http request error</exception>
        //protected internal bool SetPassword(D42Password password){
        //    HttpRequestInfo requestData = null;
            
        //    requestData=new HttpRequestInfo(
        //        string.Concat(serverAddress, D42URLs.SetPassword)
        //        , RequestType.Post
        //        , new HttpContentToSend(password.ToPostString(), Encoding.UTF8, ContentType.PostForm)
        //        , authHeader
        //    );

        //    try {
        //        response = HttpRunner.SendHttpRequest(requestData);
        //    }catch(Exception excep){
        //        throw new FailedSettingPasswordException("The password could not be created/updated", excep);
        //    }

        //    return true;
        //}
    }
}
