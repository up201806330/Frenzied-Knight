using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attack = 1;
    public float knockback = 5000;

    GameObject player;
    private Renderer rend;
    private Color c;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainPlayer");
        rend = player.GetComponent<Renderer>();
        c = rend.material.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // when enemy collides with the player we take damage
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<Animator>().SetTrigger("Hit");

            player.GetComponent<PlayerHealth>().TakeDamage(attack);

            StartCoroutine(Knockback(0.02f, knockback, player.GetComponent<Rigidbody2D>().transform));

            StartCoroutine(getInvulnerable());
        }
    }

    IEnumerator getInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(1f);
        c.a = 1f;
        rend.material.color = c;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Transform obj)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            player.GetComponent<Rigidbody2D>().AddForce(direction * knockbackPwr);
        }

        yield return 0;
    }
}