using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healthGain = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        //when colliding with player the player gains health and the potion gets destroyed
        if(other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<PlayerHealth>().TakeDamage(-healthGain);
            Destroy(this.gameObject);
        }
    }
}