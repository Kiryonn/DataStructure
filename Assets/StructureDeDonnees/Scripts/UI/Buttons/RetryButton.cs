using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton: Button
{
	protected override void Start()
	{
		base.Start();
		onClick.AddListener(() => SceneManager.LoadScene("Main"));
	}
}