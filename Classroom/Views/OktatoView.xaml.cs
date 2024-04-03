using Classroom.ModelViews;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace Classroom.Views
{
    public partial class OktatoView : UserControl
    {
        private readonly OktatoViewModel? _viewModel;

        public OktatoView()
        {
            InitializeComponent();
            _viewModel = App.Current.Services.GetService<OktatoViewModel>();
            DataContext = _viewModel ?? throw new System.ArgumentNullException(nameof(_viewModel));
        }
    }
}