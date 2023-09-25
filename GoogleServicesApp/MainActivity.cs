using Com.Google.Android.Gms.Ads;
using Com.Google.Android.Gms.Ads.Admanager;
using GoogleServicesApp.Ads;

namespace GoogleServicesApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private AdView MAdView;
        private AdManagerAdView AdManagerAdView;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);
                AdsGoogle.InitializeAdsGoogle.Initialize(this);

                MAdView = FindViewById<AdView>(Resource.Id.ad_view);
                AdsGoogle.InitAdView(MAdView, null);
                 
                AdManagerAdView = FindViewById<AdManagerAdView>(Resource.Id.multiple_ad_sizes_view);
                AdsGoogle.InitAdManagerAdView(AdManagerAdView);
                 
                AdsGoogle.Ad_RewardedInterstitial(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e); 
            } 
        }



        protected override void OnResume()
        {
            try
            {
                base.OnResume(); 
                MAdView?.Resume();
                AdManagerAdView?.Resume();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnPause()
        {
            try
            {
                base.OnPause(); 
                MAdView?.Pause();
                AdManagerAdView?.Pause();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnDestroy()
        {
            try
            {
                MAdView?.Destroy();
                AdManagerAdView?.Destroy();

                base.OnDestroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}