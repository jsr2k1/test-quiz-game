using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
	public float timer;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		if(PlayerPrefs.HasKey("Coins")==false){
			PlayerPrefs.SetInt("Coins", 300);
		}
		if(!PlayerPrefs.HasKey("CurrentLevel")){
			PlayerPrefs.SetInt("CurrentLevel", 0);
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
