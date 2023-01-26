//using HmsPlugin;
//using HuaweiMobileServices.Ads;
//using HuaweiMobileServices.IAP;
//using HuaweiMobileServices.Id;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    public bool IsSubscriptionActive { get; private set; }

    public GameObject rewardedAdPanel;
    public GameObject nativeAdPanel;

    private bool didRewardedEarned = false;

    void Start()
    {
        nativeAdPanel.SetActive(false);
        OnAdsInitialize();        
    }
    public void OnAdsInitialize()
    {
        int thisVal = PlayerPrefs.GetInt("isSubscriptionActive");
        Debug.Log("[HMS Hilal]" + thisVal.ToString());
        Debug.Log("[HMS Hilal]" + (PlayerPrefs.GetInt("isSubscriptionActive") == 0).ToString());

        if (PlayerPrefs.GetInt("isSubscriptionActive") == 0)
        {
            nativeAdPanel.SetActive(true);

            //HMSAdsKitManager.Instance.OnRewardedAdLoaded = OnRewardedAdLoaded;
            //HMSAdsKitManager.Instance.OnRewardAdCompleted = OnRewardAdCompleted;


            //HMSAdsKitManager.Instance.ConsentOnFail = OnConsentFail;
            //HMSAdsKitManager.Instance.ConsentOnSuccess = OnConsentSuccess;
            //HMSAdsKitManager.Instance.RequestConsentUpdate();


        }
        //var builder = HwAds.RequestOptions.ToBuilder();
    }
    //private void OnConsentSuccess(ConsentStatus arg1, bool arg2, IList<AdProvider> arg3)
    //{
    //    Debug.Log("Consent Success");
    //}

    //private void OnConsentFail(string error)
    //{
    //    Debug.LogError("Consent Failed:" + error);
    //}

    //public void DisableAds()
    //{
    //    PlayerPrefs.SetInt("isSubscriptionActive", 1);
    //    nativeAdPanel.SetActive(false);
    //    HMSAdsKitManager.Instance.HideBannerAd();
        
    //}

    //public void ShowAds()
    //{
    //    if (PlayerPrefs.GetInt("isSubscriptionActive") == 0)
    //    {
    //        HMSAdsKitManager.Instance.ShowBannerAd();
    //        if (HMSAdsKitManager.Instance.IsInterstitialAdLoaded)
    //        {
    //            HMSAdsKitManager.Instance.ShowInterstitialAd();
    //        }

    //        rewardedAdPanel.SetActive(true);

    //    }
        
    //    if(PlayerPrefs.GetInt("isSubscriptionActive") == 1)
    //    {
    //        rewardedAdPanel.SetActive(false);
    //        nativeAdPanel.SetActive(false);

    //    }
    //}
    //public void OnRewardedAdButton()
    //{
    //    HMSAdsKitManager.Instance.ShowRewardedAd();
    //}
    //private void OnRewardedAdLoaded()
    //{
    //    if (!didRewardedEarned) // With this, you can prevent your users from watching your rewarded ads repeatedly. Will be reload rewarded ads after watching it.
    //        rewardedAdPanel.SetActive(true);
    //}

    //private void OnRewardAdCompleted()
    //{
    //    Debug.Log("ON REWARD COMPLETED!");
    //    rewardedAdPanel.SetActive(false);
    //    TotalScore totalScore = FindObjectOfType<TotalScore>();
    //    totalScore.DoubleScore();

    //    didRewardedEarned = true;
    //}

    //public void OnApplicationFocus(bool focus)
    //{
    //    if(focus && didRewardedEarned)
    //    {
    //        Debug.Log("app has gained focus"); 

    //    }
    //}

}
