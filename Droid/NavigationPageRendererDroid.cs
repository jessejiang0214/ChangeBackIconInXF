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

            // As the Title is not alignment as center, so that we need to load customer view.
            actionBar.SetCustomView (Resource.Layout.CustomNavigationBarLayout);
            actionBar.SetDisplayShowCustomEnabled (true);

            // If you want to hide the back button in some pages, 
            // you can pass a value to renderer and do this.
            var pagemodel = this.Element as ICanHideBackButton;
            if (pagemodel != null) {
                if (pagemodel.HideBackButton) {
                    // I didn't find out another way to hide the UpInicator
                    // I have tried this, but not work
                    // actionBar.SetDisplayHomeAsUpEnabled(false);
                    actionBar.SetHomeAsUpIndicator (new ColorDrawable (Color.Transparent.ToAndroid ())); 
                }
            } else {
                actionBar.SetHomeAsUpIndicator (Resource.Drawable.Back);
            }

            // This function is used for hide the App Icon
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
            // As we used customer view, so Title cannot be update after page loaded.
            if (e.PropertyName == "Title")
                UpdatePageTitle ();

        }
    }
}

