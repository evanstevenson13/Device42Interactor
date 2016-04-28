

using HttpCommand;
using HttpCommands.Objects;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Web;


namespace Device42Interactor.Commands{
    /// <summary>
    /// Command to get all the devices
    /// </summary>
    public class Command_GetAllDevices : Command{

        /// <summary>
        /// Sets the server address and authentication for the command to use
        /// </summary>
        /// <param name="serverAddress">Server to send command to</param>
        /// <param name="authHeader">Authentication to use when contacting server</param>
        public Command_GetAllDevices(string serverAddress, AuthenticationHeader authHeader) : base(serverAddress, authHeader){}


        /// <summary>
        /// Gets a list of all the devices and their information from Device42
        /// </summary>
        /// <returns>Json string of all the devices and their information</returns>
        /// <exception cref="RequestFailedException">The http request failed while trying to get the device list</exception>
        public override string Execute(){
            responseText = string.Empty;

            HttpRequestInfo requestData = new HttpRequestInfo(
                string.Concat(serverAddress, D42URLs.AllDevices)
                , RequestType.Get
                , authHeader
            );
            
            AuthenticationHeaderValue auth = requestData.GetHeader();

            try{
                responseText = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new RequestFailedException("Request to get all devices failed", excep);
            }

            return responseText;
        }
    }
}
