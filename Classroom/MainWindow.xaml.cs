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
        private readonly OktatoView _oktatoView;
        public MainWindow()
        {
            InitializeComponent();
            _oktatoView = new OktatoView();
        }

        private void miKurzusNezet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void miOktatokNezet_Click(object sender, RoutedEventArgs e)
        {
            ucKurzusNezet.Content = _oktatoView;
        }
    }
}