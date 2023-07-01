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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginPasswordGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string specificChars = "-+_=^@!\"";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var birth = dpBirthday.SelectedDate;
            var login = tbLogin.Text.ToLower();
            
            var generatedLogin = "";
            var generatedPassword = "";

            var rnd = new Random();

            if (birth == null)
            {
                MessageBox.Show("Выберите дату рождения");
                return;
            }

            foreach (var c in login)
            {
                generatedLogin += (alphabet.IndexOf(c) + 1);

            }

            var birthSum = 0;

            var day = birth.Value.Day;
            var month = birth.Value.Month;
            var year = birth.Value.Year;

            foreach (var c in day.ToString())
            {
                birthSum += int.Parse(c.ToString());
            }
            foreach (var c in month.ToString())
            {
                birthSum += int.Parse(c.ToString());
            }
            foreach (var c in year.ToString())
            {
                birthSum += int.Parse(c.ToString());
            }

            generatedLogin += birthSum;

            var specificCharPosition = rnd.Next(10);

            for (var i = 0; i <= 10; i++)
            {
                if (i == specificCharPosition)
                    generatedPassword += specificChars[rnd.Next(specificChars.Length)];
                else
                    generatedPassword += alphabet[rnd.Next(alphabet.Length)];
            }


            tbGeneratedLogin.Text = generatedLogin;
            tbPassword.Text = generatedPassword;
        }
    }
}
