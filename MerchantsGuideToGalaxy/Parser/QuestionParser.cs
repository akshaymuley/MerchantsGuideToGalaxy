using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class QuestionParser : StringParser
    {
        public QuestionParser(IGalaxy galaxy)
            : base(galaxy)
        {
        }

        public QuestionParser(StringParser successor, IGalaxy galaxy)
            : base(successor, galaxy)
        {            
        }
        
        public override void Parse(string stringToParse)
        {
            stringToParse = stringToParse.Trim();

            if (!IsValidString(stringToParse))
            {
                if (successor != null) successor.Parse(stringToParse);
                return;
            }

            var romanValue = string.Empty;
            string productName = string.Empty;
            var words = stringToParse.Trim().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(romanValue))
                {
                    var valueString = galaxy.GetRomanValue(words[i]);
                    if (string.IsNullOrEmpty(valueString))
                        continue;
                    romanValue = string.Concat(romanValue, valueString);
                    
                    for (; i < words.Length; )
                    {
                        valueString = galaxy.GetRomanValue(words[i + 1]);
                        if (string.IsNullOrEmpty(valueString))
                            break;
                        romanValue = string.Concat(romanValue, valueString);
                        i++;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(productName))
                    {
                        productName = words[i];
                        continue;
                    }                    
                }
            }

            if (string.IsNullOrEmpty(romanValue) || string.IsNullOrEmpty(productName))
                Console.WriteLine("I have no idea what you are talking about");
            else
            {
                var productValue = galaxy.GetProductsValue(productName);
                var quantity = RomanValueConverter.GetValue(romanValue);
                if (productValue != 0.0 && quantity != 0)
                    Console.WriteLine(productValue * quantity);
                else if (quantity != 0)
                    Console.WriteLine(quantity);
            }
        }

        private bool IsValidString(string stringToParse)
        {
            if (stringToParse[stringToParse.Trim().Length - 1].Equals('?'))
                return true;
            return false;
        }
    }
}
