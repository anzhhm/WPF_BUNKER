﻿using System;
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
using System.Windows.Threading;
using WPF_BUNKER.Models;
using WPF_BUNKER.ViewModels;


namespace WPF_BUNKER.Views
{
    /// <summary>
    /// Interaction logic for BunkerDisplay.xaml
    /// </summary>
    public partial class BunkerDisplay : Window
    {
        //Колекція, що зберігає гравців
        private ObservableCollection<CharacterViewModel> characters;

        // Лічильник створених персонажів
        private int characterCount = 0;

        // Зберігає кількість гравців
        private int numOfPlayers;
        public int numOfSurvivors;

        public string cataclysm;
        public string bunker;

        public BunkerDisplay(int numOfPlayers, int numOfSurvivors)
        {
            InitializeComponent();
            // Підписка на подію зміни DataContext
            playerDataGrid.PreviewMouseLeftButtonDown += PlayerDataGrid_PreviewMouseLeftButtonDown;

            this.numOfPlayers = numOfPlayers;
            this.numOfSurvivors = numOfSurvivors;
            characters = new ObservableCollection<CharacterViewModel>();

            // Створення нового генератора гри
            GameGenerator newGame = new GameGenerator(numOfSurvivors);
            // Генерація і відображення катаклізму
            cataclysm = newGame.GenerateCataclysm();
            tbApocalipseDisplay.Text = cataclysm;
            // Генерація і відображення бункера
            bunker = newGame.GenerateBunker();
            tbBunkerDisplay.Text = bunker;
            playerDataGrid.ItemsSource = characters;
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
        }

        // Обробник кліку на кнопку "Згенерувати карту"
        private void btnGenerateCard_Click(object sender, RoutedEventArgs e)
        {

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
                imgCard.Visibility = Visibility.Collapsed;

                // Показати табличку
                playerDataGrid.Visibility = Visibility.Visible;
                btnGameInfo.Visibility = Visibility.Visible;

                // Відображає повідомлення про закінчення гри
                btnEndTheGame.Visibility = Visibility.Visible;

            }
        }
        // Обробник кліку на кнопку "Закінчити гру"
        private void btnEndTheGame_Click(object sender, RoutedEventArgs e)
        {
            // Завершує роботу програми
            Environment.Exit(0);
        }
        //private int time = 60;
        //private DispatcherTimer timer;

        private void PlayerDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Find the clicked cell
            DependencyObject depObj = (DependencyObject)e.OriginalSource;
            while (depObj != null && !(depObj is DataGridCell))
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }

            if (depObj is DataGridCell cell)
            {
                // Apply your desired style changes here
                cell.Background = Brushes.AntiqueWhite; // Change background color
                cell.Foreground = Brushes.Black; // Change foreground color
            }
        }

        private void btnGameInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Кількість місць у бункері: {numOfSurvivors}" +
                $"\n\nБункер:" +
                $"\n\n{bunker}" +
                $"\n\nАпокаліпсис:" +
                $"\n\n{cataclysm}");
        }
    }
}


