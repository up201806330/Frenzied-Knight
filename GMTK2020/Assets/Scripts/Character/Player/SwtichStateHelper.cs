using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichStateHelper : MonoBehaviour
{
    private SwitchState switchState;

    private void Start()
    {
        switchState = GetComponentInParent<SwitchState>();
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
        switchState.deadDone = true;
    }
}