using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

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
	public static LanguageManager instance;
	int lang;
	Dictionary<string, DictEntry> dict;
	public int numAnswers;

	public enum Categories{
		ANIMATION,
		CARTOONS,
		TV,
		MOVIES,
		VIDEOGAMES,
		NULL
	};
	
	enum Languages{
		EN,
		ES
	};
	Languages currentLanguage;
	
	public delegate void LanguageChanged();
	public static event LanguageChanged OnLanguageChanged;
	
	public Toggle toggleES;
	public Toggle toggleEN;

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
		dict = new Dictionary<string, DictEntry>();
		fillDict();
		numAnswers = dict.Count(o => o.Key.StartsWith("id_answer"));
		SetLanguage();
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void SetLanguage()
	{
		if(PlayerPrefs.HasKey("language")){
			if(PlayerPrefs.GetString("language") == "ES"){
				currentLanguage = Languages.ES;
				toggleES.isOn = true;
			}else{
				currentLanguage = Languages.EN;
				toggleEN.isOn = true;
			}
		}else{
			if(Application.systemLanguage == SystemLanguage.Spanish){
				currentLanguage = Languages.ES;
				toggleES.isOn = true;
			}else{
				currentLanguage = Languages.EN;
				toggleEN.isOn = true;
			}
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public void OnButtonLanguagePressed(int id)
	{
		if(id==0){
			currentLanguage = Languages.EN;
			PlayerPrefs.SetString("language", "EN");
		}else{
			currentLanguage = Languages.ES;
			PlayerPrefs.SetString("language", "ES");
		}
		if(OnLanguageChanged!=null){
			OnLanguageChanged();
		}
	}
	
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public string GetText(string id)
	{
		if(dict.ContainsKey(id)){
			if(currentLanguage == Languages.ES){
				return dict[id].answer_ES;
			}else{
				return dict[id].answer_EN;
			}
		}else{
			Debug.Log("No se encuentra la key en el diccionario: " + id);
			return "ID_ERROR";
		}
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public string GetCategory(string id)
	{
		if(dict.ContainsKey(id)){
			if(dict[id].category == Categories.ANIMATION){
				return GetText("id_animation");
			}
			else if(dict[id].category == Categories.CARTOONS){
				return GetText("id_cartoons");
			}
			else if(dict[id].category == Categories.TV){
				return GetText("id_tv");
			}
			else if(dict[id].category == Categories.MOVIES){
				return GetText("id_movies");
			}
			else if(dict[id].category == Categories.VIDEOGAMES){
				return GetText("id_videogames");
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
		//Etiquetas botones y textos
		dict.Add("id_play", new DictEntry(Categories.NULL, "JUGAR", "PLAY"));
		dict.Add("id_connect", new DictEntry(Categories.NULL, "CONECTAR", "CONNECT"));
		dict.Add("id_settings", new DictEntry(Categories.NULL, "AJUSTES", "SETTINGS"));
		dict.Add("id_quit", new DictEntry(Categories.NULL, "¿SALIR DEL JUEGO?", "EXIT GAME?"));
		dict.Add("id_yes", new DictEntry(Categories.NULL, "SI", "YES"));
		dict.Add("id_no", new DictEntry(Categories.NULL, "NO", "NO"));
		dict.Add("id_back", new DictEntry(Categories.NULL, "VOLVER", "BACK"));
		dict.Add("id_shop", new DictEntry(Categories.NULL, "TIENDA", "SHOP"));
		dict.Add("id_ads", new DictEntry(Categories.NULL, "GRATIS (Anuncio)", "FREE (View Ad)"));
		dict.Add("id_welldone", new DictEntry(Categories.NULL, "BIEN HECHO!", "WELL DONE!"));
		dict.Add("id_level", new DictEntry(Categories.NULL, "Nivel", "Level"));
		dict.Add("id_completed", new DictEntry(Categories.NULL, "completado", "completed"));
		dict.Add("id_next", new DictEntry(Categories.NULL, "Siguiente", "Next"));
		dict.Add("id_reset", new DictEntry(Categories.NULL, "¿Est\u00E1s seguro? Perder\u00E1s el progreso!", "Are you sure? All progress will be lost!"));
		

		//Categorias
		dict.Add("id_categories", new DictEntry(Categories.NULL, "CATEGOR\u00CDA", "CATEGORY"));
		dict.Add("id_animation", new DictEntry(Categories.NULL, "ANIMACI\u00D3N", "ANIMATION"));
		dict.Add("id_cartoons", new DictEntry(Categories.NULL, "DIBUJOS", "CARTOONS"));
		dict.Add("id_tv", new DictEntry(Categories.NULL, "TV", "TV"));
		dict.Add("id_movies", new DictEntry(Categories.NULL, "CINE", "MOVIES"));
		dict.Add("id_videogames", new DictEntry(Categories.NULL, "VIDEOJUEGOS", "VIDEOGAMES"));
		
		//Respuestas
		dict.Add("id_answer_001", new DictEntry(Categories.CARTOONS, "LOS SIMPSON", "THE SIMPSONS"));
		dict.Add("id_answer_002", new DictEntry(Categories.ANIMATION, "LOS INCREIBLES", "THE INCREDIBLES"));
		dict.Add("id_answer_003", new DictEntry(Categories.CARTOONS, "TORTUGAS NINJA", "NINJA TURTLES"));
		dict.Add("id_answer_004", new DictEntry(Categories.CARTOONS, "LOS PITUFOS", "THE SMURFS"));
		dict.Add("id_answer_005", new DictEntry(Categories.VIDEOGAMES, "MARIO & LUIGI", "MARIO & LUIGI"));
		dict.Add("id_answer_006", new DictEntry(Categories.TV, "ASTERIX & OBELIX", "ASTERIX & OBELIX"));
		dict.Add("id_answer_007", new DictEntry(Categories.TV, "EPI & BLAS", "BERT & ERNIE"));
		dict.Add("id_answer_008", new DictEntry(Categories.CARTOONS, "PATO DONALD", "DONALD DUCK"));
		dict.Add("id_answer_009", new DictEntry(Categories.TV, "LUCKY LUKE", "LUCKY LUKE"));
		dict.Add("id_answer_010", new DictEntry(Categories.CARTOONS, "SOUTH PARK", "SOUTH PARK"));
		dict.Add("id_answer_011", new DictEntry(Categories.CARTOONS, "TOM & JERRY", "TOM & JERRY"));
		dict.Add("id_answer_012", new DictEntry(Categories.MOVIES, "BATMAN & ROBIN", "BATMAN & ROBIN"));
		dict.Add("id_answer_013", new DictEntry(Categories.MOVIES, "JOKER", "JOKER"));
		dict.Add("id_answer_014", new DictEntry(Categories.MOVIES, "LOS HOBBITS", "THE HOBBITS"));
		dict.Add("id_answer_015", new DictEntry(Categories.CARTOONS, "SCOOBY DOO", "SCOOBY DOO"));
		dict.Add("id_answer_016", new DictEntry(Categories.MOVIES, "STAR WARS", "STAR WARS"));
		dict.Add("id_answer_017", new DictEntry(Categories.MOVIES, "TARZAN", "TARZAN"));
		dict.Add("id_answer_018", new DictEntry(Categories.CARTOONS, "BOB ESPONJA", "SPONGEBOB"));
		dict.Add("id_answer_019", new DictEntry(Categories.CARTOONS, "MICKEY MOUSE", "MICKEY MOUSE"));
		dict.Add("id_answer_020", new DictEntry(Categories.ANIMATION, "MONSTRUOS SA", "MONSTERS INC"));
		dict.Add("id_answer_021", new DictEntry(Categories.MOVIES, "SUPERMAN", "SUPERMAN"));
		dict.Add("id_answer_022", new DictEntry(Categories.VIDEOGAMES, "STREET FIGHTER", "STREET FIGHTER"));
		dict.Add("id_answer_023", new DictEntry(Categories.MOVIES, "HULK", "HULK"));
		dict.Add("id_answer_024", new DictEntry(Categories.VIDEOGAMES, "ZELDA", "ZELDA"));
		dict.Add("id_answer_025", new DictEntry(Categories.VIDEOGAMES, "SONIC & TAILS", "SONIC & TAILS"));
		dict.Add("id_answer_026", new DictEntry(Categories.VIDEOGAMES, "MEGAMAN", "MEGAMAN"));
		dict.Add("id_answer_027", new DictEntry(Categories.ANIMATION, "WALL-E", "WALL-E"));
		dict.Add("id_answer_028", new DictEntry(Categories.MOVIES, "4 FANTASTICOS", "FANTASTIC FOUR"));
		dict.Add("id_answer_029", new DictEntry(Categories.TV, "LOS PICAPIEDRA", "THE FLINTSTONES"));
		dict.Add("id_answer_030", new DictEntry(Categories.ANIMATION, "LOS MINIONS", "MINIONS"));
		dict.Add("id_answer_031", new DictEntry(Categories.ANIMATION, "GRU", "GRU"));
		dict.Add("id_answer_032", new DictEntry(Categories.ANIMATION, "TOY STORY", "TOY STORY"));
		dict.Add("id_answer_033", new DictEntry(Categories.ANIMATION, "FROZEN", "FROZEN"));
		dict.Add("id_answer_034", new DictEntry(Categories.CARTOONS, "FINN & JAKE", "FINN & JAKE"));
		dict.Add("id_answer_035", new DictEntry(Categories.TV, "SNOOPY", "PEANUTS"));
		dict.Add("id_answer_036", new DictEntry(Categories.TV, "LAS SUPERNENAS", "POWERPUFF GIRLS"));
		dict.Add("id_answer_037", new DictEntry(Categories.TV, "DRAGON BALL", "DRAGON BALL"));
		dict.Add("id_answer_038", new DictEntry(Categories.MOVIES, "AVATAR", "AVATAR"));
		dict.Add("id_answer_039", new DictEntry(Categories.TV, "POCOYO", "POCOYO"));
		dict.Add("id_answer_040", new DictEntry(Categories.MOVIES, "CAZA - FANTASMAS", "GHOST - BUSTERS"));
		dict.Add("id_answer_041", new DictEntry(Categories.TV, "MAZINGUER Z", "MAZINGUER Z"));
		dict.Add("id_answer_042", new DictEntry(Categories.ANIMATION, "DEL REVES", "INSIDE OUT"));
		dict.Add("id_answer_043", new DictEntry(Categories.ANIMATION, "SHREK", "SHREK"));
		dict.Add("id_answer_044", new DictEntry(Categories.ANIMATION, "KUNGFU PANDA", "KUNGFU PANDA"));
		dict.Add("id_answer_045", new DictEntry(Categories.TV, "PANTERA ROSA", "PINK PANTHER"));
		dict.Add("id_answer_046", new DictEntry(Categories.VIDEOGAMES, "ANGRY BIRDS", "ANGRY BIRDS"));
		dict.Add("id_answer_047", new DictEntry(Categories.VIDEOGAMES, "PUZZLE BOBBLE", "PUZZLE BOBBLE"));
		dict.Add("id_answer_048", new DictEntry(Categories.VIDEOGAMES, "PAC MAN", "PAC MAN"));
		dict.Add("id_answer_049", new DictEntry(Categories.VIDEOGAMES, "DONKEY KONG", "DONKEY KONG"));
		dict.Add("id_answer_050", new DictEntry(Categories.VIDEOGAMES, "TOMB RAIDER", "TOMB RAIDER"));
	}
}



