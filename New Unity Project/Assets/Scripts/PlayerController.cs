using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 200f;
	void Update()
	{
		float horizontalMove = Input.GetAxisRaw("Horizontal") * speed, verticalMove = Input.GetAxis("Vertical") * speed;
		GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
	}

  
}
