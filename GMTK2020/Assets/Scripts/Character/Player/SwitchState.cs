using System.Collections;
using UnityEditor.UI;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    private GameObject knight, demon;

    [SerializeField]
    public bool enraged = false;
    
    void Start()
    {
        knight = GameObject.Find("Knight");
        demon = GameObject.Find("Demon");
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }

    public void switchToKnight()
    {
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }

    public void switchToDemon()
    {
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
    }
}