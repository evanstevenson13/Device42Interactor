

using Device42API.Objects;
using HttpCommand;
using System;
using System.Text;

namespace Device42API.Commands{
    /// <summary>
    /// Command to set a password
    /// </summary>
    public class Command_SetPassword : Command{
        private D42CommandController parent;

        /// <summary>
        /// Creates a set password command
        /// </summary>
        /// <param name="caller">The command controller</param>
        public Command_SetPassword(D42CommandController caller){
            parent = caller;
        }

        
        /// <summary>
        /// Attempts to create/change the a device 42 password
        /// </summary>
        /// <param name="password">The password object(username, password, devices)</param>
        /// <returns>Indication if the opertion was successful</returns>
        /// <exception cref="FailedSettingPasswordException">Password was not set because of a http request error</exception>
        protected internal bool SetPassword(D42Password password){
            HttpRequestInfo requestData = null;
            
            requestData=new HttpRequestInfo(
                string.Concat(parent.serverAddress, D42URLs.SetPassword)
                ,RequestType.Post
                ,new HttpContentToSend(password.ToPostString(), Encoding.UTF8, ContentType.PostForm)
                ,parent.authHeader
            );

            try {
                response = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new FailedSettingPasswordException("The password could not be created/updated", excep);
            }

            return true;
        }
    }
}
