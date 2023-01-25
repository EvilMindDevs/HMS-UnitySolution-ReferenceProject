//using HmsPlugin;
//using HuaweiMobileServices.IAP;
//using HuaweiMobileServices.Utils;
//using HuaweiMobileServices.Base;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    public static Action<string> IAPLog;

    //private IList<ProductInfoResult> productInfos = new List<ProductInfoResult>();

    private int Counter = 0;

    public bool isIAPavailable { get; private set; }

    private void Start()
    {
        //HMSIAPManager.Instance.OnBuyProductSuccess = OnBuyProductSuccess;

        //HMSIAPManager.Instance.OnCheckIapAvailabilitySuccess += OnCheckIapAvailabilitySuccess;
        //HMSIAPManager.Instance.OnCheckIapAvailabilityFailure += OnCheckIapAvailabilityFailure;

        //HMSIAPManager.Instance.OnBuyProductFailure = OnBuyProductFailure;

       
    }

    public void BuyProduct(string productId)
    {
    
        //HMSIAPManager.Instance.BuyProduct(productId);
       
    }
    private void OnBuyProductFailure(int obj)
    {
        Debug.LogError("[HMSIAP]OnBuyProductFailure:" + obj);

        //if (obj == OrderStatusCode.ORDER_PRODUCT_OWNED)
        //{

        //    HMSIAPManager.Instance.OnObtainOwnedPurchasesSuccess = OnObtainOwnedPurchasesSuccess;
        //    HMSIAPManager.Instance.ObtainOwnedPurchases(PriceType.IN_APP_NONCONSUMABLE);
           
        //}
    }

   
    //private void OnConsumeProduct(PriceType priceType)
    //{
    //    IIapClient iapClient = Iap.GetIapClient();

    //    // Construct an OwnedPurchasesReq object.
    //    OwnedPurchasesReq ownedPurchasesReq = new OwnedPurchasesReq();
    //    // priceType: 0: consumable; 1: non-consumable; 2: subscription
    //    ownedPurchasesReq.PriceType = priceType;

    //    ITask<OwnedPurchasesResult> task = iapClient.ObtainOwnedPurchases(ownedPurchasesReq);
    //    task.AddOnSuccessListener((result) => {
    //        if (result != null && result.InAppPurchaseDataList != null)
    //        {
    //            for (int i = 0; i < result.InAppPurchaseDataList.Count; i++)
    //            {
    //                InAppPurchaseData inAppPurchaseData = result.InAppPurchaseDataList[i];

    //                ConsumeOwnedPurchaseReq consumeOwnedPurchaseReq = new ConsumeOwnedPurchaseReq
    //                {
    //                    PurchaseToken = inAppPurchaseData.PurchaseToken
    //                };
    //                ITask<ConsumeOwnedPurchaseResult> consumeTask = iapClient.ConsumeOwnedPurchase(consumeOwnedPurchaseReq);
    //                consumeTask.AddOnSuccessListener((consumeResult) => {
    //                    // Consume the product successfully.
    //                    Debug.Log("[IAPManager]: Consume the product successfully.");
    //                }).AddOnFailureListener((exception) => {
    //                    // Consume the product failed.
    //                    Debug.Log("[IAPManager]: Consume the product failed.");
    //                });
    //            }

    //        }
    //    }).AddOnFailureListener((exception) => {
    //        // Handle the exception.
    //        Debug.Log("[IAPManager]: Handle the exception.");
    //    });
    //}

    //private void OnBuyProductSuccess(PurchaseResultInfo obj)
    //{
    //    Debug.Log("OnBuyProductSuccess:" + obj.InAppPurchaseData.ProductName);

    //    if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.NoAds)
    //    {
    //        AdsManager adsManager = gameObject.AddComponent<AdsManager>();
    //        adsManager.DisableAds();
    //        Debug.Log("NOADS HAS PURCHASED");
            
            
    //    }
    //    else if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.Booster)
    //    {
    //        int currentBoosterCount = PlayerPrefs.GetInt("booster_count", 0);
    //        currentBoosterCount++;
    //        PlayerPrefs.SetInt("booster_count", currentBoosterCount);
    //        PlayerPrefs.Save();
    //        Debug.Log("BOOSTER HAS PURCHASED");

    //        UIController uIController = FindObjectOfType<UIController>();
    //        uIController.DisplayBoosterCount();

    //    }
    //    else if (obj.InAppPurchaseData.ProductId == HMSIAPConstants.PinkColor)
    //    {
    //        BalloonColor balloonColor = new BalloonColor();
    //        balloonColor.UnlockColor();
    //        Debug.Log("PINK COLOR HAS PURCHASED");
    //    }
       
    //}
  
    //private void OnObtainOwnedPurchasesSuccess(OwnedPurchasesResult result)
    //{
    //    if (result != null)
    //    {
    //        foreach (var obj in result.InAppPurchaseDataList)
    //        {
                                      
    //            Debug.Log("[HMS IAP MANAGER] OnObtainOwnedPurchasesSuccess icerisinde");
    //            HMSIAPManager.Instance.ConsumePurchaseWithToken(obj.PurchaseToken);

    //        }
    //    }


    //}

    //internal void InitIAP()
    //{
    //    //Uncheck Init on start box in IAP page
    //    HMSIAPManager.Instance.OnCheckIapAvailabilitySuccess = OnCheckIapAvailabilitySuccess;
    //    HMSIAPManager.Instance.OnObtainProductInfoSuccess = OnObtainProductInfoSuccess;
    //    HMSIAPManager.Instance.CheckIapAvailability();
    //}

    //public void OnObtainProductInfoSuccess(IList<ProductInfoResult> list)
    //{
    //    Debug.Log("productInfos infoyu dolduruyoruz :)" + list.Count);
    //    if(list != null)
    //    {
    //        foreach (var item in list)
    //        {
    //            productInfos.Add(item);
                
    //        }

    //    }
                
    //}

    //public void FillProducts()
    //{
    //    GameObject product1 = GameObject.Find("Product1");
    //    GameObject product2 = GameObject.Find("Product2");
    //    GameObject product3 = GameObject.Find("Product3");

    //    if (productInfos == null)
    //    {
    //        Debug.Log("PRODUCT INFOS NULL");
    //    }
    //    foreach (ProductInfoResult res in productInfos)
    //        for (int i = 0; i < res.ProductInfoList.Count; i++)
    //        {
    //            switch (Counter++)
    //            {
    //                case 0:
    //                    FillProduct(product1, res.ProductInfoList[i]);
    //                    break;
    //                case 1:
    //                    FillProduct(product2, res.ProductInfoList[i]);
    //                    break;
    //                case 2:
    //                    FillProduct(product3, res.ProductInfoList[i]);
    //                    break;
    //            }
    //        }
    //}

    //private void FillProduct(GameObject product, ProductInfo productInfo)
    //{
    //    if (product == null)
    //        Debug.Log("product is null");

    //    Debug.Log("FillProduct" + product.name + " - productInfo" + productInfo.ProductName);
    //    product.SetActive(true);
    //    if (product.transform.childCount > 0)
    //    {
    //        product.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = productInfo.ProductName;
    //        product.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = productInfo.ProductDesc;
    //        product.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = productInfo.Price + productInfo.Currency;
    //        product.transform.GetChild(4).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = productInfo.ProductName;
    //        product.transform.GetChild(4).gameObject.GetComponent<Button>().onClick.AddListener(delegate { BuyProduct(productInfo.ProductId); });

    //    }
    //    else
    //        Debug.Log("product doesnt have any child");
    

    //}
    //private void OnCheckIapAvailabilityFailure(HMSException obj)
    //{
        
    //    IAPLog?.Invoke("IAP is not ready.");
    //}

    //private void OnCheckIapAvailabilitySuccess()
    //{
    //    isIAPavailable = true;
    //    OnConsumeProduct(PriceType.IN_APP_CONSUMABLE);
    //    IAPLog?.Invoke("IAP is ready.");
    //}
   
}
