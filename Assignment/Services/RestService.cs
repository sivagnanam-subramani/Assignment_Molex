using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Assignment.Services.Interfaces;
using Newtonsoft.Json;

namespace Assignment.Services
{
    public class RestService : IRestService
    {
        private HttpClient _client;
        private string baseUrl = "https://hacker-news.firebaseio.com/v0";

        public RestService()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromMinutes(3);
        }

        public async Task<HttpResponseMessage> GetAsync(string endPoint)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            try
            {
                Uri uri;
                uri = new Uri(string.Format(baseUrl + endPoint));
                response = await _client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            try
            {
                Uri uri;
                uri = new Uri(string.Format(baseUrl + url));
                response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string endPoint, object payload)
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            try
            {
                Uri uri;
                uri = new Uri(string.Format(baseUrl + endPoint));
                var data = JsonConvert.SerializeObject(payload);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}
