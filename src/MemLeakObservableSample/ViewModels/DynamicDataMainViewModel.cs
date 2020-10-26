using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;
using DynamicData;
using DynamicData.Binding;
using Xamarin.Forms;

namespace MemLeakObservableSample.ViewModels
{
    public class DynamicDataMainViewModel : BindableBase
    {
        public DynamicDataMainViewModel()
        {
            App.Current.AddItem += OnAddItem;
            Clear = new Command(OnClear);

            var refCount = _sourceList
                .Connect()
                .RefCount();

            refCount
                .Bind(out _items)
                .DisposeMany()
                .Subscribe();

            _sourceList
                .CountChanged
                .Do(x => _count = x)
                .Subscribe(_ =>  RaisePropertyChanged(nameof(Count)));
        }

        public ICommand Clear { get; }
        public string Title => "DynamicData Sample";

        public ReadOnlyObservableCollection<string> Items => _items;

        public int Count => _count;

        void OnAddItem(object sender, AddItemEventArgs eventArgs)
        {
            _sourceList.Add(eventArgs.Name);
        }

        void OnClear()
        {
            _sourceList.Clear();
        }

        SourceList<string> _sourceList = new SourceList<string>();
        private readonly ReadOnlyObservableCollection<string> _items;
        private int _count;
    }
}
