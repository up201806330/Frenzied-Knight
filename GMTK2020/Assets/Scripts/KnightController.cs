using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : CharacterController
{
    public bool alive = true;

    protected override void Flip()
    {
        base.Flip();

        // So that the knight body stays on the same position when getting flipped with the spear, instead of flipping the entire sprite.
        // Not optimal but faster than making the spear a game object on its own.
        if (gameObject.name == "Knight")
        {
            if (m_FacingRight) transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            else if (!m_FacingRight) transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z); ;
        }
    }
}
