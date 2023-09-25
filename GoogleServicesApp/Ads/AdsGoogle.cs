using Android.Content;
using Android.Content.Res;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Anjo.Android.GoogleAds;
using App1;
using Com.Google.Android.Gms.Ads;
using Com.Google.Android.Gms.Ads.Admanager;
using Com.Google.Android.Gms.Ads.Appopen;
using Com.Google.Android.Gms.Ads.Initialization;
using Com.Google.Android.Gms.Ads.Interstitial;
using Com.Google.Android.Gms.Ads.Rewarded;
using Com.Google.Android.Gms.Ads.Rewardedinterstitial;
using Exception = System.Exception; 
using Object = Java.Lang.Object;

namespace GoogleServicesApp.Ads
{
    public static class AdsGoogle
    {
        private static int CountInterstitial;
        private static int CountRewarded;
        private static int CountAppOpen;
        private static int CountRewardedInterstitial;

        #region Interstitial
          
        private class AdMobInterstitial : AnjoInterstitialLoadCallback
        { 
            private Activity ActivityContext;
             
            public void Show(Activity context)
            {
                try
                { 
                    ActivityContext = context;
                    var requestBuilder = new AdRequest.Builder().Build();
                    InterstitialAd.Load(context, AppSettings.AdInterstitialKey, requestBuilder, this);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
           
            public override void OnAdLoaded(InterstitialAd p0)
            {
                try
                {
                    p0?.Show(ActivityContext);
                    base.OnAdLoaded(p0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //public override void OnAdLoaded(Object p0)
            //{
            //    try
            //    {
            //        if (p0 is InterstitialAd interstitialAd)
            //        {
            //            interstitialAd?.Show(ActivityContext);
            //        }
            //        base.OnAdLoaded(p0);
            //    }
            //    catch (Exception exception)
            //    {
            //        Console.WriteLine(exception);
            //    }
            //}

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                Log.Debug("Google-Ads", "I_Ad Load Failed: " + p0.Message); 
                base.OnAdFailedToLoad(p0);
            }

            
        }
          
        public static void Ad_Interstitial(Activity context)
        {
            try
            {
                AdMobInterstitial ads = new AdMobInterstitial();
                ads.Show(context);

                //switch (AppSettings.ShowAdMobInterstitial)
                //{
                //    case true:
                //    {
                //        if (CountInterstitial == AppSettings.ShowAdMobInterstitialCount)
                //        {
                //            CountInterstitial = 0;
                //            }
                //        else
                //        {
                //            Ad_AppOpenManager(context);
                //        }

                //        CountInterstitial++;
                //        break;
                //    }
                //    default:
                //        Ad_AppOpenManager(context);
                //        break;
                //}
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        #endregion
         
        #region Rewarded

        public class AdMobRewardedVideo : AnjoRewardedLoadCallback
        {
            private Activity Context;
            public void ShowAd(Activity context)
            {
                try
                {
                    Context = context;

                    AdRequest adRequest = new AdRequest.Builder().Build();
                    RewardedAd.Load(context, AppSettings.AdRewardVideoKey, adRequest, this);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            public override void OnAdLoaded(RewardedAd p0)
            {
                try
                { 
                    p0?.Show(Context, new MyRewardedAdCallback(p0));
                    base.OnAdLoaded(p0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //public override void OnAdLoaded(Object p0)
            //{
            //    try
            //    {
            //        if (p0 is RewardedAd rewardedAd)
            //        {
            //            rewardedAd?.Show(Context, new MyRewardedAdCallback(rewardedAd));
            //        }
            //        base.OnAdLoaded(p0);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //}

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                Log.Debug("Google-Ads", "I_Ad Load Failed: " + p0.Message);
                base.OnAdFailedToLoad(p0);
            }

            private class MyRewardedAdCallback : Object, IOnUserEarnedRewardListener
            {
                private RewardedAd Rad;
                public MyRewardedAdCallback(RewardedAd rad)
                {
                    Rad = rad;
                }

                public void OnUserEarnedReward(IRewardItem rewardItem)
                {
                    try
                    {
                        // Handle the reward.
                        Console.WriteLine("The user earned the reward.");
                        int rewardAmount = rewardItem.Amount;
                        string rewardType = rewardItem.Type;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public static AdMobRewardedVideo Ad_RewardedVideo(Activity context)
        {
            try
            {
                AdMobRewardedVideo ads = new AdMobRewardedVideo();
                ads.ShowAd(context);

                //switch (AppSettings.ShowAdMobRewardVideo)
                //{
                //    case true when CountRewarded == AppSettings.ShowAdMobRewardedVideoCount:
                //    {
                //        CountRewarded = 0;
                //        return ads;
                //    }
                //    case true:
                //        Ad_RewardedInterstitial(context);
                //        break;
                //    default:
                //        Ad_RewardedInterstitial(context);
                //        break;
                //}

                return null!;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null!;
            }
        }

        #endregion

        #region Banner

        public static void InitAdView(AdView mAdView, RecyclerView mRecycler)
        {
            try
            {
                switch (mAdView)
                {
                    case null:
                        return;
                }

                switch (AppSettings.ShowAdMobBanner)
                {
                    case true:
                    {
                        mAdView.Visibility = ViewStates.Visible;
                        var adRequest = new AdRequest.Builder();

                        mAdView.LoadAd(adRequest.Build());
                        mAdView.AdListener = new MyAdListener(mAdView, mRecycler);
                        break;
                    }
                    default:
                    {
                        mAdView.Pause();
                        mAdView.Visibility = ViewStates.Gone;
                      //  if (mRecycler != null) Methods.SetMargin(mRecycler, 0, 0, 0, 0);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private class MyAdListener : AdListener
        {
            private readonly AdView MAdView;
            private readonly RecyclerView MRecycler;
            public MyAdListener(AdView mAdView, RecyclerView mRecycler)
            {
                MAdView = mAdView;
                MRecycler = mRecycler;
            }

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                try
                {
                    MAdView.Visibility = ViewStates.Gone;
                  //  if (MRecycler != null) Methods.SetMargin(MRecycler, 0, 0, 0, 0);
                    base.OnAdFailedToLoad(p0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }


            public override void OnAdLoaded()
            {
                try
                {
                    MAdView.Visibility = ViewStates.Visible;

                    Resources r = Application.Context.Resources;
                    int px = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, MAdView.AdSize.Height, r.DisplayMetrics);
                   // if (MRecycler != null) Methods.SetMargin(MRecycler, 0, 0, 0, px);

                    base.OnAdLoaded();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion

        #region Manager

        public static void InitAdManagerAdView(AdManagerAdView mAdView)
        {
            try
            { 
                switch (mAdView)
                {
                    case null:
                        return;
                }

                switch (AppSettings.ShowAdMobBanner)
                {
                    case true:
                    {
                        mAdView.Visibility = ViewStates.Visible;
                        var adRequest = new AdManagerAdRequest.Builder();
                        mAdView.AdListener = new MyAdManagerAdViewListener(mAdView);
                        mAdView.LoadAd(adRequest.Build());
                        break;
                    }
                    default:
                        mAdView.Pause();
                        mAdView.Visibility = ViewStates.Gone;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private class MyAdManagerAdViewListener : AdListener
        {
            private readonly AdManagerAdView MAdView;
            public MyAdManagerAdViewListener(AdManagerAdView mAdView)
            {
                MAdView = mAdView;
            }

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                try
                {
                    MAdView.Visibility = ViewStates.Gone;
                    base.OnAdFailedToLoad(p0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            public override void OnAdLoaded()
            {
                try
                {
                    MAdView.Visibility = ViewStates.Visible;
                    base.OnAdLoaded();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion

        #region AppOpen

        public static void Ad_AppOpenManager(Activity context)
        {
            try
            {
                AppOpenManager appOpenManager = new AppOpenManager(context);
                appOpenManager.ShowAdIfAvailable();
                //switch (AppSettings.ShowAdMobAppOpen)
                //{
                //    case true:
                //    {
                //        if (CountAppOpen == AppSettings.ShowAdMobAppOpenCount)
                //        {
                //            CountAppOpen = 0;

                           
                //        }
                //        CountAppOpen++;
                //        break;
                //    }
                //}
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private class AppOpenManager : AnjoAppOpenLoadCallback
        { 
            private readonly Activity MostCurrentActivity;
            private static AppOpenAd Ad; 

            public AppOpenManager(Activity context)
            {
                try
                {
                    MostCurrentActivity = context;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
             
            public void ShowAdIfAvailable()
            {
                try
                { 
                    AdRequest request = new AdRequest.Builder().Build();
                    AppOpenAd.Load(MostCurrentActivity, AppSettings.AdAdMobAppOpenKey, request, this); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
             
            public override void OnAdLoaded(AppOpenAd p0)
            {
                try
                {
                    base.OnAdLoaded(p0);
                     
                    Ad = p0;
                    Ad.Show(MostCurrentActivity); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //public override void OnAdLoaded(Object p0)
            //{
            //    try
            //    {
            //        base.OnAdLoaded(p0);

            //        if (p0 is AppOpenAd ad)
            //        {
            //            LastAdFetchTime = CurrentTimeMillis();
            //            Ad = ad;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
            //} 
        }

        #endregion

        #region RewardedInterstitial

        public class AdMobRewardedInterstitial : AnjoRewardedInterstitialLoadCallback
        {
            private Activity Context;
            public void ShowAd(Activity context)
            {
                try
                {
                    Context = context;

                    AdRequest adRequest = new AdRequest.Builder().Build();

                    // Use an activity context to get the rewarded video instance. 
                    RewardedInterstitialAd.Load(context, AppSettings.AdRewardedInterstitialKey, adRequest, this);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            public override void OnAdLoaded(RewardedInterstitialAd p0)
            {
                try
                {
                    p0?.Show(Context, new MyUserEarnedRewardListener(p0));
                    base.OnAdLoaded(p0);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            //public override void OnAdLoaded(Object p0)
            //{
            //    try
            //    {
            //        if (p0 is RewardedInterstitialAd ad)
            //        {
            //            ad?.Show(Context, new MyUserEarnedRewardListener(ad));
            //        }
            //        base.OnAdLoaded(p0);
            //    }
            //    catch (Exception exception)
            //    {
            //        Console.WriteLine(exception);
            //    }
            //}

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                Log.Debug("Google-Ads", "I_Ad Load Failed: " + p0.Message);
                base.OnAdFailedToLoad(p0);
            }
             
            private class MyUserEarnedRewardListener : Object, IOnUserEarnedRewardListener
            {
                private RewardedInterstitialAd Rad;
                public MyUserEarnedRewardListener(RewardedInterstitialAd rad)
                {
                    Rad = rad;
                }

                public void OnUserEarnedReward(IRewardItem rewardItem)
                {
                    try
                    {
                        // Handle the reward.
                        Console.WriteLine("The user earned the reward.");
                        int rewardAmount = rewardItem.Amount;
                        string rewardType = rewardItem.Type;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            } 
        }

        public static AdMobRewardedInterstitial Ad_RewardedInterstitial(Activity context)
        {
            try
            {
                AdMobRewardedInterstitial ads = new AdMobRewardedInterstitial();
                ads.ShowAd(context);
                //switch (AppSettings.ShowAdMobRewardedInterstitial)
                //{
                //    case true when CountRewardedInterstitial == AppSettings.ShowAdMobRewardedInterstitialCount:
                //    {
                //        CountRewardedInterstitial = 0;
                       
                //        return ads;
                //    }
                //}

                return null!;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null!;
            }
        }

        #endregion
       
        public static string AndroidId = "33BE2250B43518CCDA7DE426D04EE231";
        private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1St1970).TotalMilliseconds;
        }
        public static class InitializeAdsGoogle
        {
            public static void Initialize(Context context)
            {
                try
                {
                    if (AppSettings.ShowAdMobBanner || AppSettings.ShowAdMobInterstitial || AppSettings.ShowAdMobRewardVideo || AppSettings.ShowAdMobNative || AppSettings.ShowAdMobAppOpen || AppSettings.ShowAdMobRewardedInterstitial)
                    {
                        RequestConfiguration configuration = new RequestConfiguration.Builder().SetTestDeviceIds(new List<string>(){ AndroidId }).Build();
                        MobileAds.RequestConfiguration = configuration;

                        MobileAds.Initialize(context, new MyInitializationCompleteListener());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            private class MyInitializationCompleteListener : Object, IOnInitializationCompleteListener
            {
                public void OnInitializationComplete(IInitializationStatus p0)
                {

                }
            }
        }
    }
}