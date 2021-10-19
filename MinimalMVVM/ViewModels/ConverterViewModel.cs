using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MinimalMVVM.Models;

namespace MinimalMVVM.ViewModels
{
    internal sealed class ConverterViewModel : ObservableObject
    {
        private readonly ConverterModel _model;
        private string _someText = string.Empty;

        public ConverterViewModel(ConverterModel model, ObservableCollection<string> history) =>
            (_model, History) = (model, history);

        public string SomeText
        {
            get => _someText;
            set => SetProperty(ref _someText, value);
        }

        public ObservableCollection<string> History { get; }

        public ICommand ConvertTextCommand => new RelayCommand(() => _model.ConvertText(SomeText, OnUpdate));

        private void OnUpdate() => SomeText = string.Empty;
    }
}