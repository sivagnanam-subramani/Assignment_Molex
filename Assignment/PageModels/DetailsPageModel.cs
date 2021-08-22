using System;
using System.Threading.Tasks;
using Assignment.Models;
using MvvmHelpers.Commands;
using PropertyChanged;

namespace Assignment.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class DetailsPageModel : BasePageModel
    {
        #region Properties
        public StoryDetailModel Data { get; set; }
        #endregion

        #region Commands
        public AsyncCommand CloseCommand { get; set; }
        #endregion

        public DetailsPageModel()
        {
            CloseCommand = new AsyncCommand(CloseModal);
        }

        #region Internal Methods
        public override void Init(object initData)
        {
            Data = (StoryDetailModel)initData;
        }

        private async Task CloseModal()
        {
            await CoreMethods.PopPageModel(true);
        }
        #endregion
    }
}
