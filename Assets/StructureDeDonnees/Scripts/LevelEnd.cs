using System;
using UnityEngine;

public class LevelEnd: MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Player>())
			GameManager.Instance.LoadNextLevel();
	}
}