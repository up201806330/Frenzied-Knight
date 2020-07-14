using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float knightSpeed = 200f;
	public float demonSpeed = 300f;
	private float speed;
	private Rigidbody2D rb;
	private SwitchState state;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		state = GetComponent<SwitchState>();
	}

	void FixedUpdate()
	{

		float horizontalMove = Input.GetAxisRaw("Horizontal") * speed, verticalMove = Input.GetAxis("Vertical") * speed;
		
		if (state.dead)
        {
			horizontalMove = 0; 
			verticalMove = 0;
        }

		if(!state.enraged) speed = knightSpeed;
		else if(state.enraged) speed = demonSpeed;

		if(horizontalMove == 0 || verticalMove == 0)
		{
			rb.velocity = new Vector2(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
		} else
		{
			rb.velocity = new Vector2(0.85f * horizontalMove * Time.fixedDeltaTime, 0.85f * verticalMove * Time.fixedDeltaTime);
		}
		
	}
}