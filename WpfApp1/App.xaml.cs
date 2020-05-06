using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
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
        public static ObservableCollection<Question> _questions;

        //Declaring List for Colleges,Jobs and Details start
        public static List<string> Colleges = new List<string>();
        public static List<string> Jobs = new List<string>();
        public static List<string> Details = new List<string>();
        //Declaring List for Colleges,Jobs and Details end


        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //loading the courses from the file start
            _courses = MyStorage.ReadXML<ObservableCollection<Course>>("Courses.xml");
            
            //Questionare._askedQuestionAnswer = MyStorage.ReadXML<ObservableCollection<QuestionAnswer>>("QandA.xml");

            if (_courses == null)
            {
                _courses = new ObservableCollection<Course>();
            }
            if (Questionare._askedQuestionAnswer == null)
            {
                Questionare._askedQuestionAnswer = new ObservableCollection<QuestionAnswer>();
            }
            //loading the courses from the file end

        }

        //Load results based on the language start
        public static void Load_Results(string category,string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
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
                        else if (innerAtt == "details")
                        {
                            Details.Add(child.InnerText);
                        }
                    }
                }
            }
        }
        //Load results based on the language end


        //Return the Results list Start
        public static List<string> CollegeList(string category,string file)
        {
            Load_Results(category,file);
            return Colleges;
        }
        public static List<string> JobList()
        {
            return Jobs;
        }
        public static List<string> DetailsList()
        {
            return Details;
        }
        //Return the Results list End
    }
}
