using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemLeakObservableSample.ViewModels
{
    public class ConcurrentMainViewModel : BindableBase
    {
        ConcurrentStack<string> concurrentItems = new ConcurrentStack<string>();
        public ConcurrentMainViewModel()
        {
            Clear = new Command(OnClear);
            App.Current.AddItem += OnAddItem;
        }

        public string Title => "Memory Leak Sample - Fixed";

        public ICommand Clear { get; }

        public ObservableCollection<string> Items => new ObservableCollection<string>(GetItems());

        public int Count => concurrentItems.Count;
        IEnumerable<string> GetItems()
        {
            foreach (var item in concurrentItems)
            {
                yield return item;
            }
        }

        void OnAddItem(object sender, AddItemEventArgs eventArgs)
        {
            concurrentItems.Push(eventArgs.Name);
            RaisePropertyChanged(nameof(Count));
            RaisePropertyChanged(nameof(Items));
        }

        void OnClear()
        {
            concurrentItems.Clear();
            RaisePropertyChanged(nameof(Count));
            RaisePropertyChanged(nameof(Items));
        }
    }
}
