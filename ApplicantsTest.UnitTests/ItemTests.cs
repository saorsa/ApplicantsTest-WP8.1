namespace ApplicantsTest.UnitTests
{
    using ApplicantsTest.Domain;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    /// <summary>
    /// Covering the basic scenarions for the domain specific logic.
    /// Of course the code coverage can be extended, but given the timeframe for the test application, I will just show TDD attitude. [:
    /// </summary>
    [TestClass]
    public class ItemTests
    {
        /// <summary>
        /// Test correct extraction of items from a byte data 
        /// </summary>
        [TestMethod]
        public void When_String_Data_Valid_Test_Item_Conversion()
        {
            var item = Item.Parse(byte.Parse("140"));
            Assert.AreEqual(4, item.Number);
            Assert.AreEqual(true, item.Checked);
        }
    }
}