using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    private SwitchState switchState;
    public int health = 30;
    private int healthToEnrage;
    private Rigidbody2D rb;

    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switchState = GetComponent<SwitchState>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthToEnrage = (int)Math.Ceiling((double)health / 2); 
        healthBar.SetMaxSlider(health); //we set the slider's max value to the max value of player's health
    }

    // player takes damage (or gains health if damage is negative)
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.ChangeSliderValue(-damage);
       
        //we enrage the player based on current health
        if(health > healthToEnrage && switchState.enraged)
        {
            StartCoroutine(switchState.Transform(false));
        }
        if (health <= healthToEnrage && health > 0 && !switchState.enraged)
        {
            StartCoroutine(switchState.Transform(true));
        }
        else if (health <= 0)
        {
            GameObject.Find("Generator").GetComponent<EnemyGenerator>().active = false; // Stop spawner
            Destroy(gameObject);
        }
    }
}