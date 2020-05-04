using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool firstTime = true;
        public static string language = "de";
        public MainWindow()
        {
            language = Properties.Settings.Default.language;

            CultureInfo.CurrentCulture = new CultureInfo(language);
            CultureInfo.CurrentUICulture = new CultureInfo(language);
           
             InitializeComponent();

        }

        private void Btn_GoToCourses(object sender, RoutedEventArgs e)
        {
            var win = new Courses();
            win.Owner = this;
            //win.Show();
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_GoToQuestionareClick(object sender, RoutedEventArgs e)
        {
            var win = new Questionare();
            win.Owner = this;
            //win.Show();
            Visibility = Visibility.Hidden;
            win.ShowDialog();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firstTime)
            {
                firstTime = false;
                return;
            }
            language = Cobx_Language.SelectedItem.ToString().Substring(0, 2);

            Properties.Settings.Default.language = language;
            Properties.Settings.Default.Save();


            Process.Start(Application.ResourceAssembly.Location);
            App.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var lst = new List<string> { "en", "de" };
            var itm = (from l in lst where l.Contains(language) select l).FirstOrDefault();
            Cobx_Language.SelectedItem = itm;
            Cobx_Language.ItemsSource = lst;

        }

        public static string getCurrentLanguage()
        {
            return language;
        }
    }
}
