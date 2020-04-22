using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Course> _courses;
        //private void Application_Exit(object sender, ExitEventArgs e)
        //{
        //    MyStorage.WriteXml<ObservableCollection<Course>>(_courses, "courses.xml");
        //}

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _courses = MyStorage.ReadXML<ObservableCollection<Course>>("courses.xml");
            if (_courses == null)
            {
                _courses = new ObservableCollection<Course>();
            }
        }
    }
}
