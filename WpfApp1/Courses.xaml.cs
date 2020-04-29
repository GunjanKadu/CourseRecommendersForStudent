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
using System.Xml;

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
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Course_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = (sender as TextBox).Text.ToLower();
            var lst = from s in App._courses where s.Title.ToLower().Contains(filter) select s;
            List_Courses.ItemsSource = lst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List_Courses.ItemsSource = App._courses;

        }

        private void List_Courses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Txt_CourseDesc.Text != "" && Course_Image.Source != null)
            {
                // Clean Previously selected course
                Txt_CourseDesc.Text = "";

                // Clean Previously Selected Image
                //string imagePath ="";
                //Uri uri = new Uri(imagePath, UriKind.Absolute);
                //ImageSource imgSource = new BitmapImage(uri);
                Course_Image.Source = null;

            }

            // Adding the selected Course Into Combo Box source 
            var lstCourseItems = new List<string>();
            var selection = (sender as ListBox).SelectedItem as Course;
            if (selection != null)
            {
                lstCourseItems.Add(selection.content_1);
                lstCourseItems.Add(selection.content_2);
                lstCourseItems.Add(selection.content_3);
                lstCourseItems.Add(selection.content_4);
                lstCourseItems.Add(selection.content_5);
            }

            Cmbx_CourseTopics.ItemsSource = lstCourseItems;

        }

        private void Cmbx_CourseTopics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cmbx_CourseTopics.SelectedItem != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Data_Course.xml");

                foreach (XmlNode node in doc.DocumentElement)
                {

                    // Loading a selected image from xml file

                    string name = node.Attributes[0].InnerText;
                    if (name == Cmbx_CourseTopics.SelectedItem.ToString() + "_img")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            string imagePath = child.InnerText;
                            Uri uri = new Uri(imagePath, UriKind.Absolute);
                            ImageSource imgSource = new BitmapImage(uri);
                            Course_Image.Source = imgSource;
                        }
                    }

                    // Loading a selected data from xml file
                    if (name == Cmbx_CourseTopics.SelectedItem.ToString())
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            Txt_CourseDesc.Text = child.InnerText;
                        }
                    }
                }
            }
        }
    }
}
