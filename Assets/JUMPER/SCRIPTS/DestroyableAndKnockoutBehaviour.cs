using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableAndKnockoutBehaviour: MovementItemBehaviour
{
    public virtual void collisionComportement()
    {
        gameObject.transform.Translate(new Vector3(gameObject.transform.position.x - 15, 0, 0));
    }
}
