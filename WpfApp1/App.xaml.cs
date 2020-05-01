using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Course> _courses;

        public static List<string> Colleges = new List<string>();
        public static List<string> Jobs = new List<string>();

        public static ObservableCollection<Question> _questions;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _courses = MyStorage.ReadXML<ObservableCollection<Course>>("courses.xml");
            Questionare._askedQuestionAnswer = MyStorage.ReadXML<ObservableCollection<QuestionAnswer>>("QandA.xml");
            //_questions = MyStorage.ReadXML<ObservableCollection<Question>>("questions.xml");
            if (_courses == null)
            {
                _courses = new ObservableCollection<Course>();
            }
            if (Questionare._askedQuestionAnswer == null)
            {
                Questionare._askedQuestionAnswer = new ObservableCollection<QuestionAnswer>();
            }
        }

        public static void Load_Results(string category)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Results.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                string att1 = node.Attributes[0].InnerText;
                if (att1 == category)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string innerAtt = child.Attributes[0].InnerText;
                        if ((innerAtt == "college"))
                        {
                            Colleges.Add(child.InnerText);
                        }
                        else if (innerAtt == "job")
                        {
                            Jobs.Add(child.InnerText);
                        }
                    }
                }
            }
        }

        public static List<string> CollegeList(string category)
        {
            Load_Results(category);
            return Colleges;
        }

        public static List<string> JobList()
        {
            return Jobs;
        }
    }
}
