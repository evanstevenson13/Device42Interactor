using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device42API.Objects{
    [Serializable]
    public class D42PasswordList : D42Object{
        public List<D42Password> Passwords = new List<D42Password>();

        public D42PasswordList(){}

        public void JsonToObject(string jsonData){
            JsonToObject<D42PasswordList>(jsonData);
        }

        public override string ToString(){
            return string.Concat("Password list contains ", Passwords.ToString(), " passwords");
        }
    }
}
