using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HuaweiServiceDemo
{
    public class HMSManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public void OnCanvasEnable(string str)
        {
            AccountManager accountManager = new AccountManager();
            //accountManager.Initial(str);
        }
    }
}
