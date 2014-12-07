using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToGalaxy;

namespace MerchantsGuideToGalaxyTest
{
    [TestClass]
    public class GoodsValueParserTest
    {
        [TestMethod]
        public void ParseTest()
        {
            IGalaxy galaxy = new Galaxy();

            StringParser goodsValueParser = new GoodsValueParser(galaxy);
            StringParser parser = new VariableMapperParser(goodsValueParser, galaxy);

            parser.Parse("glob is I");
            parser.Parse("prok is V");
            parser.Parse("pish is X");
            parser.Parse("tegj is L");

            parser.Parse("glob glob Silver is 34 Credits");
            parser.Parse("glob prok Gold is 57800 Credits");
            parser.Parse("pish pish Iron is 3910 Credits");

            Assert.AreEqual(galaxy.GetProductsValue("Silver"),17);

        }
    }
}
