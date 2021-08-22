using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assignment.Services.Interfaces
{
    public interface IRestService
    {
        Task<HttpResponseMessage> GetAsync(string url);

        Task<HttpResponseMessage> DeleteAsync(string url);

        Task<HttpResponseMessage> PostAsync(string endPoint, object payload);
    }
}
