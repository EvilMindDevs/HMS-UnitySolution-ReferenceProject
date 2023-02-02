using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

namespace HuaweiServiceDemo
{
    public class AccountManager : MonoBehaviour
    {
        //public bool AnalyticEnabled;
        //public bool PushEnabled;
        //public bool LocationEnabled;
        //public bool RemoteConfigEnabled;
        //public bool AppLinkingEnabled;
        //public bool AppMessageEnabled;
        //public bool CrashEnabled;
        //public bool DatabaseEnabled;
        public bool AccountEnabled;
        public bool IAPEnabled;
        public bool AdsEnabled;

        public Transform btnParent;
        public GameObject btnCrtAuthParams;
        public GameObject btnSignIn;
        public GameObject btnSignOut;
        public TestTip testTip;


        private int index = 1;
        public int start = 0;
        public int space = 40;

        private void Start()
        {
            Initial();
        }
        public void Initial()
        {
           
           
            if (AccountEnabled)
            {
                AccountTest.GetInstance().RegisterEvent(RegistEvent);
            }
            if (IAPEnabled)
            {
                IAPTest.GetInstance().RegisterEvent(RegistEvent);
            }
            if (AdsEnabled)
            {
                AdsTest.GetInstance().RegisterEvent(RegistEvent);
            }
        }

        public void RegistEvent(string text, UnityAction action)
        {
            //var btnClone = Instantiate(btnPrefab, btnParent);
            //var btn = btnClone.GetComponent<TestBtn>();
            //btn.transform.localPosition = new Vector3(10, start - space * index, 0);
            //btn.Init(text, action);
            //index++;
            

            if (text == "Signin")
            {
                btnSignIn.GetComponent<TestBtn>().Init(text, action);
                btnSignIn.GetComponent<Button>().onClick.AddListener(action);
            }
            else if (text == "signOut")
            {
                btnSignOut.GetComponent<TestBtn>().Init(text, action);
                btnSignOut.GetComponent<Button>().onClick.AddListener(action);
            }
            else
            {
                Debug.Log("[HMS ELSE TEXT]" + text);
            }
        }
       
    }
}