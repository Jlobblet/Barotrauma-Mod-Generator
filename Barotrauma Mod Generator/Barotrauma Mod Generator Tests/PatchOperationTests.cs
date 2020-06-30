using Barotrauma_Mod_Generator.PatchOperations;
using System.Xml.Linq;
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
        [InlineData("TestData/Edit/Override/Local/Output.xml", "TestData/Edit/Override/Local/Diff.xml")]
        [InlineData("TestData/Edit/Override/All/Output.xml", "TestData/Edit/Override/All/Diff.xml")]
        [InlineData("TestData/Edit/Override/Local/Multiple/Output.xml", "TestData/Edit/Override/Local/Multiple/Diff.xml")]
        [InlineData("TestData/Edit/Override/Root/Output.xml", "TestData/Edit/Override/Root/Diff.xml")]
        public void TestApplyAll(string OutputPath, string DiffPath)
        {
            XDocument outputData = XDocument.Load(OutputPath);
            XDocument diff = XDocument.Load(DiffPath);

            XDocument testData = ApplyPatchOperation.ApplyAll(diff);

            Assert.True(XNode.DeepEquals(outputData.Root, testData.Root));
        }
    }
}
