using Classroom.ModelViews;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classroom.Views
{
    /// <summary>
    /// Interaction logic for TanuloView.xaml
    /// </summary>
    public partial class TanuloView : UserControl
    {
        private readonly TanuloViewModel? _viewModel;
        public TanuloView()
        {
            InitializeComponent();
            _viewModel = App.Current.Services.GetService<TanuloViewModel>();
            DataContext = _viewModel ?? throw new System.ArgumentNullException(nameof(_viewModel));
        }

        
    }
}
