using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;
//using GameAnalyticsSDK;
//using com.adjust.sdk;

public class IABManager : MonoBehaviour
{
#if UNITY_ANDROID || UNITY_IPHONE
	string item1 = "small_pack";
	string item2 = "medium_pack";
	string item3 = "big_pack";
#endif
#if UNITY_ANDROID
	string androidPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnxq3OtnCAilcjzntBIkTUiQS0QLeLir2uOhaHpJD0A5iC5FcwcAdGEsQLuIczAdNNALTj7me7IrwAmHpzpznP0JRIhVPqiUDx8Rs2dgsYB9U9m4TfD+XBXpYkrFdFUVXdAt5zL+gBZLXkkgBPZlBkZrG6p+zZV93DavbMZmQLkQG2ZRoFjNjH/E6MJdCPsEcR8Z5YMijb1bJzcAgKp3qZ+gCUoT98UckjA9GKKn5/c+85wjRgDtlBOO28+ElagPWTtA6QiOa76no9Cam7osB1VCYuaRbW+1sESUa71LzXMII1xOXMNlhoYZQL47gG9MJkXc3zwItKRoyld/UuCyJpwIDAQAB";
#endif

	public static IABManager instance;
	public Dictionary<string,string> dictPrices;
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		instance = this;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//En Android hay que hacer el init(), esperar a que termine y entonces hacer el QueryInventory
	//En iOS hacemos el RequestProductData directamente
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		dictPrices = new Dictionary<string, string>();

#if UNITY_ANDROID
		GoogleIAB.init(androidPublicKey);
#elif UNITY_IPHONE
		//Request product data
		var androidSkus = new string[] { item1, item2, item3 };
		var iosProductIds = new string[] { item1, item2, item3 };
		IAP.requestProductData( iosProductIds, androidSkus, productList =>
		{
			Debug.Log("IABManager: Product list received" );
			Utils.logObject(productList);
			/*
			foreach(IAPProduct product in productList){
				string s = product.currencyCode;
				dictPrices.Add(product.productId, product.currencyCode+" "+product.price);
				Debug.Log(product.productId + ": " + product.currencyCode+" "+product.price);
			}*/
		});
#endif		
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#if UNITY_ANDROID
	public void CallAndroidQueryInventory()
	{
		var androidSkus = new string[] { item1, item2, item3 };
		GoogleIAB.queryInventory(androidSkus);
	}
#endif	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void PurchaseSomething(string productId)
	{
#if UNITY_EDITOR
		DoPurchase(productId);
#else
		if(dictPrices.ContainsKey(productId)){
			IAP.purchaseConsumableProduct(productId,(didSucceed, error) =>
			{
				Debug.Log("purchasing product " + productId + " result: " + didSucceed);
				
				if(didSucceed){
					DoPurchase(productId);
				}else{
					Debug.Log("purchase error: " + error);
				}
			});
		}
#endif
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void DoPurchase(string productId)
	{
		if(productId == "small_pack") {
			int letters = PlayerPrefs.GetInt("SolveLetters");
			letters = letters + 5;
			CoinsManager.instance.solveLetters = letters;
			PlayerPrefs.SetInt("SolveLetters", letters);
		}
		if(productId == "medium_pack") {
			int letters = PlayerPrefs.GetInt("SolveLetters");
			letters = letters + 25;
			CoinsManager.instance.solveLetters = letters;
			PlayerPrefs.SetInt("SolveLetters", letters);
		}
		if(productId == "big_pack") {
			int letters = PlayerPrefs.GetInt("SolveLetters");
			letters = letters + 75;
			CoinsManager.instance.solveLetters = letters;
			PlayerPrefs.SetInt("SolveLetters", letters);
		}
	}
}



