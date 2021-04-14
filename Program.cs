using System;
using System.Collections.Generic;
using System.IO;

namespace GameWithWords
{
    class Program
    {
        static void Main()
        {
            string[] words = File.ReadAllLines(@"C:\Users\f0611312\Desktop\ПРОЕКТ ИКС\russian_nouns.txt");
            var enteredChars = GetRandomBaseString();
            Console.WriteLine($"Рандом ввел: {enteredChars}");
            //Console.WriteLine("Введите набор букв: ");
            //string enteredChars = Console.ReadLine();
            
            //SearchingWordsFromFile(enteredChars, words);
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите искомое слово: ");
                    string enteredWord = Console.ReadLine();
                    ReadLine(enteredChars, enteredWord);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        static string GetRandomBaseString()
        {
            string[] alphabetCharsHighPriority = { "о", "е", "а", "и", "н", "т" };
            string[] alphabetCharsMediumPriority = { "с", "р", "в", "л", "к", "м", "д", "п", "у", "я" };
            string[] alphabetCharsLowPriority = { "ы", "ь", "г", "д", "з", "б", "ч", "й", "х", "ж", "ш", "ю", "ц", "щ", "э", "ф", "ъ", "ё" };
            string baseString = "";
            Random rnd = new Random();

            for (var el = 0; el < 5; el++)
            {
                int rndValue = rnd.Next(0, 5);
                char rndChar = char.Parse(alphabetCharsHighPriority[rndValue]);
                baseString += rndChar;
            }
            for (var el = 0; el < 3; el++)
            {
                int rndValue = rnd.Next(0, 9);
                char rndChar = char.Parse(alphabetCharsMediumPriority[rndValue]);
                baseString += rndChar;
            }
            for (var el = 0; el < 2; el++)
            {
                int rndValue = rnd.Next(0, 17);
                char rndChar = char.Parse(alphabetCharsLowPriority[rndValue]);
                baseString += rndChar;
            }
            return baseString;
        }

        static void SearchingWordsFromFile(string enteredChars, string[] dictionary)
        {
            //List<bool> searshingBoolList = new List<bool>();
            foreach (var character in enteredChars)
            {
                for (var i = 0; i < dictionary[i].Length; i++)
                {
                    Console.WriteLine(character);

                }
            }

        }

        static void ReadLine(string enteredChars, string enteredWord)
        {
            var originalEnteredChars = enteredChars;

            for (var i = 0; i < enteredWord.Length; i++)
            {
                if (!enteredChars.Contains(enteredWord[i]))
                {
                    throw new Exception($"Слова [{enteredWord}] нет в строке из символов [{originalEnteredChars}].");
                }

                var indexForSortArray = Array.IndexOf(enteredChars.ToCharArray(), enteredWord[i]);
                enteredChars = enteredChars.Remove(indexForSortArray, 1);
            }
            Console.WriteLine($"Слово [{enteredWord}] найдено в строке из символов [{originalEnteredChars}].");

        }
    }
}

// https://habr.com/ru/post/444594/ прочесть

//у тебя есть алфавит русских букв.
//ты случайным образом создаешь комбинацию из букв заданной длины (допустим 10). Буквы могут повторяться.
//1 этап - пользователь вводит комбинацию из букв - программа читает ответ, проверяет может ли введенная
//пользователем комбинация принадлежать заданному множеству из 10 букв.
//пример
//> Создана комбинация: ппрцатсуив
//- сива
//> True
//- сява
//> False

//2 этап - скачай словарь в текстовом файле (http://blog.harrix.org/article/3334).
//Загрузи его в память программы через:

//using System.IO;
//...
//string[] words = File.ReadAllLines(@"C:\Documents\Downloads\words.txt"); //ясное дело у тебя путь другой будет

//Введенное пользователем слово проверяй теперь не только на принадлежность комбинации, но и на то есть ли такое слово в словаре.
//Если есть - начисляй очки - сколько букв - столько очков, можно бонусы за слова длиннее 4 букв, ну сам подумаешь

//Задания со звездочкой:
//*-пускай генерация комбинации будет не совсем случайной, так как буквы в алфавите используются с разной частотой, надо чтоб комбинация
//была из вменяемых букв, а не ъхйхзчщуй - назначь буквам редкость и пусть комбинация создается допустим из 5 частых букв, 3 менее частых и 2 редких

//** - пускай выполняется проверка комбинации на наличие в ней слов. Т.е. у тебя будет метод, который будет автоматически проверять
//комбинацию на то есть ли в ней слова и сколько. И допустим подсчитает эти слова и когда выдаст комбу напишет (5 слов) -и игрок должен все 5 слов найти

//в словаре есть дефисы - пускай пользователь может ввести слово с дефисом, но он будет игнорироваться при проверке наличия его в комбинации

//но не в словаре!

//File.ReadAllLines - как и большинство методов, работающих с файловой системой принимает относительный путь и работает от папки где лежит экзешник.
//Если положишь файл туда же, можешь указать просто File.ReadAllLines("words.txt");

//работает и ..\..\words.txt ну кароч досовская хуйня

//на всякий случай уточню - если в комбинации одна буква, а в слове ты используешь две таких буквы - это незачет