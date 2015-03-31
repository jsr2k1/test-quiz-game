﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Controlador para las letras de la respuesta
public class ButtonLetterCtrl : MonoBehaviour
{
	public int index;
	
	//Button button;
	//Image image;
	public Text text;
	ButtonPanelCtrl buttonPanelCtrl;		//Letra del panel que se ha pulsado (linkamos para poder colocarla si el usuario la borra)
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		//button = GetComponent<Button>();
		//image = GetComponent<Image>();
		text = transform.GetChild(0).GetComponent<Text>();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnEnable()
	{
		AnswersManager.OnLetterButtonPressed += SetLetter;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void OnDisable()
	{
		AnswersManager.OnLetterButtonPressed -= SetLetter;
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Si esta es la siguiente letra a rellenar -> la rellenamos
	void SetLetter()
	{
		if(index==AnswersManager.instance.currentIndex){
			text.text = AnswersManager.instance.currentLetter;
			buttonPanelCtrl = AnswersManager.instance.currentButtonPanelCtrl;
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Si se pulsa una letra de la respuesta hay que quitar esa letra y volverla a poner en el panel
	public void OnButtonPressed()
	{
		text.text = "";
		buttonPanelCtrl.SetLetterEnable();
		AnswersManager.instance.SetNextIndex();
	}
}



