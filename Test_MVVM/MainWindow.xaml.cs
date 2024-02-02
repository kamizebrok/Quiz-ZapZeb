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
using test_MVVM.Model;

namespace test_MVVM
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        int counter = 0;
        private List<Button> przyciski = new List<Button>();
        private List<Question> pytania = new List<Question>();
        
        private Button zaznaczonyPrzycisk;
        string id_button;


        private void UsunZaznaczonyPrzycisk_Click(object sender, RoutedEventArgs e)
        {
            // Upewnij się, że jest zaznaczony przycisk
            if (zaznaczonyPrzycisk != null)
            {

                przyciski.Remove(zaznaczonyPrzycisk);
                ListBoxElementy.Items.Remove(zaznaczonyPrzycisk);
                zaznaczonyPrzycisk = null;
                counter--;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //button "dodaj pytanie"
            counter += 1;
            Button nowyButton = new Button();
            nowyButton.Content = "Pytanie " + Convert.ToString(counter);
            NazwaPytania.Text = nowyButton.Content.ToString();
            nowyButton.Width = 145;
            nowyButton.Height = 25;
            nowyButton.Click += Element_Click;
            nowyButton.Tag = Guid.NewGuid().ToString();
            //nowyButton.Command = myCommand;

            przyciski.Add(nowyButton);
            ListBoxElementy.Items.Add(nowyButton);

            if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Background = Brushes.LightGray;
                zaznaczonyPrzycisk = null;
            }
            nowyButton.Background = Brushes.LightBlue;
            zaznaczonyPrzycisk = nowyButton;
            id_button = nowyButton.Tag.ToString();

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            RadioButton1.IsChecked = false;
            RadioButton2.IsChecked = false;
            RadioButton3.IsChecked = false;
            RadioButton4.IsChecked = false;
            Question newQuestion = new Question(id_button, TextBox1.Text);
            pytania.Add(newQuestion);
        }


        private void Element_Click(object sender, RoutedEventArgs e)
        {
            //metoda dodawana do nowych buttonow
            Button kliknietyButton = (Button)sender;
            id_button = kliknietyButton.Tag.ToString();
            Console.WriteLine("Klikasz przycisk "+id_button);

            if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Background = Brushes.LightGray;
                zaznaczonyPrzycisk = null;
            }
            kliknietyButton.Background = Brushes.LightBlue;
            zaznaczonyPrzycisk = kliknietyButton;
            NazwaPytania.Text = kliknietyButton.Content.ToString();
            Console.WriteLine("Szukam przycisku "+ id_button);
            Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);

            if(current_question != null) {
                TextBox1.Text = current_question.Quest;
                TextBox2.Text = current_question.AnswerA;
                TextBox3.Text = current_question.AnswerB;
                TextBox4.Text = current_question.AnswerC;
                TextBox5.Text = current_question.AnswerD;

                if (current_question.CorrectAnswer != null)
                {
                    if (current_question.CorrectAnswer == current_question.AnswerA) { RadioButton1.IsChecked = true; }
                    else if (current_question.CorrectAnswer == current_question.AnswerB) { RadioButton2.IsChecked = true; }
                    else if (current_question.CorrectAnswer == current_question.AnswerC) { RadioButton3.IsChecked = true; }
                    else if (current_question.CorrectAnswer == current_question.AnswerD) { RadioButton4.IsChecked = true; }
                }
            }
            else
            {
                TextBox1.Text = "nie znaleziono";
            }

            Zapisano.Content = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //zapisywanie
            Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);
            if (current_question != null)
            {
                current_question.Quest = TextBox1.Text;
                Zapisano.Content = "Pomyślnie zapisano pytanie!";
                current_question.AnswerA = TextBox2.Text;
                current_question.AnswerB = TextBox3.Text;
                current_question.AnswerC = TextBox4.Text;
                current_question.AnswerD = TextBox5.Text;
            }
            else
            {
                TextBox1.Text = "nie zapisano";
                Zapisano.Content = "Nie zapisano pytania :(";
            }
            zaznaczonyPrzycisk.Content = NazwaPytania.Text;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBoxElementy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NazwaPytania_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Content = NazwaPytania.Text;
            }*/
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);
                if (current_question != null)
                {
                    current_question.CorrectAnswer = TextBox2.Text;
                }
            }
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);
                if (current_question != null)
                {
                    current_question.CorrectAnswer = TextBox3.Text;
                }
            }
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);
                if (current_question != null)
                {
                    current_question.CorrectAnswer = TextBox4.Text;
                }
            }
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Question current_question = pytania.Find(pytanie => pytanie.QuestionID == id_button);
                if (current_question != null)
                {
                    current_question.CorrectAnswer = TextBox5.Text;
                }
            }
        }
    }
}
