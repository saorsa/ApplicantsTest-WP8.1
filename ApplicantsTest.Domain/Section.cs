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
        private const byte SectionNumberBitsMask = 3;
        private const byte SectionNumberShift = 0;
        /// <summary>
        /// Depending on the use case we can construct like this
        /// </summary>
        /// <param name="number">The section number</param>
        /// <param name="items">The section items</param>
        public Section(int number, IEnumerable<Item> items)
        {
            Number = number;
            Items = items;
        }

        

        /// <summary>
        /// Again assuming the bitwise conversion is an action familiar to the domain object and not concrete to the data sources.
        /// </summary>
        public static Section Parse(byte data)
        {
            return new Section(GetSectionNumberFromBytes(data), new List<Item>
                                                                       {
                                                                           Item.Parse(data)
                                                                       });
        }

        private static int GetSectionNumberFromBytes(byte bytes)
        {
            return ((bytes >> SectionNumberShift) & SectionNumberBitsMask) + 1;
        }
        public int Number
        {
            get; private set;
        }

        public IEnumerable<Item> Items
        {
            get; private set;
        }
    }
}