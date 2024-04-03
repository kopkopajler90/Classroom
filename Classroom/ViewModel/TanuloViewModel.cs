using Classroom.Models;
using Classroom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.ModelViews
{
    internal class TanuloViewModel
    {
        private readonly ITanuloDataService _tanuloDataService;
        public ObservableCollection<Tanulo> TanulokOC { get; set; }

        public TanuloViewModel(ITanuloDataService tanuloDataService)
        {
            _tanuloDataService = tanuloDataService;
            TanulokOC = new ObservableCollection<Tanulo>();
            LoadData();
        }

        private void _tanuloDataService_ChangesSaved()
        {
            TanulokOC.Clear();
            LoadData();
        }

        public async void LoadData()
        {
            var tanulok = await _tanuloDataService.GetAllAsync();
            foreach (var tanulo in tanulok)
            {
                TanulokOC.Add(tanulo);
            }
        }
    }
}
