

using System;
using System.Collections.Generic;


namespace Device42Interactor{
    /// <summary>
    /// Contains a list of Device42 devices
    /// </summary>
    [Serializable]
    public class D42DeviceList : D42Object{
        /// <summary>
        /// List of Device42 devices
        /// </summary>
        public List<D42Device> devices = new List<D42Device>();


        /// <summary>
        /// Empty constructor because this object in binded to
        /// </summary>
        public D42DeviceList(){ }


        /// <summary>
        /// Description of the object
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString(){
            return string.Concat("Device list contains ", devices.Count.ToString(), " devices");
        }
    }
}
