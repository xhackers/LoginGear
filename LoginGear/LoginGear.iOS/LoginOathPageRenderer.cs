using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoginGear.iOS;
using LoginGear.Model;
using LoginGear.View;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginOathPage), typeof(LoginOathPageRenderer))]
namespace LoginGear.iOS
{
    public class LoginOathPageRenderer : PageRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


            var auth = new OAuth2Authenticator(
                 clientId: LoginPage.clientId, // your OAuth2 client id
                scope: LoginPage.scope, // the scopes for the particular API you're accessing, delimited by "+" symbols
                authorizeUrl: LoginPage.authorizeUrl, // the auth URL for the service
                redirectUrl: LoginPage.redirectUrl); // the redirect URL for the service
            auth.ClearCookiesBeforeLogin = false;
            auth.Completed += async (sender, eventArgs) =>
            {
                // We presented the UI, so it's up to us to dimiss it on iOS.
                App.SuccessfulLoginAction.Invoke();
                
                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    
                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    try
                    {
                        Response response = await request.GetResponseAsync();
                        var json = (response.GetResponseText());

                        //Debug.WriteLine("Name: " + obj["name"]);

                        LoginGear.App.SuccessfulLoginAction.Invoke();


                        if (eventArgs.IsAuthenticated)
                        {
                            // Use eventArgs.Account to do wonderful things
                            LoginGear.App.ParseSocial<FacebookRootObject>(json);
                        }
                        else
                        {
                            // The user cancelled


                        }
                    }

                    catch (OperationCanceledException)
                    {
                        System.Diagnostics.Debug.WriteLine("Canceled");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                    
                }
                else
                {
                    // The user cancelled
                }
            };

            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
