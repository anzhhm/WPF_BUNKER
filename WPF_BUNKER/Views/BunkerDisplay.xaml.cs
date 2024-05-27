using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WPF_BUNKER.ViewModels;
using WPF_BUNKER.Models;

namespace WPF_BUNKER.Views
{
    // Логіка взаємодії для BunkerDisplay.xaml
    public partial class BunkerDisplay : UserControl
    {
        //Колекція, що зберігає гравців
        private ObservableCollection<CharacterViewModel> characters;

        // Лічильник створених персонажів
        private int characterCount = 0;

       // BunkerDisplayViewModel _bunkerViewModel;

        public BunkerDisplay()
        {
            InitializeComponent();
            // Підписка на подію зміни DataContext
            // _bunkerViewModel = new BunkerDisplayViewModel();
            DataContextChanged += BunkerDisplay_DataContextChanged;
           // DataContext = _bunkerViewModel;
            characters = new ObservableCollection<CharacterViewModel>();
            playerDataGrid.ItemsSource = characters;
        }

        // Обробник зміни DataContext
        private void BunkerDisplay_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is BunkerDisplayModel model)
            {
                // Отримання кількості виживших із DataContext
                int numOfSurvivors = model.NumOfSurvivors;

                // Створення нового генератора гри
                GameGenerator newGame = new GameGenerator(numOfSurvivors);
                // Генерація і відображення катаклізму
                tbApocalipseDisplay.Text = newGame.GenerateCataclysm();
                // Генерація і відображення бункера
                tbBunkerDisplay.Text = newGame.GenerateBunker();
            }
        }

        // Обробник кліку на кнопку "Продовжити"
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            // Приховує попередній UI
            btnContinue.Visibility = Visibility.Collapsed;
            tbApocalipse.Visibility = Visibility.Collapsed;
            tbApocalipseDisplay.Visibility = Visibility.Collapsed;
            tbBunker.Visibility = Visibility.Collapsed;
            tbBunkerDisplay.Visibility = Visibility.Collapsed;

            // Відображає новий UI
            btnGenerateCard.Visibility = Visibility.Visible;

            // Підписка на подію зміни DataContext
            DataContextChanged += BunkerDisplay_DataContextChanged;
        }

        // Обробник кліку на кнопку "Згенерувати карту"
        private void btnGenerateCard_Click(object sender, RoutedEventArgs e)
        {
            //List<CharacterViewModel> characters = new List<CharacterViewModel>();
            if (DataContext is BunkerDisplayModel model)
            {
                int numOfPlayers = model.NumOfPlayers;

                if (characterCount < numOfPlayers)
                {
                    // Створення нового персонажа
                    Character newCharacter = new Character();
                    characterCount++;


                    string character = newCharacter.GenerateCharacter(characterCount);
                    // Відображення створеного персонажа
                    tbCharacterDisplay.Text = character;
                    // Відображення картки
                    imgCard.Visibility = Visibility.Visible;

                    // Створення колекції гравців
                    characters.Add(new CharacterViewModel(character));
                }

                else
                {
                    // Приховує кнопку генерації картки, коли всі персонажі створені
                    btnGenerateCard.Visibility = Visibility.Collapsed;
                    tbCharacterDisplay.Visibility = Visibility.Collapsed;
                    btnEndTheGame.Visibility = Visibility.Visible;
                    imgCard.Visibility = Visibility.Collapsed;

                    // Показати табличку
                    playerDataGrid.Visibility = Visibility.Visible;

                    // Відображає повідомлення про закінчення гри
                    //tbCharacterDisplay.Text = "Гарної гри! \nНехай врятуються найкмітливіші!";
                    //tbCharacterDisplay.FontSize = 50;
                    //tbCharacterDisplay.Visibility = Visibility.Visible;
                }
            }
        }

        // Обробник кліку на кнопку "Закінчити гру"
        private void btnEndTheGame_Click(object sender, RoutedEventArgs e)
        {
            // Завершує роботу програми
            Environment.Exit(0);
        }
    }
}
