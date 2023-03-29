using System.Collections.Generic;
using UnityEngine;

public class Globals {
	public static Vector3 RandomVector3(float min, float max) {
		return new Vector3(
			Random.Range(min, max),
			Random.Range(min, max),
			Random.Range(min, max));
	}

	public static readonly Dictionary<SettingsCheckers, string> settingCheckers = new Dictionary<SettingsCheckers, string> {
		{ SettingsCheckers.AsteroidHpVisibility, "asteroidHpVisibility" },
		{ SettingsCheckers.EnemyHpVisibility, "enemyHpVisibility" }
	};
}

public enum SettingsCheckers {
	None = 0,
	AsteroidHpVisibility = 1,
	EnemyHpVisibility = 2
}