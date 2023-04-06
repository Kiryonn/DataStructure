using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Asteroid: MonoBehaviour {
	[SerializeField] private Transform model;
	private Vector3 rotationVelocity;
	private Vector3 velocity;
	private float heightMax;

	private void Start() {
		rotationVelocity = Globals.RandomVector3(0, 5);
		velocity = new Vector3(-Random.Range(0, 10), Random.Range(-0.2f, 0.2f), 0);
		heightMax = Player.Instance.heightMax;
	}

	private void Update() {
		model.rotation = Quaternion.Euler(model.rotation.eulerAngles + Time.deltaTime * 10 * rotationVelocity);
		transform.position += Time.deltaTime * 10 * velocity;

		if (transform.position.y >= heightMax || transform.position.y < -heightMax)
			velocity.y *= -1;
	}
}