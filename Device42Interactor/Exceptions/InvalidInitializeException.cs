

using System;

namespace Device42Interactor {
    class InvalidInitializeException:Exception{
        public InvalidInitializeException(){
                
        }

        public InvalidInitializeException(string message):base(message){

        }

        public InvalidInitializeException(string message, Exception inner):base(message, inner){

        }
    }
}
