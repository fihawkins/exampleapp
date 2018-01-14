using ExampleApp.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ExampleApp.Controllers
{
    public class ProductsController : ApiController
    {
        Repository repo;

        public ProductsController()
        {
            repo = Repository.Current;
        }

        public IEnumerable<Product> GetAll()
        {
            return repo.Products;
        }
    }
}
