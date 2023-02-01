using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using HuaweiMobileServices.InAppComment;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject storeCanvas;
    //[SerializeField] private GameObject nativeAdCanvas;
    //[SerializeField] private GameObject signInCanvas;
   
    //public GameObject nativeAdButton;
    
    private void Start()
    {
        Debug.Log("ShowInAppComment");
        //InAppComment.ShowInAppComment();
        
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        storeCanvas.SetActive(false);
        //signInCanvas.SetActive(false);

        
    }
    public void OnStartButton()
    {
        Time.timeScale = 1;
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        //nativeAdButton.SetActive(false);
    }

   
    public void EndTheGame()
    {
        //nativeAdButton.SetActive(true);
        Time.timeScale = 0;
        var clickToPop = GameObject.Find(Constants.gameControllerObject).GetComponent<ClickToPop>();
        clickToPop.enabled = false;
        gameOverCanvas.SetActive(true);

        AdsManager adsManager = GameObject.FindObjectOfType<AdsManager>();
        if (adsManager != null)
        {
            //adsManager.ShowAds();
        }

        PlayerPrefs.SetInt("RealMaxSpeed", 6);

        int currentBoosterCount = PlayerPrefs.GetInt("booster_count", 0);
        if(currentBoosterCount > 0)
        {
            currentBoosterCount--;
        }
            
        PlayerPrefs.SetInt("booster_count", currentBoosterCount);
        PlayerPrefs.Save();



    }
  
    
    public void OnMainMenu()
    {
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        storeCanvas.SetActive(false);

    }
    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    public void OnStoreButton()
    {
        storeCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        //nativeAdCanvas.SetActive(false);

        DisplayBoosterCount();
        AfterStoreButton();

    }

    private void AfterStoreButton()
    {
        Debug.Log("Trying to find store manager object");
        StoreManager storeManager = GameObject.FindObjectOfType<StoreManager>();

        if (storeManager == null)
            Debug.Log("Store Manager is null!");
        else
        {
            //storeManager.FillProducts();
        }
    }

    public void OnResetBelongings()
    {
        PlayerPrefs.SetInt("booster_count", 0);
        PlayerPrefs.SetInt("isSubscriptionActive", 0);
        PlayerPrefs.Save();

        

        AdsManager adsManager = GameObject.FindObjectOfType<AdsManager>();
        if (adsManager != null)
        {
            adsManager.OnAdsInitialize();
        }

        DisplayBoosterCount();
    }

    public void DisplayBoosterCount()
    {
        GameObject boosterCountValue = GameObject.Find("boosterCount");

        int currentBoosterCount = PlayerPrefs.GetInt("booster_count", 0);
        boosterCountValue.GetComponent<TextMeshProUGUI>().SetText("You Have: " + currentBoosterCount.ToString() + " Booster");
    }
}
