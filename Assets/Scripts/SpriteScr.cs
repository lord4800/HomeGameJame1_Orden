using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
/*
public struct BasisLine
{
	public int normal;
	public int position;

	public int start;
	public int end;
}

public class SpriteScr: MonoBehaviour{


	Sprite[] GetSprites(Texture2D texture) {
		//var path =	AssetDatabase.GetAssetPath(texture);
		return Resources.LoadAll<Sprite>(texture.name);
		//return (Sprite)AssetDatabase.LoadAllAssetsAtPath(path);
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}

[CustomEditor(typeof(Edges.SpriteGenerator))]
public class SpriteGeneratorEditor : Editor {
	public override void OnInspectorGUI() {
		this.DrawDefaultInspector();

		if (targets.Length != 1)
			return;

		var generator = (Edges.SpriteGenerator)target;

		if (GUILayout.Button("Generate")) {
			generator.UpdateMeshes(true);
			serializedObject.ApplyModifiedProperties();
		}
	}
}
*/
