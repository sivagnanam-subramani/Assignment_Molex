using System;
using System.ComponentModel;
using PropertyChanged;
using Xamarin.Forms;

namespace Assignment.Common.Triggers
{
    [AddINotifyPropertyChangedInterface]
    public class TogglePasswordTriggerAction : TriggerAction<ImageButton>
    {
        public string ShowIcon { get; set; }
        public string HideIcon { get; set; }

        public bool HidePassword { get; set; } = true;

        protected override void Invoke(ImageButton sender)
        {
            sender.Source = HidePassword ? ShowIcon : HideIcon;
            HidePassword = !HidePassword;
        }
    }
}
