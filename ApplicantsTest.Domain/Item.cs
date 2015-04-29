namespace ApplicantsTest.Domain
{
    using System;

    /// <summary>
    /// A simple DTO for holding the section item
    /// </summary>
    public sealed class Item
    {
        private const byte ItemNumberBitsMask = 31;
        private const byte ItemNumberShift = 2;
        private const byte ItemStateBitsMask = 1;
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

        public int Number
        {
            get;
            private set;
        }
        
        public bool Checked
        {
            get;
            private set;
        }

        public static Item Parse(byte data)
        {
            return new Item(
                    GetItemNumber(data),
                    GetItemState(data)
                );
        }

        private static bool GetItemState(byte data)
        {
            return Convert.ToBoolean((data >> ItemStateShift) & ItemStateBitsMask);
        }

        private static int GetItemNumber(byte data)
        {
            return ((data >> ItemNumberShift) & ItemNumberBitsMask) + 1;
        }
    }
}
