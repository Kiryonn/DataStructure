using UnityEngine;
using Random = UnityEngine.Random;

public abstract class ShipController: MonoBehaviour {
	public Health health;
	public Animator anim;
	[SerializeField] protected Transform model;

	[Header("Laser")]
	[SerializeField] private bool isShooting = true;
	public Transform[] cannons;
	public GameObject laserPrefab;
	public float laserCooldown = 1;
	public float minAttackCooldown = 0.1f;
	public float damage = 10;
	public AudioSource laserAudio;
	protected float laserTimer = 0;

	protected virtual void Update() {
		Movement();
		Animation();
		if (isShooting)
			Laser();
	}

	private void Laser() {
		laserTimer += Time.deltaTime;

		if (!(laserTimer >= laserCooldown)) return;

		foreach (Transform cannon in cannons) {
			GameObject laser = Instantiate(laserPrefab, cannon);
			laser.transform.parent = null;
			laser.layer = gameObject.layer;
			laser.GetComponent<Laser>().damage = damage;
		}

		laserAudio.pitch = Random.Range(0.5f, 1.5f);
		laserAudio.Play();
		laserTimer = 0;
	}

	protected abstract void Movement();

	protected virtual void Animation() { }

	protected virtual void OnCollisionEnter(Collision other) {
		if (other.gameObject.GetComponent<Asteroid>()) {
			var asteroidHealth = other.gameObject.GetComponent<Health>().currentHealth;
			Destroy(other.gameObject);
			health.DamageBy(asteroidHealth);
		}
	}
}