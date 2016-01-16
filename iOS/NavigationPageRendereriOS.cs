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

            var page = this.Element as ICanHideBackButton;
            if (page != null) {
                if (page.HideBackButton) {
                    this.NavigationController.TopViewController.NavigationItem.SetHidesBackButton (true, false);
                    return;
                }
            }
            this.NavigationController.TopViewController.NavigationItem.LeftBarButtonItem = 
                new UIBarButtonItem (
                    UIImage.FromFile ("Back.png"),
                    UIBarButtonItemStyle.Plain,
                    (sender, args) => {
                        NavigationController.PopViewController (true);
                    });
        }
    }
}

