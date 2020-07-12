using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dash = 5000f; 
    private float fixedTimer = 0.3f;
    private float timer;
    private PlayerHealth health;

    private GameObject spear;


    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        timer = fixedTimer;
        health = GetComponentInParent<PlayerHealth>();

        spear = transform.GetChild(0).gameObject; //get the spear which is a child of this object
    }

    // Update is called once per frame
    void Update()
    {
        spear.SetActive(false);

        timer -= Time.deltaTime; //dash cooldown goes down

        //if player presses spacebar
        if(Input.GetButtonDown("Attack") && timer <= 0 && !health.takingDamage)
        {
            GetComponent<Animator>().SetTrigger("Attacking");
            Attack();
            timer = fixedTimer; //reset the timer
        }
    }

    private void Attack()
    {
        spear.SetActive(true); //the spear is able to deal damage
        Vector3 direction = transform.localScale.normalized; 
        rb.AddForce( new Vector2(direction.x * dash, 0f)); //we apply the force in the direction character is facing
        StartCoroutine(getInvulnerable());
    }

    
    IEnumerator getInvulnerable()
    {
        yield return new WaitForSeconds(0.35f);
    }
}