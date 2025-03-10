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
        public async Task<List<ProductDto>> List()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos=_mapper.Map<List<ProductDto>>(products); 
            return productDtos;
        }

        [HttpGet("{id}")]
        public async  Task<ProductDto> GetById(int id)
        {
            var product =await _productRepository.GetByIdAsync(id);
            var productDto=_mapper.Map<ProductDto>(product);       
            return productDto;
        }

        [HttpPost]
        public async Task< ResultDto> Add(ProductDto model)
        {
           var product=_mapper.Map<Product>(model);
            product.Created = DateTime.Now;
            product.Updated = DateTime.Now;
            await  _productRepository.AddAsync(product);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public async Task<ResultDto> Update(Product model)
        {
            var product = _mapper.Map<Product>(model);
            product.Updated = DateTime.Now;
            await _productRepository.UpdateAsync(product);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete]
        public async Task<ResultDto> Delete(int id) {

            await _productRepository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }

    }
}
