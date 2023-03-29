using UnityEngine;

public class LevelEnd: MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.TryGetComponent(out Player player)) {
			GameManager.Instance.LoadNextLevel();
			player.transform.position = Vector3.zero;
		}
	}
}