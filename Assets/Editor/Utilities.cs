using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

class MyWindow : EditorWindow
{
	[MenuItem ("Custom/DeletePlayerPrefs")]
	public static void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
}
