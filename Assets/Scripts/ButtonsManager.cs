using UnityEngine;
using System.Collections;

public class ButtonsManager : MonoBehaviour
{
	//PLAY (01 Main)
	public void OnButtonPlayPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("02 Categories"));
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//RESET (01 Main)
	public void OnButtonResetPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		//PlayerPrefs.SetInt("CurrentLevel", 1);
		CategoriesManager.instance.ResetAll();
		PlayerPrefs.SetInt("SolveLetters", 50);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//CATEGORY (02 Categories)
	public void OnButtonCategoryPressed(string sCategory)
	{
		CategoriesManager.instance.SetCurrentCategory(sCategory);
		StartCoroutine(DoLoadLevel("03 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//NEXT-DEBUG (03 GameScene) 
	//De momento, lo uso para pasar directamente al siguiente nivel
	public void OnButtonDebugNextLevelPressed()
	{
		//int maxLevel = AnswersManager.instance.maxLevel;
		//int currentLevel = AnswersManager.instance.currentLevel;
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		//PlayerPrefs.SetInt("CurrentLevel", currentLevel<maxLevel ? currentLevel+1 : 1);
		CategoriesManager.instance.SetCurrentLevel(true);
		StartCoroutine(DoLoadLevel("03 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//PREV-DEBUG (03 GameScene) 
	//De momento, lo uso para pasar directamente al nivel anterior
	public void OnButtonDebugPrevLevelPressed()
	{
		//int maxLevel = AnswersManager.instance.maxLevel;
		//int currentLevel = AnswersManager.instance.currentLevel;
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		//PlayerPrefs.SetInt("CurrentLevel", currentLevel>1 ? currentLevel-1 : maxLevel);
		CategoriesManager.instance.SetCurrentLevel(false);
		StartCoroutine(DoLoadLevel("03 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//NEXT (03 GameScene-PopUp)
	public void OnButtonNextPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("03 GameScene"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//BACK (02 Categories)
	public void OnButtonBackCategoriesPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("01 Main"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//BACK (03 GameScene)
	public void OnButtonBackGameScenePressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel("02 Categories"));
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//FACEBOOK (03 GameScene)
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



