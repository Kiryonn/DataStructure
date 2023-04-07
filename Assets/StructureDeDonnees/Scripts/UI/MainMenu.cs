using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour {
	[Header("Menu Buttons")]
	[SerializeField] private Button playButton;
	[SerializeField] private Button QuitButton;

	private void Start() {
		playButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
		QuitButton.onClick.AddListener(Application.Quit);
		
		// set default settings values if they don't exist
		var asteroidHpChecker = Globals.settingCheckers[SettingsCheckers.Asteroid];
		if (!PlayerPrefs.HasKey(asteroidHpChecker))
			PlayerPrefs.SetInt(asteroidHpChecker, 1);
		
		var enemyHpChecker = Globals.settingCheckers[SettingsCheckers.Enemy];
		if (!PlayerPrefs.HasKey(enemyHpChecker))
			PlayerPrefs.SetInt(enemyHpChecker, 1);
	}
}