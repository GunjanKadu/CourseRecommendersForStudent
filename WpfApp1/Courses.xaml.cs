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
        public Courses()
        {
            InitializeComponent();
            List<Course> courseItem = new List<Course>();
            courseItem.Add(new Course() { Title = "Programming",content_1="C",content_2="C++",content_3="Java" });
            courseItem.Add(new Course() { Title = "Mathematics", content_1 = "Coding Theory", content_2 = "Game Theory", content_3 = "Graph Theory" });
            courseItem.Add(new Course() { Title = "Security", content_1 = "Hacking Tools", content_2 = "Infrastructure Security", content_3 = "Cloud Security" });
            courseItem.Add(new Course() { Title = "Cloud Computing", content_1 = "Enterprise Social Media", content_2 = "Marketing Analytics", content_3 = "CRM" });
            courseItem.Add(new Course() { Title = "Micro-Controllers & Micro-Processors", content_1 = "VLSI", content_2 = "Embedded Systems", content_3 = "Assembly Language Progarmming" });
            courseItem.Add(new Course() { Title = "Data Science", content_1 = "Data Storage Tools", content_2 = "Data Transforming Tools", content_3 = "Developement Tools" });
            courseItem.Add(new Course() { Title = "Data Analytics", content_1 = "Graphs", content_2 = "Data Analysis Platform", content_3 = "Data WareHousing" });
            courseItem.Add(new Course() { Title = "Signals & Systems", content_1 = "Digital Communication ", content_2 = "Computer Communication Networks", content_3 = "Electronics Devices & Circuits" });

            List_Courses.ItemsSource = courseItem;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;

        }

        private void List_Courses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
