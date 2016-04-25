

using Device42API.Objects;
using HttpCommand;

namespace Device42API.Commands{

    /// <summary>
    /// General type for a command
    /// </summary>
    public abstract class Command{
        //protected internal HttpRunner HRunner = new HttpRunner();
        protected internal string response;
        //public D42Message responseMessage = new D42Message();

        //todo Should return repsonseMessage
        public string GetResponseMessage(){
            return response;
            //return responseMessage.ToString();
        }
    }
}
