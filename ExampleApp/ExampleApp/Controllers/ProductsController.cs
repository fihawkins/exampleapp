﻿using ExampleApp.Infrastructure;
using ExampleApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        {
            return repo.Products;
        }

        public IHttpActionResult Delete(int id)
        {
            repo.DeleteProduct(id);
            return new NoContentResult();
        }

        [HttpGet]
        [Route("api/products/noop")]
        public IHttpActionResult NoOp()
        {
            return Ok();
        }
    }
}
