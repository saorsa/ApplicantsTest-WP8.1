namespace ApplicantsTest.UnitTests
{
    using System.Linq;
    using ApplicantsTest.Repositories.Concrete;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    /// <summary>
    /// Covering the basic scenarions for the domain specific logic.
    /// Of course the code coverage can be extended, but given the timeframe for the test application, I will just show TDD attitude. [:
    /// For now I am only covering the basic sample JSON string test
    /// </summary>
    [TestClass]
    public class DataRepositoryTests
    {
        /// <summary>
        /// Test correct extraction of items from a JSON string
        /// </summary>
        [TestMethod]
        public void When_String_Data_Valid_Test_Sections_Extraction()
        {
            // ReSharper disable PossibleMultipleEnumeration
            var sections = DataRepository.GetSectionsAndItemsFromString("{ \"numbers\": [ 4, 150, 12, 21, 136, 16, 3 ]}");
            Assert.AreEqual(7, sections.SelectMany(s=>s.Items).Count());
            Assert.AreEqual(4, sections.Count());
            Assert.IsTrue(sections.Any(s=>s.Number==1));
            Assert.IsTrue(sections.Any(s=>s.Number==3));
            Assert.IsTrue(sections.Any(s=>s.Number==2));
            Assert.IsTrue(sections.Any(s=>s.Number==4));
            // ReSharper restore PossibleMultipleEnumeration

        }
    }
}