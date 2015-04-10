using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// www.utf8-chartable.de

public class LanguageManager : MonoBehaviour
{
	static int lang;
	static Dictionary<string, string[]> dict;
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		SystemLanguage currentLang = Application.systemLanguage;

		if(currentLang == SystemLanguage.Spanish){
			lang=0;
		}else{
			lang=1;
		}
		dict = new Dictionary<string, string[]>();
		fillDict();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public static string GetText(string id)
	{
		if(dict.ContainsKey(id)){
			string[] res = LanguageManager.dict[id];
			string value = res[lang];
			return value;
		}else{
			Debug.Log("No se encuentra la key en el diccionario: " + id);
			return "ID_ERROR";
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void fillDict()
	{
		dict.Add("id_play", new string[] {"JUGAR", "PLAY"});
		dict.Add("id_connect", new string[] {"CONECTAR", "CONNECT"});
		dict.Add("id_settings", new string[] {"AJUSTES", "SETTINGS"});
		dict.Add("id_quit", new string[] {"¿SALIR DEL JUEGO?", "EXIT GAME?"});
		dict.Add("id_yes", new string[] {"SI", "YES"});
		dict.Add("id_no", new string[] {"NO", "NO"});
		dict.Add("id_back", new string[] {"SALIR", "BACK"});

		dict.Add("id_answer_001", new string[] {"LOS SIMPSON", "THE SIMPSONS"});
		dict.Add("id_answer_002", new string[] {"INCRE - IBLES", "INCRE - DIBLES"});
		dict.Add("id_answer_003", new string[] {"TORTUGAS NINJA", "NINJA TURTLES"});
		dict.Add("id_answer_004", new string[] {"LOS PITUFOS", "THE SMURFS"});
		dict.Add("id_answer_005", new string[] {"MARIO & LUIGI", "MARIO & LUIGI"});
		dict.Add("id_answer_006", new string[] {"ASTERIX & OBELIX", "ASTERIX & OBELIX"});
		dict.Add("id_answer_007", new string[] {"EPI & BLAS", "BERT & ERNIE"});
		dict.Add("id_answer_008", new string[] {"PATO DONALD", "DONALD DUCK"});
		dict.Add("id_answer_009", new string[] {"LUCKY LUKE", "LUCKY LUKE"});
		dict.Add("id_answer_010", new string[] {"SOUTH PARK", "SOUTH PARK"});
		dict.Add("id_answer_011", new string[] {"TOM & JERRY", "TOM & JERRY"});
	}
}













