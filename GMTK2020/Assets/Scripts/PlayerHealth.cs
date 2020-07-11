using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SwitchState switchState;
    public int health = 30;
    private int healthToEnrage;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switchState = GetComponent<SwitchState>();
        healthToEnrage = health % 4;
    }

    // player takes damage (or gains health if damage is negative)
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("PLAYER HEALTH: " + health);
        //we enrage the player based on current health
        if(health > healthToEnrage)
        {
            switchState.enraged = false;
        }
        if(health <= healthToEnrage && health > 0)
        {
            switchState.enraged = true;
        } else if(health <= 0) Destroy(gameObject);
    }
}