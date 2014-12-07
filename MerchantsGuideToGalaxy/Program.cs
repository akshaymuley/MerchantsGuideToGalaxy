using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IGalaxy galaxy = new Galaxy();
            StringParser questionParser = new QuestionParser(galaxy);
            StringParser goodsValueParser = new GoodsValueParser(questionParser, galaxy);
            StringParser parser = new VariableMapperParser(goodsValueParser, galaxy);

            parser.Parse("glob is I");
            parser.Parse("prok is V");
            parser.Parse("pish is X");
            parser.Parse("tegj is L");
            
            parser.Parse("glob glob Silver is 34 Credits");
            parser.Parse("glob prok Gold is 57800 Credits");
            parser.Parse("pish pish Iron is 3910 Credits");

            Console.ReadLine();
        }
    }
}
