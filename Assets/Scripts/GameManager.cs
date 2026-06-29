using System.Threading;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject CountDownText;
	[SerializeField] GameObject TimerText;
	float limitTime = 3;
	float Timer = 30;
	bool TimerEnabled = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		Application.targetFrameRate = 60;
		CountDownText.SetActive(true);
		TimerText.SetActive(false);
	}

	// Update is called once per frame
	private void Update()
	{
		// カウントダウン開始
		limitTime -= Time.deltaTime;

		if (limitTime < 0.9f)
		{
			limitTime = 0;
			TimerEnabled = true;
			CountDownText.SetActive(false);
			TimerText.SetActive(true);
		}
		CountDownText.GetComponent<TextMeshProUGUI>().text = limitTime.ToString("F0");

		if (TimerEnabled == true)
		{
			Timer -= Time.deltaTime;
			TimerText.GetComponent<TextMeshProUGUI>().text = "Time:" + Timer.ToString("F2");
		}
	}
}
