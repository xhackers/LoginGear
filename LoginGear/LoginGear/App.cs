using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoginGear.Model;
using LoginGear.View;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace LoginGear
{
    public class App
    {
        private static INavigation _navPage;

        public static Page GetMainPage()
        {
            var profilePage = new ProfilePage();

            _navPage = profilePage.Navigation;
            return new NavigationPage(profilePage); ;
        }

        public static bool IsLoggedIn
        {
            get { return (SocialRootObject != null); }
        }


        public static SocialRootObject SocialRootObject;

        public static async void ParseSocial(string json, SocialInfo socialInfo)
        {
            SocialRootObject socialRootObject;
            if (socialInfo.GetType() == typeof(FacebookInfo))
                socialRootObject = JObject.Parse(json).ToObject<FacebookRootObject>();
            else if (socialInfo.GetType() == typeof(MicrosoftInfo))
                socialRootObject = JObject.Parse(json).ToObject<MicrosoftRootObject>();
            else// if (socialInfo.GetType() == typeof(GoogleInfo))
                socialRootObject = JObject.Parse(json).ToObject<GoogleRootObject>();
            
            var o = socialRootObject;
            if (o != null) { 
                SocialRootObject = o;
                await _navPage.PopModalAsync();
            }
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    
                    //_navPage.PopModalAsync();
                });
            }
        }
    }
}
