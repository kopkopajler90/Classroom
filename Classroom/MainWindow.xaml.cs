using Classroom.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  OktatoView _oktatoView;
        private  TanuloView _tanuloView;
        private KurzusView _kurzusView;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void miKurzusNezet_Click(object sender, RoutedEventArgs e)
        {
            _kurzusView = new();
            ucKurzusNezet.Content = _kurzusView;
        }

        private void miOktatokNezet_Click(object sender, RoutedEventArgs e)
        {
            _oktatoView = new();
            ucKurzusNezet.Content = _oktatoView;
        }

        private void miTanuloNezet_Click(object sender, RoutedEventArgs e)
        {
            _tanuloView = new();
            ucKurzusNezet.Content = _tanuloView;
        }
    }
}