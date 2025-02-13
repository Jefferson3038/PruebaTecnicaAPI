using System.Net;

namespace PruebaTecnicaAPI.Models
{
    public class ResponseGeneric<T>
    {
        public string StatusCodeMessage { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
