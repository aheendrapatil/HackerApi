using HackerNewsApi2.Models;
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
        // GET: api/<HackerController>
        [HttpGet]
        public IEnumerable<Story> Get()        {
            List<Story> list = new List<Story>();
            list = getAllBestStories();                        
            return list;
        }

        // GET api/<HackerController>/5
        [HttpGet("{id}")]
        public IEnumerable<Story> Get(int id)
        {
            List<Story> list = new List<Story>();
            list = getAllBestStories();
            List<Story> SortedList = list.OrderByDescending(o => o.score).ToList();
            return SortedList.Take(id);
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

        public List<Story> getAllBestStories()
        {
            List<Story> list = new List<Story>();
            string jsn = ((new WebClient()).DownloadString("https://hacker-news.firebaseio.com/v0/beststories.json"));
            
            string urlPrefix = "https://hacker-news.firebaseio.com/v0/item/";
            string urlSufix = ".json";
            jsn = jsn.Substring(1, jsn.Length - 2);
            string[] storyIds = jsn.Split(',');
            Story story = new Story();
            for (int i = 0; i < storyIds.Length; i++)
            {
                storyIds[i] = storyIds[i].Trim();

                story = new Story();
                var stry = ((new WebClient()).DownloadString(urlPrefix + storyIds[i] + urlSufix));
                var obj = JsonConvert.DeserializeObject<Story>(stry);
                story = obj;                
                list.Add(story);
            }            
            
            return list;
        }
    }
}
