using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel: MonoBehaviour {
	[SerializeField] private Toggle asteroidsLifeBarVisibilityToggle;
	[SerializeField] private Toggle enemiesLifeBarVisibilityToggle;


	private void Start() {
		asteroidsLifeBarVisibilityToggle.isOn = PlayerPrefs.GetInt(Globals.settingCheckers[SettingsCheckers.Asteroid]) == 1;
		enemiesLifeBarVisibilityToggle.isOn = PlayerPrefs.GetInt(Globals.settingCheckers[SettingsCheckers.Enemy]) == 1;
		
		asteroidsLifeBarVisibilityToggle.onValueChanged.AddListener(
			status => PlayerPrefs.SetInt(Globals.settingCheckers[SettingsCheckers.Asteroid], status ? 1 : 0));
		enemiesLifeBarVisibilityToggle.onValueChanged.AddListener(
			status => PlayerPrefs.SetInt(Globals.settingCheckers[SettingsCheckers.Enemy], status ? 1 : 0));
	}
}


