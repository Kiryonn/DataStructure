using UnityEngine;



public class GameManager: MonoBehaviour {
	public static GameManager Instance;
	[SerializeField] private GameData gameData;
	private int _currentLevelIndex;

	private void Awake() {
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	private void Start() {
		LoadNextLevel();
	}

	public void LoadNextLevel() {
		// win condition
		if (_currentLevelIndex >= gameData.levels.Count) {
			// todo win call
			return;
		}
		
		// load next level
		gameData.levels[_currentLevelIndex].Load();
		_currentLevelIndex++;
	}

	private void Victory() {
		Time.timeScale = 0;
	}
}