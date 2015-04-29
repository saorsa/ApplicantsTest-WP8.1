namespace ApplicantsTest.Domain
{
    using System;

    /// <summary>
    /// A simple DTO for holding the section item
    /// </summary>
    public sealed class Item
    {
        /// <summary>
        /// The bit mask to apply to extract the item number
        /// </summary>
        private const byte ItemNumberBitsMask = 31;
        /// <summary>
        /// Number of bytes to shift to extract the item number
        /// </summary>
        private const byte ItemNumberShift = 2;
        /// <summary>
        /// The bit mask to apply to extract the item checked state
        /// </summary>
        private const byte ItemStateBitsMask = 1;
        /// <summary>
        /// Number of bytes to shift to extract the item state
        /// </summary>
        private const byte ItemStateShift = 7;
        /// <summary>
        /// Again as mentioned before we can construct with concrete parameters
        /// </summary>
        /// <param name="number">Section number</param>
        /// <param name="checked">Section </param>
        public Item(int number, bool @checked)
        {
            Checked = @checked;
            Number = number;
        }
        /// <summary>
        /// Construction using the byte data
        /// </summary>
        public Item(byte data)
        {
            Checked = GetItemState(data);
            Number = GetItemNumber(data);
        }
        /// <summary>
        /// Represents the section number
        /// </summary>
        public int Number
        {
            get;
            private set;
        }
        /// <summary>
        /// Represents the section "Checked" state
        /// </summary>
        public bool Checked
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the "Changed" state of an item
        /// </summary>
        /// <param name="data">The byte data</param>
        /// <returns>True/false for checked/not checked</returns>
        private static bool GetItemState(byte data)
        {
            return Convert.ToBoolean((data >> ItemStateShift) & ItemStateBitsMask);
        }
        /// <summary>
        /// Gets the "Item number" property of an item
        /// </summary>
        /// <param name="data">The byte data</param>
        /// <returns>The actual item number</returns>
        private static int GetItemNumber(byte data)
        {
            //I could have been a freak and add a XOR / XAND, for the sake of readibility, I decided to let the compiler figure it out itself.
            return ((data >> ItemNumberShift) & ItemNumberBitsMask) + 1;
        }
    }
}
