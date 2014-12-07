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

        internal IGalaxy galaxy;

        public StringParser(IGalaxy galaxy)
        {
            this.galaxy = galaxy;
        }

        public StringParser(StringParser successor, IGalaxy galaxy) : this(galaxy)
        {
            this.successor = successor;
        }

        public abstract void Parse(string stringToParse);
    }
}
