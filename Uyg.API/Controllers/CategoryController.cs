using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Uyg.API.DTOs;
using Uyg.API.Models;
using Uyg.API.Repositories;

namespace Uyg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        ResultDto _result = new ResultDto();
        public CategoryController( IMapper mapper, CategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> List()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var CategoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return CategoryDtos;
        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var CategoryDto = _mapper.Map<CategoryDto>(category);
            return CategoryDto;
        }

        [HttpPost]
        public async Task<ResultDto> Add(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            category.Created = DateTime.Now;
            category.Updated = DateTime.Now;
            await _categoryRepository.AddAsync(category);
            _result.Status = true;
            _result.Message = "Kayıt Eklendi";
            return _result;
        }
        [HttpPut]
        public async Task<ResultDto> Update(Category model)
        {
            var category = _mapper.Map<Category>(model);
            category.Updated = DateTime.Now;
            await _categoryRepository.UpdateAsync(category);
            _result.Status = true;
            _result.Message = "Kayıt GüncelLendi";
            return _result;
        }

        [HttpDelete]
        public async Task<ResultDto> Delete(int id)
        {

            await _categoryRepository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Kayıt Silindi";
            return _result;

        }
    }
}
