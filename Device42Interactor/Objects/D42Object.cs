

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;


namespace Device42Interactor{
    /// <summary>
    /// General Properties and methods for all objects
    /// </summary>
    [Serializable]
    public abstract class D42Object{
        /// <summary>
        /// Dictionary of the class fields and thier values
        /// </summary>
        protected Dictionary<string, object> classValues = new Dictionary<string, object>();


        /// <summary>
        /// Empty constructor since the class intherting will define their own
        /// </summary>
        public D42Object(){}


        /// <summary>
        /// Refreshs the dictonary object of variables and their values
        /// </summary>
        protected void refreshObjectValues(){
            //List<PropertyInfo> classProperties = this.GetType().GetProperties(BindingFlags.NonPublic).ToList();
            //todo check if exists and update it instead of clearing it
            //todo don't add nulls to this list
            classValues.Clear();
            foreach(FieldInfo fInfo in this.GetType().GetFields()){
                classValues.Add(fInfo.Name, fInfo.GetValue(this));
            }
        }


        /// <summary>
        /// Converts the current object to a json string
        /// </summary>
        /// <returns>Json string of the current object</returns>
        public virtual string ToJson(){
            return new JavaScriptSerializer().Serialize(this);
        }


        //todo Remove this
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual internal bool IsValid(){
            return false;
        }        


        /// <summary>
        /// Converts to object into a string that can be sent in a post request
        /// </summary>
        /// <returns>Query string representation of the object</returns>
        public virtual string ToPostString(){
            refreshObjectValues();
            string postString = string.Empty;
            foreach(KeyValuePair<string, object> item in classValues){
                string value = string.Empty;
                //todo Make this better
                if(item.Value != null){
                    if(item.GetType().IsGenericType && item.Value is IList){
                        var test = (IList<string>)item.Value;
                        foreach(string listItem in test) {
                            value+=HttpUtility.UrlEncode(listItem);
                            value+=",";
                        }
                        value=value.TrimEnd(',');
                    }else{
                        value=item.Value.ToString();
                        if(!string.IsNullOrEmpty(value)){
                            value = HttpUtility.UrlEncode(value);
                        }
                    }
                }

                if(!string.IsNullOrEmpty(value)){
                    postString += item.Key + "=" + value + "&";
                }
            }
            postString = postString.TrimEnd('&');
            return postString;
        }


        /// <summary>
        /// Bind the provided json data to the current object
        /// </summary>
        /// <typeparam name="T">type of object to bind to</typeparam>
        /// <param name="jsonData">data to be binded to the object</param>
        /// <returns>The object with the data binded to it</returns>
        /// <exception cref="DeserializeException">Error occurred binding json data to object</exception>
        public void JsonToObject<T>(string jsonData){          
            try{
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                if(!string.IsNullOrEmpty(jsonData)){
                    T dataObject = serializer.Deserialize<T>(jsonData);
                    MemberInfo[] objectMembers = FormatterServices.GetSerializableMembers(this.GetType());
                    FormatterServices.PopulateObjectMembers(this, objectMembers, FormatterServices.GetObjectData(dataObject, objectMembers));
                }
            }catch(Exception excep){
                throw new DeserializeException("Error occurred while deserializing json data to a object", excep);
            }
        }
    }
}
