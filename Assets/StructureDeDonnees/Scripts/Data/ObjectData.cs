using System;
using UnityEngine;

[Serializable]
public class ObjectData {
	public GameObject prefab;
	public Vector3 position;

	public ObjectData(GameObject prefab, Transform transform)
	{
		this.prefab = prefab;
		this.position = transform.position;
	}
	
	public ObjectData(GameObject prefab, Vector3 position)
	{
		this.prefab = prefab;
		this.position = position;
	}
}