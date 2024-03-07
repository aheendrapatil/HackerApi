using HackerNewsApi2.Models;

namespace HackerNewsApi2.Repositories
{
    public interface IStoryRepositories
    {
        List<Story> GetAllBestStories();
    }
}