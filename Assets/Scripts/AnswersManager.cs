﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AnswersManager : MonoBehaviour
{
	//THE SIMPSONS
	//SOUTH PARK
	//THE SMURFS
	//NINJA TURTLES
	//ASTERIX & OBELIX
	//BERT & ERNIE
	//DONALD DUCK
	//STREET FIGHTER
	//MARIO & LUIGI
	//LUCKY LUKE
	
	public static AnswersManager instance;
	
	int currentLevel=0;				//Nivel actual del usuario
	int nextIndex=0;				//Vamos numerando las letras de la respuesta para poder rellenarlas despues
	public int currentIndex;		//Indice de la letra siguiente a rellenar
	public string currentLetter;	//Letra siguiente a rellenar
	public ButtonPanelCtrl currentButtonPanelCtrl;		//Ultimo boton pulsado del panel de letras
	List<ButtonLetterCtrl> listButtonLetterCtrl;		//Lista para recorrer y buscar posibles huecos
	
	List<string> answers;
	const int totalLettersPanel=14;
	
	public GameObject panelLettersOneLine;
	public GameObject panelLettersTwoLines01;
	public GameObject panelLettersTwoLines02;
	public GameObject panelButtons;
	
	public GameObject buttonLetterAnswerPrefab;
	public GameObject buttonSpacePrefab;
	
	/*Creamos 3 listas de numeros aleatorios para colocar las letras del panel de letras
	(Al parecer, crear listas de numeros aleatorios sin repeticion no es trivial)*/
	List<int> randomNumbers1 = new List<int>(){3,11,5,1,8,0,2,6,12,9,4,7,10,13};
	List<int> randomNumbers2 = new List<int>(){8,13,9,1,10,0,2,5,12,6,4,7,3,11};
	List<int> randomNumbers3 = new List<int>(){6,10,9,3,13,11,2,5,0,8,4,7,1,12};
	List<List<int>> randomNumbers;
	
	string currentAnswer;
	string[] words;
	
	//Creamos un evento para avisar a las letras de la respuesta que un boton letra ha sido pulsado
	public delegate void LetterButtonPressed();
	public static event LetterButtonPressed OnLetterButtonPressed;

	public GameObject panelLevelCompleted;
	public Sprite[] images;
	public Image currentImage;
	public Text textCurrentLevel;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		instance = this;
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		if(PlayerPrefs.HasKey("CurrentLevel")) {
			currentLevel = PlayerPrefs.GetInt("CurrentLevel");
		}else{
			PlayerPrefs.SetInt("CurrentLevel", 0);
			currentLevel = 0;
		}

		answers = new List<string>();
		answers.Add("THE SIMPSONS");
		answers.Add("ASTERIX & OBELIX");
		answers.Add("SOUTH PARK");
		answers.Add("THE SMURFS");
		answers.Add("NINJA TURTLES");
		answers.Add("LUCKY LUKE");
		answers.Add("BERT & ERNIE");
		answers.Add("DONALD DUCK");
		
		randomNumbers = new List<List<int>>();
		randomNumbers.Add(randomNumbers1);
		randomNumbers.Add(randomNumbers2);
		randomNumbers.Add(randomNumbers3);
		
		listButtonLetterCtrl = new List<ButtonLetterCtrl>();
		
		currentAnswer = answers[currentLevel];
		words = currentAnswer.Split(' ');
		
		PopulateAnswerPanel();
		PopulateLettersPanel();

		currentImage.sprite = images[currentLevel];
		textCurrentLevel.text = (currentLevel + 1).ToString();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void PopulateAnswerPanel()
	{	
		//One word
		if(words.Length==1){
			panelLettersOneLine.SetActive(true);
			panelLettersTwoLines01.SetActive(false);
			panelLettersTwoLines02.SetActive(false);
			FillOneLine(words[0], panelLettersOneLine);
		}
		//Two or more words
		else{
			panelLettersOneLine.SetActive(false);
			panelLettersTwoLines01.SetActive(true);
			panelLettersTwoLines02.SetActive(true);
			
			//Caso especial para las respuestas que contienen "&"
			if(currentAnswer.Contains("&")){
				FillOneLine(words[0]+" &", panelLettersTwoLines01);
				FillOneLine(words[2], panelLettersTwoLines02);
			}else{
				FillOneLine(words[0], panelLettersTwoLines01);
				FillOneLine(words[1], panelLettersTwoLines02);
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Añadimos los botones con las letras de la respuesta ocultas
	void FillOneLine(string word, GameObject currentPanel)
	{
		for(int i=0;i<word.Length;i++)
		{
			GameObject buttonLetter;
			//Si es un espacio ocultamos el boton
			if(word[i]==' '){
				buttonLetter = Instantiate(buttonSpacePrefab) as GameObject;
			}
			else{
				//Si es un "&" lo mostramos
				buttonLetter = Instantiate(buttonLetterAnswerPrefab) as GameObject;
				Text text = buttonLetter.transform.GetChild(0).GetComponent<Text>();
				text.text = word[i].ToString();
				
				if(word[i]=='&'){
					buttonLetter.transform.GetComponent<Button>().interactable=false;
				}
				//Las letras normales las ocultamos
				else{	
					ButtonLetterCtrl buttonLetterCtrl = buttonLetter.GetComponent<ButtonLetterCtrl>();
					buttonLetterCtrl.index = nextIndex;
					buttonLetterCtrl.SetAnswer(text.text);
					listButtonLetterCtrl.Add(buttonLetterCtrl);
					nextIndex++;
					text.text = "";
				}
			}
			buttonLetter.transform.SetParent(currentPanel.transform);
			buttonLetter.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Añadimos las letras del panel de letras con un random sobre las letras de la respuesta (y añadimos las que falten)
	void PopulateLettersPanel()
	{
		string cleanAnswer = currentAnswer.Replace(" ", "");
		cleanAnswer = cleanAnswer.Replace("&", "");
		
		//Cogemos aleatoriamente una de las 3 listas de numeros para colocar las letras en el panel
		List<int> positions = randomNumbers[Random.Range(0,3)];
		for(int i=0;i<cleanAnswer.Length;i++){
			Button currentButton = panelButtons.transform.GetChild(positions[i]).GetComponent<Button>();
			currentButton.transform.GetChild(0).GetComponent<Text>().text = cleanAnswer[i].ToString();
		}
		//Terminamos de rellenar los botones que faltan con letras aleatorias
		for(int i=cleanAnswer.Length;i<totalLettersPanel;i++){
			int num = Random.Range(0, 26);
			char letter = (char)('A' + num);
			Button currentButton = panelButtons.transform.GetChild(positions[i]).GetComponent<Button>();
			currentButton.transform.GetChild(0).GetComponent<Text>().text = letter.ToString();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Colocamos la letra que ha pulsado el usuario en la posicion que corresponda
	public void SetLetter(string letter, ButtonPanelCtrl buttonPanelCtrl)
	{
		currentLetter = letter;
		currentButtonPanelCtrl = buttonPanelCtrl;
		
		if(OnLetterButtonPressed!=null){
			OnLetterButtonPressed();
		}
		if(CheckLevelIsFinished()){
			Debug.Log("LEVEL COMPLETED");
			panelLevelCompleted.SetActive(true);
			currentLevel++;
			PlayerPrefs.SetInt("CurrentLevel", currentLevel);
		}else{
			SetNextIndex();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Miramos cual va a ser la siguiente letra que se tiene que rellenar
	//Hay que ir con cuidado porque el usuario puede haver ido borrando letras y hay que rellenar los huecos
	public void SetNextIndex()
	{
		foreach(ButtonLetterCtrl buttonLetterCtrl in listButtonLetterCtrl){
			if(buttonLetterCtrl.text.text==""){
				currentIndex = buttonLetterCtrl.index;
				break;
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Comprobamos si el usuario ha completado el nivel comparando las letras que ha puesto con la respuesta oculta
	bool CheckLevelIsFinished()
	{
		bool correct=true;
		foreach(ButtonLetterCtrl buttonLetterCtrl in listButtonLetterCtrl){
			if(!buttonLetterCtrl.CheckAnswer()){
				correct=false;
				break;
			}
		}
		return correct;
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public void OnNextButtonPressed()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void OnBackButtonPressed()
	{
		PlayerPrefs.DeleteAll();
		Application.LoadLevel(Application.loadedLevel);
	}
}






