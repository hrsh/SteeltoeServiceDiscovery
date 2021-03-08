using Marten;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IDocumentStore _store;

        public HomeController(IDocumentStore store)
        {
            _store = store;
        }

        public IEnumerable<Product> Index()
        {
            using var session = _store.LightweightSession();
            var p = session.Query<Product>().ToList();
            return p;
        }

        //public Product Index()
        //{
        //    using var session = _store.LightweightSession();
        //    var  p = session.Query<Product>().First();
        //    return p;
        //}

        //public IEnumerable<Product> Index()
        //{
        //    var model = Product.Shop;
        //    using var session = _store.LightweightSession();
        //    foreach (var p in model)
        //        session.Store(p);
        //    session.SaveChanges();
        //    return model;
        //}
    }
}
