using UnityEngine.UI;

public class PauseButton: Button {
	protected override void Start() {
		base.Start();
		onClick.AddListener(() => GameManager.Instance.Pause());
	}
}
