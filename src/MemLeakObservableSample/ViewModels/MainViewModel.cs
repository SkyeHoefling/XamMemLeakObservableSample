using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemLeakObservableSample.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
            Clear = new Command(() => Items.Clear());
            App.Current.AddItem += OnAddItem;
        }

        public ICommand Clear { get; }

        public ObservableCollection<string> Items { get; }

        void OnAddItem(object sender, AddItemEventArgs eventArgs)
        {
            Items.Add(eventArgs.Name);
        }
    }
}
