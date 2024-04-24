#if UNITY_EDITOR
#define APPODEAL
#endif

using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using Difference.Android;
using System.Collections.Generic;
using UnityEngine;

public class AppodealCore : IAppodealInitializationListener
{
    private readonly AppodealInterstitial appodealInterstitial;
    private readonly AndroidPopup androidPopup;

    private const string APP_KEY = "f3030f603c1d5d3cb372d59941024417200b601e5cebed60";
    private const int AD_TYPES = AppodealAdType.Interstitial;

    public AppodealCore(AppodealInterstitial appodealInterstitial, AndroidPopup androidPopup)
    {
        this.appodealInterstitial = appodealInterstitial;
        this.androidPopup = androidPopup;
    }

    public void Initialize()
    {
#if APPODEAL
        Appodeal.Initialize(APP_KEY, AD_TYPES, this);
#else
        OnInitializationFinished(null);
#endif
    }

    public void OnInitializationFinished(List<string> errors)
    {
#if APPODEAL
        Appodeal.SetInterstitialCallbacks(appodealInterstitial);
#else
        androidPopup.ShowPopup("Appodeal Initialization", "Инициализация Appodeal завершена");
#endif
        Debug.Log("Appodeal Initialization Finished");
    }
}