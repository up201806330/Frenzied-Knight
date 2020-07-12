using UnityEngine;

public class EnemyController : CharacterController
{
    private GameObject target;
    [SerializeField]
    private float speed = 100f;
    private bool playerDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {      
        if (target.GetComponentInParent<SwitchState>().dead)
        {
            animator.SetBool("playerDead", true);
            playerDead = true;
        }
        if (!playerDead)
        {
            float horizontalMove = target.transform.position.x - transform.position.x;
            if ((horizontalMove > 0f && !m_FacingRight) || (horizontalMove < 0f && m_FacingRight)) Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}