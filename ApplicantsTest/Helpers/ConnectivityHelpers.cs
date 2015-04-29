namespace ApplicantsTest.Helpers
{
    using System.Net.NetworkInformation;
    using Windows.Networking.Connectivity;

    public class ConnectivityHelpers
    {
        public static bool CheckNetworkConnection()
        {
            var isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (!isConnected)
            {
                return false;
            }
            var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            var connection = internetConnectionProfile.GetNetworkConnectivityLevel();
            return connection != NetworkConnectivityLevel.None && connection != NetworkConnectivityLevel.LocalAccess;
        }

    }
}
