using UnityEngine;

public class TheBoss: Enemy {
	[SerializeField] private Transform beamCannon;
	[SerializeField] private GameObject beamPrefab;
	[SerializeField] private float beamCooldown;
	
	private float speed;
	private float cooldown;

	private void Start() {
		speed = Player.Instance.speed;
		health = GetComponent<Health>();
	}

	private void Update() {
		Move();
		cooldown -= Time.deltaTime;

		if (cooldown > 0) return;
		ShootBeam();
	}

	private void ShootBeam() {
		GameObject beam = Instantiate(beamPrefab, beamCannon);
		
		cooldown = beamCooldown;
	}

	private void Move() {
		var horizontalAxis = Input.GetAxis("Horizontal");
		var speedForward = speed * Time.deltaTime;
		var speedHorizontal = Mathf.Clamp(horizontalAxis * speed * Time.deltaTime, -0.9f, 1f);
		transform.position += new Vector3(speedHorizontal + speedForward, 0, 0);
	}
}