using System;
using Android.Runtime;
using Com.Google.Android.Gms.Ads.Appopen;
using Com.Google.Android.Gms.Ads.Interstitial;
using Com.Google.Android.Gms.Ads.Rewarded;
using Com.Google.Android.Gms.Ads.Rewardedinterstitial;

namespace Anjo.Android.GoogleAds
{
    public abstract class AnjoInterstitialLoadCallback : Com.Google.Android.Gms.Ads.Interstitial.InterstitialAdLoadCallback
    {
        private static Delegate cb_onAdLoaded;

        private static Delegate GetOnInterstitialAdLoadedHandler()
        {
            if (cb_onAdLoaded is null)
            {
                cb_onAdLoaded = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_onAdLoaded);
            }
            return cb_onAdLoaded;
        }

        private static void n_onAdLoaded(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            AnjoInterstitialLoadCallback thisobject = GetObject<AnjoInterstitialLoadCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            InterstitialAd resultobject = GetObject<InterstitialAd>(native_p0, JniHandleOwnership.DoNotTransfer);
            thisobject.OnAdLoaded(resultobject);
        }

        [Register("onAdLoaded", "(Lcom/google/android/gms/ads/interstitial/InterstitialAd;)V", "GetOnInterstitialAdLoadedHandler")]
        public virtual void OnAdLoaded(InterstitialAd p0)
        {

        }
    }

    public abstract class AnjoRewardedLoadCallback : Com.Google.Android.Gms.Ads.Rewarded.RewardedAdLoadCallback
    {
        private static Delegate cb_onAdLoaded;

        private static Delegate GetOnRewardedAdLoadedHandler()
        {
            if (cb_onAdLoaded is null)
            {
                cb_onAdLoaded = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_onAdLoaded);
            }
            return cb_onAdLoaded;
        }

        private static void n_onAdLoaded(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            AnjoRewardedLoadCallback thisobject = GetObject<AnjoRewardedLoadCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            RewardedAd resultobject = GetObject<RewardedAd>(native_p0, JniHandleOwnership.DoNotTransfer);
            thisobject.OnAdLoaded(resultobject);
        }

        [Register("onAdLoaded", "(Lcom/google/android/gms/ads/rewarded/RewardedAd;)V", "GetOnRewardedAdLoadedHandler")]
        public virtual void OnAdLoaded(RewardedAd p0)
        {

        }
    }


    public abstract class AnjoAppOpenLoadCallback : AppOpenAd.AppOpenAdLoadCallback
    {
        private static Delegate cb_onAdLoaded;

        private static Delegate GetOnAppOpenAdLoadedHandler()
        {
            if (cb_onAdLoaded is null)
            {
                cb_onAdLoaded = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_onAdLoaded);
            }
            return cb_onAdLoaded;
        }

        private static void n_onAdLoaded(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            AnjoAppOpenLoadCallback thisobject = GetObject<AnjoAppOpenLoadCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            AppOpenAd resultobject = GetObject<AppOpenAd>(native_p0, JniHandleOwnership.DoNotTransfer);
            thisobject.OnAdLoaded(resultobject);
        }

        [Register("onAdLoaded", "(Lcom/google/android/gms/ads/appopen/AppOpenAd;)V", "GetOnAppOpenAdLoadedHandler")]
        public virtual void OnAdLoaded(AppOpenAd p0)
        {

        }
    }

    public abstract class AnjoRewardedInterstitialLoadCallback : Com.Google.Android.Gms.Ads.Rewardedinterstitial.RewardedInterstitialAdLoadCallback
    {
        private static Delegate cb_onAdLoaded;

        private static Delegate GetOnRewardedInterstitialAdLoadedHandler()
        {
            if (cb_onAdLoaded is null)
            {
                cb_onAdLoaded = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_onAdLoaded);
            }
            return cb_onAdLoaded;
        }

        private static void n_onAdLoaded(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            AnjoRewardedInterstitialLoadCallback thisobject = GetObject<AnjoRewardedInterstitialLoadCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            RewardedInterstitialAd resultobject = GetObject<RewardedInterstitialAd>(native_p0, JniHandleOwnership.DoNotTransfer);
            thisobject.OnAdLoaded(resultobject);
        }

        [Register("onAdLoaded", "(Lcom/google/android/gms/ads/rewardedinterstitial/RewardedInterstitialAd;)V", "GetOnRewardedInterstitialAdLoadedHandler")]
        public virtual void OnAdLoaded(RewardedInterstitialAd p0)
        {

        }
    }


}
