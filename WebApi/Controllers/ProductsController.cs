using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Business.Abstract;
using WebApi.Entities.Concrete;
using WebApi.Models.ProductModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _productService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public IActionResult Add(ProductCreateModel productCreateModel)
        {
            var product = new Product
            {
                CategoryId = productCreateModel.CategoryId,
                ProductName = productCreateModel.ProductName,
                UnitPrice = productCreateModel.UnitPrice,
                UnitsInStock = productCreateModel.UnitsInStock
            };
            var result = _productService.Add(product);
            if (result.Success)
            {
                return CreatedAtAction("Get", new { id = product.ProductId }, product);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(int id, ProductUpdateModel productUpdateModel)
        {
            var product = _productService.Get(id).Data;

            if (product is null)
            {
                product = new Product
                {
                    CategoryId = productUpdateModel.CategoryId,
                    ProductName = productUpdateModel.ProductName,
                    UnitPrice = productUpdateModel.UnitPrice,
                    UnitsInStock = productUpdateModel.UnitsInStock
                };
                _productService.Update(product);
                return CreatedAtAction("Get", new { id = product.ProductId }, product);
            }

            product.CategoryId = productUpdateModel.CategoryId;
            product.ProductName = productUpdateModel.ProductName;
            product.UnitPrice = productUpdateModel.UnitPrice;
            product.UnitsInStock = productUpdateModel.UnitsInStock;
            _productService.Add(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult Delete(int id)
        {
            var product = _productService.Get(id).Data;
            if (product is null) return NotFound();

            _productService.Delete(product);
            return NoContent();
        }
    }
}
