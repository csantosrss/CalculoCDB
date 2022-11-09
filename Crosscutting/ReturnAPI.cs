using System.Net;

namespace CalculoCDB.Crosscutting
{
    public class ReturnAPI<TReturnType> : ReturnAPI
    {
        public TReturnType Content { get; set; }

        public ReturnAPI<TReturnType> Adapt(ResponseAPI<TReturnType> response)
        {
            this.Content = response.Content;
            this.Exception = response.Exception;
            this.Messages = response.Messages;
            this.Status = response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
            return this;
        }

        public ReturnAPI(HttpStatusCode status = HttpStatusCode.OK)
            : base(status) { }
    }

    public class ReturnAPI
    {
        public HttpStatusCode Status { get; set; }
        public List<string> Messages { get; set; }
        public string Exception { get; set; }
        public ReturnAPI(HttpStatusCode status = HttpStatusCode.OK)
        {
            this.Status = status;
            this.Messages = new List<string>();

        }
    }
}
