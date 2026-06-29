using System.Threading.Tasks;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
	[SerializeField] GameObject basketPrefab;
	[SerializeField] GameObject Ball;
	[SerializeField] Transform centerPoint;
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
}
