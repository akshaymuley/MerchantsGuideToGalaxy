using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class VariableMapperParser : StringParser
    {
        public VariableMapperParser()
        {
        }

        public VariableMapperParser(StringParser successor):base(successor)
        {
        }

        public override void Parse(string stringToParse)
        {
            var words = stringToParse.Trim().Split(' ');

            if (words.Length != 3)
            {
                if (successor != null) successor.Parse(stringToParse);
                return;
            }
            foreach (string word in words)
            {
                
            }
        }
    }
}
