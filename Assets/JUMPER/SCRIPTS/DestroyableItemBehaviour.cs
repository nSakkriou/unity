using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableItemBehaviour : MovementItemBehaviour
{
    public int pv;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            pv -= (collision.gameObject.GetComponent<BulletBehaviour>().damage);
            Destroy(collision.gameObject);
            collisionComportement();
        }

        if(pv <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void collisionComportement()
    {

    }
}
