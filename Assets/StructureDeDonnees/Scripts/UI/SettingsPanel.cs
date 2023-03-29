using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel: MonoBehaviour {
	[SerializeField] private Toggle asteroidsLifeBarVisibilityToggle;
	[SerializeField] private Toggle enemiesLifeBarVisibilityToggle;


	private void Start() {
		asteroidsLifeBarVisibilityToggle.isOn = PlayerPrefs.GetInt(Globals.settingCheckers[SettingsCheckers.AsteroidHpVisibility]) == 1;
		enemiesLifeBarVisibilityToggle.isOn = PlayerPrefs.GetInt(Globals.settingCheckers[SettingsCheckers.EnemyHpVisibility]) == 1;
		
		asteroidsLifeBarVisibilityToggle.onValueChanged.AddListener(
			status => PlayerPrefs.SetInt(Globals.settingCheckers[SettingsCheckers.AsteroidHpVisibility], status ? 1 : 0));
		enemiesLifeBarVisibilityToggle.onValueChanged.AddListener(
			status => PlayerPrefs.SetInt(Globals.settingCheckers[SettingsCheckers.EnemyHpVisibility], status ? 1 : 0));
	}
}


