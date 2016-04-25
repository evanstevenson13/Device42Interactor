

using System;

namespace Device42API {
    class FailedSettingPasswordException : Exception{
        public FailedSettingPasswordException(){
                
        }

        public FailedSettingPasswordException(string message) : base(message){

        }

        public FailedSettingPasswordException(string message, Exception inner) : base(message, inner){

        }
    }
}
