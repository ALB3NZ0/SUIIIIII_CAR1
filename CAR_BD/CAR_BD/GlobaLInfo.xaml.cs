using CAR_BD.SELLS_CARDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для GlobaLInfo.xaml
    /// </summary>
    public partial class GlobaLInfo : Page
    {


        GLOBAL_INFOTableAdapter globalInfo = new GLOBAL_INFOTableAdapter();

        SUPPLIERTableAdapter supplier = new SUPPLIERTableAdapter();

        CARTableAdapter car = new CARTableAdapter();

        WHERE_THE_CAR_COMES_FROMTableAdapter wherethecar = new WHERE_THE_CAR_COMES_FROMTableAdapter();


        private int suiCARNAMEId;
        private int suiWHERE_THE_CAR_COMES_FROMId;
        private int suiSUPPLIERId;


        

        public GlobaLInfo()
        {
            InitializeComponent();
            avto.ItemsSource = globalInfo.GetData();

            SUPPLIER_IDComboBox.ItemsSource = supplier.GetData();
            SUPPLIER_IDComboBox.DisplayMemberPath = "ID_SUPPLIER";

            CAR_IDComboBox.ItemsSource = car.GetData();
            CAR_IDComboBox.DisplayMemberPath = "ID_CARNAME";

            WHERE_IDComboBox.ItemsSource = wherethecar.GetData();
            WHERE_IDComboBox.DisplayMemberPath = "ID_WHERE_THE_CAR_COMES_FROM";

            avto.SelectionChanged += avto_SelectionChanged;


        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void AddID_Click(object sender, RoutedEventArgs e)
        {

            if(CAR_IDComboBox.SelectedItem != null && WHERE_IDComboBox.SelectedItem != null && SUPPLIER_IDComboBox.SelectedItem != null)
            {
                DataRowView carNameRow = CAR_IDComboBox.SelectedItem as DataRowView;
                int CARNAME_ID = Convert.ToInt32(carNameRow["ID_CARNAME"]);

                DataRowView whereRow = WHERE_IDComboBox.SelectedItem as DataRowView;
                int WhereTheCar_ID = Convert.ToInt32(whereRow["ID_WHERE_THE_CAR_COMES_FROM"]);

                DataRowView suplierRow = SUPPLIER_IDComboBox.SelectedItem as DataRowView;
                int Supplier_ID = Convert.ToInt32(suplierRow["ID_SUPPLIER"]);

                globalInfo.InsertQuery(CARNAME_ID, WhereTheCar_ID, Supplier_ID);
                avto.ItemsSource = globalInfo.GetData();
            }




        }

        private void DeleteIDr_Click(object sender, RoutedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                DataRowView selectedRow = avto.SelectedItem as DataRowView;
                int ID = Convert.ToInt32(selectedRow["ID_GLOBAL_INFO"]);
                globalInfo.DeleteQuery(ID);
                avto.ItemsSource = globalInfo.GetData();
            }
        }

        private void UpdateID_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selecRow = avto.SelectedItem as DataRowView;


            selecRow["CARNAME_ID"] = suiCARNAMEId;
            selecRow["WHERE_THE_CAR_COMES_FROM_ID"] = suiWHERE_THE_CAR_COMES_FROMId;
            selecRow["SUPPLIER_ID"] = suiSUPPLIERId;


            globalInfo.Update(selecRow.Row);

            avto.Items.Refresh();
        }

        private void CAR_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CAR_IDComboBox.SelectedItem != null)
            {
                DataRowView row = CAR_IDComboBox.SelectedItem as DataRowView;
                suiCARNAMEId = Convert.ToInt32(row["ID_CARNAME"]);
            }
        }

        private void WHERE_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WHERE_IDComboBox.SelectedItem != null)
            {
                DataRowView row = WHERE_IDComboBox.SelectedItem as DataRowView;
                suiWHERE_THE_CAR_COMES_FROMId = Convert.ToInt32(row["ID_WHERE_THE_CAR_COMES_FROM"]);
            }
        }

        private void SUPPLIER_IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SUPPLIER_IDComboBox.SelectedItem != null)
            {
                DataRowView row = SUPPLIER_IDComboBox.SelectedItem as DataRowView;
                suiSUPPLIERId = Convert.ToInt32(row["ID_SUPPLIER"]);
            }
        }


        private void avto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (avto.SelectedItem != null)
            {
                DataRowView selectedRow = avto.SelectedItem as DataRowView;

                int suiCARNAMEId = Convert.ToInt32(selectedRow["CARNAME_ID"]);
                int suiWHERE_THE_CAR_COMES_FROMId = Convert.ToInt32(selectedRow["WHERE_THE_CAR_COMES_FROM_ID"]);
                int suiSUPPLIERId = Convert.ToInt32(selectedRow["SUPPLIER_ID"]);

                // Находим соответствующие элементы в ComboBox'ах по ID и устанавливаем их выбранными
                foreach (DataRowView item in CAR_IDComboBox.Items)
                {
                    if (Convert.ToInt32(item["ID_CARNAME"]) == suiCARNAMEId)
                    {
                        CAR_IDComboBox.SelectedItem = item;
                        break;
                    }
                }


                foreach (DataRowView item in WHERE_IDComboBox.Items)
                {
                    if (Convert.ToInt32(item["ID_WHERE_THE_CAR_COMES_FROM"]) == suiWHERE_THE_CAR_COMES_FROMId)
                    {
                        WHERE_IDComboBox.SelectedItem = item;
                        break;
                    }
                }

                foreach (DataRowView item in SUPPLIER_IDComboBox.Items)
                {
                    if (Convert.ToInt32(item["ID_SUPPLIER"]) == suiSUPPLIERId)
                    {
                        SUPPLIER_IDComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
        }


    }
}
