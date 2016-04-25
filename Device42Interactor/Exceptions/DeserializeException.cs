﻿

using System;

namespace Device42API {
    class DeserializeException:Exception{
        public DeserializeException(){
                
        }

        public DeserializeException(string message):base(message){

        }

        public DeserializeException(string message, Exception inner):base(message, inner){

        }
    }
}
