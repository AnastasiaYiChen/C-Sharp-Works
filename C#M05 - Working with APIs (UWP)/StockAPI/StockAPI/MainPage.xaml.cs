using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using System.Data;




// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StockAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();           
        }

        private void Click_Btn_Click(object sender, RoutedEventArgs e)
        {
            var tuShareUtility = new TuShareUtility(new HttpClientUtility());
            Dictionary<string, string> p = new Dictionary<string, string>();
            /* p["trade_date"] = "20210226";
             var table = tuShareUtility.GetData("daily", p, "");
             p["start_date"] = "20210226";
             var table2 = tuShareUtility.GetData("daily", p, "");*/
            p["end_date"] = "20210226";
            var table = tuShareUtility.GetData("new_share", p, "");

            p["start_date"] = "20210226";
            var table2 = tuShareUtility.GetData("new_share", p, "");

            dataGrid.ItemsSource = table.DefaultView;
            dataGrid1.ItemsSource = table2.DefaultView;

            FillDataGrid(table, dataGrid);
            FillDataGrid(table2, dataGrid1);
        }

        public static void FillDataGrid(DataTable table, DataGrid grid)
        {
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                grid.Columns.Add(new DataGridTextColumn()
                {
                    Header = table.Columns[i].ColumnName,
                    Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                });
            }

            var collection = new ObservableCollection<object>();
            foreach (DataRow row in table.Rows)
            {
                collection.Add(row.ItemArray);
            }

            grid.ItemsSource = collection;
        }


    }
}
