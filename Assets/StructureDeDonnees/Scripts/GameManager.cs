using UnityEngine;


public class GameManager: MonoBehaviour {
	public static GameManager Instance;
	[SerializeField] private GameData gameData;
	[SerializeField] private CanvasRenderer victoryPanel;
	[SerializeField] private CanvasRenderer defeatPanel;
	[SerializeField] private CanvasRenderer pausePanel;
	private int currentLevelIndex;
	private bool canPause = true;

	private void Awake() {
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	private void Start() {
		LoadNextLevel();
		Time.timeScale = 1;
	}

	public void LoadNextLevel() {
		// win condition
		if (currentLevelIndex >= gameData.levels.Count) {
			Victory(); return; }
		
		// load next level
		gameData.levels[currentLevelIndex].Load();
		currentLevelIndex++;
	}

	private void Update() {
		if (!Input.GetButtonDown("Cancel")) return;
		if (!canPause) return;

		if (Time.timeScale == 0) Resume();
		else Pause();
	}

	private void Victory() {
		canPause = false;
		victoryPanel.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void Defeat() {
		canPause = false;
		defeatPanel.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void Pause() {
		pausePanel.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void Resume() {
		pausePanel.gameObject.SetActive(false);
		Time.timeScale = 1;
	}
}
