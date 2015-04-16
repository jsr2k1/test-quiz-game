using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Controlador para las letras del panel
public class ButtonPanelCtrl : MonoBehaviour
{
	Button button;
	Image image;
	Text text;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		text = transform.GetChild(0).GetComponent<Text>();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void OnButtonPressed()
	{
		if(!AnswersManager.instance.bFullAnswer){
			button.enabled = false;
			image.enabled = false;
			text.enabled = false;

			AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
			StartCoroutine(SetLetter());
		}
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Nos esperamos un frame para que el audio no suene con retraso
	IEnumerator SetLetter()
	{
		yield return null;
		AnswersManager.instance.SetLetter(text.text, this);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Volvemos a mostrar una letra del panel si el usuario la ha borrado de la respuesta
	public void SetLetterEnable()
	{
		button.enabled = true;
		image.enabled = true;
		text.enabled = true;
	}
}
