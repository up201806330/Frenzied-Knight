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

    private void Update()
    {
        if (enraged)
        {
            switchToDemon();
        } else if (!enraged)
        {
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