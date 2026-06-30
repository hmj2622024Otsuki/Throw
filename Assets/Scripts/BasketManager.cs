using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
	[SerializeField] GameObject basketPrefab;
	[SerializeField] Transform centerPoint;
	[SerializeField] AudioClip onSE;
	float radius = 0.07f;
	float speed = 1.5f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		transform.position = new Vector3(7, 0, 0);
	}

    // Update is called once per frame
    void Update()
    {
		// バスケットを上下に動かす処理
		float angle = Time.time * speed;

		float y = centerPoint.position.y + Mathf.Cos(angle) * radius;
		float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

		transform.position = new Vector3(transform.position.x, y, z);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// ボールのクローンに触れたときに、ボールのクローンを削除する
		if (collision.CompareTag("Ball"))
		{
			AudioSource.PlayClipAtPoint(onSE, transform.position);
			GetComponent<GameManager>().AddScore(); // GameManagerにあるscore++;を実行
			Destroy(collision.gameObject);
		}
	}
}
