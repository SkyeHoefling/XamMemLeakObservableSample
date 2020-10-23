using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemLeakObservableSample.Views
{
    public partial class MainPage
    {
        public MainPage() =>
            InitializeComponent();

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            for (int index = 0; index < 5000; index++)
            {
                var name = $"test-{index}";

                App.Current.OnAddItem(name);
                listView.ScrollTo(name, ScrollToPosition.End, true);
                await Task.Delay(20);
            }
        }

        private void Modal_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage(), true);
        }
    }
}
