using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : MonoBehaviour
{
    private float fixedTimer = 0.4f;
    private float timer;

    private AudioSource fireballSound;

    // Start is called before the first frame update
    void Start()
    {
        timer = fixedTimer;
        fireballSound = GameObject.Find("FireballSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; //dash cooldown goes down

        //if player presses spacebar
        if(Input.GetButtonDown("Attack") && timer <= 0)
        {
            GetComponent<Animator>().SetTrigger("Attacking");
            Shoot();
            timer = fixedTimer; //reset the timer
        }
    }

    //spawn a fireball
    private void Shoot()
    {
        fireballSound.Play();
        Instantiate(Resources.Load("Prefabs/Fireball"), transform.position, transform.rotation);
    }
}