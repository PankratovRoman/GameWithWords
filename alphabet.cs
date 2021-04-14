using System;
using System.Collections.Generic;
using System.Text;

namespace GameWithWords
{
    enum LetterPriority
    {
        High,
        Medium,
        Low
    }
    class Alphabet
    {

        char Letter;
      
        int PriorityIndex;

        public Alphabet(char letter, int priorityIndex)
        {
            Letter = letter;
            PriorityIndex = priorityIndex;
        }

        public void Type()
        {
            Console.WriteLine($"The letter {Letter} have priority {PriorityIndex}");
        }
    }
}
