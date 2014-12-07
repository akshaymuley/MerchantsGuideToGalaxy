using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy.Parser
{
    public class GoodsValueParser : StringParser
    {
        public GoodsValueParser()
        {
        }

        public GoodsValueParser(StringParser successor) : base(successor)
        {
        }

        public override void Parse(string stringToParse)
        {
            throw new NotImplementedException();
        }
    }
}
