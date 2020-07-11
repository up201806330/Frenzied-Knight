using UnityEngine;

public class EnemyController : CharacterController
{
    private GameObject target;
    [SerializeField]
    private float speed = 100f;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        followPlayer();
    }

    void followPlayer(){
        if (!target.GetComponent<KnightController>().alive) animator.SetBool("playerDead", false);
        else
        {
            animator.SetBool("playerDead", true);
            return;
        }

        float horizontalMove = target.transform.position.x - transform.position.x;
        if ((horizontalMove > 0.8f && !m_FacingRight) || (horizontalMove < -0.8f && m_FacingRight)) Flip();
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    
}