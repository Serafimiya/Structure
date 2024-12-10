using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Net.NetworkInformation;
using System.Reflection;
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
using Struct;
using Structure;

namespace Structure 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу со списком сотрудников на 7 человек с полями:\r\nФИО, пол, должность, стаж работы, оклад.\r\nВывести результат на экран. Вывести средний оклад. ", "О программе:");
        }

        private void btnInfoProgrammist_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: \nЛосева Анастасия Игорревна\nГруппа ИСП-31", "О создателе:");
        }

        public ObservableCollection<Struct.Employee1> employees; //объявление публичной переменной

        private void btn_FillTable(object sender, RoutedEventArgs e)
        {
            employees = new ObservableCollection<Struct.Employee1>();
            //Колллекция которая уведомляет об измененниях своих элементов, это важно так как мы работаем с DataGrid
            //Enumerable.Repeat метод который представляет собой последовательность, которая содержит данное ей значение указанное количество раз
            dataGrid.ItemsSource = employees;

            Random rnd = new Random();

            string fullName = FullName.Text;
            string gender = Gender.Text;
            string position = outPosition.Text;

            if (int.TryParse(Seniority.Text, out int seniority) && int.TryParse(Salary.Text, out int salary))
            {
                employees.Add(new Employee1(fullName, gender, position, seniority, salary));
            }
            else MessageBox.Show("Ошибка! Введите данные сотрудника");
        }

        private void btn_DeleteLine(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(outPosition.Text, out int position) && position > 0 && position <= employees.Count)
            {
                employees.RemoveAt(position - 1);
            }
            else
            {
                MessageBox.Show("Номер строки не выбран или выбран неверно", "Ошибка");
            }
        }

        private void btn_Search(object sender, RoutedEventArgs e)
        {
            if (employees.Add != null)
            {
                if (employees.Count > 0) 
                {
                    double sum = employees.Sum(emp => emp.Salary);
                    double average = Math.Round(sum / employees.Count,2);
                    AverageSalary.Text = average.ToString();
                }
                else
                {
                    AverageSalary.Text = "";
                }
            }
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            FullName.Clear();
            Gender.Clear();
            Position.Clear();
            Seniority.Clear();
            Salary.Clear();
            AverageSalary.Clear();
            outPosition.Clear();
        }
    }
}

