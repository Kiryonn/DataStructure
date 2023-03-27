using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor: Editor
{
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		LevelData levelData = (LevelData) target;
		GUILayout.Space(10);
		if (GUILayout.Button("Save")) {
			levelData.Save();
		}

		if (GUILayout.Button("Load")) {
			levelData.Load();
		}
	}
}