using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API
{
    public interface IApiService
    {
        (bool success, string message, string error, TResponse response) Get<TResponse>(string url);
        (bool success, string message, string error, TResponse response)
            Post<TRequest, TResponse>(string url, TRequest model);
    }
}
