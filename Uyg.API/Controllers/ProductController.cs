using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uyg.API.Models;
using Uyg.API.Repositories;

namespace Uyg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        Result _result = new Result();
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public List<Product> List()
        {
            var products = _productRepository.GetList();
            return products;
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        [HttpPost]
        public Result Add(Product model)
        {
           _productRepository.Add(model);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public Result Update(Product model)
        {
            _productRepository.Update(model);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete]
        public Result Delete(int id) {

            _productRepository.Delete(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }

    }
}
