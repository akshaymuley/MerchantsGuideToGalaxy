using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    public abstract class StringParser
    {
        internal StringParser successor;

        public StringParser(StringParser successor)
        {
            this.successor = successor;
        }

        public StringParser()
        {
        }

        public abstract void Parse(string stringToParse);
    }
}
