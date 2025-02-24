using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uyg.API.DTOs;
using Uyg.API.Models;
using Uyg.API.Repositories;

namespace Uyg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;
        ResultDto _result = new ResultDto();
        public ProductController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ProductDto> List()
        {
            var products = _productRepository.GetList();
            var productDtos=_mapper.Map<List<ProductDto>>(products); 
            return productDtos;
        }

        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            var product = _productRepository.GetById(id);
            var productDto=_mapper.Map<ProductDto>(product);       
            return productDto;
        }

        [HttpPost]
        public ResultDto Add(ProductDto model)
        {
           var product=_mapper.Map<Product>(model);
            _productRepository.Add(product);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public ResultDto Update(Product model)
        {
            var product = _mapper.Map<Product>(model);
            _productRepository.Update(product);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete]
        public ResultDto Delete(int id) {

            _productRepository.Delete(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }

    }
}
