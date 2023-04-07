using System.Linq;
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
		var asteroidHpChecker = Globals.settingCheckers[SettingsCheckers.AsteroidHpVisibility];
		if (!PlayerPrefs.HasKey(asteroidHpChecker))
			PlayerPrefs.SetInt(asteroidHpChecker, 1);
		
		var enemyHpChecker = Globals.settingCheckers[SettingsCheckers.EnemyHpVisibility];
		if (!PlayerPrefs.HasKey(enemyHpChecker))
			PlayerPrefs.SetInt(enemyHpChecker, 1);
	}
}