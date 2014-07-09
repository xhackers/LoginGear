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
        static NavigationPage _NavPage;

        public static Page GetMainPage()
        {
            var profilePage = new ProfilePage();

            _NavPage = new NavigationPage(profilePage);

            return _NavPage;
        }

        public static bool IsLoggedIn
        {
            get { return (SocialRootObject != null); }
        }


        public static SocialRootObject SocialRootObject;

        public static void ParseSocial<T>(string json)
        {
            var socialRootObject = JObject.Parse(json).ToObject<T>();
            var o = socialRootObject as SocialRootObject;
            if (o != null)
                SocialRootObject = o;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    _NavPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
