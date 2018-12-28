using System;
using System.Net.Http;
using System.Threading.Tasks;
using Task_1_Extra.Application.Interfaces;

namespace Task_1_Extra.Application.Services
{
    public class MockioService : IMockioService
    {
        HttpClient httpClient;

        public MockioService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetResponseAsync(string url)
        {
            try
            {
                var response = await httpClient.GetStringAsync(url);
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
