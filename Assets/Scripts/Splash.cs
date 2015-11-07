using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
	public float timer;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		if(!PlayerPrefs.HasKey("CurrentLevel")){
			PlayerPrefs.SetInt("CurrentLevel", 1);
		}
		if(!PlayerPrefs.HasKey("SolveLetters")){
			PlayerPrefs.SetInt("SolveLetters", 20);
		}
		StartCoroutine("DisplayScene");
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	IEnumerator DisplayScene()
	{
		yield return new WaitForSeconds(timer);
		Application.LoadLevel("01 Main");
	}
}
