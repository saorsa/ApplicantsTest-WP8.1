namespace ApplicantsTest.Repositories.Concrete
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Windows.Data.Json;
    using ApplicantsTest.Domain;

    /// <summary>
    /// A concrete implementation of the data repository (using a HTTP GET request)
    /// </summary>
    public class DataRepository : IDataRepository
    {
        public async Task<IEnumerable<Section>> GetSections(string url)
        {
            //Satisfying the requirement: Effective, performant processes by disposing of the object.
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        //Using the JsonObject to avoid external libraries like Json.NET
                        return GetSectionsAndItemsFromString(result);
                    }
                }
                
            }

        }

        public static IEnumerable<Section> GetSectionsAndItemsFromString(string result)
        {
            var data = JsonObject.Parse(result);
            //Just in case
            if (data.ContainsKey("numbers"))
            {
                var sectionsAndItems = data.GetObject()
                                           .GetNamedArray("numbers");
                //Again better safe than sorry
                if (sectionsAndItems != null
                    && sectionsAndItems.Any())
                {
                    //Will lazy loading be overengineering?
                    //Also assuming that the section number will always be byte
                    return sectionsAndItems.Select(s => new Section((byte)s.GetNumber()))
                                           .GroupBy(s => s.Number,
                                                    s => s,
                                                    (key, group) => new Section(key, @group.SelectMany(s => s.Items).ToList()))
                                                    .ToList();
                }
            }
            //Assuming that the endpoint just did not return any results (the opposite is not stated anywhere in the assignment)
            return new List<Section>();
        }

        //Satisfying the requirement: Effective, performant processes by disposing of other resources if any.
        public void Dispose()
        {
            
        }
    }
}