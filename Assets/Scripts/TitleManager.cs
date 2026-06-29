using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	private void Start()
	{
		Application.targetFrameRate = 60;
	}
	private void Update()
	{
		if (Keyboard.current.enterKey.wasPressedThisFrame)
			SceneManager.LoadScene("GameScene");
	}
}
