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

            if (!stringToParse[stringToParse.Trim().Length - 1].Equals('?'))
            {
                if (successor != null) successor.Parse(stringToParse);
                return;
            }
        }
    }
}
