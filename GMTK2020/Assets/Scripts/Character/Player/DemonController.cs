using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : CharacterController
{
    private SwitchState state;

    private void Start()
    {
        state = GetComponentInParent<SwitchState>();
    }

    protected override void Update()
    {
        base.Update();
        Flip();
    }

    protected override void Flip()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal"), verticalMove = Input.GetAxis("Vertical");
        if (!state.dead && ((horizontalMove > 0f && !m_FacingRight) || (horizontalMove < 0f && m_FacingRight)))
        {
            base.Flip();
        }
    }
}
