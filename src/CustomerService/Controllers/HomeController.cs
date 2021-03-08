using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Model;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DiscoveryHttpClientHandler _handler;

        public HomeController(IDiscoveryClient client)
        {
            _handler = new DiscoveryHttpClientHandler(client);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Index()
        {
            var client = new HttpClient(_handler, false);
            var t = await client
                .GetStringAsync("http://ProductService/api/v1/home");
            var result = JsonConvert.DeserializeObject<IEnumerable<Product>>(t);
            return result;
        }
    }
}
