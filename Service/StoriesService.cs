using TaskBamboo.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace TaskBamboo.Service
{
    public class StoriesService : IStoriesService
    {
        private readonly HttpClient _client;
        private readonly IMemoryCache _cache;

        public StoriesService(IHttpClientFactory httpClientFactory, IMemoryCache cache) {
            _client = httpClientFactory.CreateClient();
            _cache = cache;
        }
        public async Task<List<StoriesModel>> bestStories()
        {
            var bestStories = new List<StoriesModel>();
            try
            {
                const string cacheKey = "HackerApiData";
                List<StoriesModel> cachedData;

                if (!_cache.TryGetValue(cacheKey, out cachedData))
                {
                   
                    var bestStoriesPath = "https://hacker-news.firebaseio.com/v0/beststories.json";

                    var response = await _client.GetAsync(bestStoriesPath);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bestStoryIds = JsonConvert.DeserializeObject<List<long>>(result);

                        var tasks = bestStoryIds.Select(async id =>
                        {
                            var storyPath = $"https://hacker-news.firebaseio.com/v0/item/{id}.json";
                            var storyResponse = await _client.GetAsync(storyPath);
                            if (storyResponse.IsSuccessStatusCode)
                            {
                                var storyResult = await storyResponse.Content.ReadAsStringAsync();
                                var storyContent = JsonConvert.DeserializeObject<StoriesAPIModel>(storyResult);
                                var stories = new StoriesModel();
                                stories.title = storyContent.Title;
                                stories.url = storyContent.Url;
                                stories.postedBy = storyContent.By;
                                stories.time = DateTimeOffset.FromUnixTimeSeconds(storyContent.Time).UtcDateTime;
                                stories.score = storyContent.Score;
                                stories.commentCount = storyContent.Kids.Count;
                                bestStories.Add(stories);
                            }
                        });

                        await Task.WhenAll(tasks);
                    }
                    _cache.Set(cacheKey, bestStories, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTimeOffset.UtcNow.AddHours(1)
                    });
                    return bestStories;
                }
                return cachedData;
            }
            catch (Exception ex)
            {
                return bestStories;
            }
        }

    }
}
