using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HuaweiServiceDemo
{
    public class ASAccountManager : MonoBehaviour
    {
        public bool AdsEnabled;
        public bool AnalyticEnabled;
        public bool PushEnabled;
        public bool LocationEnabled;
        public bool RemoteConfigEnabled;
        public bool AppLinkingEnabled;
        public bool AppMessageEnabled;
        public bool CrashEnabled;
        public bool DatabaseEnabled;
        public bool AccountEnabled;
        public bool IAPEnabled;

        public void Start()
        {
            Initial();
        }
        public void Initial()
        {
            Screen.SetResolution(1080, 2340, true); // hack

            if (AccountEnabled)
            {
                AccountTest.GetInstance().RegisterEvent(RegistEvent);
            }
        }
        public void RegistEvent(string text, UnityAction action)
        {
           
        }

    }
}