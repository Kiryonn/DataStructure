using System;
using UnityEngine;
using UnityEngine.UI;


public class GameManager: MonoBehaviour {
	public static GameManager Instance;
	[SerializeField] private GameData gameData;
	[SerializeField] private CanvasRenderer victoryPanel;
	[SerializeField] private CanvasRenderer defeatPanel;
	[SerializeField] private CanvasRenderer pausePanel;
	private int currentLevelIndex;

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
		if (Input.GetButtonDown("Cancel"))
			if (Time.timeScale == 0) Resume();
			else Pause();
	}

	private void Victory() {
		Time.timeScale = 0;
		victoryPanel.gameObject.SetActive(true);
	}

	public void Defeat() {
		Time.timeScale = 0;
		defeatPanel.gameObject.SetActive(true);
	}

	public void Pause() {
		Time.timeScale = 0;
		pausePanel.gameObject.SetActive(true);
	}

	public void Resume() {
		Time.timeScale = 1;
		pausePanel.gameObject.SetActive(false);
	}
}
