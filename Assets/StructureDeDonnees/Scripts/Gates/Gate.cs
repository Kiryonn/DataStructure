using UnityEngine;

public abstract class Gate: MonoBehaviour {

	private void OnCollisionEnter(Collision collision) {
		if (!collision.gameObject.TryGetComponent(out Player player)) return;
		
		Action(player);
		Destroy(gameObject);
	}

	protected abstract void Action(Player player);
}
