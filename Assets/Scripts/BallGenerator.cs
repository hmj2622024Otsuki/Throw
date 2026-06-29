using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallGenerator : MonoBehaviour
{
	[SerializeField] GameObject nekoPrefab;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] private float throwForce = 10f;
	Rigidbody2D rigid2D;

	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			GameObject Ball = Instantiate(ballPrefab);
			rigid2D = Ball.GetComponent<Rigidbody2D>();

			if (rigid2D != null)
			{
				Ball.transform.position = nekoPrefab.transform.position;
				Vector2 throwDirection = new Vector2(1f, 1f).normalized;

				rigid2D.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
			}

			Destroy(Ball, 3.0f);
		}
	}
}