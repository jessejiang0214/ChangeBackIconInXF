using System;

using Xamarin.Forms;

namespace ChangeBackIcon
{
    public class FirstPage : ContentPage, ICanHideBackButton
    {
        public FirstPage ()
        {
            Title = "FirstPage";
            HideBackButton = true;
            Content = new StackLayout { 
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Button { 
                        Text = "Go to Next Page",
                        Command = new Command (async (obj) => {
                            await Navigation.PushAsync (new SecondPage ());
                        })
                    }
                }
            };
        }

        public bool HideBackButton { get; set; }
    }
}


