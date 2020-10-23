
using Xamarin.Forms;

namespace MemLeakObservableSample.Views
{
    public class ModalPage : ContentPage
    {
        public ModalPage()
        {
            var backButton = new Button { Text = "Back" };
            backButton.Clicked += (s, e) => Navigation.PopModalAsync();
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" },
                    backButton
                }
            };
        }
    }
}