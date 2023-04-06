using UnityEngine;

public class Rendroach: Enemy {
	protected override void Movement() {
		Vector3 playerPosition = Player.Instance.transform.position;
		model.LookAt(playerPosition);
		model.Rotate(0, 180, 0);  // rectify rotation

		Vector3 position = model.position;
		Vector3 towards = new(position.x, playerPosition.y, position.z); 
		transform.position = Vector3.Lerp(position, towards, 0.015f);
	}
}