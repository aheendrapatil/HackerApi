using HackerNewsApi2.Models;
using HackerNewsApi2.Utilities;
using Newtonsoft.Json;
using System.Net;

namespace HackerNewsApi2.Repositories
{
    public class StoryRepositories : IStoryRepositories
    {
        private List<Story> list = new List<Story>();
        private Story story = new Story();
        public List<Story> GetAllBestStories()
        {
            List<Story> list = new List<Story>();
            string jsn = ((new WebClient()).DownloadString(GlobalConstants.BEST_STORIES_LINK));

            //string urlPrefix = GlobalConstants.STORY_DETAIL_LINK;
            //string urlSufix = JSON;
            jsn = jsn.Substring(1, jsn.Length - 2);
            string[] storyIds = jsn.Split(',');            
            for (int i = 0; i < storyIds.Length; i++)
            {
                storyIds[i] = storyIds[i].Trim();

                story = new Story();
                var stry = ((new WebClient()).DownloadString(GlobalConstants.STORY_DETAIL_LINK + storyIds[i] + GlobalConstants.JSON_EXTENSION));
                var obj = JsonConvert.DeserializeObject<Story>(stry);
                story = obj;
                list.Add(story);
            }
            return list.OrderByDescending(o => o.score).ToList();
        }
    }
}
