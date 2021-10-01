using AspNetCoreSample.Common.Contexts;
using AspNetCoreSample.Common.Helpers;
using AspNetCoreSample.Common.Models;
using AspNetCoreSample.Common.Models.Requests;
using AspNetCoreSample.Common.Repositories;
using AspNetCoreSample.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IProductRepository ProductRepository;

        public ProductsController(IProductRepository productRepository, ISeedService seedService, ProductContext context)
        {
            ProductRepository = productRepository;

            if (productRepository.Count() == 0)
            {
                seedService.Initialize(context); 
            }

        }

        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] GetProductsRequest queryParams)
        {
            var items = ProductRepository.GetAll(queryParams);

            if (items == null)
            {
                return StatusCode(500);
            }

            var returnItems = items.Select(x => ProductHelper.CreateResponse(x));

            return Ok(returnItems);
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetSingleProduct(long id)
        {
            var product = ProductRepository.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(ProductHelper.CreateResponse(product));
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductCreateUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var product = ProductHelper.CreateProduct(request);

            var result = ProductRepository.Add(product);

            if (result)
            {
                return Ok(ProductHelper.CreateResponse(product));
            }
            else
            {
                return BadRequest("Add product failed.");
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteProduct(long id)
        {
            var product = ProductRepository.GetSingle(id);

            if (product == null)
            {
                return NotFound();
            }

            var result = ProductRepository.Delete(id);

            if (result)
            {
                return Ok("Delete done.");
            }
            else
            {
                return StatusCode(500, "Delete failed.");
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        public IActionResult UpdateProduct(long id, [FromBody] ProductCreateUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var product = ProductHelper.CreateProduct(request);

            var result = ProductRepository.Update(id, product);

            if (result)
            {
                product = ProductRepository.GetSingle(id);
                return Ok(ProductHelper.CreateResponse(product));
            }
            else
            {
                return BadRequest("Update product failed");
            }
        }
    }
}
