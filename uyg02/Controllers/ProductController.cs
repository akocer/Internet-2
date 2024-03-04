using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uyg02.Dtos;
using uyg02.Models;

namespace uyg02.Controllers
{

    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        ResultDto _resultDto = new ResultDto();
        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public List<ProductDto> GetAll()
        {
            var products = _context.Products.ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        [HttpGet]
        [Route("{id}")]

        public ProductDto Get(int id)
        {
            var product = _context.Products.Where(s => s.Id == id).SingleOrDefault();
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        [HttpPost]
        public ResultDto Post(ProductDto dto)
        {
            if (_context.Products.Count(c => c.Name == dto.Name) > 0)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Girilen Ürün İsmi Kayıtıdır!";
                return _resultDto;
            }

            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            _context.SaveChanges();

            _resultDto.Status = true;
            _resultDto.Message = " Ürün Eklendi";
            return _resultDto;
        }

        [HttpPut]
        public ResultDto Put(ProductDto dto)
        {
            var product = _context.Products.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (product == null)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Ürün Bulunamadı!";
                return _resultDto;
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.isActive = dto.isActive;
            _context.Products.Update(product);
            _context.SaveChanges();

            _resultDto.Status = true;
            _resultDto.Message = " Ürün Düzenledi";
            return _resultDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var product = _context.Products.Where(s => s.Id == id).SingleOrDefault();
            if (product == null)
            {
                _resultDto.Status = false;
                _resultDto.Message = "Ürün Bulunamadı!";
                return _resultDto;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            _resultDto.Status = true;
            _resultDto.Message = " Ürün Silindi";
            return _resultDto;
        }
    }
}
