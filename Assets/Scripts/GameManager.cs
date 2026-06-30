using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject CountDownText;
	[SerializeField] GameObject TimerText;
	[SerializeField] GameObject ScoreText;
	[SerializeField] GameObject Frame;
	float limitTime = 3;
	float Timer = 30;
	static int TimerInitial = 30;
	static int score = 0;
	bool TimerEnabled = false;

	public int GetScore() { return score; }
	public void AddScore() { score++; }

	public int GetTime() { return TimerInitial; }

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Application.targetFrameRate = 60;
		CountDownText.SetActive(true);
		CountDownText.SetActive(Frame);
		ScoreText.SetActive(false);
		TimerText.SetActive(false);
	}

	// Update is called once per frame
	private void Update()
	{
		// カウントダウン開始
		limitTime -= Time.deltaTime;

		CountDownText.GetComponent<TextMeshProUGUI>().text = limitTime.ToString("F0");
		if (limitTime < 0.99f)
		{
			limitTime = 0;
			TimerEnabled = true;
			CountDownText.SetActive(false);
			ScoreText.SetActive(true);
			TimerText.SetActive(true);
			Destroy(Frame);
		}

		// タイマー開始
		if (TimerEnabled == true)
		{
			Timer -= Time.deltaTime;
			TimerText.GetComponent<TextMeshProUGUI>().text = "Time:" + Timer.ToString("F1");
			ScoreText.GetComponent<TextMeshProUGUI>().text = "Score:" + score.ToString("F0");

			// Timerが0になった場合、リザルトシーンへ遷移する
			if (Timer < 0f)
			{
				Timer = 0;
				SceneManager.LoadScene("ResultScene");
			}
		}
	}
}
