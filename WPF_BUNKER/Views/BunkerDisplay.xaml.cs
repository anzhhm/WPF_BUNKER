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

        public BunkerDisplay(int numOfPlayers, int numOfSurvivors)
        {
            InitializeComponent();
            // Підписка на подію зміни DataContext
            DataContextChanged += BunkerDisplay_DataContextChanged;

            this.numOfPlayers = numOfPlayers;
            this.numOfSurvivors = numOfSurvivors;
            characters = new ObservableCollection<CharacterViewModel>();

            // Створення нового генератора гри
            GameGenerator newGame = new GameGenerator(numOfSurvivors);
                // Генерація і відображення катаклізму
                tbApocalipseDisplay.Text = newGame.GenerateCataclysm();
                // Генерація і відображення бункера
                tbBunkerDisplay.Text = newGame.GenerateBunker();
                playerDataGrid.ItemsSource = characters;
        }
        private void BunkerDisplay_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is BunkerDisplayModel model)
            {
                // Отримання кількості виживших із DataContext
               // int numOfSurvivors = model.NumOfSurvivors;

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
                tbPlacesInBunker.Visibility= Visibility.Visible;

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
    }
}

