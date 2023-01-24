using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
using UnityEngine.UI;
using HuaweiMobileServices.Ads;

public class AdsDemoManager : MonoBehaviour
{
    //private Toggle testAdStatusToggle;

    #region Singleton

    public static AdsDemoManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        HMSAdsKitManager.Instance.OnRewarded = OnRewarded;
        HMSAdsKitManager.Instance.OnInterstitialAdClosed = OnInterstitialAdClosed;

        HMSAdsKitManager.Instance.ConsentOnFail = OnConsentFail;
        HMSAdsKitManager.Instance.ConsentOnSuccess = OnConsentSuccess;
        HMSAdsKitManager.Instance.RequestConsentUpdate();

        //testAdStatusToggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        //testAdStatusToggle.isOn = HMSAdsKitSettings.Instance.Settings.GetBool(HMSAdsKitSettings.UseTestAds);
        

        #region SetNonPersonalizedAd , SetRequestLocation

        var builder = HwAds.RequestOptions.ToBuilder();

        builder
            .SetConsent("tcfString")
            .SetNonPersonalizedAd((int)NonPersonalizedAd.ALLOW_ALL)
            .Build();

        bool requestLocation = true;
        var requestOptions = builder.SetConsent("testConsent").SetRequestLocation(requestLocation).Build();

        Debug.Log($"RequestOptions NonPersonalizedAds:  {requestOptions.NonPersonalizedAd}");
        Debug.Log($"Consent: {requestOptions.Consent}");

        #endregion

    }

    private void OnConsentSuccess(ConsentStatus consentStatus, bool isNeedConsent, IList<AdProvider> adProviders)
    {
        Debug.Log($"11111[HMS] AdsDemoManager OnConsentSuccess consentStatus:{consentStatus} isNeedConsent:{isNeedConsent}");
        foreach (var AdProvider in adProviders)
        {
            Debug.Log($"11111[HMS] AdsDemoManager OnConsentSuccess adproviders: Id:{AdProvider.Id} Name:{AdProvider.Name} PrivacyPolicyUrl:{AdProvider.PrivacyPolicyUrl} ServiceArea:{AdProvider.ServiceArea}");
        }
    }

    private void OnConsentFail(string desc)
    {
        Debug.Log($"11111[HMS] AdsDemoManager OnConsentFail:{desc}");
    }

    public void ShowBannerAd()
    {
        Debug.Log("11111[HMS] AdsDemoManager ShowBannerAd");

        HMSAdsKitManager.Instance.ShowBannerAd();
    }

    public void HideBannerAd()
    {
        Debug.Log("11111[HMS] AdsDemoManager HideBannerAd");

        HMSAdsKitManager.Instance.HideBannerAd();
    }

    public void ShowRewardedAd()
    {
        Debug.Log("11111[HMS] AdsDemoManager ShowRewardedAd");
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }

    public void ShowInterstitialAd()
    {
        Debug.Log("11111[HMS] AdsDemoManager ShowInterstitialAd");
        HMSAdsKitManager.Instance.ShowInterstitialAd();
    }

    public void ShowSplashImage()
    {
        Debug.Log("11111[HMS] ShowSplashImage!");

        HMSAdsKitManager.Instance.LoadSplashAd("testq6zq98hecj", SplashAd.SplashAdOrientation.PORTRAIT);
    }

    public void ShowSplashVideo()
    {
        Debug.Log("11111[HMS] ShowSplashVideo!");

        HMSAdsKitManager.Instance.LoadSplashAd("testd7c5cewoj6", SplashAd.SplashAdOrientation.PORTRAIT);
    }

    public void OnRewarded(Reward reward)
    {
        Debug.Log("11111[HMS] AdsDemoManager rewarded!");
    }

    public void OnInterstitialAdClosed()
    {
        Debug.Log("11111[HMS] AdsDemoManager interstitial ad closed");
    }

    public void SetTestAdStatus()
    {
       // HMSAdsKitManager.Instance.SetTestAdStatus(testAdStatusToggle.isOn);
        HMSAdsKitManager.Instance.SetTestAdStatus(HMSAdsKitSettings.Instance.Settings.GetBool(HMSAdsKitSettings.UseTestAds));
        HMSAdsKitManager.Instance.DestroyBannerAd();
        HMSAdsKitManager.Instance.LoadAllAds();
    }
}
