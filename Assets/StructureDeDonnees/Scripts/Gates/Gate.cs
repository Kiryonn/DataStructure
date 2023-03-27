using UnityEngine;

public abstract class Gate: MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		if (!other.TryGetComponent(out Player player)) return;
		
		Action(player);
		Destroy(gameObject);
	}

	protected abstract void Action(Player player);
}
