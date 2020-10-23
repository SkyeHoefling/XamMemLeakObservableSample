using MemLeakObservableSample.Views;
using System;
using Xamarin.Forms;

namespace MemLeakObservableSample
{
    public partial class App : Application
    {
        public event EventHandler<AddItemEventArgs> AddItem;

        public static new App Current => (App)Application.Current;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void OnAddItem(string name)
        {
            AddItem?.Invoke(this, new AddItemEventArgs { Name = name });
        }
    }

    public class AddItemEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}
