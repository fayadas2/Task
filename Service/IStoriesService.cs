using TaskBamboo.Models;

namespace TaskBamboo.Service
{
    public interface IStoriesService
    {
       Task<List<StoriesModel>> bestStories();
    }
}
