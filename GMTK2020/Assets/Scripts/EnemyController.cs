using UnityEngine;

public class EnemyController : CharacterController
{
    [SerializeField]
    private PlayerController target;
    [SerializeField]
    private float speed = 100f;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = target.GetComponent<SwitchState>().currentState().GetComponent<PlayerController>();
    }

    void Update()
    {
        followPlayer();
    }

    void followPlayer(){
        if (!target.alive) animator.SetBool("playerDead", false);
        else
        {
            animator.SetBool("playerDead", true);
            return;
        }

        float horizontalMove = target.transform.position.x - transform.position.x;
        if ((horizontalMove > 0.8f && !m_FacingRight) || (horizontalMove < -0.8f && m_FacingRight)) Flip();
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
        }
    }
}
