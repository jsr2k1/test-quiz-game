using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class CoinsManager : MonoBehaviour
{
	public static CoinsManager instance;
	public int coins;
	public int solveLetters;
	public Text textCoins;
	public Text textSolveLetters;
	public Animator ShopPopUpAnimator;
	public Button buttonsAds;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		instance = this;
	
//		coins = PlayerPrefs.GetInt("Coins");
//		textCoins.text = coins.ToString();
		
		solveLetters = PlayerPrefs.GetInt("SolveLetters");
		textSolveLetters.text = solveLetters.ToString();
		
		//ads
		if(Advertisement.isSupported) {
			//Advertisement.allowPrecache = true; //Obsolete
			#if UNITY_ANDROID
			Advertisement.Initialize("84320", false/*testMode*/); //Android
			#else
			Advertisement.Initialize("...RELLENAR!!", false/*testMode*/); //iOS
			#endif
		}else{
			Debug.Log("Platform not supported");
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Update()
	{
		if(Advertisement.IsReady()){
			buttonsAds.interactable = true;
		}else{
			buttonsAds.interactable = false;
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public void OnButtonCoinsPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void OnButtonShopClosePressed()
	{
		ShopPopUpAnimator.SetTrigger("HidePopUp");
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//SOLVE LETTER (02 GameScene)
	public void OnButtonSolveLetterPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		
		if(solveLetters>0){
			solveLetters--;
			PlayerPrefs.SetInt("SolveLetters", solveLetters);
			textSolveLetters.text = solveLetters.ToString();
			AnswersManager.instance.SolveOneLetter();
		}else{
			ShopPopUpAnimator.SetTrigger("ShowPopUp");
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void OnButtonAdsPressed()
	{
		if(Advertisement.IsReady()){
			Advertisement.Show(null, new ShowOptions { /*pause = false,*/ resultCallback = ResultCallback } );
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void ResultCallback(ShowResult result)
	{
		//Debug.Log("-_-_ ResultCallback: " + result.ToString());
		
		if(result == ShowResult.Finished){
			solveLetters = PlayerPrefs.GetInt("SolveLetters");
			solveLetters++;
			textSolveLetters.text = solveLetters.ToString();
			ShopPopUpAnimator.SetTrigger("HidePopUp");
		}
	}	
}




