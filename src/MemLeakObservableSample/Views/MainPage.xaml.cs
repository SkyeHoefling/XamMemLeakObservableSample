using MemLeakObservableSample.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemLeakObservableSample.Views
{
    public partial class MainPage
    {
        public MainPage() =>
            InitializeComponent();

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Task.Factory.StartNew(async () =>
            {
                for (int index = 0; index < 5000; index++)
                {
                    var name = $"test-{index}";

                    App.Current.OnAddItem(this, name);
                    listView.ScrollTo(name, ScrollToPosition.End, true);
                    await Task.Delay(20);
                }
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        private void Modal_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage(), true);
        }

        private void ObservableCollectionStrategy_Clicked(object sender, System.EventArgs e) =>
            BindingContext = new MainViewModel();

        void ConcurrentStackStrategy_Clicked(object sender, System.EventArgs e) =>
            BindingContext = new ConcurrentMainViewModel();

        void DynamicDataStrategy_Clicked(object sender, System.EventArgs e) =>
            BindingContext = new DynamicDataMainViewModel();

    }
}
