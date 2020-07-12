using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTutorial : MonoBehaviour
{
    private static bool show = true;
    // Start is called before the first frame update
    void Start()
    {
        if(show)
        {
            this.gameObject.SetActive(true);
            StartCoroutine(DestroyTuto());
            show = false;
        }
    }

    IEnumerator DestroyTuto()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}