using System;
using Xamarin.Forms;

namespace Borrame
{
    public partial class HomePage : ContentPage
    {
        public static string clientId = "84f3c1ad-41ef-4133-abd3-230f07800055";
        public static string authority = "https://login.microsoftonline.com/common";
        public static string returnUri = "http://definityfirst-authentication";
        private const string graphResourceUri = "https://graph.windows.net";
        public static string graphApiVersion = "2013-11-08";
        //private AuthenticationResult authResult = null;

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var data = await DependencyService.Get<IAuthenticator>()
                .Authenticate(authority, graphResourceUri, clientId, returnUri);
                var userName = data.UserInfo.GivenName + " " + data.UserInfo.FamilyName;
                await DisplayAlert("Token", userName, "Ok", "Cancel");

            }
            catch (Exception ex)
            {

                string qonda = ex.ToString();
            }
        }
    }
}
