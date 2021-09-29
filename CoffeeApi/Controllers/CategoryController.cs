using CoffeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApi.Controllers
{
    [ApiController]
    [Route("api/category")]  //change this to specifics from [Route("api/[controller]")]     
    public class CategoryController : ControllerBase
    {
        [HttpGet()]
        public List<Models.Coffee.Category> getAll()
        {
            return DAL.GetAllCategories();
        }

        [HttpGet("{id}")]
        public Models.Coffee.Category getSingleCategory(string id)
        {
            return DAL.GetCategory(id);
        }

        [HttpGet("products/{id}")]
        public List<Coffee.Product> getProductsInCategory(string id)
        {
            return DAL.GetAllForCategory(id);
        }

        [HttpPost()]
        public string insertCategory(Models.Coffee.Category cat)
        {
            DAL.InsertCategory(cat);
            return cat.id;
        }

        [HttpDelete("{id}")]
        public bool deleteCategory(string id)
        {
            DAL.DeleteCategory(id);
            return true;
        }

        



        //samples below!
        [HttpGet("test")] //no slash! /api/category/testhello
        public string test()
        {
            return "Hello!";
        }
        [HttpGet("test2")] //no slash! /api/category/testhello
        public string test2()
        {
            return "Hello2!";
        }

        [HttpGet("testcat")] //no slash! /api/category/testcat
        public Models.Coffee.Category testcat()
        {
            return DAL.GetCategory("PAST");
        }
        [HttpGet("testcat/{id}")]
        public Models.Coffee.Category getSingleCategoryprac(string id)
        {
            return DAL.GetCategory(id);
        }
    }
}
