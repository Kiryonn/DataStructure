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
	}
}