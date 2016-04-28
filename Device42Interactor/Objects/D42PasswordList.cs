

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Device42Interactor{
    /// <summary>
    /// Object to hold a list of D42 password objects
    /// </summary>
    [Serializable]
    public class D42PasswordList : D42Object{
        /// <summary>
        /// List of D42 password objects
        /// </summary>
        public List<D42Password> Passwords = new List<D42Password>();


        /// <summary>
        /// Empty constructor, this class is binded to
        /// </summary>
        public D42PasswordList(){}


        /// <summary>
        /// A caller to the json binder so the caller does not need to provide the type
        /// </summary>
        /// <param name="jsonData">The json data to be binded to this object</param>
        public void JsonToObject(string jsonData){
            JsonToObject<D42PasswordList>(jsonData);
        }


        /// <summary>
        /// Give a description of the instance of this object
        /// </summary>
        /// <returns>A string presentation of the object</returns>
        public override string ToString(){
            return string.Concat("Password list contains ", Passwords.ToString(), " passwords");
        }
    }
}
