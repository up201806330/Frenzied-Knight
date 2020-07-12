using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : CharacterController
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

            // So that the knight body stays on the same position when getting flipped with the spear, instead of flipping the entire sprite.
            // Not optimal but faster than making the spear a game object on its own.
            if (m_FacingRight) transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            else if (!m_FacingRight) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z); ;
        }
    }
}
