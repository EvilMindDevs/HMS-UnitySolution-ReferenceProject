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

        public void Initial()
        {
            IAPTest.GetInstance().RegisterEvent(RegistEvent);
        }

        public void RegistEvent(string text, UnityAction action)
        {
           
            Debug.Log("[HMS TEXT]" + text);

            if (text == "is env ready")
            {
                IAPTest.GetInstance().IsEnvReady();
            }
            
        }
       
        public void GetProductInfo(string type)
        {
            IAPTest.GetInstance().ObtainProductInfo(type);
        }

        public void BuyProduct(string type)
        {
            IAPTest.GetInstance().CreatePurchaseIntent(type);
        }

        public void GetPurchaseHistory(string type)
        {
            IAPTest.GetInstance().ObtainOwnedPurchaseRecord(type);
        }

    }
}