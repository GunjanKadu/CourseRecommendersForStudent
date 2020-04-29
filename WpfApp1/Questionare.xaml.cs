using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Questionare.xaml
    /// </summary>
    public partial class Questionare : Window
    {
        int questionNumber = 1;
        string singleAnswer;

        ObservableCollection<AnswerList> lstAnswer = new ObservableCollection<AnswerList>();
        ObservableCollection<string> selectedAnswers = new ObservableCollection<string>();

        ObservableCollection<AnswerList> askedQuestion = new ObservableCollection<AnswerList>();

        XmlDocument doc = new XmlDocument();
        public Questionare()
        {
            InitializeComponent();
            doc.Load("questions.xml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            startApplication(questionNumber, "general");
        }

        private void startApplication(int questionNumber, string questionType)
        {
            Txt_PressStart.Visibility = Visibility.Hidden;
            Btn_Start.Visibility = Visibility.Hidden;

            Lst_AnswerList.Visibility = Visibility.Visible;
            Txt_Question.Visibility = Visibility.Visible;
            Txt_Question_Border.Visibility = Visibility.Visible;
            Stack_Summary.Visibility = Visibility.Visible;
            Btn_Next_Question.Visibility = Visibility.Visible;
            Btn_Next_Question.IsEnabled = false;

            Btn_Next_Question.DataContext = new Classes.ToolTip() { toolTipText = "Select An Answer To See The Next Question" };

            if (questionNumber > 1)
            {
                Btn_Prev_Question.Visibility = Visibility.Visible;
            }

            foreach (XmlNode node in doc.DocumentElement)
            {
                string att1 = node.Attributes[0].InnerText;
                string att2 = node.Attributes[1].InnerText;
                string att3 = node.Attributes[2].InnerText;
                if (att1 == "Question" && att2 == questionNumber.ToString() && att3 == questionType)
                {
                    // Loading a selected data from xml file
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string name = child.Attributes[0].InnerText;

                        if (name == "Q" + questionNumber)
                        {
                            Txt_Question.Text = questionNumber + ". " + child.InnerText;

                            // Filling The Answered Questions

                            askedQuestion.Add(new AnswerList() { AskedQuestion = child.InnerText, Category=questionType,QuestionNumber=questionNumber });

                            Lst_AskedQuestion.ItemsSource = askedQuestion;

                        }
                        if (name == "A" + questionNumber)
                        {
                            lstAnswer.Add(new AnswerList() { Answer = child.InnerText });
                        }
                        Lst_AnswerList.ItemsSource = lstAnswer;
                    }
                }
            }
        }

        private void Lst_AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (sender as ListBox).SelectedItem as AnswerList;

            if(selection!=null && questionNumber == 3)
            {
                switch (selection.Answer.ToString())
                {
                    case "Bachelor's In Computer Science":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.BCS;
                        break;
                    case "Master's In Computer Science":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text =Hints.MCS;
                        break;

                    case "Bachelor's In Information Techcnology":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.BIT;
                        break;
                    case "Master's In Information Technology":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MIT;
                        break;
                    case "Bachelor's In Electronics & Telecomm":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.BETC;
                        break;
                    case "Master's In Big Data & Business Analytics":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MBDBA;
                        break;
                    case "Master's In International Business And Eng":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MIBE;
                        break;
                    case "Master's In Computer Engineering":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MCE;
                        break;
                    default:
                        break;
                }
                singleAnswer = selection.Answer.ToString();
                Btn_Next_Question.IsEnabled = true;
                Btn_Next_Question.DataContext = new Classes.ToolTip() { toolTipText = "Click To See The Next Question" };
            }
            else if (selection != null)
            {
                singleAnswer = selection.Answer.ToString();

                Btn_Next_Question.IsEnabled = true;
                Btn_Next_Question.DataContext = new Classes.ToolTip() { toolTipText = "Click To See The Next Question" };
            }
        }

        private void Btn_Next_Question_Click(object sender, RoutedEventArgs e)
        {
            selectedAnswers.Add(singleAnswer);

            Txt_Block_Hint.Visibility = Visibility.Hidden;
            askedQuestion.Add( new AnswerList() { SubmittedAnswers = "• " + selectedAnswers.Last<string>() });
            if (selectedAnswers.Count == questionNumber)
            {
                questionNumber += 1;
                if (selectedAnswers.Contains("Master's In Computer Science") && selectedAnswers[0] == "Master's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Master's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "MCS");
                    }
                    else
                    {
                        askedQuestion.RemoveAt(5);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In Computer Science"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "MCS");
                }
                else
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "general");
                }
            }
        }

        private void Btn_Prev_Question_Click(object sender, RoutedEventArgs e)
        {
            lstAnswer.Clear();
            questionNumber -= 1;
            if (selectedAnswers.Contains("Master's In Computer Science") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MCS");
            }
            if (questionNumber <= 4)
            {
                startApplication(questionNumber, "general");
            }

        }
    }
}

public class AnswerList
{
    public string Answer { get; set; }
    public string AskedQuestion { get; set; }

    public string SubmittedAnswers { get; set; }

    public string Category { get; set; }

    public int QuestionNumber { get; set; }

}