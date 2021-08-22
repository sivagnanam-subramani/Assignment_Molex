using System;
using FreshMvvm;
using PropertyChanged;

namespace Assignment.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageModel : FreshBasePageModel
    {
        #region DataModels
        public bool IsError { get; set; }

        public string ErrorMessage
        {
            get;
            set;
        }
        #endregion

        public BasePageModel()
        {
        }
        protected void ShowError(string errorMessage)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                IsError = true;
                ErrorMessage = errorMessage;
            }
            else
            {
                IsError = false;
                ErrorMessage = string.Empty;
            }
        }
    }
}
