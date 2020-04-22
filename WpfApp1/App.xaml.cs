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
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Course>>(_courses, "courses.xml");
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _courses = MyStorage.ReadXML<ObservableCollection<Course>>("courses.xml");
            if (_courses == null)
            {
                //var lst = new ObservableCollection<Course>();
                //lst.Add(new Course() { Title = "Bachelor's In Computer Science", content_1 = "Objected Oriented Programming C++", contentDescription_1 = "Object-oriented programming – As the name suggests uses objects in programming. Object-oriented programming aims to implement real-world entities like inheritance, hiding, polymorphism, etc in programming. The main aim of OOP is to bind together the data and the functions that operate on them so that no other part of the code can access this data except that function.", content_2 = "Objected Oriented Programming Java", content_3 = "Data Structures And Algorithm", content_4 = "Database Mananagement Systems", content_5 = "Computer Networks", content_6 = "Web Technologies" });
                //lst.Add(new Course() { Title = "Bachelor's In Information Techcnology", content_1 = "Objected Oriented Programming", content_2 = "Computer Architecture", content_3 = "Digital Signal Processing", content_4 = "Image Processing", content_5 = "Web Technologies" });
                //lst.Add(new Course() { Title = "Bachelor's In Electronics & Telecommunication", content_1 = "Electronic Devices And Circuits", content_2 = "Microprocessors and MicroControllers", content_3 = "Signals & Systems", content_4 = "Digital Communication", content_5 = "VHDL" });
                //lst.Add(new Course() { Title = "Master's In Computer Science", content_1 = "IT-Security", content_2 = "International Project Management", content_3 = "Software Architecture & Development", content_4 = "Advanced Database", content_5 = "Business Computing", content_6 = "UI & UX" });
                //lst.Add(new Course() { Title = "Master's In Big Data & Business Analytics", content_1 = "Data Engineering", content_2 = "Data Management", content_3 = "Privacy,Ethics & Management", content_4 = "International Law", content_5 = "Data Story Telling" });
                //lst.Add(new Course() { Title = "Master's In Big Information Technology", content_1 = "Information & Coding Theory", content_2 = "Real Time Programming", content_3 = "Embedded Systems", content_4 = "Embedded Security", content_5 = "Robotics", content_6 = "Image Processing" });
                //lst.Add(new Course() { Title = "Master's In International Business And Engineering", content_1 = "Business Law", content_2 = "Market Analysis ", content_3 = "Marketing & Saled", content_4 = "Human Resources", content_5 = "Business Startup" });
                //lst.Add(new Course() { Title = "Master's In Computer Engineering", content_1 = "Computer Architecture", content_2 = "VLSI Design", content_3 = "Advanced Data Structure", content_4 = "Networks & Systems", content_5 = "Embedded Systems" });

                //_courses = lst;
                _courses = new ObservableCollection<Course>();
            }
        }
    }
}
