﻿using UnityEngine;
using System.Collections;

public class ButtonsManager : MonoBehaviour
{
	//PLAY (01 Main)
	public void OnButtonPlayPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("02 GameScene"));
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//RESET (01 Main)
	public void OnButtonResetPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		PlayerPrefs.SetInt("CurrentLevel", 1);
		PlayerPrefs.SetInt("SolveLetters", 50);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//COINS (02 GameScene) 
	//De momento, lo uso para pasar directamente al siguiente nivel
	public void OnButtonDebugNextLevelPressed()
	{
		int maxLevel = AnswersManager.instance.maxLevel;
		int currentLevel = AnswersManager.instance.currentLevel;
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		PlayerPrefs.SetInt("CurrentLevel", currentLevel<maxLevel ? currentLevel+1 : 1);
		StartCoroutine(DoLoadLevel("02 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//COINS (02 GameScene) 
	//De momento, lo uso para pasar directamente al nivel anterior
	public void OnButtonDebugPrevLevelPressed()
	{
		int maxLevel = AnswersManager.instance.maxLevel;
		int currentLevel = AnswersManager.instance.currentLevel;
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		PlayerPrefs.SetInt("CurrentLevel", currentLevel>1 ? currentLevel-1 : maxLevel);
		StartCoroutine(DoLoadLevel("02 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//NEXT (02 GameScene-PopUp)
	public void OnButtonNextPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("02 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//BACK (02 GameScene)
	public void OnButtonBackPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("01 Main"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//FACEBOOK (02 GameScene)
	public void OnButtonFacebookPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		//TODO: Colgar una pregunta a los amigos de Facebook
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	IEnumerator DoLoadLevel(string level)
	{
		yield return null;
		Application.LoadLevel(level);
	}
}