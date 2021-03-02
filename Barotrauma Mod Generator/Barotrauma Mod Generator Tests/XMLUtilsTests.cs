using System.Collections.Generic;
using System.Xml.Linq;
using Barotrauma_Mod_Generator.Util;
using Xunit;

namespace Barotrauma_Mod_Generator_Tests
{
    public class XmlUtilsTests
    {
        [Fact]
        public void TestNullFilter()
        {
            XDocument inputData = XDocument.Load("TestData/TestInput.xml");
            XDocument diff = XDocument.Load("TestData/Filter/Null/Diff.xml");

            HashSet<string> allElements = XmlUtils.GetFilteredXPaths(diff, inputData);
            var expectedOutput = new HashSet<string>
                                 {
                                     "/Items/Item[1]",
                                     "/Items/Item[2]"
                                 };

            Assert.Equal(expectedOutput, allElements);
        }
    }
}
