using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment.Repository.Interfaces;
using Assignment.Services.Interfaces;
using Newtonsoft.Json;

namespace Assignment.Repository
{
    public class StoriesRepository : IStoriesRepository
    {
        private IRestService restService;

        public StoriesRepository(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<ObservableCollection<string>> GetStories()
        {
            ObservableCollection<String> stories = new ObservableCollection<String>();
            try
            {
                var response = await restService.GetAsync("/topstories.json");
                if (response.IsSuccessStatusCode)
                {
                    stories = new ObservableCollection<String>();
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        stories = JsonConvert.DeserializeObject<ObservableCollection<String>>(content);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stories;
        }

        public async Task<ObservableCollection<StoryDetailModel>> GetStoryDetails(List<String> stories)
        {
            ObservableCollection<StoryDetailModel> storyDetails = new ObservableCollection<StoryDetailModel>();

            try
            {
                foreach (String story in stories)
                {
                    using (var response = await restService.GetAsync("/item/" + story + ".json"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            if (!string.IsNullOrEmpty(content))
                            {
                                storyDetails.Add(JsonConvert.DeserializeObject<StoryDetailModel>(content));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return storyDetails;
        }
    }
}
