using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Asteroid: MonoBehaviour {
	[SerializeField] private Transform model;
	private Vector3 rotationVelocity;
	private Vector3 velocity;

	private void Start() {
		rotationVelocity = Globals.RandomVector3(0, 1);
		velocity = new Vector3(-Random.Range(0, 2), Random.Range(-0.1f, 0.1f), 0);
	}

	private void Update() {
		model.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Time.deltaTime * 10 * rotationVelocity);
		transform.position += velocity;
	}
}