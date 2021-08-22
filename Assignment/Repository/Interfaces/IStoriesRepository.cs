using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Repository.Interfaces
{
    public interface IStoriesRepository
    {
        Task<ObservableCollection<string>> GetStories();

        Task<ObservableCollection<StoryDetailModel>> GetStoryDetails(List<String> stories);
    }
}
