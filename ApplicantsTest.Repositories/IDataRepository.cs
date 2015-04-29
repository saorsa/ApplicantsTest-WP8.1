
namespace ApplicantsTest.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApplicantsTest.Domain;

    /// <summary>
    /// Naming the repository that gets the data IDataRepository is brilliant, 
    /// but for the current case it does the job done. [:
    /// The interfacing is needed to satisfy my TDD wishes, although they are not explicitly stated in the requirements
    /// and can be considered overengineering.
    /// </summary>
    public interface IDataRepository : IDisposable
    {
        /// <summary>
        /// Gets the data from the specified source
        /// The url parameter satisfies the requirement: The application queries a http-address with a GET-request to receive a file.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>A list of section returned depending on the nature of the implemented repository.</returns>
        Task<IEnumerable<Section>> GetSections(string url);
    }
}
