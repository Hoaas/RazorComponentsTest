using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShibaPower.Services
{
    public class ShibaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShibaService(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Shiba>> GetShibas()
        {
            var client = _httpClientFactory.CreateClient();

            var stuff = await client.GetAsync("http://shibe.online/api/shibes?count=1&urls=true&httpsUrls=true");

            var urls = await stuff.Content.ReadAsAsync<List<string>>();

            return urls
                .Select(x => new Shiba { Url = x })
                .ToList();
        }
    }
}
