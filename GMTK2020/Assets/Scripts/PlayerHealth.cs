using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SwitchState switchState;
    public int health = 10;
    private int healthToEnrage;

    // Start is called before the first frame update
    void Start()
    {
        switchState = GetComponent<SwitchState>();
        healthToEnrage = health % 4;
    }

    // player takes damage (or gains health if damage is negative)
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        //we enrage the player based on current health
        if(health > healthToEnrage)
        {
            switchState.enraged = false;
        }
        if(health <= healthToEnrage)
        {
            switchState.enraged = true;
        } else if(health <= 0) Destroy(gameObject);
    }
}