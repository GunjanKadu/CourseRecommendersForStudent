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
        int firstQuestionNumber = 1;
        ObservableCollection<AnswerList> lstAnswer = new ObservableCollection<AnswerList>();
        ObservableCollection<AnswerList> selectedAnswers = new ObservableCollection<AnswerList>();

        public Questionare()
        {
            InitializeComponent();      
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Are You Sure You Want To Start?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                startApplication(firstQuestionNumber);
            }

        }

        private void startApplication(int questionNumber)
        {
                Txt_PressStart.Visibility = Visibility.Hidden;
                Btn_Start.Visibility = Visibility.Hidden;
                Lst_AnswerList.Visibility = Visibility.Visible;
                Txt_Question.Visibility = Visibility.Visible;

                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("questions.xml");

                    foreach (XmlNode node in doc.DocumentElement)
                    {
                    string att1 = node.Attributes[0].InnerText;
                    string att2 = node.Attributes[1].InnerText;
                    if (att1 == "Question" && att2 == questionNumber.ToString())
                    {
                        // Loading a selected data from xml file
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            string name = child.Attributes[0].InnerText;

                            if (name == "Q" + questionNumber)
                            {
                                Txt_Question.Text = child.InnerText;
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
            
        }

        private void Lst_AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (sender as ListBox).SelectedItem as AnswerList;
            var res = MessageBox.Show("Your Selection Was:"+ selection + "Do You Want To Proceed?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                if (selection != null)
                {
                    lstAnswer.Clear();
                    int nextQuestionNumber = firstQuestionNumber + 1;
                    selectedAnswers.Add(new AnswerList() { SelectedAnswer = selection.Answer });
                    startApplication(nextQuestionNumber);
                }
            }

        }


    }
}

public class AnswerList
{
    public string Answer { get; set; }
    public string SelectedAnswer { get; set; }
}