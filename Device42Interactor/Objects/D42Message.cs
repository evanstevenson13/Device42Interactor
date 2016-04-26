


namespace Device42Interactor{
    class D42Message{
        public int? code = 0;
        public string msg = string.Empty;

        public D42Message(){}

        public override string ToString(){
            return string.Concat("Message returned a code of ", code, "and a message of \"", msg, "\"");
        }
    }
}
