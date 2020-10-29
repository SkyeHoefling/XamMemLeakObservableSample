﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemLeakObservableSample.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
            Clear = new Command(OnClear);
            App.Current.AddItem += OnAddItem;
        }

        public ICommand Clear { get; }
        public string Title => "Memory Leak Sample";

        public ObservableCollection<string> Items { get; }

        public int Count => Items.Count;
 
        void OnAddItem(object sender, AddItemEventArgs eventArgs)
        {
            Items.Add(eventArgs.Name);
        }

        void OnClear()
        {
            Items.Clear();
        }
    }
}
