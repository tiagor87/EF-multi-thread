using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFMultiThread.Domain;
using EFMultiThread.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EFMultiThread.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository repository;

        public CategoryController(CategoryRepository repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet("{organizationId}")]
        public List<Category> Get(Guid organizationId)
        {

            var tasks = new List<Task<List<Category>>>(10);
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(this.repository.GetAllAsync(organizationId));
            }
            return tasks.SelectMany(t => t.Result).ToList();
        }
    }
}
