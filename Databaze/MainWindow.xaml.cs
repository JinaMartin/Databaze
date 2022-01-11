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

namespace Databaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel VM = ViewModel.Instance;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void save_butt_Click(object sender, RoutedEventArgs e)
        {
            VM.CreatePerson(name_txt.Text, surname_txt.Text, Convert.ToDateTime(birth_txt.Text), id_txt.Text);
        }
    }

    public class Person : IValidInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string Id { get; set; }
        public string ToString()
        {
            return string.Format($"{Name} {Surname} - {Birth} - {Id}");
        }
    }

    public class ViewModel
    {
        private static ViewModel instance = new ViewModel();
        static ViewModel() { }
        public static ViewModel Instance { get { return instance; } }

        private IList<Person> People
        {
            get { return GetPeople; }
            set { GetPeople = value; }
        }
        public IList<Person> GetPeople = new List<Person>();

        public void CreatePerson(string n, string s, DateTime b, string i)
        {
            Person p = new Person { Name = n, Surname = s, Birth = b, Id = i };
            People.Add(p);
        }
    }

    public interface IValidInfo
    {
        string Name { get; set; }
        string Surname { get; set; }
        DateTime Birth { get; set; }
        string Id { get; set; }
    }
}