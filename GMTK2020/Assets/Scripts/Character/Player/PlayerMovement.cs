using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 200f;
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		float horizontalMove = Input.GetAxisRaw("Horizontal") * speed, verticalMove = Input.GetAxis("Vertical") * speed;
		if(horizontalMove == 0 || verticalMove == 0)
		{
			rb.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
		} else
		{
			rb.velocity = new Vector2(0.85f * horizontalMove * Time.fixedDeltaTime, 0.85f * verticalMove * Time.fixedDeltaTime);
		}
		
	}
}