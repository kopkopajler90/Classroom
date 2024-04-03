using Classroom.Models;
using Classroom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Classroom.ModelViews
{
    public class OktatoViewModel : ViewModelBase
    {
        private readonly IOktatoDataService _oktatoService;

        public ObservableCollection<Oktato> Oktatok { get; set; }

        private Oktato _selectedOktato;
        public Oktato SelectedOktato
        {
            get { return _selectedOktato; }
            set
            {
                _selectedOktato = value;
                OnPropertyChanged(nameof(SelectedOktato));
            }
        }

        private string _ujOktatoVnev;
        public string UjOktatoVnev
        {
            get { return _ujOktatoVnev; }
            set
            {
                _ujOktatoVnev = value;
                OnPropertyChanged(nameof(UjOktatoVnev));
            }
        }

        private string _ujOktatoKnev;
        public string UjOktatoKnev
        {
            get { return _ujOktatoKnev; }
            set
            {
                _ujOktatoKnev = value;
                OnPropertyChanged(nameof(UjOktatoKnev));
            }
        }

        public ICommand AddOktatoCommand { get; set; }

        public OktatoViewModel(IOktatoService oktatoService)
        {
            _oktatoService = oktatoService;
            Oktatok = new ObservableCollection<Oktato>(_oktatoService.GetAll());

            AddOktatoCommand = new RelayCommand(AddOktato);
        }

        private void AddOktato()
        {
            var ujOktato = new Oktato
            {
                Vnev = UjOktatoVnev,
                Knev = UjOktatoKnev
            };

            _oktatoService.Add(ujOktato);
            Oktatok.Add(ujOktato);

            UjOktatoVnev = string.Empty;
            UjOktatoKnev = string.Empty;
        }
    }
}
