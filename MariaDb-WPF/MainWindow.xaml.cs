using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MariaDb_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int mails;
        public MainWindow()
        {
            InitializeComponent();
            ReadAllMailBUTTON.Visibility = Visibility.Hidden;
        }

        private void ReadAllMailBUTTON_Click(object sender, RoutedEventArgs e)
        {
            int mails = Reader.ReadUnOpenedEmails(ProgressBAR);
            if(mails > 0)
            {
                MessageBox.Show($"{mails} new messages was downloaded to local DB");
            }
            else
            {
                MessageBox.Show($"No new messages was found");

            }
        }

        private void mail_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void password_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void register_BTN_Click(object sender, RoutedEventArgs e)
        {


            string Email = /*mail_TXTBOX.Text;*/ "bobertestar@gmail.com";
            string EmailPassword = /*password_TXTBOX.Text;*/ "twlmqwaalsbdogbi";
            string MariaUser = /*MariaUsername_TXTBOX.Text;*/ "root";
            string mariaPassword = /*MariaPassword_TXTBOX.Text;*/ "Hejsan123!";
            
            var sw = new StringBuilder();
            sw.AppendLine("server=localhost;UserID=");
            sw.AppendLine(MariaUser);
            sw.AppendLine(";Password=");
            sw.Append(mariaPassword + ";");
            sw.AppendLine("database=gnu;");
            sw.AppendLine("Allow User Variables=true;");

            Global.myEmail = Email;
            Global.myEmailPassword = EmailPassword;
            Global.ConnectionString = sw.ToString();

            mail_TXTBOX.IsReadOnly = true;
            password_TXTBOX.IsReadOnly = true;
            MariaUsername_TXTBOX.IsReadOnly = true;
            MariaPassword_TXTBOX.IsReadOnly = true;

            register_BTN.Visibility = Visibility.Hidden;
            ReadAllMailBUTTON.Visibility = Visibility.Visible;
        }

        private void MariaUsername_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MariaPassword_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Databasename_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateDB_BTN_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MariaUserNameDB_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MariaPasswordDB_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateDatabase_BTN_Click(object sender, RoutedEventArgs e)
        {

            string MariaUser = MariaUserNameDB_TXTBOX.Text;
            string mariaPassword = MariaPasswordDB_TXTBOX.Text;

            var sw = new StringBuilder();
            sw.AppendLine("server=localhost;UserID=");
            sw.AppendLine(MariaUser);
            sw.AppendLine(";Password=");
            sw.Append(mariaPassword + ";");
            Global.ConnectionString = sw.ToString();

            Reader.CreateCommand(Global.CreateDB); //Skapar Databas samt tabeller.

            MessageBox.Show("DB was succesfully created, go to \"Sync DB\"");

        }

        private void ProgressBAR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
