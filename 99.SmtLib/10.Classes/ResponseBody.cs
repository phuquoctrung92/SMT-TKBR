namespace SmtLib
{
    public enum StatusCode
    {
        SUCCEED = 0,
        FAILED = 1
    }
    public class ResponseBody<T> where T : new()
    {
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ResponseBody(StatusCode status = StatusCode.SUCCEED, string msg = "")
        {
            StatusCode = status;
            Message = msg;
            Data = new T();
        }
    }

}