using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SolveLetterButtonCtrl : MonoBehaviour
{
	Text textComp;
	
	void Awake()
	{
		textComp = GetComponent<Text>();
	}
	
	void Update()
	{
		textComp.text = CoinsManager.instance.solveLetters.ToString();
	}
}
