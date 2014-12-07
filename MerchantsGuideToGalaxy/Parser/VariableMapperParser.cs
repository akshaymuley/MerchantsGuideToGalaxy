using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class VariableMapperParser : StringParser
    {
        public VariableMapperParser(IGalaxy galaxy) : base(galaxy)
        {            
        }

        public VariableMapperParser(StringParser successor, IGalaxy galaxy) : base(successor, galaxy)
        {
            this.galaxy = galaxy;
        }

        public override void Parse(string stringToParse)
        {
            var words = stringToParse.Trim().Split(' ');

            if (words.Length != 3)
            {
                if (successor != null) successor.Parse(stringToParse);
                return;
            }
            if(words[1].ToUpper().Equals("IS"))
            {
                var value = RomanValueConverter.GetValue(words[2]);
                if(value != 0)
                {
                    galaxy.AddCurrency(words[0], words[2]);
                }
            }
        }
    }
}
