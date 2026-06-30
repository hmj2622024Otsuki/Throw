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

	}

    // Update is called once per frame
    void Update()
    {
		float angle = Time.time * speed;

		float y = centerPoint.position.y + Mathf.Cos(angle) * radius;
		float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

		transform.position = new Vector3(transform.position.x, y, z);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			AudioSource.PlayClipAtPoint(onSE, transform.position);
			Destroy(collision.gameObject);
		}
	}
}
