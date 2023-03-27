using System;
using UnityEngine;
using UnityEngine.UI;

public class Health: MonoBehaviour
{
	[SerializeField] private float maxHealth;
	[SerializeField] private GameObject deathAnimation;
	[SerializeField] private float deathAnimationDuration;
	[SerializeField] private string visibilityCheckerName;
	[SerializeField] private Slider healthBar;

	[NonSerialized] public float currentHealth;

	protected virtual void Start() {
		currentHealth = maxHealth;
		healthBar.maxValue = maxHealth;
		healthBar.value = maxHealth;
		if (PlayerPrefs.GetInt(visibilityCheckerName) == 0)
			healthBar.gameObject.SetActive(false);
	}

	public virtual void HealBy(float heal) {
		currentHealth = Mathf.Clamp(currentHealth + heal, 0, maxHealth);

		if (currentHealth == 0)
			Death();

		if (PlayerPrefs.GetInt(visibilityCheckerName) == 1)
			healthBar.value = currentHealth;
	}
	
	// private void Update()
	// {
	// 	healthBar.transform.rotation = Quaternion.Euler(0, 0, 0);
	// }

	public void DamageBy(float damage) {
		HealBy(-damage);
	}

	public void ApplyEffect(Effect effect) {
		var effectExists = TryGetComponent(out Effect oldEffect);

		if (effectExists && oldEffect.duration - oldEffect.timer < effect.duration)
			Destroy(oldEffect);
		effect.transform.parent = transform;
		effect.Activate();
	}

	private void Death() {
		Destroy(gameObject);
	}

	private void OnDestroy() {
		if (deathAnimation)
			Destroy(Instantiate(deathAnimation, transform.position, Quaternion.identity), deathAnimationDuration);
	}
}
