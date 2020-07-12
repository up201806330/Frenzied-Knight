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
        healthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        healthToEnrage = (int)Math.Ceiling((double)health / 2); 
        healthBar.SetMaxSlider(health); //we set the slider's max value to the max value of player's health
    }

    // player takes damage (or gains health if damage is negative)
    public void TakeDamage(int damage)
    {
        if(!switchState.enraged && GameObject.Find("Knight").GetComponent<KnightAttack>().canTakeDamage || switchState.enraged)
        {
            health -= damage;
            healthBar.ChangeSliderValue(-damage);
            
            if(health > healthToEnrage && switchState.enraged) // Is in demon mode and regained enough health
            {
                switchState.Transform(false);
            }
            
            if (health <= healthToEnrage && health > 0 && !switchState.enraged) // Is in knight mode and lost enough health
            {
                switchState.Transform(true);
            }
            else if (health <= 0) // Died
            {
                Destroy(gameObject);
            }
            else if (damage > 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("Hit");
            } else if (damage < 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("Heal");
            }
        }
    }
}