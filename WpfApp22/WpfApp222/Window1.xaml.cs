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
using System.Runtime.InteropServices;

namespace WpfApp222
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string g;
        private SqlConnection SqlConnection = null;
        public Window1()
        {
            InitializeComponent();
            this.TextBox1.PreviewTextInput += new TextCompositionEventHandler(Letter_PreviewTextInput);
            this.TextBox2.PreviewTextInput += new TextCompositionEventHandler(Letter_PreviewTextInput);
            this.TextBox3.PreviewTextInput += new TextCompositionEventHandler(Letter_PreviewTextInput);
            this.TextBox5.PreviewTextInput += new TextCompositionEventHandler(Letter_PreviewTextInput);
            this.TextBox9.PreviewTextInput += new TextCompositionEventHandler(Letter_PreviewTextInput);
            //this.TextBox6.PreviewTextInput += new TextCompositionEventHandler(TextBox3_PreviewTextInput);
            this.TextBox7.PreviewTextInput += new TextCompositionEventHandler(Digit_PreviewTextInput);
        }

        void Letter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }
        void Digit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["KafedraDB"].ConnectionString);

            SqlConnection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButton1.IsChecked == true)
            {
                g = "Да";
            }
            else g = "Нет";
            SqlCommand command = new SqlCommand($"Insert Into [Prepodat] (Фамилия, Имя, Отчество, Ученая_степень, Заработная_плата, Нагрузка, Предмет_преподавания, Совместительство, Должность) values (N'{TextBox1.Text}', N'{TextBox2.Text}', N'{TextBox3.Text}', N'{TextBox5.Text}', N'{TextBox6.Text}', N'{TextBox7.Text}', N'{TextBox9.Text}', N'"+g+"', N'"+ComboBox1.SelectedValue+"')", SqlConnection);
            

            if ((string.IsNullOrWhiteSpace(TextBox1.Text)) || (string.IsNullOrWhiteSpace(TextBox2.Text)) || (string.IsNullOrWhiteSpace(TextBox3.Text)) || (string.IsNullOrWhiteSpace(TextBox5.Text)) || (string.IsNullOrWhiteSpace(TextBox6.Text)) || (string.IsNullOrWhiteSpace(TextBox7.Text)) || (string.IsNullOrWhiteSpace(TextBox9.Text)))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Запись добавлена в базу", "Уведомление", MessageBoxButton.OK);
                Close();
            }
            command.ExecuteNonQuery();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
