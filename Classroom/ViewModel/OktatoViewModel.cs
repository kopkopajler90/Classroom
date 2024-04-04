using Classroom.Commands;
using Classroom.Models;
using Classroom.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Classroom.ModelViews
{
    public class OktatoViewModel : INotifyPropertyChanged
    {
        private readonly IOktatoDataService _oktatoDataService;
        private ObservableCollection<Oktato> _oktatok = new();
        private Oktato _ujOktato = new Oktato();

        public event PropertyChangedEventHandler? PropertyChanged;

        public OktatoViewModel(IOktatoDataService oktatoDataService)
        {
            _oktatoDataService = oktatoDataService;
            InitAsync();

            HozzaadCommand = new RelayCommand(Hozzaad, CanHozzaad);
        }
        private async Task InitAsync()
        {
            await LoadOktatokAsync();
        }
        private async Task LoadOktatokAsync()
        {
            var oktatokList = await _oktatoDataService.GetAllAsync();
            Oktatok = new ObservableCollection<Oktato>(oktatokList);
        }

        public ObservableCollection<Oktato> Oktatok
        {
            get { return _oktatok; }
            set
            {
                _oktatok = value;
                OnPropertyChanged(nameof(Oktatok));
            }
        }

        public Oktato UjOktato
        {
            get { return _ujOktato; }
            set
            {
                _ujOktato = value;
                OnPropertyChanged(nameof(UjOktato));
            }
        }

        public ICommand HozzaadCommand { get; }

        private async void Hozzaad(object obj)
        {
            await _oktatoDataService.CreateAsync(UjOktato);
            UjOktato = new Oktato();
            await LoadOktatokAsync(); 
        }


        private bool CanHozzaad(object obj)
        {
            return !string.IsNullOrWhiteSpace(UjOktato.Vnev) && !string.IsNullOrWhiteSpace(UjOktato.Knev);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}