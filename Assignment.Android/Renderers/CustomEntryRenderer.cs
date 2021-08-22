using System;
using Android.Content;
using Assignment.Common.Controls;
using Assignment.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Assignment.Droid.Renderers
{
    public class CustomEntryRenderer :EntryRenderer
    {
        public CustomEntryRenderer(Context context):base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
            }
        }
    }
}
