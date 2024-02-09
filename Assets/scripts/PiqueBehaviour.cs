using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiqueBehaviour : MonoBehaviour
{

    public int Damage = 2;
    public bool move = false;
    
    public float Speed = 0.01f;
    public float time = 1;

    private float currentTime = 0;
     

    // Side : true -> vers la gauche
    private string side = "left";

    private void Update()
    {
        if (move)
        {
            if(currentTime <= time) {
                if(side.Equals("left"))
                {
                    gameObject.transform.Translate(new Vector3(-Speed, 0, 0));
                }
                else
                {
                    gameObject.transform.Translate(new Vector3(Speed, 0, 0));
                }

                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0;
                side = side.Equals("left") ? "right" : "left";
            }
            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            // Retirer une vie au joueur
            GameManager.Instance.Hit(this);
        }
    }
}
