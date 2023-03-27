using UnityEngine;

public class Globals {
	public static Vector3 RandomVector3(float min, float max) {
		return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
	}
	
}