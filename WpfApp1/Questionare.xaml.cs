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
        //Classes needed for the application start
        QuestionAnswer answerList;
        XmlDocument doc = new XmlDocument();
        //Classes needed for the application end

        //variables for the application start
        int questionNumber = 1;
        int oldQuestionNumber;
        string oldCategory;
        string singleAnswer;
        //variables for the application end

        //Declaring  Obsevable collection to store selected questions and answers start
        public static ObservableCollection<QuestionAnswer> _askedQuestionAnswer = new ObservableCollection<QuestionAnswer>();
        ObservableCollection<QuestionAnswer> lstAnswer = new ObservableCollection<QuestionAnswer>();
        ObservableCollection<string> selectedAnswers = new ObservableCollection<string>();
        //Declaring  Obsevable collection to store selected questions and answers end


        public Questionare()
        {
            InitializeComponent();

            // Loading Previously Stored Question and Answer Start
            if (MainWindow.language == "en")
            {
                Questionare._askedQuestionAnswer = MyStorage.ReadXML<ObservableCollection<QuestionAnswer>>("QandA.xml");
            }
            if (MainWindow.language == "de")
            {
                Questionare._askedQuestionAnswer = MyStorage.ReadXML<ObservableCollection<QuestionAnswer>>("QandA.de.xml");
            }
            // Loading Previously Stored Question and Answer End

            // Loading Question Start
            if (MainWindow.language == "en")
            {
                doc.Load("Questions.xml");
            }
            if (MainWindow.language == "de")
            {
                doc.Load("Questions.de.xml");
            }
            // Loading Question End

            //Text for start or Continue start
            if (_askedQuestionAnswer.Count != 0)
            {
                if (MainWindow.language == "en")
                {
                    Txt_PressStart.Margin = new System.Windows.Thickness(-45, 0, 0, 0);
                    Txt_PressStart.Text = "Press Continue To Resume Your Sessions ";
                }
                else if (MainWindow.language == "de")
                {
                    Txt_PressStart.Margin = new System.Windows.Thickness(-5, 0, 0, 0);
                    Txt_PressStart.Text = "Weiter drücken, um fortzufahren";
                }
                Btn_Continue.Visibility = Visibility.Visible;
            }
            else
            {
                if (MainWindow.language == "en")
                {
                    Txt_PressStart.Margin = new System.Windows.Thickness(15, 5, 0, 0);
                    Txt_PressStart.Text = "Press New To Find Your Career";
                }
                else if (MainWindow.language == "de")
                {
                    Txt_PressStart.Text = "Presse Neu, um Ihre Karriere zu finden";

                }
            }
            //Text for start or Continue end
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Visibility = Visibility.Visible;

            //Clearing saved session if all answered start
            if (questionNumber >= 8)
            {
                _askedQuestionAnswer.Clear();
            }
            //Clearing saved session if all answered end

            // Storing Answered Question and Answer Start
            if (MainWindow.language == "en")
            {
                MyStorage.WriteXml<ObservableCollection<QuestionAnswer>>(Questionare._askedQuestionAnswer, "QandA.xml");
            }
            if (MainWindow.language == "de")
            {
                MyStorage.WriteXml<ObservableCollection<QuestionAnswer>>(Questionare._askedQuestionAnswer, "QandA.de.xml");
            }
            // Storing Answered Question and Answer End

            //Clearing the Results List Start
            App.Colleges.Clear();
            App.Jobs.Clear();
            App.Details.Clear();
            //Clearing the Results List End
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            //Deleting the previous question and answers if there and starting the appplication Start
            _askedQuestionAnswer.Clear();
            startApplication(questionNumber, "general");
            //Deleting the previous question and answers if there and starting the application Start
        }

        private void Btn_Continue_Click(object sender, RoutedEventArgs e)
        {
            //Handling the continue click if previously on question 3 or not start
            if (_askedQuestionAnswer[_askedQuestionAnswer.Count - 1].QuestionNumber == 3)
            {
                questionNumber = _askedQuestionAnswer[_askedQuestionAnswer.Count - 1].QuestionNumber - 1;
                foreach (QuestionAnswer item in _askedQuestionAnswer.Take(questionNumber - 1))
                {
                    selectedAnswers.Add(item.SubmittedAnswers);
                }
            }
            else
            {
                questionNumber = _askedQuestionAnswer[_askedQuestionAnswer.Count - 1].QuestionNumber + 1;
                foreach (QuestionAnswer item in _askedQuestionAnswer)
                {
                    selectedAnswers.Add(item.SubmittedAnswers);
                }

            }
            //Handling the continue click if previously on question 3 or not end

            //Adding the previously stored global answer to local answer list start
            selectedAnswers.Distinct().ToList<string>();
            startApplication(questionNumber, _askedQuestionAnswer[_askedQuestionAnswer.Count - 1].Category);
            //Adding the previously stored global answer to local answer list end

            Btn_Continue.Visibility = Visibility.Hidden;
        }

        private void startApplication(int questionNumber, string questionType)
        {
            //Show current question start
            Txt_Question_Number.Text = questionNumber + "/8";
            //Show current question end

            //Initializing answerList to store question,answer,category&questionNumber start
            answerList = new QuestionAnswer();
            //Initializing answerList to store question,answer,category&questionNumber end

            //Handling the visibility of the elemenss after the application starts start
            Txt_PressStart.Visibility = Visibility.Hidden;
            Btn_Start.Visibility = Visibility.Hidden;
            Lst_AnswerList.Visibility = Visibility.Visible;
            Txt_Question.Visibility = Visibility.Visible;
            Txt_Question_Border.Visibility = Visibility.Visible;
            Stack_Summary.Visibility = Visibility.Visible;
            Btn_Next_Question.Visibility = Visibility.Visible;
            Btn_Next_Question.IsEnabled = false;
            Txt_Question_Number.Visibility = Visibility.Visible;
            Txt_Question_Number_Border.Visibility = Visibility.Visible;
            //Initializing answerList to store question,answer,category&questionNumber end



            //Handling submit and next button content start
            if (questionNumber == 8)
            {
                if (MainWindow.language == "en")
                {
                    Btn_Next_Question.Content = "SUBMIT";
                }
                else if (MainWindow.language == "de")
                {
                    Btn_Next_Question.Content = "ABGEBEN";
                }
            }
            else
            {
                Btn_Next_Question.Content = ">>";
            }
            //Handling submit and next button content end

            //Handling button tooltip start
            Btn_Next_Question.DataContext = new Classes.ToolTip() { toolTipText = "Select An Answer To See The Next Question" };
            //Handling button content end

            //Handling the Previous button visibility start
            if (questionNumber == 1)
            {
                Btn_Prev_Question.Visibility = Visibility.Hidden;
            }
            else
            {
                Btn_Prev_Question.Visibility = Visibility.Visible;
            }
            //Handling the Previous button visibility end

            //Loading Question and answer logic start
            foreach (XmlNode node in doc.DocumentElement)
            {
                string att1 = node.Attributes[0].InnerText;
                string att2 = node.Attributes[1].InnerText;
                string att3 = node.Attributes[2].InnerText;
                if (att1 == "Question" && att2 == questionNumber.ToString() && att3 == questionType)
                {
                    // Loading a selected data from xml file child node start
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string name = child.Attributes[0].InnerText;

                        if (name == "Q" + questionNumber)
                        {
                            Txt_Question.Text = questionNumber + ". " + child.InnerText;

                            answerList.QuestionNumber = questionNumber;
                            answerList.AskedQuestion = child.InnerText;
                            answerList.Category = questionType;
                            Lst_AskedQuestion.ItemsSource = _askedQuestionAnswer;

                        }
                        if (name == "A" + questionNumber)
                        {
                            lstAnswer.Add(new QuestionAnswer() { Answer = child.InnerText });
                        }
                        lstAnswer.Distinct().ToList<QuestionAnswer>();
                        Lst_AnswerList.ItemsSource = lstAnswer;
                    }
                    // Loading a selected data from xml file child node end

                }
            }
            //Loading Question and answer logic end


        }

        private void Lst_AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = (sender as ListBox).SelectedItem as QuestionAnswer;

            //Handling hints and next question button start
            if (selection != null && questionNumber == 3)
            {
                //Showing hints for the selected course
                switch (selection.Answer.ToString())
                {
                    case "Bachelor's In Computer Science":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.BCS;
                        break;
                    case "Master's In Computer Science":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MCS;
                        break;

                    case "Bachelor's In Information Techcnology":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.BIT;
                        break;
                    case "Master's In Information Technology":
                        Txt_Block_Hint.Visibility = Visibility.Visible;
                        Txt_Block_Hint.Text = Hints.MIT;
                        break;
                    case "Bachelor's In Electronics and Telecomm":
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
                //Showing hints for the selected course

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
            //Handling hints and next question button start
        }

        private void Btn_Next_Question_Click(object sender, RoutedEventArgs e)
        {
            //adding the single answer to the class instance start
            answerList.SubmittedAnswers = singleAnswer;
            //adding the single answer to the class instance end

            //add the fully assembled answerlist to observable collection and removing the duplicate item start
            _askedQuestionAnswer.Add(answerList);
            _askedQuestionAnswer.Distinct().ToList<QuestionAnswer>();
            //add the fully assembled answerlist to observable collection and removing the duplicate item end


            //storing the old question nuumber and old category
            oldQuestionNumber = _askedQuestionAnswer[_askedQuestionAnswer.Count - 1].QuestionNumber;
            oldCategory = _askedQuestionAnswer[_askedQuestionAnswer.Count - 1].Category;
            //storing the old question nuumber and old category

            selectedAnswers.Add(singleAnswer);
            Txt_Block_Hint.Visibility = Visibility.Hidden;


            //Handling which category of question to ask after 3rd question start
            if (selectedAnswers.Count == questionNumber && questionNumber != 8)
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
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Bachelor's In Computer Science") && selectedAnswers[0] == "Bachelor's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Bachelor's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "BCS");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Bachelor's In Information Techcnology") && selectedAnswers[0] == "Bachelor's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Bachelor's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "BIT");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Bachelor's In Electronics and Telecomm") && selectedAnswers[0] == "Bachelor's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Bachelor's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "BETC");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In Big Data and Business Analytics") && selectedAnswers[0] == "Master's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Master's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "MBDBA");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In Information Technology") && selectedAnswers[0] == "Master's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Master's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "MIT");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In International Business And Eng") && selectedAnswers[0] == "Master's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Master's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "MIBE");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In Computer Engineering") && selectedAnswers[0] == "Master's" && questionNumber == 4)
                {
                    var res = MessageBox.Show("Do You Again Want To Study A Master's Degree?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.Yes)
                    {
                        lstAnswer.Clear();
                        startApplication(questionNumber, "MCE");
                    }
                    else
                    {
                        _askedQuestionAnswer.RemoveAt(2);
                        selectedAnswers.RemoveAt(questionNumber - 2);
                        return;
                    }
                }
                else if (selectedAnswers.Contains("Master's In Computer Engineering"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "MCE");
                }
                else if (selectedAnswers.Contains("Master's In International Business And Eng"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "MIBE");
                }
                else if (selectedAnswers.Contains("Master's In Information Technology"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "MIT");
                }
                else if (selectedAnswers.Contains("Master's In Big Data and Business Analytics"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "MBDBA");
                }
                else if (selectedAnswers.Contains("Bachelor's In Information Techcnology"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "BIT");
                }
                else if (selectedAnswers.Contains("Bachelor's In Electronics and Telecomm"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "BETC");
                }
                else if (selectedAnswers.Contains("Bachelor's In Computer Science"))
                {
                    lstAnswer.Clear();
                    startApplication(questionNumber, "BCS");
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
            //Handling which category of question to ask after 3rd question start

            //Showing the results after answering all the questions start
            else if (selectedAnswers.Count == questionNumber && questionNumber == 8)
            {
                //Handling the visibility of results start
                Lst_AnswerList.Visibility = Visibility.Collapsed;
                Txt_Question.Visibility = Visibility.Collapsed;
                Txt_Question_Border.Visibility = Visibility.Collapsed;
                Btn_Next_Question.Visibility = Visibility.Collapsed;
                Btn_Prev_Question.Visibility = Visibility.Collapsed;
                Btn_Next_Question.IsEnabled = false;
                Stack_QandA.Visibility = Visibility.Collapsed;
                Tab_Results.Visibility = Visibility.Visible;
                Btn_StartAgain.Visibility = Visibility.Visible;
                Txt_Question_Number.Visibility = Visibility.Hidden;
                Txt_Question_Number_Border.Visibility = Visibility.Hidden;
                //Handling the visibility of results end

                //Loading the results based on the language start
                if (MainWindow.language == "en")
                {
                    Lst_Result_College.ItemsSource = App.CollegeList(oldCategory, "Results.xml");
                }
                else if (MainWindow.language == "de")
                {
                    Lst_Result_College.ItemsSource = App.CollegeList(oldCategory, "Results.de.xml");
                }
                //Loading the results based on the language start

                //Loading details and jobs list start
                Lst_Result_Job.ItemsSource = App.JobList();
                Lst_Result_Details.ItemsSource = App.DetailsList();
                //Loading details and jobs list end

            }
            //Showing the results after answering all the questions start

        }

        private void Btn_Prev_Question_Click(object sender, RoutedEventArgs e)
        {
            //clearing the answer list and reducing the question number start
            Txt_Block_Hint.Visibility = Visibility.Hidden;
            lstAnswer.Clear();
            questionNumber -= 1;
            //clearing the answer list and reducing the question number end

            if (questionNumber > 0)
            {
                if (_askedQuestionAnswer.Count > 0)
                {
                    _askedQuestionAnswer.RemoveAt(_askedQuestionAnswer.Count - 1);
                }
                selectedAnswers.RemoveAt(selectedAnswers.Count - 1);
            }


            //Handling which category of question to show next start
            if (selectedAnswers.Contains("Master's In Computer Science") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MCS");
            }
            if (selectedAnswers.Contains("Bachelor's In Computer Science") && questionNumber >= 5)
            {
                startApplication(questionNumber, "BCS");
            }
            if (selectedAnswers.Contains("Master's In Information Technology") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MIT");
            }
            if (selectedAnswers.Contains("Bachelor's In Information Techcnology") && questionNumber >= 5)
            {
                startApplication(questionNumber, "BIT");
            }
            if (selectedAnswers.Contains("Bachelor's In Electronics and Telecomm") && questionNumber >= 5)
            {
                startApplication(questionNumber, "BETC");
            }
            if (selectedAnswers.Contains("Master's In Big Data and Business Analytics") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MBDBA");
            }
            if (selectedAnswers.Contains("Master's In International Business And Eng") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MIBE");
            }
            if (selectedAnswers.Contains("Master's In Computer Engineering") && questionNumber >= 5)
            {
                startApplication(questionNumber, "MCE");
            }
            if (questionNumber <= 4)
            {
                startApplication(questionNumber, "general");
            }
            //Handlingwhich category of question to show next end

        }

        private void Btn_StartAgain_Click(object sender, RoutedEventArgs e)
        {
            //clearing all the previous storage start
            App.Colleges.Clear();
            App.Jobs.Clear();
            App.Details.Clear();
            lstAnswer.Clear();
            selectedAnswers.Clear();
            _askedQuestionAnswer.Clear();
            //clearing all the previous storage end


            Lst_AnswerList.Visibility = Visibility.Visible;
            Txt_Question.Visibility = Visibility.Visible;
            Txt_Question_Border.Visibility = Visibility.Visible;
            Stack_Summary.Visibility = Visibility.Visible;
            Btn_Next_Question.Visibility = Visibility.Visible;
            Stack_QandA.Visibility = Visibility.Visible;
            Btn_StartAgain.Visibility = Visibility.Collapsed;
            Tab_Results.Visibility = Visibility.Collapsed;

            //starting the application again start
            questionNumber = 1;
            startApplication(questionNumber, "general");
            //starting the application again end

        }
    }
}
