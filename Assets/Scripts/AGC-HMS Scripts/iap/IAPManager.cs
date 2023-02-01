using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

namespace HuaweiServiceDemo
{
    public class IAPManager : MonoBehaviour
    {
        public Transform btnParent;
        public GameObject btnCrtAuthParams;
        public GameObject btnSignIn;
        public GameObject btnSignOut;
        public TestTip testTip;


        private int index = 1;
        public int start = 0;
        public int space = 40;

        public void IAPInitial()
        {
            
            IAPTest.GetInstance().RegisterEvent(RegistEvent);
            
            
        }

        public void RegistEvent(string text, UnityAction action)
        {
            //var btnClone = Instantiate(btnPrefab, btnParent);
            //var btn = btnClone.GetComponent<TestBtn>();
            //btn.transform.localPosition = new Vector3(10, start - space * index, 0);
            //btn.Init(text, action);
            //index++;
            Debug.Log("[HMS TEXT]" + text);

            if (text == "createAuthParam")
            {
                Debug.Log("[HMS crt icinde 1 TEXT]" + text);
                btnCrtAuthParams.GetComponent<TestBtn>().Init(text, action);
                Debug.Log("[HMS crt icinde 2 TEXT]" + text);
                btnCrtAuthParams.GetComponent<Button>().onClick.AddListener(action);
                Debug.Log("[HMS crt icinde 3 TEXT]" + text);
                Debug.Log("[HMS crt icinde 4 TEXT]" + text);
            }
            else if (text == "Signin")
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