using UnityEngine;

public abstract class Effect: MonoBehaviour {
	public float duration;
	public float timer;
	public float cooldown;

	public void Activate() {
		InvokeRepeating(nameof(Activation), 0, cooldown);
		Invoke(nameof(Cancel), duration);
	}

	private void Activation() {
		timer += cooldown;
		Action();
	}

	protected abstract void Action();

	public void Cancel() {
		Destroy(this);
	}
}
