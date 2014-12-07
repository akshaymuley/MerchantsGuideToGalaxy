using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public class QuestionParser : StringParser
    {
        public QuestionParser(StringParser successor): base(successor)
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
