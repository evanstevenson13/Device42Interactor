

using HttpCommand;
using HttpCommands.Objects;

namespace Device42Interactor.Commands{

    /// <summary>
    /// General type for a command
    /// </summary>
    public abstract class Command{
        //protected internal HttpRunner HRunner = new HttpRunner();
        protected internal string responseText;
        protected internal string serverAddress = string.Empty;
        protected internal AuthenticationHeader authHeader = null;
        //public D42Message responseMessage = new D42Message();


        public Command(string serverAddress, AuthenticationHeader authHeader){
            this.serverAddress = serverAddress;
            this.authHeader = authHeader;
        }


        public virtual string Execute(){
            return string.Empty;
        }


        //todo Should return repsonseMessage
        public string GetResponseMessage(){
            return string.Empty;
            //return response;
            //return responseMessage.ToString();
        }
    }
}
