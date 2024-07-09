using System.Net;

namespace VillaAPI.Models;

public class APIResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> ErrorMessages { get; set; }
    public object Data { get; set; }

    public APIResponse(HttpStatusCode statusCode = HttpStatusCode.OK, bool isSuccess = true,
        List<string> errorMessages = null, object data = null)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        ErrorMessages = errorMessages;
        Data = data;
    }
}