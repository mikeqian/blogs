namespace Mike.MM.Models.Base
{
    public class JsonResponseModel
    {

        public bool Success { get; set; }
        public string Msg { get; set; }
        public string Code { get; set; }
        public object Rows { get; set; }
        public int Total { get; set; }

        public dynamic Result { get; set; }
    }
}