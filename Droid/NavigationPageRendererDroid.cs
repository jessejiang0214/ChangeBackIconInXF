using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Widget;

[assembly: ExportRenderer (typeof(ContentPage), typeof(ChangeBackIcon.Droid.NavigationPageRendererDroid))]
namespace ChangeBackIcon.Droid
{
    public class NavigationPageRendererDroid : PageRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged (e);

            var actionBar = ((Android.App.Activity)Context).ActionBar;

            actionBar.SetCustomView (Resource.Layout.CustomNavigationBarLayout);
            actionBar.SetDisplayShowCustomEnabled (true);

            var pagemodel = this.Element as ICanHideBackButton;
            if (pagemodel != null) {
                if (pagemodel.HideBackButton)
                    actionBar.SetHomeAsUpIndicator (new ColorDrawable (Color.Transparent.ToAndroid ()));               
            } else {
                actionBar.SetHomeAsUpIndicator (Resource.Drawable.Back);
            }
            actionBar.SetIcon (new ColorDrawable (Color.Transparent.ToAndroid ()));


            UpdatePageTitle ();
        }

        void UpdatePageTitle ()
        {
            var actionBar = ((Android.App.Activity)Context).ActionBar;
            if (actionBar == null || actionBar.CustomView == null)
                return;
            var view = actionBar.CustomView.FindViewById<TextView> (Resource.Id.TitleText);
            if (view != null)
                view.Text = Element.Title;
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);
            if (e.PropertyName == "Title")
                UpdatePageTitle ();

        }
    }
}

