using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Pig_Latin
{
    public class Translator
    {
        public string Translate(string pigSentence)
        {
            string[] sentenceArray = pigSentence.Split(' ');
            string newSentence = "";

            foreach (string word in sentenceArray)
            {
                newSentence += PigFormat(word);
            }

            return newSentence.Trim();
        }

        public string AddAy(string word)
        {
            // Simply the most important method in the entire class. 
            return word += "ay";
        }

        public string PigFormat(string word)
        {
            string newWord = "", vowels = "aeiouy";

            //Find vowel
            foreach(char c in word)
            {
                //Format sentences with QU
                if (c == 'q' && word.IndexOf("qu") >= 0)
                {
                    newWord = word.Substring(word.IndexOf("qu") + 2) + word.Substring(0, word.IndexOf("qu") + 2);
                    break;
                }
                //Format sentences without QU
                if (vowels.IndexOf(c) >= 0)
                {                    
                    newWord = word.Substring(word.IndexOf(c)) + word.Substring(0, word.IndexOf(c));
                    break;
                }
            }

            //Add ay
            newWord = AddAy(newWord);

            //Fix punctuation and caps
            newWord = FixPunctuation(newWord);
            newWord = FixCaps(newWord);

            return newWord + " ";
        }

        public string FixPunctuation(string word)
        {
            string punctuations = ",.!?";
            string newWord = word;

            foreach (char c in word)
            {
                if (punctuations.IndexOf(c) >= 0)
                {
                    newWord = word.Substring(0, word.IndexOf(c)) + word.Substring(word.IndexOf(c) + 1) + c;
                    break;
                }
            }

            return newWord;
        }

        public string FixCaps(string word)
        {
            string newWord = word.ToLower();

            foreach (char c in word)
            {
                if (char.IsUpper(c))
                {
                    newWord = newWord.Substring(0, 1).ToUpper() + newWord.Substring(1);
                    break;
                }
            }

            return newWord;
        }
    }
}
