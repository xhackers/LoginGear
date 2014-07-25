using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginGear.Model;
using Xamarin.Forms;

namespace LoginGear.View
{
    public class LoginOathPage : ContentPage
    {
        public static SocialInfo SocialInfo { get; set; }

        public LoginOathPage(SocialInfo socialInfo)
        {
            SocialInfo = socialInfo;
        }
    }
}
