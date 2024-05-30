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
using WPF_BUNKER.Models;
using WPF_BUNKER.ViewModels;

namespace WPF_BUNKER.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>

    
        public partial class MainPage : Window
        {
            public MainPage()
            {
                InitializeComponent();
            }
            // Обробник події кліку на кнопку "Почати гру"
            private void btnStartTheGame_Click(object sender, RoutedEventArgs e)
            {
                int numOfPlayers;
                int numOfSurvivors;

                // Перевірка, чи введене число виживших є цілим числом
                if (int.TryParse(txtbNumOfSurvivors.Text, out int num))
                {
                    // Перевірка, чи введене число гравців є цілим числом
                    if (int.TryParse(txtbNumOfPlayers.Text, out int num2))
                    {
                        // Перевірка умов: число виживших менше числа гравців, обидва числа більше 0, число гравців в межах 5-30
                        if (num < num2 && num > 0 && num2 > 4 && num2 < 30)
                        {
                            numOfPlayers = int.Parse(txtbNumOfPlayers.Text);
                            numOfSurvivors = int.Parse(txtbNumOfSurvivors.Text);

                            // Створює нову модель відображення для гри з вказаними параметрами
                            //var bunkerDisplayModel = new BunkerDisplayModel(numOfPlayers, numOfSurvivors);
                            //DataContext = bunkerDisplayModel;
                            // Create an instance of BunkerDisplayModel
                            try
                            {
                                var bunkerDisplay = new BunkerDisplay(numOfPlayers, numOfSurvivors);
                                bunkerDisplay.Show();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                // Handle the exception as needed
                                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            // Set the DataContext of the main window to the BunkerDisplayModel instance
                            //this.DataContext = bunkerDisplay;
                        }
                        else
                        {
                            // Виводить повідомлення про помилку, якщо умови не виконані
                            MessageBox.Show("Упс! Я не можу створити таку гру :(" +
                                "\n\nБудь ласка, перевір умови створення гри: " +
                                "\n1) Число гравців має бути більшим за число виживших та більшим за 0. " +
                                "\n2) Число гравців не може перевищувати 30 та бути меншим за 5" +
                                "\n3) Число виживших має бути більше 0");
                        }
                    }
                    else
                    {
                        // Виводить повідомлення про помилку, якщо введено некоректне число гравців
                        MessageBox.Show("Введи ціле додатне число, аби позначити кількість гравців");
                    }
                }
                else
                {
                    // Виводить повідомлення про помилку, якщо введено некоректне число виживших
                    MessageBox.Show("Введи ціле додатне число, аби позначити кількість виживших");
                }
            }

            // Обробник події фокусу на текстовому полі
            private void TextBox_GotFocus(object sender, RoutedEventArgs e)
            {
                if (sender is TextBox textBox)
                {
                    // Очищає текстове поле, коли воно отримує фокус
                    textBox.Text = string.Empty;
                }
            }

            private void btnRules_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Сюжет: " +
                    "\r\nЯк це – опинитися у самому серці глобальної катастрофи? Як довести, що саме ти вартий пережити її?" +
                    "\r\nСаме для отримання цих гострих відчуттів і було створено гру “Бункер”! Тут, ти зможеш зануритись у постапокаліптичні сварки за “місце під лампою” зі своїми майбутніми сусідами по підвалу. Твоя остання надія – це укриття. Доведи, що вартий бути врятованим!" +
                    "\r\n\r\nПроцес гри:" +
                    "\r\n\r\n1) У першому ігровому колі все починається з представлення один одного." +
                    "\r\n2) У процесі знайомства гравець розкриває свій основний параметр - це спеціальність." +
                    "\r\n3) На це дається кожному гравцеві по 1 хвилині." +
                    "\r\n4) Після того як кожен гравець розповів про свій параметр, гравці отримують 1 хвилину загального часу на колективне обговорення." +
                    "\r\n5) Після цього приходить час голосування. Гравці мають обрати того, хто покине тимчасовий табір і не потрапить у бункер. Розголошувати ще не відкриті параметри з метою переконання гравців - забороняється." +
                    "\r\n6) Тимчасовий табір покидає гравець, що набрав найбільшу кількість голосів проти себе. У разі рівної кількості голосів – відбувається переголосування між гравцями з рівною кількістю голосів." +
                    "\r\n7) Після голосування починається наступне ігрове коло (раунд)." +
                    "\r\n8) У всіх наступних раундах розкривається тільки один параметр." +
                    "\r\n9) Наприкінці гри гравці, які потрапили в бункер, розкривають свої характеристики. Ведучий підбиває підсумок.");
            }
        }
    }
    
