﻿using System.Collections;
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
    private KnightAttack knightAttack;

    private AudioSource hitSound;
    private AudioSource healSound;
    private AudioSource deathSound;
    public bool takingDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switchState = GetComponent<SwitchState>();
        healthBar = GameObject.Find("PlayerHealthBar").GetComponent<HealthBar>();
        healthToEnrage = (int)Math.Ceiling((double)health / 2); 
        healthBar.SetMaxSlider(health); //we set the slider's max value to the max value of player's health
        knightAttack = GameObject.Find("Knight").GetComponent<KnightAttack>();

        hitSound = GameObject.Find("HitSound").GetComponent<AudioSource>();
        healSound = GameObject.Find("HealSound").GetComponent<AudioSource>();
        deathSound = GameObject.Find("DeathSound").GetComponent<AudioSource>();
    }

    // player takes damage (or gains health if damage is negative)
    public void TakeDamage(int damage)
    {
        if (!takingDamage)
        {
            health -= damage;
            healthBar.ChangeSliderValue(-damage);
            takingDamage = true;

            if (damage > 0)
            {
                hitSound.Play();
                GetComponentInChildren<Animator>().SetTrigger("Hit");
            }
            else if (damage < 0)
            {
                healSound.Play();
                GetComponentInChildren<Animator>().SetTrigger("Heal");
            }
            
            if(health > healthToEnrage) // Is in demon mode and regained enough health
            {
                switchState.enraged = true;
                switchState.Transform(false);
            }
            if (health <= healthToEnrage && health > 0) // Is in knight mode and lost enough health
            {
                switchState.enraged = false;
                switchState.Transform(true);
            }
            else if (health <= 0) // Died
            {
                //Destroy(gameObject);
                deathSound.Play();
                GetComponentInChildren<Animator>().SetTrigger("Dead");
            }
        }  
    }
}