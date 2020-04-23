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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Questionare.xaml
    /// </summary>
    public partial class Questionare : Window
    {
        Question question;
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
                Txt_PressStart.Visibility = Visibility.Hidden;
                Btn_Start.Visibility = Visibility.Hidden;
                Lst_AnswerList.Visibility = Visibility.Visible;
                Txt_Question.Visibility = Visibility.Visible;



                question = new Question { id = 0, qText = "1).What is Your Current Qualification ?  " };
                question.answers.Add(new Answer { aText = "High School Graduate", isCorrect = false });
                question.answers.Add(new Answer { aText = "Bachelor's", isCorrect = false });
                question.answers.Add(new Answer { aText = "Masters's", isCorrect = true });
                question.answers.Add(new Answer { aText = "Other", isCorrect = false });

                DataContext = question;
            }

        }

        private void Lst_AnswerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
