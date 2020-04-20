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
            courseItem.Add(new Course() { Title = "Bachelor's In Computer Science",content_1="Objected Oriented Programming C++",content_2= "Objected Oriented Programming Java", content_3="Data Structures And Algorithm",content_4="Database Mananagement Systems",content_5="Computer Networks",content_6="Web Technologies" });
            courseItem.Add(new Course() { Title = "Bachelor's In Information Techcnology", content_1 = "Objected Oriented Programming", content_2 = "Computer Architecture", content_3 = "Digital Signal Processing", content_4 = "Image Processing", content_5 = "Web Technologies" });
            courseItem.Add(new Course() { Title = "Bachelor's In Electronics & Telecommunication", content_1 = "Electronic Devices And Circuits", content_2 = "Microprocessors and MicroControllers", content_3="Signals & Systems" ,content_4="Digital Communication",content_5="VHDL"});
            courseItem.Add(new Course() { Title = "Master's In Computer Science", content_1 = "IT-Security", content_2 = "International Project Management", content_3 = "Software Architecture & Development",content_4="Advanced Database",content_5="Business Computing",content_6="UI & UX" });
            courseItem.Add(new Course() { Title = "Master's In Big Data & Business Analytics", content_1 = "Data Engineering", content_2 = "Data Management", content_3 = "Privacy,Ethics & Management", content_4="International Law",content_5="Data Story Telling" });
            courseItem.Add(new Course() { Title = "Master's In Big Information Technology", content_1 = "Information & Coding Theory", content_2 = "Real Time Programming", content_3 = "Embedded Systems",content_4="Embedded Security",content_5="Robotics",content_6="Image Processing" });
            courseItem.Add(new Course() { Title = "Master's In International Business And Engineering", content_1 = "Business Law", content_2 = "Market Analysis ", content_3 = "Marketing & Saled",content_4="Human Resources",content_5="Business Startup" });
            courseItem.Add(new Course() { Title = "Master's In Computer Engineering", content_1 = "Computer Architecture", content_2="VLSI Design", content_3 = "Advanced Data Structure",content_4="Networks & Systems",content_5="Embedded Systems" });

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
