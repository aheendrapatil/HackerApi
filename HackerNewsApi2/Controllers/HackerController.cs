using HackerNewsApi2.Models;
using HackerNewsApi2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackerNewsApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerController : ControllerBase
    {
        private readonly IStoryRepositories _storyRepositories;
        public HackerController(IStoryRepositories storyRepositories)
        {
            _storyRepositories = storyRepositories;
        }
        // GET: api/<HackerController>
        [HttpGet]
        public IEnumerable<Story> Get()        {
            List<Story> list = new List<Story>();
            list = _storyRepositories.GetAllBestStories();                        
            return list;
        }

        // GET api/<HackerController>/5
        [HttpGet("{topCount}")]
        public IEnumerable<Story> Get(int topCount)
        {
            List<Story> list = new List<Story>();
            list = _storyRepositories.GetAllBestStories();
            return list.Take(topCount);
        }

        // POST api/<HackerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HackerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HackerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}
