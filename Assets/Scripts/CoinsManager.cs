using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinsManager : MonoBehaviour
{
	public static CoinsManager instance;
	public int coins;
	public int solveLetters;
	public Text textCoins;
	public Text textSolveLetters;
	//int priceLetter = 50;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		instance = this;
	
		coins = PlayerPrefs.GetInt("Coins");
		textCoins.text = coins.ToString();
		
		solveLetters = PlayerPrefs.GetInt("SolveLetters");
		textSolveLetters.text = solveLetters.ToString();
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public void OnButtonCoinsPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
			//TODO: Mostrar popup de conseguir monedas
		}
	}
}
