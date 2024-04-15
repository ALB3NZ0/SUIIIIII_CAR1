using CAR_BD.SELLS_CARDataSetTableAdapters;
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

namespace CAR_BD
{
    /// <summary>
    /// Логика взаимодействия для Fuul_Info.xaml
    /// </summary>
    public partial class Fuul_Info : Page
    {

        CARTableAdapter fullInfo = new CARTableAdapter();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            avto.Columns[9].Visibility = Visibility.Collapsed;
            avto.Columns[10].Visibility = Visibility.Collapsed;
            avto.Columns[11].Visibility = Visibility.Collapsed;
            avto.Columns[12].Visibility = Visibility.Collapsed;
            avto.Columns[13].Visibility = Visibility.Collapsed;
            avto.Columns[14].Visibility = Visibility.Collapsed;
            avto.Columns[15].Visibility = Visibility.Collapsed;
            avto.Columns[16].Visibility = Visibility.Collapsed;
            avto.Columns[17].Visibility = Visibility.Collapsed;
            avto.Columns[18].Visibility = Visibility.Collapsed;
            avto.Columns[19].Visibility = Visibility.Collapsed;
            avto.Columns[8].Visibility = Visibility.Collapsed;
        }


        public Fuul_Info()
        {
            InitializeComponent();
            avto.ItemsSource = fullInfo.GetFullInfo();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
