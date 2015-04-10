using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.Sprites;

public class CustomImportSettings : AssetPostprocessor 
{
	//TEXTURES
	void OnPreprocessTexture()
	{
		TextureImporter textureImporter = assetImporter as TextureImporter;

		textureImporter.textureType = TextureImporterType.Sprite;
		textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
		textureImporter.mipmapEnabled = false;
		textureImporter.filterMode = FilterMode.Point;
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//AUDIOS
	void OnPreprocessAudio()
	{
		AudioImporter audioImporter = assetImporter as AudioImporter;
		audioImporter.threeD = false;
	}
}
