using Classroom.Commands;
using Classroom.Models;
using Classroom.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Classroom.ModelViews
{
    public class KurzusViewModel : INotifyPropertyChanged
    {
        private readonly IKurzusDataService _kurzusDataService;
        private readonly IOktatoDataService _oktatoDataService;
        private ObservableCollection<Kurzus> _kurzusok = new();
        private Kurzus _ujKurzus = new Kurzus();
        private ObservableCollection<Oktato> _oktatok = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public KurzusViewModel(IKurzusDataService kurzusDataService, IOktatoDataService oktatoDataService)
        {
            _kurzusDataService = kurzusDataService;
            _oktatoDataService = oktatoDataService;
            InitAsync();

            HozzaadCommand = new RelayCommand(Hozzaad, CanHozzaad);
        }

        private async Task InitAsync()
        {
            await LoadKurzusokAsync();
            await LoadOktatokAsync();
        }

        private async Task LoadKurzusokAsync()
        {
            var kurzusokList = await _kurzusDataService.GetAllAsync();
            Kurzusok = new ObservableCollection<Kurzus>(kurzusokList);
        }

        private async Task LoadOktatokAsync()
        {
            var oktatokList = await _oktatoDataService.GetAllAsync();
            Oktatok = new ObservableCollection<Oktato>(oktatokList);
        }

        public ObservableCollection<Kurzus> Kurzusok
        {
            get { return _kurzusok; }
            set
            {
                _kurzusok = value;
                OnPropertyChanged(nameof(Kurzusok));
            }
        }

        public Kurzus UjKurzus
        {
            get { return _ujKurzus; }
            set
            {
                _ujKurzus = value;
                OnPropertyChanged(nameof(UjKurzus));
            }
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

        public ICommand HozzaadCommand { get; }

        private void Hozzaad(object obj)
        {
            if (UjKurzus.Oktato != null)
            {
                UjKurzus.OktatoId = UjKurzus.Oktato.Id;
            }
            _kurzusDataService.CreateAsync(UjKurzus);
            UjKurzus = new Kurzus();
        }

        private bool CanHozzaad(object obj)
        {
            return !string.IsNullOrWhiteSpace(UjKurzus.Nev) && UjKurzus.Kezdet!=default && UjKurzus.Vege!=default;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}