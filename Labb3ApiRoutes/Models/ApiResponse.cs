using System.Net;

namespace Labb3ApiRoutes.Models
{
    public class ApiResponse
    {
        //Hanterar response 
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }
        public List<string>? Messages { get; set; }
        public object? Result { get; set; }
    }
}
