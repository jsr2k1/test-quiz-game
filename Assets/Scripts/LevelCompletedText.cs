using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompletedText : MonoBehaviour
{
	Text text;
	
	void Awake()
	{
		text = GetComponent<Text>();
	}
	
	void Start()
	{
		text.text = "Level " + PlayerPrefs.GetInt("CurrentLevel") + " completed";
	}
}
