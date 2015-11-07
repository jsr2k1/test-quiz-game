using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Category
{
	string mId;
	public string Id{
		get{return mId;}
	}
	int mCurrentLevel;
	public int CurrentLevel{
		get{return mCurrentLevel;}
		set{mCurrentLevel = value;}
	}
	List<int> mLevels;
	public List<int> Levels{
		get{return mLevels;}
	}
	
	public Category(string id, List<int> levels)
	{
		mId = id;
		mLevels = levels;
		mCurrentLevel = 0;
	}
	
	public int GetCurrentLevel()
	{
		return mLevels[CurrentLevel];
	}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

public class CategoriesManager : MonoBehaviour
{
	public static CategoriesManager instance;
	
	Category animations;
	Category cartoons;
	Category tv;
	Category movies;
	Category videogames;
	
	Category currentCategory;
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		instance = this;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void Start()
	{
		animations = new Category("animations", new List<int>(){2,20,27,30,31,32,33,42,43,44});
		cartoons = new Category("cartoons", new List<int>(){1,3,4,8,10,11,15,18,19,34});
		tv = new Category("tv", new List<int>(){6,7,9,29,35,36,37,39,41,45});
		movies = new Category("movies", new List<int>(){12,13,14,16,17,21,23,28,38,40});
		videogames = new Category("videogames", new List<int>(){5,22,24,25,26,46,47,48,49,50});
		
		InitializeCategories();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	void InitializeCategories()
	{
		if(PlayerPrefs.HasKey("animations")){
			animations.CurrentLevel = PlayerPrefs.GetInt("animations");
		}else{
			animations.CurrentLevel = 0;
			PlayerPrefs.SetInt("animations", 0);
		}
		if(PlayerPrefs.HasKey("cartoons")){
			cartoons.CurrentLevel = PlayerPrefs.GetInt("cartoons");
		}else{
			cartoons.CurrentLevel = 0;
			PlayerPrefs.SetInt("cartoons", 0);
		}
		if(PlayerPrefs.HasKey("tv")){
			tv.CurrentLevel = PlayerPrefs.GetInt("tv");
		}else{
			tv.CurrentLevel = 0;
			PlayerPrefs.SetInt("tv", 0);
		}
		if(PlayerPrefs.HasKey("movies")){
			movies.CurrentLevel = PlayerPrefs.GetInt("movies");
		}else{
			movies.CurrentLevel = 0;
			PlayerPrefs.SetInt("movies", 0);
		}
		if(PlayerPrefs.HasKey("videogames")){
			videogames.CurrentLevel = PlayerPrefs.GetInt("videogames");
		}else{
			videogames.CurrentLevel = 0;
			PlayerPrefs.SetInt("videogames", 0);
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Se llama cuando se pulsa el boton de la categoria
	public void SetCurrentCategory(string s)
	{
		if(s=="animations"){ currentCategory = animations; }
		else if(s=="cartoons"){ currentCategory = cartoons; }
		else if(s=="tv"){ currentCategory = tv; }
		else if(s=="movies"){ currentCategory = movies; }
		else if(s=="videogames"){ currentCategory = videogames; }
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public bool CategoryCompleted(string s)
	{
		if(s=="animations"){ return animations.CurrentLevel==10; }
		else if(s=="cartoons"){ return cartoons.CurrentLevel==10; }
		else if(s=="tv"){ return tv.CurrentLevel==10; }
		else if(s=="movies"){ return movies.CurrentLevel==10; }
		else if(s=="videogames"){ return videogames.CurrentLevel==10; }
		
		return true;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public int GetCurrentLevel()
	{
		return currentCategory.GetCurrentLevel();
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
	public int GetCurrentLevelInd()
	{
		return currentCategory.CurrentLevel+1;
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Se llama al finalizar un nivel
	public void SetCurrentLevel(bool add)
	{
		if(add){
			if(currentCategory.CurrentLevel<10){
				currentCategory.CurrentLevel++;
			}
			PlayerPrefs.SetInt(currentCategory.Id, currentCategory.CurrentLevel);
		}else{
			if(currentCategory.CurrentLevel>0){
				currentCategory.CurrentLevel--;
				PlayerPrefs.SetInt(currentCategory.Id, currentCategory.CurrentLevel);
			}
		}
	}
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//Resetear todas las categorias
	public void ResetAll()
	{
		animations.CurrentLevel=0;
		cartoons.CurrentLevel=0;
		tv.CurrentLevel=0;
		movies.CurrentLevel=0;
		videogames.CurrentLevel=0;
		
		PlayerPrefs.SetInt("animations", 0);
		PlayerPrefs.SetInt("cartoons", 0);
		PlayerPrefs.SetInt("tv", 0);
		PlayerPrefs.SetInt("movies", 0);
		PlayerPrefs.SetInt("videogames", 0);
	}
}












