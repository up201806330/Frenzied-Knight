using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTuto());
    }

    IEnumerator DestroyTuto()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}