

using Device42API.Objects;
using HttpCommand;
using System;
using System.Text;
using System.Web;

namespace Device42API.Commands {
    /// <summary>
    /// Command to set a password
    /// </summary>
    public class Command_GetPassword : Command{
        private D42CommandController parent;

        /// <summary>
        /// Creates a get password command
        /// </summary>
        /// <param name="caller">The command controller</param>
        public Command_GetPassword(D42CommandController caller){
            parent = caller;
        }


        /// <summary>
        /// Get the password object for based on a certian parameter
        /// </summary>
        /// <param name="parameter">The parameter used to select the specific password</param>
        /// <param name="value">The specific value the password has</param>
        /// <returns>The password object for the requested device</returns>
        /// <exception cref="FailedGettingPasswordException">Error occurred while trying to get the password</exception>
        private D42PasswordList GetSpecificPassword(string parameter, string value){
            D42PasswordList passwordList = new D42PasswordList();

            if(string.IsNullOrEmpty(parameter) || string.IsNullOrEmpty(value)){
                return passwordList;
            }
            
            string dataToSend = string.Concat(parameter, "=", HttpUtility.UrlEncode(value));

            HttpRequestInfo requestData = new HttpRequestInfo(
                string.Concat(parent.serverAddress, D42URLs.GetPassword)
                ,RequestType.Get
                ,new HttpContentToSend(dataToSend, Encoding.UTF8, ContentType.PostForm)
                ,parent.authHeader
            );

            try
            {
                response = HttpRunner.SendHttpRequest(requestData);
            }
            catch (Exception excep)
            {
                throw new FailedGettingPasswordException("Could not get the password(" + string.Concat(parameter, "=", value) + ")", excep);
            }
            //response = "{\"Passwords\": [{\"username\": \"sharepointadmin\", \"last_pw_change\": \"2013-11-05T19:29:35Z\", \"notes\": \"\", \"label\": \"sharepoint admin account\", \"first_added\": \"2013-11-05T19:07:05.534Z\", \"password\": \"L8tirgcd&Loh\", \"id\": 5}]}";

            try{
                passwordList.JsonToObject(response);
            }catch(Exception excep){
                throw new FailedGettingPasswordException("Data binding failed when getting the password(" + string.Concat(parameter, "=", value) +")", excep);
            }

            return passwordList;
        }// GetSpecificPassword


        /// <summary>
        /// Get the password object for a device
        /// </summary>
        /// <param name="deviceName">Name of the device you want to get the passord for</param>
        /// <returns>The password object for the requested device</returns>
        /// <exception cref="FailedGettingPasswordException">Error occurred while trying to get the password</exception>
        protected internal D42Password GetPasswordByDeviceName(string deviceName){
            D42PasswordList list = GetSpecificPassword("device", deviceName);
            if(list.Passwords.Count == 0){
                D42Password password = new D42Password();
                password.devices.Add(deviceName);
                return password;
            }
            foreach(D42Password password in list.Passwords){
                password.devices.Add(deviceName);
            }
            return list.Passwords[0];
        }//GetPasswordForDevice

    }// Class
}// Namespace
