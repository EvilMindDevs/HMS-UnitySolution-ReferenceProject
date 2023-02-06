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
        //public Transform btnParent;
        public GameObject noAds;
        public GameObject booster;
        public GameObject pinkColor;


        public void Initial()
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

            //if (text == "obtain Consumables Product Info")
            //{
            //    Debug.Log("[HMS crt icinde 1 TEXT]" + text);
            //    obtainConsumablesProductInfo.GetComponent<TestBtn>().Init(text, action);
            //    Debug.Log("[HMS crt icinde 2 TEXT]" + text);
            //    obtainConsumablesProductInfo.GetComponent<Button>().onClick.AddListener(action);
            //    Debug.Log("[HMS crt icinde 3 TEXT]" + text);
            //    Debug.Log("[HMS crt icinde 4 TEXT]" + text);
            //}
            //else if (text == "obtain Subscription Product Info")
            //{
            //    obtainSubscriptionProductInfo.GetComponent<TestBtn>().Init(text, action);
            //    obtainSubscriptionProductInfo.GetComponent<Button>().onClick.AddListener(action);
            //}
            //else if (text == "is env ready")
            //{
            //    isenvready.GetComponent<TestBtn>().Init(text, action);
            //    isenvready.GetComponent<Button>().onClick.AddListener(action);
            //}
           
            //else
            //{
            //    Debug.Log("[HMS ELSE TEXT]" + text);
            //}
        }
       

    }
}