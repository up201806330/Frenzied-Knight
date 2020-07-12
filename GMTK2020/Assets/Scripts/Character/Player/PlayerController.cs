using UnityEngine;

public class PlayerController : CharacterController
{
	public float speed = 200f;
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	protected override void Update()
	{

		float horizontalMove = Input.GetAxisRaw("Horizontal") * speed, verticalMove = Input.GetAxis("Vertical") * speed;
		
		if (GetComponent<SwitchState>().dead)
        {
			horizontalMove = 0; verticalMove = 0;
        }

		if(horizontalMove == 0 || verticalMove == 0)
		{
			rb.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
		} else
		{
			rb.velocity = new Vector2(0.85f * horizontalMove * Time.fixedDeltaTime, 0.85f * verticalMove * Time.fixedDeltaTime);
			if ((horizontalMove > 0f && !m_FacingRight) || (horizontalMove < 0f && m_FacingRight)) Flip();
		}

		
	}
}