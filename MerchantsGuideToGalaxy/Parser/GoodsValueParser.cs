using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class GoodsValueParser : StringParser
    {
        public GoodsValueParser(IGalaxy galaxy)
            : base(galaxy)
        {
        }

        public GoodsValueParser(StringParser successor, IGalaxy galaxy)
            : base(successor, galaxy)
        {
        }

        public override void Parse(string stringToParse)
        {
            var romanValue = string.Empty;
            string productName = string.Empty;
            long productValue = 0;
            var numberFound = false;
            var words = stringToParse.Trim().Split(' ');

            for (int i = 0; i < words.Length; i++)
            {               
                if (numberFound == false)
                {
                    var valueString = galaxy.GetRomanValue(words[i]);
                    if (string.IsNullOrEmpty(valueString))
                        continue;
                    romanValue = string.Concat(romanValue, valueString);
                    numberFound = true;
                    for (; i < words.Length; )
                    {
                        valueString = galaxy.GetRomanValue(words[i+1]);
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

                    if (long.TryParse(words[i], out productValue))
                        break;
                }
            }

            if(string.IsNullOrEmpty(romanValue) || string.IsNullOrEmpty(productName) || productValue == 0)
            {
                successor.Parse(stringToParse);
                return;
            }

            var productUnits = RomanValueConverter.GetValue(romanValue);
            float productCost =(float) productValue / productUnits;

            galaxy.AddProductsValue(productName, productCost);
        }
    }
}
