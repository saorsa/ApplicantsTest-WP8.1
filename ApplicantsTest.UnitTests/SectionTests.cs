using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace ApplicantsTest.UnitTests
{
    using System.Linq;
    using ApplicantsTest.Domain;

    [TestClass]
    public class SectionTests
    {
        [TestMethod]
        public void When_String_Data_Valid_Test_Section_Creation()
        {
            var section = Section.Parse(140);
            Assert.AreEqual(1, section.Number,"Incorrect section number extraction.");
            Assert.IsNotNull(section.Items, "Incorrect Items extraction");
            Assert.AreEqual(1, section.Items.Count(), "Incorrect Items extraction");
        }
    }
}
