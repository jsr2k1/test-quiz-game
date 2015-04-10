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
			audio.volume = 1.0f;
			audio.clip = levelCompleteAudio;
		}
		if(audios == Audios.ButtonClick){
			audio.volume = 0.2f;
			audio.clip = buttonClick;
		}
		if(audios == Audios.ButtonClickAlt){
			audio.volume = 0.2f;
			audio.clip = buttonClickAlt;
		}
		audio.Play();
	}
}
