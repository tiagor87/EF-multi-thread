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
    public class HostController : Controller
    {
        private readonly HostRepository repository;

        public HostController(HostRepository repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public List<Host> Get()
        {
            var tasks = new List<Task<List<Host>>>(10);
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(this.repository.GetAllAsync());
            }
            Task.WaitAll(tasks.ToArray());
            return tasks.SelectMany(t => t.Result).ToList();
        }
    }
}
