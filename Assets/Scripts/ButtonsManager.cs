using UnityEngine;
using System.Collections;

public class ButtonsManager : MonoBehaviour
{
	public void OnButtonPlayPressed()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		StartCoroutine(DoLoadLevel());
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	IEnumerator DoLoadLevel()
	{
		yield return null;
		Application.LoadLevel("02 GameScene");
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public void OnButtonResetPresset()
	{
		AudioManager.instance.PlayAudio(AudioManager.Audios.ButtonClick);
		PlayerPrefs.SetInt("CurrentLevel", 1);
	}
}