using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ApplicantsTest
{
    using ApplicantsTest.ViewModels;

    /// <summary>
    /// The main and only page for the applicants test application.
    /// Implements a simple MVVM pattern.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
            //Initializing the view model
            DataContext = new MainPageViewModel();
        }
    }
}
