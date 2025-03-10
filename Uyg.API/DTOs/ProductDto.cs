﻿

namespace Uyg.API.DTOs
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
