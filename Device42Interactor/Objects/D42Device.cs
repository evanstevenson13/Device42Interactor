

using System;

namespace Device42Interactor{
    /// <summary>
    /// Represents a Device42 device
    /// </summary>
    [Serializable]
    public class D42Device{
        /// <summary>
        /// Assest number of the device
        /// </summary>
        public int? asset_no;
        /// <summary>
        /// Id of the device
        /// </summary>
        public int? device_id;
        /// <summary>
        /// Url if the device
        /// </summary>
        public string device_url;
        /// <summary>
        /// Name of the device
        /// </summary>
        public string name;
        /// <summary>
        /// Groups the device is in
        /// </summary>
        public string groups;
        /// <summary>
        /// Serial number of the device
        /// </summary>
        public string serial_no;
        /// <summary>
        /// Guid of the device
        /// </summary>
        public Guid? uuid;


        /// <summary>
        /// Empty constructor because this object gets binded to
        /// </summary>
        public D42Device(){}


        /// <summary>
        /// Description of the object
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString(){
            return string.Concat("Device Info(id, name, url):\t", device_id.ToString(), "\t", name, "\t", device_url);
        }
    }
}
