using UnityEditor.UI;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    public GameObject knight, demon;

    [SerializeField]
    public bool enraged = false;
    private bool locked = false;
    void Start()
    {
        knight.gameObject.SetActive(true);
        demon.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (enraged && !locked)
        {
            switchToDemon();
            enraged = false;
            locked = true;
        }
    }

    public void switchToDemon()
    {
        knight.gameObject.SetActive(false);
        demon.gameObject.SetActive(true);
    }
}
