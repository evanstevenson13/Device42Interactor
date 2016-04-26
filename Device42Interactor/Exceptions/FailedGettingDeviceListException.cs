

using System;


namespace Device42Interactor{
    class FailedGettingDeviceListException:Exception{
        public FailedGettingDeviceListException(){
                
        }

        public FailedGettingDeviceListException(string message) : base(message){

        }

        public FailedGettingDeviceListException(string message, Exception inner) : base(message, inner){

        }
    }
}
