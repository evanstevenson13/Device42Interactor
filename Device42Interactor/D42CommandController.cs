

//using Device42Interactor.Commands;
//using Device42Interactor.Objects;
//using HttpCommands.Objects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Script.Serialization;


//namespace Device42Interactor{
//    /// <summary>
//    /// Controller to interact with the Device42 api
//    /// </summary>
//    public class D42CommandController{
//        protected string address = string.Empty;
//        protected string port = string.Empty;
//        protected string authUser = string.Empty;
//        protected string authPassword = string.Empty;
//        protected internal AuthenticationHeader authHeader = null;
        
//            // Look up device by using its name
//        private Dictionary<string, D42Device> allDevices = new Dictionary<string, D42Device>();
//            // Look up password by using its id
//        //private Dictionary<string, D42Password> allPasswords = new Dictionary<string, D42Password>();


//        protected internal string serverAddress{
//            get{
//                return string.Concat("https://", address, ":", port);
//            }
//            private set{}
//        }
//        //private object bindedData = null;

//            // Commands that can be called
//        private Command_GetAllDevices getAllDevices;
//        private Command_SetPassword setPassword;
//        private Command_GetPassword getPassword;


//        /// <summary>
//        /// Creates a command controller with the settings to access a Device42 device, no authentication
//        /// </summary>
//        /// <param name="address">Url of the device42 device</param>
//        /// <param name="port">port of the device42 device</param>
//        public D42CommandController(string address, string port){
//            this.address = address;
//            this.port = port;

//                // Set Commands
//            getAllDevices = new Command_GetAllDevices(this);
//            setPassword = new Command_SetPassword(this);
//            getPassword = new Command_GetPassword(this);
//        }


//        /// <summary>
//        /// Creates a command controller with the settings to access a Device42 device, includess authentication
//        /// </summary>
//        /// <param name="address">Url of the device42 device</param>
//        /// <param name="port">port of the device42 device</param>
//        /// <param name="user">Username to access the device42 device</param>
//        /// <param name="password">Password to access the device42 device</param>
//        public D42CommandController(string address, string port, string username, string password) : this(address, port){
//            authHeader = new AuthenticationHeader(username, password);
//        }

        
//        //todo if can't find here should try refreshing list before returning null
//        /// <summary>
//        /// Get a device by its name
//        /// </summary>
//        /// <param name="deviceName">device to get</param>
//        /// <returns>device object with the devices info</returns>
//        public D42Device GetDeviceByName(string deviceName){
//            D42Device device = null;
//            if(deviceName != null){
//                allDevices.TryGetValue(deviceName, out device);
//            }
//            return device;
//        }


//        /// <summary>
//        /// Calls the get all devices command
//        /// </summary>
//        /// <returns>List of all the devices</returns>
//        /// <exception cref="FailedGettingDeviceListException">Error occurred while trying to get the device list</exception>
//        /// <exception cref="DeserializeExceptionz">Error occurred while converting json string to device list object</exception>
//        public D42DeviceList GetAllDevices(){
//            //string response = getAllDevices.GetDevices();
//            string response = "{Devices:[]}";
//            D42DeviceList deviceList = JsonToObject<D42DeviceList>(response);

//            allDevices.Clear();

//            foreach(D42Device device in deviceList.devices){
//                allDevices.Add(device.name, device);
//            }
            
//            return new D42DeviceList(){devices = allDevices.Values.ToList()};

//                // Bind resulting json data to an object
//            //return JsonToObject<D42DeviceList>(response);
//        }


//        /// <summary>
//        /// Calls the set password command
//        /// </summary>
//        /// <param name="password">Password data to set</param>
//        /// <returns>Indication if the opertion was successful</returns>
//        /// <exception cref="FailedSettingPasswordException">Error occurred while trying to set the password</exception>
//        public bool SetPassword(D42Password password, out string responseMessage){
//            responseMessage = string.Empty;
//                // If fields are missing then don't even both trying to set the password
//            if(string.IsNullOrEmpty(password.username) || string.IsNullOrEmpty(password.password)){
//                return false;
//            }
            
//            responseMessage = setPassword.GetResponseMessage();

//            if(setPassword.SetPassword(password)){
//                return true;
//            }else{
//                return false;
//            }
//        }


//        public D42Password GetPasswordByDeviceName(string deviceName){
//            return getPassword.GetPasswordByDeviceName(deviceName);
//        }


//        /// <summary>
//        /// Bind the provided data to an object
//        /// </summary>
//        /// <typeparam name="T">type of object to bind to</typeparam>
//        /// <param name="data">data to be binded to the object</param>
//        /// <returns>The object with the data binded to it</returns>
//        /// <exception cref="DeserializeException">Error occurred while creating object from json</exception>
//        private T JsonToObject<T>(string data){
//            object bindedData = null;
//            try{
//                JavaScriptSerializer serializer = new JavaScriptSerializer();
//                if(data != string.Empty){
//                    return serializer.Deserialize<T>(data);
//                }
//            }catch(Exception excep){
//                throw new DeserializeException("Error occurred while deserializing json data to a object", excep);
//            }
//            return (T)bindedData;
//        }

//    }
//}
