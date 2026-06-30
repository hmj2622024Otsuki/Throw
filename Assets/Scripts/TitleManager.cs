using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	private void Start()
	{
		// フレームレートを60に設定
		Application.targetFrameRate = 60;
	}
	private void Update()
	{
		// スペースキーが押された場合、ゲームシーンに遷移する
		if (Keyboard.current.enterKey.wasPressedThisFrame)
			SceneManager.LoadScene("GameScene");
	}
}
