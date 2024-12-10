using System.Collections.ObjectModel;
using System.Data;
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
namespace Struct
{
    public struct Employee1
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public int Seniority { get; set; }
        public int Salary { get; set; }

        public Employee1(string fullName, string gender, string position, int seniority, int salary)
        {
            FullName = fullName;
            Gender = gender;
            Position = position;
            Seniority = seniority;
            Salary = salary;
        }
    }
}
