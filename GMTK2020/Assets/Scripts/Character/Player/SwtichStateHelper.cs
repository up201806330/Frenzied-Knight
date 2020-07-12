using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichStateHelper : MonoBehaviour
{
    private SwitchState switchState;
    private GameManager gm;

    private void Start()
    {
        switchState = GetComponentInParent<SwitchState>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void switchToKnight()
    {
        switchState.switchToKnight();
    }

    private void switchToDemon()
    {
        switchState.switchToDemon();
    }

    private void die()
    {
        switchState.dead = true;
    }

    private void dieDone()
    {
        gm.lost = true;
    }
}