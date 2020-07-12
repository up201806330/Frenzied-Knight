using UnityEngine;

public class EnemyController : CharacterController
{
    private GameObject target;
    [SerializeField]
    private float speed = 100f;
    private SwitchState state;

    private EnemyHealth enemyHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        state = target.GetComponentInParent<SwitchState>();

        enemyHealth = this.GetComponent<EnemyHealth>();
    }

    protected override void Update()
    {
        base.Update();
        if (state.dead)
        {
            animator.SetBool("playerDead", true);
            return;
        }
        if(!enemyHealth.isFrozen)
        {
            followPlayer();
        }
    }

    void followPlayer(){
       
        float horizontalMove = target.transform.position.x - transform.position.x;
        if ((horizontalMove > 0f && !m_FacingRight) || (horizontalMove < 0f && m_FacingRight)) Flip();

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
    }
}