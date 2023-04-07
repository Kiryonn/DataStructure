using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton: Button {
	protected override void Start() {
		base.Start();
		onClick.AddListener(()=> SceneManager.LoadScene(0));
	}
}