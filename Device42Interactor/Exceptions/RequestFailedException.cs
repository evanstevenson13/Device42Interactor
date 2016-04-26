

using System;


namespace Device42Interactor{
    class RequestFailedException : Exception{
        public RequestFailedException(){
                
        }

        public RequestFailedException(string message) : base(message){

        }

        public RequestFailedException(string message, Exception inner) : base(message, inner){

        }
    }
}
