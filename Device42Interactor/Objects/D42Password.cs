

using System;
using System.Collections.Generic;
using System.Security;

namespace Device42API.Objects{

    /// <summary>
    /// A D42 password object that can be sent to D42 to create/change a password
    /// </summary>
    [Serializable]
    public class D42Password : D42Object{
        public int? id;
        public string username = string.Empty;
        public string password = string.Empty;
        public string label = string.Empty;
        public string notes = string.Empty;
        public string view_edit_users = string.Empty;
        public string view_groups = string.Empty;
        public List<string> devices = new List<string>();
        public DateTime first_added;
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


        //public override string ToPostString(){
        //    //string deviceList = string.Join(",", devices.ToArray());
        //    //return string.Concat("Password Info(username, password, devices):\t", username, "\t", password, "\t", deviceList);
        //    objectValues();
        //    string final = string.Empty;
        //    final = "Object size(" + classValues.Count + "):  ";
        //    foreach(KeyValuePair<string, object> item in classValues) {
        //        final += item.Key + ":" + item.Value;
        //    }
        //    return final;
        //}


        protected internal override bool IsValid(){
            if(string.IsNullOrEmpty(username)){
                return false;
            }
            if(string.IsNullOrEmpty(password)){
                return false;
            }
            return true;
        }   

        public void JsonToObject(string jsonData){
            JsonToObject<D42Password>(jsonData);
        }

        /// <summary>
        /// Provides a string representation of the object
        /// </summary>
        /// <returns>string representing the object</returns>
        public override string ToString(){
            string deviceList = string.Join(",", devices.ToArray());
            return string.Concat("Password Info(username, password, devices):\t", username, ",\t", password, ",\t", deviceList);
        }
    }
}
