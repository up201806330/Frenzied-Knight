using System.Collections;
using UnityEditor.UI;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    public GameObject knight, demon;

    [SerializeField]
    public bool enraged = false;
    
    void Start()
    {
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }

    public IEnumerator Transform(bool enraged)
    {
        this.enraged = enraged;
        Animator anim;
        if (enraged)
        {
            anim = knight.GetComponent<Animator>();
            anim.SetTrigger("SwitchState");
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            switchToDemon();
        } else if (!enraged)
        {
            anim = demon.GetComponent<Animator>();
            anim.SetTrigger("SwitchState");
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            switchToKnight();
        }
    }

    public void switchToDemon()
    {
        knight.gameObject.SetActive(false);
        demon.gameObject.SetActive(true);
    }

    public void switchToKnight()
    {
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }
}