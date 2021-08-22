using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Assignment.Managers.Interaces;
using Assignment.Models;
using MvvmHelpers.Commands;
using PropertyChanged;

namespace Assignment.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class DashboardPageModel : BasePageModel
    {
        #region Private fields
        private int page = 0;
        private StoryDetailModel _selectedItem;
        #endregion

        #region DataModels
        public ObservableCollection<String> Stories { get; private set; }
        public ObservableCollection<StoryDetailModel> StoryDetails { get; private set; }
        public bool IsLoadingMore { get; set; }
        public StoryDetailModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                navigateToDetailsPage(value);
            }
        }
        #endregion

        #region Commands
        public AsyncCommand LoadMoreDataCommand { get; set; }
        #endregion

        #region Managers
        private IStoriesManager storiesManager;
        #endregion

        public DashboardPageModel(IStoriesManager storiesManager)
        {
            this.storiesManager = storiesManager;
            LoadMoreDataCommand = new AsyncCommand(LoadMoreDataAsync);
        }

        #region Command Methods
        async Task LoadMoreDataAsync()
        {
            IsLoadingMore = true;
            try
            {
                if (Stories != null && Stories.Any())
                {
                    page++;
                    var nextPageList = (await storiesManager.GetStoriesWithDetail(page, Stories)).ToList();
                    if (nextPageList != null && nextPageList.Any())
                        nextPageList.ForEach(x => StoryDetails.Add(x));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            IsLoadingMore = false;
        }
        #endregion

        #region Private / Internal methods
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            using (UserDialogs.Instance.Loading())
            {
                await GetAllStories();
            }
        }

        private async Task GetAllStories()
        {
            try
            {
                Stories = await storiesManager.GetStories();

                if (Stories != null && Stories.Any())
                    StoryDetails = await storiesManager.GetStoriesWithDetail(page, Stories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void navigateToDetailsPage(StoryDetailModel value)
        {
            await CoreMethods.PushPageModel<DetailsPageModel>(value,true);
        }
        #endregion
    }
}
