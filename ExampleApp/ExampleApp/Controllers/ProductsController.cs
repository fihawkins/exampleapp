using ExampleApp.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ExampleApp.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository repo;

        public ProductsController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        public IEnumerable<Product> GetAll()
        //public IHttpActionResult GetAll()
        {
            return repo.Products;
            //return Ok(repo.Products);
            //chumbando no código o formato de retorno (o retorno implementa a interface IHttpActionResult)
            //return Content(HttpStatusCode.OK, repo.Products, new XmlMediaTypeFormatter());
            //return Content(HttpStatusCode.OK, repo.Products, new JsonMediaTypeFormatter());
        }

        //public IHttpActionResult Delete(int id)
        public void Delete(int id)
        {
            repo.DeleteProduct(id);
            //return new NoContentResult();
        }
    }
}
