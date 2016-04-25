using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device42API.Objects{
    public class D42DeviceList : D42Object{
        public List<D42Device> devices = new List<D42Device>();

        public D42DeviceList(){ }

        public override string ToString(){
            return string.Concat("Device list contains ", devices.Count.ToString(), " devices");
        }
    }
}
