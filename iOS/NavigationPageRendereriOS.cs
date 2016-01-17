using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer (typeof(ContentPage), typeof(ChangeBackIcon.iOS.NavigationPageRendereriOS))]
namespace ChangeBackIcon.iOS
{
    public class NavigationPageRendereriOS : PageRenderer
    {
        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);

            // If you want to hide the back button in some pages, 
            // you can pass a value to renderer and do this.
            var page = this.Element as ICanHideBackButton;
            if (page != null) {
                if (page.HideBackButton) {
                    this.NavigationController.TopViewController.NavigationItem.SetHidesBackButton (true, false);
                    return;
                }
            }

            // Change back icon.
            this.NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = 
                new UIBarButtonItem (
                    UIImage.FromFile ("Back.png"),
                    UIBarButtonItemStyle.Plain,
                    (sender, args) => {
                        // This will overwrite PopView behavior in Xamarin Forms.
                        NavigationController.PopViewController (true);
                    });
        }
    }
}

