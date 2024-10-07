using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandlleResponse
{
    public class Response
    {
        public Response( int statusode, string? message )
        {
            StatusCode=statusode;
            Message = message ?? GetMessageByStatusCode(statusode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetMessageByStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "OK: The request was successful.";
                case 201:
                    return "Created: The resource was successfully created.";
                case 400:
                    return "Bad Request: The server could not understand the request due to invalid syntax.";
                case 401:
                    return "Unauthorized: Access is denied due to invalid credentials.";
                case 403:
                    return "Forbidden: The server understood the request, but it refuses to authorize it.";
                case 404:
                    return "Not Found: The server could not find the requested resource.";
                case 500:
                    return "Internal Server Error: The server encountered an unexpected condition.";
                default:
                    return "Unknown Status Code: The provided status code is not recognized.";
            }
        }

    }
}
