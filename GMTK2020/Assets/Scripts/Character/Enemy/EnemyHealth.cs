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

    [SerializeField]
    public int dropChance = 45;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    private void Update()
    {
        transform.GetChild(1).localScale = new Vector3(enemyHealth * healthSegment , 0.1f, 1);
    }

    public void DealDamageToEnemy(int damage)
    {
        
        if(enemyHealth <= 0) //if enemy health is <= 0 it has a change to drop the potion and gets destroyed 
        {
            if(Random.Range(1,100) <= dropChance) //45% chance
            {
                Instantiate(Resources.Load("Prefabs/Potion"), transform.position, transform.rotation);
            }
            
            //GameObject.Find("Generator").GetComponent<EnemyGenerator>().enemyCount--;
            
            //we add score based on enemy's name
            if(this.gameObject.name == "TinyGuy") score.AddScore(5);
            else if(this.gameObject.name == "Skeleton") score.AddScore(10);
            else if(this.gameObject.name == "Zombie") score.AddScore(15);

            Destroy(gameObject);
        }

        GetPushed();
        enemyHealth -= damage;
    }

    private void GetPushed()
    {
        transform.position = Vector2.MoveTowards(transform.position, pushPos.position, pushForce * Time.deltaTime);
    }
}