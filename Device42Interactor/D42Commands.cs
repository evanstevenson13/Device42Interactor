

using Device42Interactor.Commands;
using HttpCommand;
using HttpCommands.Objects;
using System;
using System.Web;


namespace Device42Interactor{
    /// <summary>
    /// Allows commands to be called to interact with Device42
    /// </summary>
    public static class D42Commands{
        private static string address = string.Empty;
        private static string port = string.Empty;
        private static string username = string.Empty;
        private static string password = string.Empty;
        private static AuthenticationHeader authHeader = null;
        private static string serverResponse = string.Empty;
        

            // Commands that can be called
        private static Command_GetAllDevices getAllDevices;
        private static Command_SetPassword setPassword;
        private static Command_GetPassword getPasswords;


        /// <summary>
        /// Returns the server response so you can look at unexpected errors
        /// </summary>
        /// <returns>Response from the server</returns>
        public static string GetResponse(){
            return serverResponse;
        }


        /// <summary>
        /// Set up Device42Interactor so you can send commands to it
        /// </summary>
        /// <param name="address">Address used to access Device42</param>
        /// <param name="port">Port used to access Device42</param>
        /// <param name="username">Username used to access Device42</param>
        /// <param name="password">Password used to access Device42</param>
        /// <exception cref="InvalidInitializeException">Set up parameters were incorrect</exception>
        public static void Initialize(string address, string port, string username, string password){
            D42Commands.address = address;
            D42Commands.port = port;
            D42Commands.username = username;
            D42Commands.password = password;

            string serverAddress = string.Empty;
            if(string.IsNullOrEmpty(port)){
                serverAddress = string.Concat(address, ":", port);
            }else{
                serverAddress = address;
            }

            authHeader =  new AuthenticationHeader(username, password);

            if(string.IsNullOrEmpty(serverAddress)){
                throw new InvalidInitializeException("No server address provided");
            }
                
            if(authHeader == null){
                throw new InvalidInitializeException("No authentication header created");
            }

                // Set Commands
            getAllDevices = new Command_GetAllDevices(serverAddress, authHeader);
            setPassword = new Command_SetPassword(serverAddress, authHeader);
            getPasswords = new Command_GetPassword(serverAddress, authHeader);
        }


        /// <summary>
        /// Get a list of all the devices in Device42
        /// </summary>
        /// <returns>List of D42 devices</returns>
        /// <exception cref="FailedGettingDeviceListException">Couldn't get the devices</exception>
        public static D42DeviceList GetAllDevices(){
            string response = string.Empty;
            //string response = "{Devices:[]}";
            //todo Remove hard coded test values
            D42DeviceList deviceList = new D42DeviceList();
            try{
                response = getAllDevices.Execute();
                response="{\"Devices\": [{\"asset_no\": null,\"device_id\": 0,\"device_url\": null,\"name\": \"ENCTCAPL095.labapps.state.pa.us\",\"serial_no\": null,\"uuid\": null},{\"asset_no\": null,\"device_id\": 1,\"device_url\": null,\"name\": \"ENCTCAPL099.labapps.state.pa.us\",\"serial_no\": null,\"uuid\": null},{\"asset_no\": null,\"device_id\": 2,\"device_url\": null,\"name\": \"ENCTCAPL125.labapps.state.pa.us\",\"serial_no\": null,\"uuid\": null} ]}";
                deviceList.JsonToObject<D42DeviceList>(response);
            }catch(Exception excep){
                serverResponse = HttpRunner.GetResponse();
                throw new FailedGettingDeviceListException("Could not get devices", excep);
            }

            return deviceList;
        }

        
        /// <summary>
        /// Get passwords for a specific device
        /// </summary>
        /// <param name="deviceName">Name of the device</param>
        /// <returns>List of password for the device provided</returns>
        /// <exception cref="FailedGettingPasswordListException">Couldn't get the passwords for the device</exception>
        public static D42PasswordList GetPasswordsForDevice(string deviceName){
            string response = "{Passwords:[]}";
            D42PasswordList passwordList = new D42PasswordList();
            if(!string.IsNullOrEmpty(deviceName)){
                try{
                    getPasswords.SetParameters(string.Concat("device=", HttpUtility.UrlEncode(deviceName)));
                    response = getPasswords.Execute();
                    passwordList.JsonToObject<D42PasswordList>(response);
                }catch(Exception excep){
                    throw new FailedGettingPasswordListException("Could not get passwords for the provided device",excep);
                }
            }

            return passwordList;
        }


        //public static bool SetPassword(D42Password password){

        //}

    }// Class
}// Namespace
