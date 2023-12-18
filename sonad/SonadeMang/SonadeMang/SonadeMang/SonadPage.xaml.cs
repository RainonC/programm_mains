using System;
using System.Collections.Generic;
using System.IO;

namespace LanguageLearningApp
{
    class Program
    {
        private const string dictionaryFilePath = "sonad.txt";

        static void Main(string[] args)
        {
            // Создаем словарь для хранения слов и переводов
            Dictionary<string, string> dictionary = LoadDictionary();

            // Пользователь вводит слова и их переводы
            Console.WriteLine("Введите слова и их переводы. Для завершения введите 'exit'.");
            string inputWord;
            string inputTranslation;

            do
            {
                Console.Write("Слово: ");
                inputWord = Console.ReadLine();

                if (inputWord.ToLower() != "exit")
                {
                    Console.Write("Перевод: ");
                    inputTranslation = Console.ReadLine();

                    dictionary.Add(inputWord, inputTranslation);
                }

            } while (inputWord.ToLower() != "exit");

            // Сохраняем словарь в файл
            SaveDictionary(dictionary);

            // Показываем карточки с вопросами
            ShowFlashcards(dictionary);
        }

        static void ShowFlashcards(Dictionary<string, string> dictionary)
        {
            Console.WriteLine("\nИзучаемые слова:");

            // Показываем карточки
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"- {entry.Key}");
            }

            // Пользователь выбирает слово для перевода
            Console.Write("\nВыберите слово для перевода: ");
            string selectedWord = Console.ReadLine();

            // Отображаем окно для ввода перевода
            if (dictionary.ContainsKey(selectedWord))
            {
                Console.Write($"Введите перевод для слова '{selectedWord}': ");
                string userTranslation = Console.ReadLine();

                // Проверяем правильность перевода
                if (userTranslation.ToLower() == dictionary[selectedWord].ToLower())
                {
                    Console.WriteLine("Верно! Поздравляем!");
                }
                else
                {
                    Console.WriteLine($"Неверно. Правильный перевод: {dictionary[selectedWord]}");
                }
            }
            else
            {
                Console.WriteLine("Слово не найдено в словаре.");
            }
        }

        static Dictionary<string, string> LoadDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            if (File.Exists(dictionaryFilePath))
            {
                // Загружаем словарь из файла
                string[] lines = File.ReadAllLines(dictionaryFilePath);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                    {
                        dictionary.Add(parts[0], parts[1]);
                    }
                }
            }

            return dictionary;
        }

        static void SaveDictionary(Dictionary<string, string> dictionary)
        {
            // Сохраняем словарь в файл
            List<string> lines = new List<string>();

            foreach (var entry in dictionary)
            {
                lines.Add($"{entry.Key}|{entry.Value}");
            }

            File.WriteAllLines(dictionaryFilePath, lines);
        }
    }
}


