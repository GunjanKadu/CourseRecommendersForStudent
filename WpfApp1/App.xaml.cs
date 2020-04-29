using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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

       
    }
}
