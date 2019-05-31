using System.Net;

namespace WhereIsMyMovieBusiness.Dtos
{
    public class ErrorDto
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode ErrorCode { get; set; }
    }
}
