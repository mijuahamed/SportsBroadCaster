using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BroadcasterApi.Factory.RestFactory
{
    public class RestApi
    {
        public async Task<string> ApiGet(string url) 
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
            {
                { "X-RapidAPI-Key", "88644a0b8emsh75a4ac485a927ecp1d2333jsn05d3bdc17f39" },
                { "X-RapidAPI-Host", "free-football-soccer-videos.p.rapidapi.com" },
             },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
