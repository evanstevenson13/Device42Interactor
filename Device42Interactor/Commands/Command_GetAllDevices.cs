

using HttpCommand;
using HttpCommands.Objects;
using System;
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
            HttpRequestInfo requestData = null;

            requestData = new HttpRequestInfo(
                string.Concat(serverAddress, D42URLs.AllDevices)
                , RequestType.Get
                , authHeader
            );
            

            try{
                responseText = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new RequestFailedException("Request to get all devices failed", excep);
            }


            return responseText;
        }



        //todo Change this to only get some many devices at once so the system isn;t overloaded
        /// <summary>
        /// Attempts to get a list of all the devices
        /// </summary>
        /// <returns>A list of all the devices</returns>
        /// <exception cref="FailedGettingDeviceListException">Devices were not retrieved because of a http request error</exception>
        //protected internal string GetDevices(){
        //    HttpRequestInfo requestData = null;

        //    requestData=new HttpRequestInfo(
        //        string.Concat(serverAddress, D42URLs.AllDevices)
        //        , RequestType.Get
        //        , new HttpContentToSend(null, Encoding.UTF8, ContentType.PostForm)
        //        , authHeader
        //    );

        //    try{
        //        response = HttpRunner.SendHttpRequest(requestData);
        //    }catch(Exception excep){
        //        throw new FailedGettingDeviceListException("Could not get the list of devices", excep);
        //    }

        //    return response;
        //}
    }
}
