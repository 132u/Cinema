using System;
using System.Web.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceUsage
{
    public class WebApiServiceUsage
    {
        private static HttpClient  _client;

        public WebApiServiceUsage(string url)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var t=  _client.GetAsync(path);
            return await _client.GetAsync(path);
        }
    }
}
