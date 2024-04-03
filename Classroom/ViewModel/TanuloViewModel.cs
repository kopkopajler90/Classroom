using Classroom.Commands;
using Classroom.Models;
using Classroom.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Classroom.ModelViews
{
    public class TanuloViewModel : INotifyPropertyChanged
    {
        private readonly ITanuloDataService _tanuloDataService;
        private ObservableCollection<Tanulo> _tanulok = new ObservableCollection<Tanulo>();
        private Tanulo _ujTanulo = new Tanulo();

        public event PropertyChangedEventHandler? PropertyChanged;

        public TanuloViewModel(ITanuloDataService tanuloDataService)
        {
            _tanuloDataService = tanuloDataService;
            HozzaadCommand = new RelayCommand(Hozzaad, CanHozzaad);
            InitAsync();
        }
        private async Task InitAsync()
        {
            await LoadTanulokAsync();
        }
        private async Task LoadTanulokAsync()
        {
            var tanulokList = await _tanuloDataService.GetAllAsync();
            Tanulok = new ObservableCollection<Tanulo>(tanulokList);
        }

        public ObservableCollection<Tanulo> Tanulok
        {
            get { return _tanulok; }
            set
            {
                _tanulok = value;
                OnPropertyChanged(nameof(Tanulok));
            }
        }

        public Tanulo UjTanulo
        {
            get { return _ujTanulo; }
            set
            {
                _ujTanulo = value;
                OnPropertyChanged(nameof(UjTanulo));
            }
        }

        public ICommand HozzaadCommand { get; }

        private async void Hozzaad(object obj)
        {
            await _tanuloDataService.CreateAsync(UjTanulo);
            UjTanulo = new Tanulo();
            await LoadTanulokAsync();
        }

        private bool CanHozzaad(object obj)
        {
            return !string.IsNullOrWhiteSpace(UjTanulo.Nev) && !string.IsNullOrWhiteSpace(UjTanulo.Email);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}