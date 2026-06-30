using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
	[SerializeField] GameObject Timer;
	[SerializeField] GameObject Score;
	[SerializeField] GameObject Rank;
	//

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Timer.GetComponent<TextMeshProUGUI>().text = "Time : " + GetComponent<GameManager>().GetTime().ToString("F1");
		Score.GetComponent<TextMeshProUGUI>().text = "Score : " + GetComponent<GameManager>().GetScore().ToString("F0");
		Rank.GetComponent<TextMeshProUGUI>().text = "You're good";
	}

    // Update is called once per frame
    void Update()
    {
		
	}
}
