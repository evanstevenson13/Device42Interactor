

using System;
using System.Collections.Generic;
using System.Security;


namespace Device42Interactor{

    /// <summary>
    /// A D42 password object that can be sent to D42 to create/change a password
    /// </summary>
    [Serializable]
    public class D42Password : D42Object{
        /// <summary>
        /// Id of the password
        /// </summary>
        public int? id;
        /// <summary>
        /// Username for the password
        /// </summary>
        public string username = string.Empty;
        /// <summary>
        /// Password for the password
        /// </summary>
        public string password = string.Empty;
        /// <summary>
        /// Label for the password
        /// </summary>
        public string label = string.Empty;
        /// <summary>
        /// Notes for the password
        /// </summary>
        public string notes = string.Empty;
        /// <summary>
        /// View edit groups of the password
        /// </summary>
        public string view_edit_users = string.Empty;
        /// <summary>
        /// View groups of the password
        /// </summary>
        public string view_groups = string.Empty;
        /// <summary>
        /// Devices that belong to the password
        /// </summary>
        public List<string> devices = new List<string>();
        /// <summary>
        /// Date the password was first added
        /// </summary>
        public DateTime first_added;
        /// <summary>
        /// Date the password was last changed
        /// </summary>
        public DateTime last_pw_change;


        /// <summary>
        /// Creates a empty D42 password object that can be sent to D42 to create/change a password
        /// </summary>
        public D42Password(){}


        /// <summary>
        /// Creates a D42 password object that can be sent to D42 to create/change a password
        /// </summary>
        /// <param name="user">User name for password</param>
        /// <param name="pass">Password for password</param>
        /// <param name="dList">List of D42 devices that password should apply to</param>
        public D42Password(string user, string pass, List<string>dList){
            username = user;
            password = pass;
            devices = dList;
        }


        /// <summary>
        /// Checks if the object has everything to be considered valid
        /// </summary>
        /// <returns>Status of if the object is valid</returns>
        protected internal override bool IsValid(){
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)){
                return false;
            }
            return true;
        }   


        /// <summary>
        /// A caller to the json binder so the caller does not need to provide the type
        /// </summary>
        /// <param name="jsonData">The json data to be binded to this object</param>
        public void JsonToObject(string jsonData){
            JsonToObject<D42Password>(jsonData);
        }


        /// <summary>
        /// Provides a string representation of the object
        /// </summary>
        /// <returns>String representing the object</returns>
        public override string ToString(){
            string deviceList = string.Join(",", devices.ToArray());
            return string.Concat("Password Info(username, password, devices):\t", username, ",\t", password, ",\t", deviceList);
        }
    }
}
