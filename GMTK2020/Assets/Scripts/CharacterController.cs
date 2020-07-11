using UnityEngine;

public class CharacterController : MonoBehaviour
{
	protected bool m_FacingRight = true;  // For determining which way the player is currently facing.

	public Animator animator;

	void Update()
    {
		float horizontalMove = Input.GetAxisRaw("Horizontal"), verticalMove = Input.GetAxis("Vertical");
		if ((horizontalMove > 0 && !m_FacingRight) || (horizontalMove < 0 && m_FacingRight)) Flip();

		if (horizontalMove == 0 && verticalMove == 0) animator.SetBool("isMoving", false);
		else animator.SetBool("isMoving", true);
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		// So that the knight body stays on the same position when getting flipped with the spear, instead of flipping the entire sprite.
		// Not optimal but faster than making the spear a game object on its own.
		if(gameObject.name == "Knight")
		{
			if(m_FacingRight) transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			else if(!m_FacingRight) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);;
		} 
	}
}