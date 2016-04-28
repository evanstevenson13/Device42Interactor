

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











        /// <summary>
        /// Get the password object for based on a certian parameter
        /// </summary>
        /// <param name="parameter">The parameter used to select the specific password</param>
        /// <param name="value">The specific value the password has</param>
        /// <returns>The password object for the requested device</returns>
        /// <exception cref="FailedGettingPasswordException">Error occurred while trying to get the password</exception>
        //private D42PasswordList GetSpecificPassword(string parameter, string value){
        //    D42PasswordList passwordList = new D42PasswordList();

        //    if(string.IsNullOrEmpty(parameter) || string.IsNullOrEmpty(value)){
        //        return passwordList;
        //    }
            
        //    string dataToSend = string.Concat(parameter, "=", HttpUtility.UrlEncode(value));

        //    HttpRequestInfo requestData = new HttpRequestInfo(
        //        string.Concat(serverAddress, D42URLs.GetPassword)
        //        , RequestType.Get
        //        , new HttpContentToSend(dataToSend, Encoding.UTF8, ContentType.PostForm)
        //        , authHeader
        //    );

        //    try
        //    {
        //        response = HttpRunner.SendHttpRequest(requestData);
        //    }
        //    catch (Exception excep)
        //    {
        //        //throw new FailedGettingPasswordException("Could not get the password(" + string.Concat(parameter, "=", value) + ")", excep);
        //    }
        //    //response = "{\"Passwords\": [{\"username\": \"sharepointadmin\", \"last_pw_change\": \"2013-11-05T19:29:35Z\", \"notes\": \"\", \"label\": \"sharepoint admin account\", \"first_added\": \"2013-11-05T19:07:05.534Z\", \"password\": \"L8tirgcd&Loh\", \"id\": 5}]}";

        //    try{
        //        passwordList.JsonToObject(response);
        //    }catch(Exception excep){
        //        //throw new FailedGettingPasswordException("Data binding failed when getting the password(" + string.Concat(parameter, "=", value) +")", excep);
        //    }

        //    return passwordList;
        //}// GetSpecificPassword


        /// <summary>
        /// Get the password object for a device
        /// </summary>
        /// <param name="deviceName">Name of the device you want to get the passord for</param>
        /// <returns>The password object for the requested device</returns>
        /// <exception cref="FailedGettingPasswordException">Error occurred while trying to get the password</exception>
        //protected internal D42Password GetPasswordByDeviceName(string deviceName){
        //    D42PasswordList list = GetSpecificPassword("device", deviceName);
        //    if(list.Passwords.Count == 0){
        //        D42Password password = new D42Password();
        //        password.devices.Add(deviceName);
        //        return password;
        //    }
        //    foreach(D42Password password in list.Passwords){
        //        password.devices.Add(deviceName);
        //    }
        //    return list.Passwords[0];
        //}//GetPasswordForDevice

    }// Class
}// Namespace
