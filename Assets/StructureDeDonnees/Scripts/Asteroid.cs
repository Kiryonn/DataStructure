using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Asteroid: MonoBehaviour {
	private Vector3 rotationVelocity;
	private Vector3 velocity;

	private void Start()
	{
		// rotationVelocity = Globals.RandomVector3(0, 1);
		//
		// velocity = Random.Range(0, 1) < 0.1 ? Globals.RandomVector3(0, 1) : Vector3.zero;
	}

	private void Update() {
		// transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Time.deltaTime * 10 * rotationVelocity);
		// transform.position += velocity;
	}
}