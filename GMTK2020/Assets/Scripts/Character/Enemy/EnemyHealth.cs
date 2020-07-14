using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Rigidbody2D rb;
    public float enemyHealth = 5f;
    public float healthSegment = 0.3f;
    public float pushForce = 300f;
    public Transform pushPos;
    private Score score;
    private Animator anim;

    [SerializeField]
    public int dropChance = 40;

    public bool isFrozen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.Find("GameManager").GetComponent<Score>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.GetChild(1).localScale = new Vector3(enemyHealth * healthSegment , 0.1f, 1);
    }

    public void DealDamageToEnemy(int damage)
    {
        anim.SetTrigger("Hit");
        StartCoroutine(Freeze());

        if(enemyHealth <= 0) //if enemy health is <= 0 it has a change to drop the potion and gets destroyed 
        { 
            //we add score based on enemy's name
            if(this.gameObject.name == "TinyGuy") 
            {
                score.AddScore(5);
                DropChance(20);
            } else if(this.gameObject.name == "Skeleton")
            {
                score.AddScore(10);
                DropChance(40);
            } else if(this.gameObject.name == "Zombie")
            {
                score.AddScore(15);
                DropChance(60);
            }

            Destroy(gameObject);
        }
        
        enemyHealth -= damage;
        GetPushed();
    }

    IEnumerator Freeze()
    {
        isFrozen = true;
        yield return new WaitForSeconds(0.6f);
        isFrozen = false;
    }

    //chance of dropping a potion
    private void DropChance(int chance)
    {
        if(Random.Range(1,100) <= chance) Instantiate(Resources.Load("Prefabs/Potion"), transform.position, transform.rotation);
    }

    private void GetPushed()
    {
        transform.position = Vector2.MoveTowards(transform.position, pushPos.position, pushForce * Time.deltaTime);
    }
}