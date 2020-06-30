using Barotrauma_Mod_Generator.XmlUtils;
using System.Collections.Generic;
using System.Xml.Linq;
using Xunit;

namespace Barotrauma_Mod_Generator_Tests
{
    public class XMLUtilsTests
    {
        [Fact]
        public void TestNullFilter()
        {
            XDocument inputData = XDocument.Load("TestData/TestInput.xml");
            XDocument diff = XDocument.Load("TestData/Filter/Null/Diff.xml");

            HashSet<string> AllElements = XMLUtils.GetFilteredXPaths(diff, inputData);
            HashSet<string> ExpectedOutput = new HashSet<string>
            {
                "/Items/Item[1]",
                "/Items/Item[2]"
            };

            Assert.Equal(ExpectedOutput, AllElements);
        }
    }
}
