using System;

using Xamarin.Forms;

namespace ChangeBackIcon
{
    public class ThirdPage : ContentPage, ICanHideBackButton
    {
        public ThirdPage ()
        {
            HideBackButton = true;
            Title = "Third Page";
            Content = new StackLayout { 
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label { 
                        Text = "Hello ContentPage" ,
                        HorizontalTextAlignment = TextAlignment.Center,
                    }
                }
            };
        }

        public bool HideBackButton { get; set; }

    }
}


