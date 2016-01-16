using System;

using Xamarin.Forms;

namespace ChangeBackIcon
{
    public class SecondPage : ContentPage
    {
        public SecondPage ()
        {
            Title = "Second Page";
            Content = new StackLayout { 
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label { 
                        Text = "This is the second page",
                        HorizontalTextAlignment = TextAlignment.Center,
                    },
                    new Button {
                        Text = "Go to next page",
                        Command = new Command (async (obj) => {
                            await Navigation.PushAsync (new ThirdPage ());
                        })
                    }
                }
            };
        }
    }
}


