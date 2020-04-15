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
            courseItem.Add(new Course() { Title = "Programming" });
            courseItem.Add(new Course() { Title = "Mathematics" });
            courseItem.Add(new Course() { Title = "Security" });
            courseItem.Add(new Course() { Title = "Cloud Computing" });
            courseItem.Add(new Course() { Title = "Micro-Controllers & Micro-Processors" });
            courseItem.Add(new Course() { Title = "Data Science" });
            courseItem.Add(new Course() { Title = "Data Analytics" });
            courseItem.Add(new Course() { Title = "Signals & Systems" });

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
