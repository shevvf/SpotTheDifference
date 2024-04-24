#if UNITY_EDITOR
#define APPODEAL
#endif

using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Difference.Android;
using UnityEngine;

public class AppodealInterstitial : IInterstitialAdListener
{
    private readonly AndroidPopup androidPopup;

    public AppodealInterstitial(AndroidPopup androidPopup)
    {
        this.androidPopup = androidPopup;
    }

    public void ShowInterstitial()
    {
#if APPODEAL
        if (Appodeal.IsLoaded(AppodealAdType.Interstitial) && Appodeal.CanShow(AppodealAdType.Interstitial, "default") && !Appodeal.IsPrecache(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealShowStyle.Interstitial);
        }
        else if (!Appodeal.IsAutoCacheEnabled(AppodealAdType.Interstitial))
        {
            Appodeal.Cache(AppodealAdType.Interstitial);
        }
#else
        OnInterstitialShown();
#endif
    }

    public void OnInterstitialLoaded(bool isPrecache)
    {
        Debug.Log("Interstitial loaded");
    }

    public void OnInterstitialFailedToLoad()
    {
        Debug.Log("Interstitial failed to load");
    }

    public void OnInterstitialShowFailed()
    {
        Debug.Log("Interstitial show failed");
    }

    public void OnInterstitialShown()
    {
#if APPODEAL
#else
        androidPopup.ShowPopup("Appodeal Interstitial", "Реклама показана. При нажатии кнопки <<ОК>> реклама закроется, игра продолжится.", OnInterstitialClosed);
#endif
        Time.timeScale = 0.001f;
        Debug.Log("Interstitial shown");
    }

    public void OnInterstitialClosed()
    {
        Time.timeScale = 1f;
        Debug.Log("Interstitial closed");
    }

    public void OnInterstitialClicked()
    {
        Debug.Log("Interstitial clicked");
    }

    public void OnInterstitialExpired()
    {
        Debug.Log("Interstitial expired");
    }
}