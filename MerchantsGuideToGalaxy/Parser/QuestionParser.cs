using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class QuestionParser : StringParser
    {
        private const string goodsValueOutputFormat = "{0} is {1} Credits";
        
        private const string valueConversion = "{0} is {1}";
        
        private List<string> values;

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
            values = new List<string>();

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
                    values.Add(words[i]);

                    for (; i < words.Length; )
                    {
                        valueString = galaxy.GetRomanValue(words[i + 1]);
                        if (string.IsNullOrEmpty(valueString))
                            break;
                        romanValue = string.Concat(romanValue, valueString);
                        values.Add(words[i+1]);
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
                Console.WriteLine("I have no idea what you are talking about.");
            else
            {
                var productValue = galaxy.GetProductsValue(productName);
                var quantity = RomanValueConverter.GetValue(romanValue);
                if (productValue != 0.0 && quantity != 0)
                    PrintOutput(productValue * quantity , false);
                else if (quantity != 0)
                    PrintOutput(quantity, true);
            }
        }

        private bool IsValidString(string stringToParse)
        {
            if (stringToParse[stringToParse.Trim().Length - 1].Equals('?'))
                return true;
            return false;
        }

        private void PrintOutput(float credits, bool isValueConversionString)
        {
            var valueString = string.Empty;
            foreach (string value in values)
            {
                valueString = string.Format("{0} {1}", valueString, value);
            }
            Console.WriteLine(string.Format(isValueConversionString ? valueConversion: goodsValueOutputFormat, valueString.Trim(), credits));
        }
    }
}
