namespace ApplicantsTest.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Represents a DTO for the sections object
    /// </summary>
    public class Section
    {
        /// <summary>
        /// The bit mask to apply to extract the section number
        /// </summary>
        private const byte SectionNumberBitsMask = 3;
        /// <summary>
        /// Number of bytes to shift to get the section numver
        /// </summary>
        private const byte SectionNumberShift = 0;
        /// <summary>
        /// Depending on the use case we can construct like this or through byte/string data
        /// </summary>
        /// <param name="number">The section number</param>
        /// <param name="items">The section items</param>
        public Section(int number, IEnumerable<Item> items)
        {
            Number = number;
            Items = items;
        }

        public Section(byte data)
        {
            Number = GetSectionNumberFromBytes(data);
            Items = new List<Item>
                    {
                        new Item(data)
                    };

        }
        

        /// <summary>
        /// Gets the section number from the last two least significant bits
        /// </summary>
        /// <param name="bytes">The byte data to extract the information from</param>
        /// <returns>A section number</returns>
        private static int GetSectionNumberFromBytes(byte bytes)
        {
            //I could have been a freak and add a XOR / XAND, for the sake of readibility, I decided to let the compiler figure it out itself.            
            return ((bytes >> SectionNumberShift) & SectionNumberBitsMask) + 1;
        }
        /// <summary>
        /// The section number
        /// </summary>
        public int Number
        {
            get; private set;
        }
        /// <summary>
        /// A number of items
        /// </summary>
        public IEnumerable<Item> Items
        {
            get; private set;
        }
    }
}