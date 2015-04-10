using UnityEngine;
using System.Collections;

public class Cover : MonoBehaviour
{
	IEnumerator Start()
	{
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel("01 Main");
	}
}
