using System.Threading.Tasks;
using HuaweiService;
using HuaweiService.IAP;
using UnityEngine;
using TMPro;
using Task = HuaweiService.Task;

namespace HuaweiServiceDemo
{
    public class IAPTest : Test<IAPTest>
    {
        public List productInfoList;
        public GameObject[] products;
        public ProductInfo info;
        
        public override void RegisterEvent(TestEvent registerEvent)
        {
            Init();
            Debug.Log("[HMS regist event has called");
            registerEvent("is env ready", IsEnvReady);
           
        }
        public void Init(){
            var callback = new IapCallback();
            callback.setCallback(OnActivityResultCallback);
            IapActivity.setCallback(callback);
        }
        public void CreatePurchaseIntent(string type)
        {
            if (type == "Consumables"){
                IapActivity.setIntent("Consumables");
                IapActivity.setConProductId("Booster");
                IapActivity.setPriceType(0);
                IapActivity.start(new UnityPlayerActivity());
            }else if(type == "Non-Consumables"){
                IapActivity.setIntent("Non-Consumables");
                IapActivity.setConProductId("PinkColor");
                IapActivity.setPriceType(1);
                IapActivity.start(new UnityPlayerActivity());
            }else{
                IapActivity.setIntent("Subscription");
                IapActivity.setConProductId("NoAds");
                IapActivity.setPriceType(2);
                IapActivity.start(new UnityPlayerActivity());
            }
        }
        public void CreatePurchaseIntentWithPrice(string type){
            PurchaseIntentWithPriceReq req = new PurchaseIntentWithPriceReq(); 
            req.setCurrency("CNY"); 
            req.setDeveloperPayload("test");
            if(type == "Consumables"){
                req.setPriceType(0); 
            }else{
                req.setPriceType(1); 
            }
            req.setSdkChannel("1"); 
            req.setProductName("test"); 
            req.setAmount("1.00"); 
            req.setProductId("ConsumableProduct2"); 
            req.setServiceCatalog("createPurchaseIntentWithPrice"); 
            req.setCountry("CN"); 
            UnityPlayerActivity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).createPurchaseIntentWithPrice(req); 
            task.addOnSuccessListener (new HmsSuccessListener<PurchaseIntentResult> ((result) =>{
                Debug.Log("get payment data: " + result.getPaymentData());
                Debug.Log("get payment signature: " + result.getPaymentSignature());
                Status status = result.getStatus();
                if (status.hasResolution())
                {
                    status.startResolutionForResult(activity, 6666);
                }
                int returnCode = result.getReturnCode();
                if (returnCode == OrderStatusCode.ORDER_STATE_SUCCESS){
                    Debug.Log("goods purchased successfully!");
                }
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                IapApiException apiException = HmsClassHelper.ConvertObject<IapApiException>(exception.obj);
                Debug.Log("exception msg is " + exception.toString ());
                int returnCode = apiException.getStatusCode();
                switch (returnCode) { 
                case OrderStatusCode.ORDER_HWID_NOT_LOGIN: 
                case OrderStatusCode.ORDER_NOT_ACCEPT_AGREEMENT: 
                    Status status = apiException.getStatus(); 
                    if (status != null && status.hasResolution()) { 
                        status.startResolutionForResult(activity, 8888); 
                    } 
                    break; 
                case OrderStatusCode.ORDER_PRODUCT_OWNED: 
                    break; 
                default: 
                    break; 
            } 
            }));
        }
        public void ObtainOwnedPurchaseRecord(string type){
            OwnedPurchasesReq req = new OwnedPurchasesReq();
            if (type == "Consumables"){
                req.setPriceType(0);
            }else{
                req.setPriceType(2);
            }
            Task task = Iap.getIapClient(new UnityPlayerActivity()).obtainOwnedPurchaseRecord(req);
            task.addOnSuccessListener (new HmsSuccessListener<OwnedPurchasesResult> ((result) =>{
                if (result.getReturnCode() == 0){
                    Debug.Log("obtain owned purchase record successfully!");
                }
                Debug.Log("purchase history is: "+result.getItemList());
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                Debug.Log("exception msg is " + exception.toString ());
            }));
        }
        public void ObtainOwnedPurchases()
        {
            OwnedPurchasesReq ownedPurchasesReq = new OwnedPurchasesReq();
            ownedPurchasesReq.setPriceType(0);
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).obtainOwnedPurchases(ownedPurchasesReq);
            task.addOnSuccessListener (new HmsIapListener<OwnedPurchasesResult> ((result) =>
            {
                if (result != null && result.getInAppPurchaseDataList() != null)
                {
                    List inAppPurchaseData = result.getInAppPurchaseDataList();
                    Debug.Log("owned purchases result is " + inAppPurchaseData);
                    ConsumeOwnedPurchaseReq req = new ConsumeOwnedPurchaseReq();
                    string purchaseToken = "";
                    string inAppPurchaseDataStr = HmsClassHelper.ConvertObject<InAppPurchaseData>(inAppPurchaseData.get(0)).ToString();
                    InAppPurchaseData inAppPurchaseDataBean = new InAppPurchaseData(inAppPurchaseDataStr);
                    purchaseToken = inAppPurchaseDataBean.getPurchaseToken();
                    req.setPurchaseToken(purchaseToken);
                    Activity activity = new UnityPlayerActivity();
                    Debug.Log("inAppPurchaseDataBean is " + inAppPurchaseDataBean.ToString());
                    Debug.Log("purchaseToken is "+ purchaseToken);
                    Task task = Iap.getIapClient(activity).consumeOwnedPurchase(req);
                    task.addOnSuccessListener (new HmsSuccessListener<ConsumeOwnedPurchaseResult> ((result) =>{
                        if (result.getReturnCode() == 0){
                            Debug.Log("consumed goods successfully!");
                        }
                        Debug.Log("get signatureAlgorithm is "+result.getSignatureAlgorithm());
                    })).addOnFailureListener (new HmsFailureListener ((exception) => {
                        Debug.Log("exception msg is " + exception.toString ());
                    }));
                }
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                Debug.Log("exception msg is " + exception.toString ());
            }));
        }
        public void OnActivityResultCallback(int requestCode, int resultCode,AndroidJavaObject obj)
        {
            TestTip.Inst.ShowText ("OnActivityResultCallback");
            var data = new Intent();
            data.obj = obj;
            if (requestCode == 6666) {
                if (data == null) {
                    Debug.Log("data is null");
                    return;
                }
                Activity activity = new UnityPlayerActivity();
                PurchaseResultInfo purchaseResultInfo = Iap.getIapClient(activity).parsePurchaseResultInfoFromIntent(data);
                switch(purchaseResultInfo.getReturnCode()) {
                    case OrderStatusCode.ORDER_STATE_CANCEL:
                        Debug.Log("order cancel");
                        break;
                    case OrderStatusCode.ORDER_STATE_FAILED:
                    case OrderStatusCode.ORDER_PRODUCT_OWNED:
                        Debug.Log("product owned");
                        break;
                    case OrderStatusCode.ORDER_STATE_SUCCESS:
                        Debug.Log("order success!");
                        string inAppPurchaseData = purchaseResultInfo.getInAppPurchaseData();
                        string inAppPurchaseDataSignature = purchaseResultInfo.getInAppDataSignature();
                        TestTip.Inst.ShowText ("inAppPurchase data signature is " + inAppPurchaseDataSignature);
                        TestTip.Inst.ShowText ("inAppPurchase data is " + inAppPurchaseData);
                        TestTip.Inst.ShowText ("signatureAlgorithm is " + purchaseResultInfo.getSignatureAlgorithm());
                        break;
                    default:
                        break;
                }
            }
        }
        public void ObtainProductInfo(string type)
        {
            GameObject product1 = GameObject.Find("Product1");
            GameObject product2 = GameObject.Find("Product2");
            GameObject product3 = GameObject.Find("Product3");

            products[0] = product1;
            products[1] = product2;
            products[2] = product3;

            List productIdList = new List();
            ProductInfoReq req = new ProductInfoReq();
            if (type == "Consumables"){
                productIdList.add("test01");
                req.setPriceType(0);
            }else{
                productIdList.add("test03");
                req.setPriceType(2);
            }
            req.setProductIds(productIdList);
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).obtainProductInfo(req);
            task.addOnSuccessListener (new HmsSuccessListener<ProductInfoResult> ((result) =>
            {
                productInfoList = result.getProductInfoList();
                for (int i = 0; i <3; i++)
                {
                    info = HmsClassHelper.ConvertObject<ProductInfo>(productInfoList.get(i));
                    products[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = info.getProductName().ToString();
                    products[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = info.getProductDesc().ToString();
                    products[i].transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = info.getPrice().ToString() + info.getCurrency().ToString();
                    products[i].transform.GetChild(4).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = info.getProductName().ToString();

                    //("productList is " + productInfoList);
                    //("productList is " + info);
                    //("product info currency is " + info.getCurrency());
                    //("product info micros price is " + info.getMicrosPrice());
                    //("product info getOfferUsedStatus is " + info.getOfferUsedStatus());
                    //("product info getOriginalLocalPrice is " + info.getOriginalLocalPrice());
                    //("product info getOriginalMicroPrice is " + info.getOriginalMicroPrice());
                    //("product info price is " + info.getPrice());
                    //("product info price type is " + info.getPriceType());
                    //("product info product desc is " + info.getProductDesc());
                    //("product info product id is " + info.getProductId());
                    //("product info product name is " + info.getProductName());
                    //("product info status is " + info.getStatus());
                    //("product info SubSpecialPriceMicros is " + info.getSubSpecialPriceMicros());
                }

            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                Debug.Log("exception msg is " + exception.toString ());
            }));
        }
        public void IsEnvReadyTrue()
        {
            Debug.Log("[HMS IsEnvReadyTrue() has been called");
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).isEnvReady(true);
            task.addOnSuccessListener (new HmsSuccessListener<IsEnvReadyResult> ((result) =>
            {
                result.setCountry("TR");
                result.setCarrierId("1SDGTNJUI97806NJJHGN");
                Debug.Log("[HMS AppTouch scenarios");
            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                Debug.Log("[HMS exception msg is " + exception.toString ());
            }));
        }
        public void IsEnvReady()
        {
            Debug.Log("[HMS IsEnvReady() has been called");
            Activity activity = new UnityPlayerActivity();
            Task task = Iap.getIapClient(activity).isEnvReady();
            task.addOnSuccessListener (new HmsSuccessListener<IsEnvReadyResult> ((result) =>
            {
                if (result.getCarrierId() == null && result.getCountry() == null)
                {
                   Debug.Log("[HMS Non-AppTouch scenarios");
                   IsEnvReadyTrue();
                }
                else
                {
                    Debug.Log("[HMS AppTouch scenarios");
                }
                int flag = result.getAccountFlag();
                Debug.Log("[HMS account flag is " + flag);
                int returnCode = result.getReturnCode();
                Debug.Log("[HMS return code is " + returnCode);

               

            })).addOnFailureListener (new HmsFailureListener ((exception) => {
                TestTip.Inst.ShowText ("exception msg is " + exception.toString ());
            }));

            
        }
    }
}