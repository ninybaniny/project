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
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp222
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private SqlConnection SqlConnection = null;
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KafedraDB"].ConnectionString);
            SqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Фамилия, Имя, Отчество, Должность, Нагрузка, Совместительство, Предмет_преподавания FROM Prepodat", SqlConnection);
            SqlCommand select = new SqlCommand("SELECT Фамилия, Имя, Отчество, Должность, Нагрузка, Совместительство, Предмет_преподавания FROM Prepodat", SqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            datagrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dataSet.Tables[0] });
            select.ExecuteReader();
        }
    }
}
