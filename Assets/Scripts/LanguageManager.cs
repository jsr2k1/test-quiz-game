using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// www.utf8-chartable.de

public class DictEntry
{
	public LanguageManager.Categories category;
	public string answer_ES;
	public string answer_EN;

	public DictEntry(LanguageManager.Categories _category, string _answer_ES, string _answer_EN)
	{
		category = _category;
		answer_ES = _answer_ES;
		answer_EN = _answer_EN;
	}
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

public class LanguageManager : MonoBehaviour
{
	static int lang;
	static Dictionary<string, DictEntry> dict;

	public enum Categories{
		ANIMATION,
		CARTOONS,
		COMICS,
		MOVIES_AND_TV,
		VIDEOGAMES,
		SUPERHEROES,
		NULL
	};

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		dict = new Dictionary<string, DictEntry>();
		fillDict();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public static string GetText(string id)
	{
		if(dict.ContainsKey(id)){
			if(Application.systemLanguage == SystemLanguage.Spanish){
				return dict[id].answer_ES;
			}
			else if(Application.systemLanguage == SystemLanguage.English){
				return dict[id].answer_EN;
			}else{
				return "ERROR";
			}
		}else{
			Debug.Log("No se encuentra la key en el diccionario: " + id);
			return "ID_ERROR";
		}
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public static string GetCategory(string id)
	{
		if(dict.ContainsKey(id)){
			if(dict[id].category == Categories.ANIMATION){
				return GetText("id_animation");
			}
			else if(dict[id].category == Categories.CARTOONS){
				return GetText("id_cartoons");
			}
			else if(dict[id].category == Categories.COMICS){
				return GetText("id_comics");
			}
			else if(dict[id].category == Categories.MOVIES_AND_TV){
				return GetText("id_movies");
			}
			else if(dict[id].category == Categories.VIDEOGAMES){
				return GetText("id_videogames");
			}
			else if(dict[id].category == Categories.SUPERHEROES){
				return GetText("id_superheroes");
			}
			else{
				return "ERROR";
			}
		}else{
			Debug.Log("No se encuentra la key en el diccionario: " + id);
			return "ID_ERROR";
		}
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void fillDict()
	{
		//Etiquetas botones
		dict.Add("id_play", new DictEntry(Categories.NULL, "JUGAR", "PLAY"));
		dict.Add("id_connect", new DictEntry(Categories.NULL, "CONECTAR", "CONNECT"));
		dict.Add("id_settings", new DictEntry(Categories.NULL, "AJUSTES", "SETTINGS"));
		dict.Add("id_quit", new DictEntry(Categories.NULL, "¿SALIR DEL JUEGO?", "EXIT GAME?"));
		dict.Add("id_yes", new DictEntry(Categories.NULL, "SI", "YES"));
		dict.Add("id_no", new DictEntry(Categories.NULL, "NO", "NO"));
		dict.Add("id_back", new DictEntry(Categories.NULL, "SALIR", "BACK"));

		//Categorias
		dict.Add("id_animation", new DictEntry(Categories.NULL, "ANIMACI\u00D3N", "ANIMATION"));
		dict.Add("id_cartoons", new DictEntry(Categories.NULL, "DIBUJOS ANIMADOS", "CARTOONS"));
		dict.Add("id_comics", new DictEntry(Categories.NULL, "COMICS", "COMICS"));
		dict.Add("id_movies", new DictEntry(Categories.NULL, "CINE & TV", "MOVIES & TV"));
		dict.Add("id_videogames", new DictEntry(Categories.NULL, "VIDEOJUEGOS", "VIDEOGAMES"));
		dict.Add("id_superheroes", new DictEntry(Categories.NULL, "SUPERHEROES", "SUPERHEROES"));
		
		//Respuestas
		dict.Add("id_answer_001", new DictEntry(Categories.CARTOONS, "LOS SIMPSON", "THE SIMPSONS"));
		dict.Add("id_answer_002", new DictEntry(Categories.ANIMATION, "INCRE - IBLES", "INCRE - DIBLES"));
		dict.Add("id_answer_003", new DictEntry(Categories.CARTOONS, "TORTUGAS NINJA", "NINJA TURTLES"));
		dict.Add("id_answer_004", new DictEntry(Categories.CARTOONS, "LOS PITUFOS", "THE SMURFS"));
		dict.Add("id_answer_005", new DictEntry(Categories.VIDEOGAMES, "MARIO & LUIGI", "MARIO & LUIGI"));
		dict.Add("id_answer_006", new DictEntry(Categories.COMICS, "ASTERIX & OBELIX", "ASTERIX & OBELIX"));
		dict.Add("id_answer_007", new DictEntry(Categories.MOVIES_AND_TV, "EPI & BLAS", "BERT & ERNIE"));
		dict.Add("id_answer_008", new DictEntry(Categories.CARTOONS, "PATO DONALD", "DONALD DUCK"));
		dict.Add("id_answer_009", new DictEntry(Categories.CARTOONS, "LUCKY LUKE", "LUCKY LUKE"));
		dict.Add("id_answer_010", new DictEntry(Categories.CARTOONS, "SOUTH PARK", "SOUTH PARK"));
		dict.Add("id_answer_011", new DictEntry(Categories.CARTOONS, "TOM & JERRY", "TOM & JERRY"));
		dict.Add("id_answer_012", new DictEntry(Categories.SUPERHEROES, "BATMAN & ROBIN", "BATMAN & ROBIN"));
		dict.Add("id_answer_013", new DictEntry(Categories.SUPERHEROES, "JOKER", "JOKER"));
		dict.Add("id_answer_014", new DictEntry(Categories.MOVIES_AND_TV, "LOS HOBBITS", "THE HOBBITS"));
		dict.Add("id_answer_015", new DictEntry(Categories.ANIMATION, "TOTORO", "TOTORO"));
		dict.Add("id_answer_016", new DictEntry(Categories.MOVIES_AND_TV, "STAR WARS", "STAR WARS"));
		dict.Add("id_answer_017", new DictEntry(Categories.MOVIES_AND_TV, "TARZAN", "TARZAN"));
		dict.Add("id_answer_018", new DictEntry(Categories.CARTOONS, "BOB ESPONJA", "SPONGEBOB"));
		dict.Add("id_answer_019", new DictEntry(Categories.CARTOONS, "MICKEY MOUSE", "MICKEY MOUSE"));
		dict.Add("id_answer_020", new DictEntry(Categories.ANIMATION, "MONSTRUOS SA", "MONSTERS INC"));
		dict.Add("id_answer_021", new DictEntry(Categories.SUPERHEROES, "SUPERMAN", "SUPERMAN"));
		dict.Add("id_answer_022", new DictEntry(Categories.VIDEOGAMES, "STREET FIGHTER", "STREET FIGHTER"));
		dict.Add("id_answer_023", new DictEntry(Categories.SUPERHEROES, "HULK", "HULK"));
		dict.Add("id_answer_024", new DictEntry(Categories.VIDEOGAMES, "ZELDA", "ZELDA"));
	}
}













