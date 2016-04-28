﻿

using System;


namespace Device42Interactor{
    class FailedGettingPasswordListException:Exception{
        public FailedGettingPasswordListException(){
                
        }

        public FailedGettingPasswordListException(string message) : base(message){

        }

        public FailedGettingPasswordListException(string message, Exception inner) : base(message, inner){

        }
    }
}