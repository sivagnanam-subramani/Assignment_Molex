using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Managers.Interaces;
using Assignment.Models;
using Assignment.Repository.Interfaces;

namespace Assignment.Managers
{
    public class StoriesManager : IStoriesManager
    {
        private IStoriesRepository storiesRepository;

        public StoriesManager(IStoriesRepository storiesRepository)
        {
            this.storiesRepository = storiesRepository;
        }

        public async Task<ObservableCollection<string>> GetStories()
        {
            ObservableCollection<String> stories = new ObservableCollection<String>();
            try
            {
                return await storiesRepository.GetStories();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return stories;
        }

        public async Task<ObservableCollection<StoryDetailModel>> GetStoriesWithDetail(int page, ObservableCollection<string> stories, int limit = 10)
        {
            ObservableCollection<StoryDetailModel> storyDetails = new ObservableCollection<StoryDetailModel>();
            try
            {
                if (stories == null || !stories.Any())
                {
                    return storyDetails;
                }

                int startIndex = page * limit;

                return await storiesRepository.GetStoryDetails(stories.Skip(startIndex).Take(limit).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return storyDetails;
        }
    }
}
