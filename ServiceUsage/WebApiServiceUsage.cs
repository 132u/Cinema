using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cinema.Model;
using Newtonsoft.Json;

namespace ServiceUsage
{
    public class WebApiServiceUsage
    {
        private static HttpClient _client;

        public WebApiServiceUsage(string url)
        {
            _client = new HttpClient {BaseAddress = new Uri(url)};
            
                _client.DefaultRequestHeaders.Accept.Clear();
            
            //  _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public async Task<ICollection<Actor>> GetActors()
        {
            var response = await _client.GetAsync("api/cinema");
            string responseString = null;
            if (response.IsSuccessStatusCode)
            {
                 responseString = response.Content.ReadAsStringAsync().Result;
            }
            return JsonConvert.DeserializeObject<ICollection<Actor>>(responseString);
          
         }

        public async Task<Actor> GetActor(int id)
        {
            var response = await _client.GetAsync($"api/cinema/{id}");
            string responseString = null;
            if (response.IsSuccessStatusCode)
            {
                responseString = response.Content.ReadAsStringAsync().Result;
            }
            return JsonConvert.DeserializeObject<Actor>(responseString);
        }

        //public async Task AddActor(Actor actor)
        //{
        //    var json = JsonConvert.SerializeObject(actor);
        //    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        //     await _client.PostAsync("api/cinema", stringContent);
        //}

        public async Task EditActor(Actor actor)
        {
            var json = JsonConvert.SerializeObject(actor);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            await _client.PostAsync("api/cinema", stringContent);
        }

        public async Task<HttpResponseMessage> RemoveActor(int id)
        {
           return await _client.DeleteAsync($"api/cinema/{id}");
        }
    }
}



//public async Task<IList<Movy>> GetMovies(string path)
        //{
        //    HttpResponseMessage response = _client.GetAsync(path).Result;
        //        if (response.IsSuccessStatusCode)
        //    {
        //        var yourcustomobjects = response.Content.ReadAsStringAsync();
        //        return  JsonConvert.DeserializeObject<Movy>(yourcustomobjects.Result);
        //    }
        //    else
        //    {
        //        //Something has gone wrong, handle it here
        //    }
        //    //IList<Movy> m = null;
        //    //HttpResponseMessage r =  await _client.GetAsync(path);
        //    //if (r.IsSuccessStatusCode)
        //    //{
        //    //    m = await r.Content.re();
        //    //}
        //    //return m;
        //}
        