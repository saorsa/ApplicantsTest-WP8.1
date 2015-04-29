namespace ApplicantsTest.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.UI.Popups;
    using ApplicantsTest.Annotations;
    using ApplicantsTest.Command;
    using ApplicantsTest.Domain;
    using ApplicantsTest.Helpers;
    using ApplicantsTest.Repositories.Concrete;

    /// <summary>
    /// Represents the view model for the only page in the application.
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _loadingData;

        public MainPageViewModel()
        {
            Sections = new ObservableCollection<Section>();
            // Initializing the value for the sake of user experience
            DataExtractionUrl = "http://foo.bragi.net/numbers.json";
        }

        /// <summary>
        /// Contains the sections extracted from a data store.
        /// According to the requirements there is no need for further abstraction of sections/items so DTOs will be used directly.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public ObservableCollection<Section> Sections { get; private set; }
        /// <summary>
        /// The url to extract data from.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public string DataExtractionUrl { get; set; }

        /// <summary>
        /// Provides indication on a process of loading data
        /// </summary>
        public bool LoadingData
        {
            get { return this._loadingData; }
            set
            {
                this._loadingData = value;
                OnPropertyChanged();
            }
        }

        // ReSharper disable once UnusedMember.Global
        public AsyncDelegateCommand ExtractDataCommand
        {
            get
            {
                return new AsyncDelegateCommand(ExtractData);
            }
        }
        /// <summary>
        /// The actual implementation of data extraction.
        /// </summary>
        /// <param name="obj">A command parameter</param>
        /// <returns></returns>
        private async Task ExtractData(object obj)
        {

            try
            {
                LoadingData = true;
                //Checking the obvious
                if (!ConnectivityHelpers.CheckNetworkConnection())
                {
                    var dialog = new MessageDialog("No internet connection. Please enable your mobile or WiFi network.");
                    await dialog.ShowAsync();
                    return;
                }
                Sections.Clear();
                using (var repository = new DataRepository())
                {
                    var sections = await repository.GetSections(DataExtractionUrl);
                    foreach (var section in sections)
                    {
                        Sections.Add(section);
                    }
                }
                LoadingData = false;
            }
            catch (Exception)
            {
                //Just in case
                LoadingData = false;
                throw;
            }
                                                          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
