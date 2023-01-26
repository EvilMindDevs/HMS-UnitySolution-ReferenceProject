//using HuaweiMobileServices.Id;
//using HuaweiMobileServices.Utils;
//using HuaweiMobileServices.Game;
using UnityEngine;
using UnityEngine.UI;
//using HmsPlugin;
using System;
using TMPro;


public class AccountManager : MonoBehaviour
{
    private readonly string TAG = "[HMS] AccountKitDemo ";

    [SerializeField]
    private TextMeshProUGUI textStatus;

    private const string NOT_LOGGED_IN = "No user logged in";
    private const string LOGGED_IN = "{0} is logged in";
    private const string LOGIN_ERROR = "Error or cancelled login";

    public static Action<string> AccountKitLog;

    #region Singleton

    public static AccountManager Instance { get; private set; }
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

    void Start()
    {
        //HMSAccountKitManager.Instance.OnSignInSuccess = OnLoginSuccess;
        //HMSAccountKitManager.Instance.OnSignInFailed = OnLoginFailure;

        AccountKitLog?.Invoke(NOT_LOGGED_IN);

    }

    public void OnAccountLogin()
    {
        Debug.Log(TAG + "LogIn");

        //HMSAccountKitManager.Instance.SignIn();
    }
    public void SilentSignIn()
    {
        Debug.Log(TAG + "SilentSignIn");

        //HMSAccountKitManager.Instance.SilentSignIn();
    }

    public void LogOut()
    {
        Debug.Log(TAG + "LogOut");

        //HMSAccountKitManager.Instance.SignOut();

        AccountKitLog?.Invoke(NOT_LOGGED_IN);
    }

    //public void OnLoginSuccess(AuthAccount authHuaweiId)
    //{
    //    textStatus.SetText("Welcome " + authHuaweiId.DisplayName);
    //    AccountKitLog?.Invoke(string.Format(LOGGED_IN, authHuaweiId.DisplayName));

    //    //Init IAP after OnSignInSuccess
    //    StoreManager storeManager = gameObject.AddComponent<StoreManager>();
    //    storeManager.InitIAP();
        

    //    HMSGameServiceManager.Instance.Init();
    //}

    //public void OnLoginFailure(HMSException error)
    //{
    //    AccountKitLog?.Invoke(LOGIN_ERROR);
    //}
}
