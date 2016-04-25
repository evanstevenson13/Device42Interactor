


namespace Device42API.Objects{
    class D42Message{
        public int? code;
        public string msg = string.Empty;

        public D42Message(){}

        public override string ToString(){
            return string.Concat("Message returned a code of ", code, "and a message of \"", msg, "\"");
        }
    }
}
