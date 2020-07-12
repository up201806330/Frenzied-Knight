using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
	protected bool m_FacingRight = true;  // For determining which way the player is currently facing.
	public Animator animator;

	private SwitchState playerState;

    private void Start()
    {
		playerState = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<SwitchState>();
    }

    protected virtual void Update()
    {
		//if (playerState == null) Debug.Log(this.name);
		//if (playerState.dead) return;
		float horizontalMove = Input.GetAxisRaw("Horizontal"), verticalMove = Input.GetAxis("Vertical");
		if ((horizontalMove > 0 && !m_FacingRight) || (horizontalMove < 0 && m_FacingRight)) Flip();
	}

	protected virtual void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}