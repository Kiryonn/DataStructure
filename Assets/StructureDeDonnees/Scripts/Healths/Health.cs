using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health: MonoBehaviour {
	[SerializeField] private float maxHealth;
	[SerializeField] private GameObject deathAnimation;
	[SerializeField] private float deathAnimationDuration;
	[SerializeField] private SettingsCheckers visibilityChecker;
	[SerializeField] private Slider healthBar;

	[NonSerialized] public float currentHealth;
	// private List<Effect> effets;

	protected virtual void Start() {
		currentHealth = maxHealth;
		healthBar.maxValue = maxHealth;
		healthBar.value = maxHealth;
		if (visibilityChecker == SettingsCheckers.None)
			healthBar.gameObject.SetActive(true);
		else if (PlayerPrefs.GetInt(Globals.settingCheckers[visibilityChecker]) == 0)
			healthBar.gameObject.SetActive(false);
	}

	public void HealBy(float heal) {
		currentHealth = Mathf.Clamp(currentHealth + heal, 0, maxHealth);

		if (currentHealth == 0)
			Death();
		
		if (visibilityChecker == SettingsCheckers.None)
			healthBar.value = currentHealth;
		else if (PlayerPrefs.GetInt(Globals.settingCheckers[visibilityChecker]) == 1)
			healthBar.value = currentHealth;
	}

	public void DamageBy(float damage) {
		HealBy(-damage);
	}

	public void ApplyEffect(Effect effect) {
		// todo
	}

	private void Death() {
		Destroy(gameObject);
	}

	private void OnDestroy() {
		if (deathAnimation)
			Destroy(Instantiate(deathAnimation, transform.position, Quaternion.identity), deathAnimationDuration);
	}
}
