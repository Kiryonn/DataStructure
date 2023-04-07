using UnityEngine.UI;

public class ResumeButton: Button {
	protected override void Start() {
		base.Start();
		onClick.AddListener(() => GameManager.Instance.Resume());
	}
}