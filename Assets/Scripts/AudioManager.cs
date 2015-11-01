using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public enum Audios{
		LevelComplete,
		ButtonClick,
		ButtonClickAlt
	};

	public AudioClip levelCompleteAudio;
	public AudioClip buttonClick;
	public AudioClip buttonClickAlt;

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public void PlayAudio(Audios audios)
	{
		if(audios == Audios.LevelComplete){
			GetComponent<AudioSource>().volume = 1.0f;
			GetComponent<AudioSource>().clip = levelCompleteAudio;
		}
		if(audios == Audios.ButtonClick){
			GetComponent<AudioSource>().volume = 0.5f;
			GetComponent<AudioSource>().clip = buttonClick;
		}
		if(audios == Audios.ButtonClickAlt){
			GetComponent<AudioSource>().volume = 0.5f;
			GetComponent<AudioSource>().clip = buttonClickAlt;
		}
		GetComponent<AudioSource>().Play();
	}
}
