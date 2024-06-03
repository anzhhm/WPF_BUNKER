using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BUNKER
{
    public class Character
    {
        //Конструктор створення порожнього гравця
        public Character()
        {
        }
       
        //Метод генерації характеристик гравця
        public string GenerateCharacter(int characterCount)
        {
            // Шляхи до файлів з атрибутами
            string sexFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Sex.txt";
            string ageFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Age.txt";
            string professionFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Profession.txt";
            string levelFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Level.txt";
            string healthFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Health.txt";
            string heightFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Height.txt";
            string hobbyFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Hobby.txt";
            string inventoryFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\Inventory.txt";
            string additionalInfoFilePath = "C:\\Users\\Анжеліка-Марія\\source\\repos\\WPF_BUNKER\\WPF_BUNKER\\CharacterInfoTXT\\AdditionalInfo.txt";

            // Гравець
            string character = $"Гравець {characterCount}" +
            $"\nСтать та вік:\t\t{ReadRandomLine(sexFilePath)}, {ReadRandomLine(ageFilePath)} років" +
            $"\nПрофесія:\t\t{ReadRandomLine(professionFilePath)} ({ReadRandomLine(levelFilePath)})" +
            $"\nЗдоров'я та зріст:\t\t{ReadRandomLine(healthFilePath)}, {ReadRandomLine(heightFilePath)} см" +
            $"\nХобі:\t\t\t{ReadRandomLine(hobbyFilePath)}" +
            $"\nІнвентар:\t\t{ReadRandomLine(inventoryFilePath)}" +
            $"\nДодаткова інформація 1:\t{ReadRandomLine(additionalInfoFilePath)}" +
            $"\nДодаткова інформація 2:\t{ReadRandomLine(additionalInfoFilePath)}";

            return character;
        }

        //Отримання псевдорандомного елементу з масиву атрибутів
        
        private string ReadRandomLine(string filePath)
        {
            // Перевірка чи існує файл
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return null;
            }

            // Прочитати всі строчки файлу
            string[] lines = File.ReadAllLines(filePath);

            // Перевірка чи порожній файл
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty!");
                return null;
            }

            // Згенерувати число від 0 до к-кості строчок
            Random rand = new Random();
            int randomIndex = rand.Next(0, lines.Length);

            // Повернути строчку
            return lines[randomIndex];
        }
    }
}

