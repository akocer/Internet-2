using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uyg01.Models;

namespace Uyg01.Controllers
{
    [Route("api")]
    [ApiController]
    public class ServisController : ControllerBase
    {
        List<Product> products = new List<Product> {

        new Product() { Id = 1,Name = "Elma",Price = 20,isActive = true },
        new Product() { Id = 2,Name = "Armut",Price = 24,isActive = false },
        new Product() { Id = 3,Name = "Erik",Price = 16,isActive = true },
        new Product() { Id = 4,Name = "Kayısı",Price = 23,isActive = false },
        new Product() { Id = 5,Name = "Portakal",Price = 15,isActive = true }
        };


        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "API Çalışıyor..";
        }


        [HttpGet]
        [Route("sayi")]
        public int Sayi()
        {
            return Random.Shared.Next(0, 100);
        }

        [HttpGet]
        [Route("sayiliste")]
        public List<int> SayiListe()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(Random.Shared.Next(0, 100));
            }
            return list;

        }

        [HttpGet]
        [Route("strliste")]
        public List<string> StrList()
        {
            var list = new List<string>
            {
                "Ali",
                "Veli",
                "Selami",
                "Ayşe",
                "Fatma",
                "Hayriye"
            };

            return list;
        }

        [HttpGet]
        [Route("karesi/{s}")]
        public int Karesi(int s)
        {
            return s * s;
        }

        [HttpGet]
        [Route("ort/{v}/{f}")]
        public double Ortalama(int v, int f)
        {
            return (v * 0.4) + (f * 0.6);
        }

        [HttpGet]
        [Route("Products")]
        public List<Product> Products()
        {
            return products.ToList();
        }

        [HttpGet]
        [Route("Products/{id}")]
        public Product Products(int id)
        {
            return products.Where(s => s.Id == id).SingleOrDefault();
        }

        [HttpPost]
        [Route("Products")]
        public bool Products(Product model)
        {
            products.Add(model);

            return true;
        }
        [HttpPut]
        [Route("Products/{id}")]
        public bool Products(int id, Product model)
        {
            var product = products.Where(s => s.Id == id).SingleOrDefault();
            product = model;

            return true;
        }
        [HttpDelete]
        [Route("Products/{id}")]
        public bool Delete(int id)
        {
            var product = products.Where(s => s.Id == id).SingleOrDefault();
            products.Remove(product);

            return true;
        }

    }
}
