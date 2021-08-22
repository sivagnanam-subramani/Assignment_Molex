using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Assignment.Models;

namespace Assignment.Managers.Interaces
{
    public interface IStoriesManager
    {
        Task<ObservableCollection<string>> GetStories();

        Task<ObservableCollection<StoryDetailModel>> GetStoriesWithDetail(int page, ObservableCollection<String> stores, int limit = 10);
    }
}
