using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MemLeakObservableSample.Views
{
    public partial class MainPage
    {
        SynchronizationContext context;

        public MainPage()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Task.Factory.StartNew(async () =>
            {
                for (int index = 0; index < 200000; index++)
                {
                    var name = $"test-{index}";

                    // TODO - Try this with CollectionView and ensure the scroll events are marhsaled using the sync context
                    App.Current.OnAddItem(this, name);
                    context.Send(state => ScrollTo(name), null);

                    // If you are swapping between ListView & CollectionView
                    // you will need to uncomment/comment the correct lines
                    // below

                    //listView.ScrollTo(name, ScrollToPosition.End, true);

                    // Sometimes this worked and sometimes it didn't. I ran out
                    // of time to evaluate it, but I think the scrolling is
                    // independent of the problem.
                    //collectionView.ScrollTo(name, animate: true); 

                    await Task.Delay(2);
                }
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }

        void ScrollTo(string name)
        {
            sfListView.ScrollTo(name, Syncfusion.ListView.XForms.ScrollToPosition.End, true)

        }

        private void Modal_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage(), true);
        }
    }
}
