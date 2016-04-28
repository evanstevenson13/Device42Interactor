

using System;

namespace Device42Interactor{
    [Serializable]
    public class D42Device{
        public int? asset_no;
        public int? device_id;
        public string device_url;
        public string name;
        public string groups;
        public string serial_no;
        public Guid? uuid;

        public D42Device(){}

        public override string ToString(){
            return string.Concat("Device Info(id, name, url):\t", device_id.ToString(), "\t", name, "\t", device_url);
        }
    }
}
