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

		if(textureImporter.assetPath.Contains("CharactersQuiz"))
		{
			textureImporter.textureType = TextureImporterType.Sprite;
			textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
			textureImporter.mipmapEnabled = false;
			textureImporter.maxTextureSize = 128;
			textureImporter.filterMode = FilterMode.Point;
		}
	}
	/*
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//AUDIOS
	void OnPreprocessAudio()
	{
		AudioImporter audioImporter = assetImporter as AudioImporter;
		
		audioImporter.threeD = false;
	}
	*/
	/*	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//MODELS
	void OnPreprocessModel()
	{
		ModelImporter modelImporter = assetImporter as ModelImporter;
		modelImporter.generateSecondaryUV=true;
	}
	*/
}
