using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Utlity;

namespace Service.API
{
    public class ApiService : IApiService
    {
        private string Token { set; get; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _serviceProvider;
        public ApiService(IHttpContextAccessor httpContextAccessor,
            IServiceProvider serviceProvider)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceProvider = serviceProvider;
        }
        public (bool success, string message, string error, TResponse response) Get<TResponse>(string url)
        {

            byte[] byteArray;
            var isSessionExist = _httpContextAccessor.HttpContext.Session.TryGetValue(Constant.SessionTokenKey, out byteArray);
            if (isSessionExist)
                Token = Encoding.UTF8.GetString(byteArray);
            var client = new RestClient(string.Format(Constant.BaseUrl, url));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + Token);
            request.AddHeader("X-RapidAPI-Key", "88644a0b8emsh75a4ac485a927ecp1d2333jsn05d3bdc17f39");
            request.AddHeader("X-RapidAPI-Host", "covid-193.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ThrowException(response);
                return (false, "Failed", response.StatusCode.ToString() , default(TResponse));
            }
            var res = JsonConvert.DeserializeObject<TResponse>(response.Content);
            return (true, "Executed Successfully", null, res);

        }
        public (bool success, string message, string error, TResponse response)
            Post<TRequest, TResponse>(string url, TRequest model)
        {

            byte[] byteArray;
            var isSessionExist = _httpContextAccessor.HttpContext.Session.TryGetValue(Constant.SessionTokenKey, out byteArray);
            if (isSessionExist)
                Token = Encoding.UTF8.GetString(byteArray);
            var client = new RestClient(string.Format(Constant.BaseUrl, url));
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(model);
            request.AddJsonBody(JsonConvert.SerializeObject(model));
            request.AddHeader("Authorization", "Bearer " + Token);
            var response = client.Execute<TResponse>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return (true, "Executed Successfully", null, JsonConvert.DeserializeObject<TResponse>(response.Content));
            else
            {
                ThrowException(response);
                return (false, "Not Executed Successfully", response.StatusCode.ToString(), default(TResponse));
            }
        }
        private void ThrowException(IRestResponse response)
        {
            //var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
            //            from t in assembly.GetTypes()
            //            where t.Name == "IErrorCatcher"
            //            select t).FirstOrDefault();

            //if(type == null)
            //{
            //    throw new InvalidOperationException(string.Format("Can not find the Interface {0}", "IErrorCatcher"));
            //}

            //var service = _serviceProvider.GetService(type);
            //MethodInfo methodInfo = type.GetMethod("Error");
            //methodInfo.Invoke(service,new object[] { response.StatusCode.ToString() });
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception(Constant.UnAuthorized);
        }
    }
}
