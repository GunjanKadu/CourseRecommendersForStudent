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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Window
    {
            List<Course> courseItem = new List<Course>();
        public Courses()
        {
            InitializeComponent();
            courseItem.Add(new Course() { Title = "Bachelor's In Computer Science",content_1="C",content_2="C++",content_3="Java" });
            courseItem.Add(new Course() { Title = "Bachelor's In Information Technology", content_1 = "Coding Theory", content_2 = "Game Theory", content_3 = "Graph Theory" });
            courseItem.Add(new Course() { Title = "Bachelor's In Electronics & Telecommunication", content_1 = "Hacking Tools", content_2 = "Infrastructure Security", content_3 = "Cloud Security" });
            courseItem.Add(new Course() { Title = "Master's In Computer Science", content_1 = "Enterprise Social Media", content_2 = "Marketing Analytics", content_3 = "CRM" });
            courseItem.Add(new Course() { Title = "Master's In Big Data & Business Analytics", content_1 = "VLSI", content_2 = "Embedded Systems", content_3 = "Assembly Language Progarmming" });
            courseItem.Add(new Course() { Title = "Master's In Big Information Technology", content_1 = "Data Storage Tools", content_2 = "Data Transforming Tools", content_3 = "Developement Tools" });
            courseItem.Add(new Course() { Title = "Master's In International Business And Engineering", content_1 = "Graphs", content_2 = "Data Analysis Platform", content_3 = "Data WareHousing" });
            courseItem.Add(new Course() { Title = "Master's In Computer Engineering", content_2 = "Computer Communication Networks", content_3 = "Electronics Devices & Circuits" });

            List_Courses.ItemsSource = courseItem;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;

        }

        private void Course_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in courseItem where s.Title.ToLower().Contains(filter) select s;
            List_Courses.ItemsSource = lst;
        }
    }
}
