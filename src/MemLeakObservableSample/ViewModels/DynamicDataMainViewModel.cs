using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemLeakObservableSample.ViewModels
{
    public class DynamicDataMainViewModel : BindableBase
    {
        public DynamicDataMainViewModel()
        {
            App.Current.AddItem += OnAddItem;
            Clear = new Command(OnClear);
        }

        public ICommand Clear { get; }
        public string Title => "Memory Leak Sample";

        public ObservableCollection<string> Items { get; }

        public int Count => Items.Count;

        void OnAddItem(object sender, AddItemEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        void OnClear()
        {
            throw new NotImplementedException();
        }
    }
}
