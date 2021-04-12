using System;

namespace GameWithWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите набор букв: ");
            string shifr = Console.ReadLine();
            while (true)
               ReadLine(shifr);

        }

        static bool ReadLine(string shifr)
        {
            Console.WriteLine("Введите искомое слово: ");
            string word = Console.ReadLine();
            bool[] allBool = new bool[word.Length]; // сюда будем класть тру или фолсы, которые получатся при поиске букв в шифр слове
            
            for (var i = 0; i < word.Length; i++ )
            {
                if (shifr.Contains(word[i]))
                {
                    allBool[i] = true;
                }
            }
            foreach(var elem in allBool)
            {
                if (elem == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
