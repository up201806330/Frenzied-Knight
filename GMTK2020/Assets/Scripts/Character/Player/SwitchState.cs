using System.Collections;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    private GameObject knight, demon;

    [SerializeField]
    public bool enraged = false;

    public bool dead = false;

    private AudioSource knightMusic; 
    private AudioSource demonMusic;

    private AudioSource enrageSound;

    private PlayerHealth health;
    
    void Start()
    {
        knight = GameObject.Find("Knight");
        demon = GameObject.Find("Demon");
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);

        enrageSound = GameObject.Find("EnrageSound").GetComponent<AudioSource>();

        knightMusic = GameObject.Find("KnightMusic").GetComponent<AudioSource>();
        demonMusic = GameObject.Find("DemonMusic").GetComponent<AudioSource>();
        demonMusic.volume = 0;

        health = this.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // knight and demon music
        if(enraged)
        {
            if(demonMusic.volume == 0)
            {
                demonMusic.Stop();
                demonMusic.Play();
            }
            knightMusic.volume -= 0.025f;
            demonMusic.volume += 0.025f;
        } else if(!enraged)
        {
            if(knightMusic.volume == 0)
            {
                knightMusic.Stop();
                knightMusic.Play();
            }
            demonMusic.volume -= 0.025f;
            knightMusic.volume += 0.025f;
        }
    }

    public void switchToKnight()
    {
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }

    public void switchToDemon()
    {
        enrageSound.Play();
        knight.gameObject.SetActive(false);
        demon.gameObject.SetActive(true);
    }

    public void Transform(bool enraged)
    {
        this.enraged = enraged;
        Animator anim;
        if (enraged)
        {
            anim = knight.GetComponent<Animator>();
            anim.SetTrigger("SwitchState");
        } else
        {
            anim = demon.GetComponent<Animator>();
            anim.SetTrigger("SwitchState");
        }
        health.takingDamage = false;
    }
}