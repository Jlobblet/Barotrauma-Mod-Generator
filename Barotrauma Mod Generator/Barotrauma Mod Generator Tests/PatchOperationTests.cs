using System.Xml.Linq;
using Barotrauma_Mod_Generator.PatchOperations;
using Xunit;

namespace Barotrauma_Mod_Generator_Tests
{
    public class PatchOperationTests
    {
        [Theory]
        [InlineData("TestData/Add/Output.xml", "TestData/Add/Diff.xml")]
        [InlineData("TestData/Remove/Output.xml", "TestData/Remove/Diff.xml")]
        [InlineData("TestData/Edit/Output.xml", "TestData/Edit/Diff.xml")]
        [InlineData("TestData/All/Output.xml", "TestData/All/Diff.xml")]
        [InlineData("TestData/Edit/Override/Local/Output.xml",
                    "TestData/Edit/Override/Local/Diff.xml")]
        [InlineData("TestData/Edit/Override/All/Output.xml",
                    "TestData/Edit/Override/All/Diff.xml")]
        [InlineData("TestData/Edit/Override/Local/Multiple/Output.xml",
                    "TestData/Edit/Override/Local/Multiple/Diff.xml")]
        [InlineData("TestData/Edit/Override/Root/Output.xml",
                    "TestData/Edit/Override/Root/Diff.xml")]
        [InlineData("TestData/Remove/Cleanup/Output.xml",
                    "TestData/Remove/Cleanup/Diff.xml")]
        public void TestApplyAll(string outputPath, string diffPath)
        {
            XDocument outputData = XDocument.Load(outputPath);
            XDocument diff = XDocument.Load(diffPath);

            XDocument testData = ApplyPatchOperation.ApplyAll(diff);

            Assert.True(XNode.DeepEquals(outputData.Root, testData.Root),
                        $"{nameof(outputPath)}\n\n{outputData}\n\ndoes not match file produced by {nameof(diffPath)}\n\n{testData}");
        }
    }
}
