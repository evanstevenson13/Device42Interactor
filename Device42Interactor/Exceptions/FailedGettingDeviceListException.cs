

using System;

namespace Device42API {
    class FailedGettingDeviceListException:Exception{
        public FailedGettingDeviceListException(){
                
        }

        public FailedGettingDeviceListException(string message) : base(message){

        }

        public FailedGettingDeviceListException(string message, Exception inner) : base(message, inner){

        }
    }
}
