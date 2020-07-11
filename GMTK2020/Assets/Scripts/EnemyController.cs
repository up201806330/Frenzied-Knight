﻿using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private GameObject target;
    [SerializeField]
    private float speed = 100f;

    private Vector2 direction = Vector2.zero;

    private bool m_FacingRight = true;  // For determining which way the enemy is currently facing.

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        followPlayer();
    }

    void followPlayer(){
        //if (target.alive) animator.SetBool("playerDead", false);
        //else
        //{
        //    animator.SetBool("playerDead", true);
        //    return;
        //}

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
}