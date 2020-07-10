using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float range;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer(){
        animator.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
