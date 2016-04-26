

using System.Collections.Generic;


namespace Device42Interactor{
    /// <summary>
    /// General object for something in Device42
    /// </summary>
    public class D42DeviceList : D42Object{
        public List<D42Device> devices = new List<D42Device>();

        public D42DeviceList(){ }

        public override string ToString(){
            return string.Concat("Device list contains ", devices.Count.ToString(), " devices");
        }
    }
}
