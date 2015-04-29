namespace ApplicantsTest.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Windows.UI.Popups;
    using ApplicantsTest.Domain;
    using ApplicantsTest.Helpers;
    using ApplicantsTest.Repositories.Concrete;

    /// <summary>
    /// Represents the view model for the only page in the application.
    /// </summary>
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            this.Sections = new ObservableCollection<Section>();
            // Initializing the value for the sake of user experience
            DataExtractionUrl = "http://foo.bragi.net/numbers.json";
        }

        /// <summary>
        /// Contains the sections extracted from a data store.
        /// According to the requirements there is no need for further abstraction of sections/items so DTOs will be used directly.
        /// </summary>
        public ObservableCollection<Section> Sections { get; private set; }
        /// <summary>
        /// The url to extract data from.
        /// </summary>
        public string DataExtractionUrl { get; set; }

        public AsyncDelegateCommand ExtractDataCommand
        {
            get
            {
                return new AsyncDelegateCommand(ExtractData);
            }
        }

        private async Task ExtractData(object obj)
        {
                                                          //Checking the obvious
                                                          if (!ConnectivityHelpers.CheckNetworkConnection())
                                                          {
                                                              var dialog = new MessageDialog("No internet connection. Please enable your mobile or WiFi network.");
                                                              await dialog.ShowAsync();
                                                              return;
                                                          }
                                                          using (var repository = new DataRepository())
                                                          {
                                                              var sections = await repository.GetSections(DataExtractionUrl);
                                                              Sections.Clear();
                                                              foreach (var section in sections)
                                                              {
                                                                  Sections.Add(section);
                                                              }
                                                          }
        }
    }
}
