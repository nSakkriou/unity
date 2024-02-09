using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBorderBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManagerBehaviour.instance.endGame();
        }
        
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
