

using Device42API.Objects;
using HttpCommand;
using System;
using System.Text;

namespace Device42API.Commands{
    /// <summary>
    /// Command to get all the devices
    /// </summary>
    public class Command_GetAllDevices : Command{
        private D42CommandController parent;

        /// <summary>
        /// Creates a get all devices commands
        /// </summary>
        /// <param name="caller"></param>
        public Command_GetAllDevices(D42CommandController caller){
            parent = caller;
        }


        //todo Change this to only get some many devices at once so the system isn;t overloaded
        /// <summary>
        /// Attempts to get a list of all the devices
        /// </summary>
        /// <returns>A list of all the devices</returns>
        /// <exception cref="FailedGettingDeviceListException">Devices were not retrieved because of a http request error</exception>
        protected internal string GetDevices(){
            HttpRequestInfo requestData = null;

            requestData=new HttpRequestInfo(
                string.Concat(parent.serverAddress, D42URLs.AllDevices)
                ,RequestType.Get
                ,new HttpContentToSend(null, Encoding.UTF8, ContentType.PostForm)
                ,parent.authHeader
            );

            try{
                response = HttpRunner.SendHttpRequest(requestData);
            }catch(Exception excep){
                throw new FailedGettingDeviceListException("Could not get the list of devices", excep);
            }

            return response;
        }
    }
}
