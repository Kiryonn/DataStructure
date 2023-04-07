using System;
using UnityEngine;

public class Player: ShipController {
	public static Player Instance;
	[Header("Movement")]
	public float speed = 100f;
	public float heightMax = 150f;
	
	private static readonly int UpAnimation    = Animator.StringToHash("Up");
	private static readonly int DownAnimation  = Animator.StringToHash("Down");
	private static readonly int LeftAnimation  = Animator.StringToHash("Left");
	private static readonly int RightAnimation = Animator.StringToHash("Right");

	private void Awake() {
		if (Instance == null)
			Instance = this;
	}
	
	protected override void Movement() {
		// get inputs
		var horizontalAxis = Input.GetAxis("Horizontal");
		var verticalAxis = Input.GetAxis("Vertical");
		
		// speed calculation
		var speedForward = speed * Time.deltaTime;
		var speedVertical = verticalAxis * speed * Time.deltaTime;
		var speedHorizontal = Mathf.Clamp(horizontalAxis * speed * Time.deltaTime, -0.9f, 1f);

		transform.position += new Vector3(speedHorizontal + speedForward, speedVertical, 0);

		// forbid the player from leaving the playing area
		Vector3 position = transform.position;
		position.y = Mathf.Clamp(position.y, -heightMax, heightMax);
		transform.position = position;
	}

	protected override void Animation() {
		var horizontalAxis = Input.GetAxis("Horizontal");
		var verticalAxis = Input.GetAxis("Vertical");

		anim.SetFloat(LeftAnimation, -horizontalAxis);
		anim.SetFloat(RightAnimation, horizontalAxis);
		anim.SetFloat(UpAnimation, verticalAxis);
		anim.SetFloat(DownAnimation, -verticalAxis);
	}

	protected override void OnCollisionEnter(Collision other) {
		base.OnCollisionEnter(other);

		if (other.gameObject.TryGetComponent(out Enemy enemy)) {
			var damageAmount = enemy.damage;
			Destroy(other.gameObject);
			health.DamageBy(damageAmount);
		}
	}
	private void OnDestroy()
	{
		Camera.main!.transform.parent = null;
	}
}