using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallGenerator : MonoBehaviour
{
	[SerializeField] GameObject nekoPrefab;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] AudioClip ThrowSE;
	[SerializeField] private float throwForce = 10f;
	Rigidbody2D rigid2D;

	private void Update()
	{
		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			// クローンを作成
			GameObject Ball = Instantiate(ballPrefab);
			rigid2D = Ball.GetComponent<Rigidbody2D>();

			if (rigid2D != null)
			{
				// ヌコちゃんの中心座標からボールを放つ
				Ball.transform.position = nekoPrefab.transform.position;
				Vector2 throwDirection = new Vector2(1f, 1f).normalized;

				// 投げる動作
				rigid2D.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
				AudioSource.PlayClipAtPoint(ThrowSE, transform.position);
			}

			// 何もなかった場合3秒後にクローンを消す
			Destroy(Ball, 3.0f);
		}
	}
}