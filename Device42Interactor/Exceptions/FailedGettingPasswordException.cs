

using System;

namespace Device42API {
    class FailedGettingPasswordException:Exception{
        public FailedGettingPasswordException(){
                
        }

        public FailedGettingPasswordException(string message) : base(message){

        }

        public FailedGettingPasswordException(string message, Exception inner) : base(message, inner){

        }
    }
}