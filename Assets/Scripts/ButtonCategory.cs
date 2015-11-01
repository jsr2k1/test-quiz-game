using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCategory : MonoBehaviour
{
	public Text sLevel;
	public string category;
	public Image progressFill;
	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Start()
	{	
		int level = PlayerPrefs.GetInt(category)+1;
		
		//Update level
		if(PlayerPrefs.HasKey(category)){
			sLevel.text = level+"/10";
		}else{
			sLevel.text = "1/10";
		}
		
		//Update progress bar
		progressFill.fillAmount = (float)level/10F;
	}
}
