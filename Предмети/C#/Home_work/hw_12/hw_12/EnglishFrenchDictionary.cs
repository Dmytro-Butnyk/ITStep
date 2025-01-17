using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_12
{
    public class EnglishFrenchDictionary
    {
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        public void AddWord(string english, List<string> french)
        {
            dictionary[english] = french;
        }

        public void RemoveWord(string english)
        {
            dictionary.Remove(english);
        }

        public void RemoveTranslation(string english, string french)
        {
            if (dictionary.ContainsKey(english))
            {
                dictionary[english].Remove(french);
            }
        }

        public void ChangeWord(string oldEnglish, string newEnglish)
        {
            if (dictionary.ContainsKey(oldEnglish))
            {
                List<string> french = dictionary[oldEnglish];
                dictionary.Remove(oldEnglish);
                dictionary[newEnglish] = french;
            }
        }

        public void ChangeTranslation(string english, string oldFrench, string newFrench)
        {
            if (dictionary.ContainsKey(english))
            {
                List<string> french = dictionary[english];
                int index = french.IndexOf(oldFrench);
                if (index != -1)
                {
                    french[index] = newFrench;
                }
            }
        }

        public List<string> Search(string english)
        {
            if (dictionary.ContainsKey(english))
            {
                return dictionary[english];
            }
            else
            {
                return new List<string>();
            }
        }
    }

}
