using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;
    public TMP_Text textPV;
    public PlayerBehavior playerBehavior;
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textPV.text = $"{playerBehavior.CurrentLife}/{playerBehavior.LifeTotal}";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hit(PiqueBehaviour sPiquerBehavour)
    {
        Debug.Log("Hit !");

        if (playerBehavior.isAlive)
        {
            playerBehavior.CurrentLife -= sPiquerBehavour.Damage;
            if (playerBehavior.CurrentLife <= 0)
            {
                // DEAD
                playerBehavior.isAlive = false;
                playerBehavior.CurrentLife = 0;
            }

            Debug.Log("Point de vie restant : " + playerBehavior.CurrentLife);

            if (playerBehavior.isAlive)
            {
                Debug.Log("En vie !");
            }
            else
            {
                Debug.Log("Est mort !");
                Destroy(playerBehavior.gameObject);
            }
        }

        textPV.text = $"{playerBehavior.CurrentLife}/{playerBehavior.LifeTotal}";
    }

}
