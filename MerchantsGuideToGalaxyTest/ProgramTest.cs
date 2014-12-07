using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MerchantsGuideToGalaxy;
using System.IO;

namespace MerchantsGuideToGalaxyTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void MainTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                IGalaxy galaxy = new Galaxy();
                StringParser questionParser = new QuestionParser(galaxy);
                StringParser goodsValueParser = new GoodsValueParser(questionParser, galaxy);
                StringParser parser = new VariableMapperParser(goodsValueParser, galaxy);

                parser.Parse("glob is I");
                parser.Parse("prok is V");
                
                parser.Parse("glob glob Silver is 34 Credits");
                
                parser.Parse("how many Credits is glob prok Silver ?");
                
                Assert.AreEqual(sw.ToString().Trim(),"68");
            }
        }
    }
}
