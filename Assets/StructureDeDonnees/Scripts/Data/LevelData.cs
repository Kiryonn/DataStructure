using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "LevelData", menuName = "StructureDeDonnees/LevelData")]
public class LevelData: ScriptableObject {
	[SerializeField] private static string containerName = "Objects";
	public List<ObjectData> objects;
	[Tooltip("Make sure to put objects (asteroids, enemies, gates, ...) into a GameObject with that name")]

#if UNITY_EDITOR
	// ReSharper disable Unity.PerformanceAnalysis
	public void Save() {
		objects ??= new();

		// find objects
		GameObject container = GameObject.Find(containerName);

		if (container == null) {
			Debug.LogWarning("Couldn't find the Objects container. Make sure it exists and is named correctly");
			return;
		}
		
		// save objects
		objects.Clear();
		for (var j = 0; j < container.transform.childCount; ++j) {
			GameObject obj = container.transform.GetChild(j).gameObject;
			GameObject prefab = PrefabUtility.GetCorrespondingObjectFromSource(obj);
			ObjectData objectData = new ObjectData(prefab, obj.transform);
			objects.Add(objectData);
		}
		
		// finished saving stuff successfully
		Debug.Log("Save Finished Successfully");
	}
#endif

	public void Load() {

		// retrieve container
		GameObject container = GameObject.Find(containerName);
		if (container == null) {
			Debug.LogWarning("Couldn't find the Objects container. Make sure it exists and is named correctly");
			return;
		}

		// destroy container (fast empty)
		if (Application.isPlaying) Destroy(container);
		else DestroyImmediate(container);

		// recreate container
		container = new GameObject(containerName);

		// create objects from data
		foreach (ObjectData objectData in objects)
			CreateFromData(objectData, container.transform);

		// finished loading stuff
		Debug.Log("Load Finished Successfully");
	}

	private void CreateFromData(ObjectData objectData, Transform parent) {
#if UNITY_EDITOR
		GameObject instance = (GameObject) PrefabUtility.InstantiatePrefab(objectData.prefab, parent);
#else
		GameObject instance = Instantiate(objectData.prefab, parent);
#endif
		instance.transform.position = objectData.position;
	}
}