using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerBehaviour : MonoBehaviour
{
    public float countTime = 0;
    public float second2SpawnTrapMinRange = 1.2f;
    public float second2SpawnTrapMaxRange = 2.0f;

    public float randomSecond2Spawn;

    public bool isRunning = true;

    public List<ItemBehaviour> itemsList = new List<ItemBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        randomSecond2Spawn = getRandomSecond2Spawn(second2SpawnTrapMinRange, second2SpawnTrapMaxRange);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning)
        {
            countTime += Time.deltaTime;
            if (countTime >= randomSecond2Spawn)
            {
                generateTrap();
                countTime = 0;

                randomSecond2Spawn = getRandomSecond2Spawn(second2SpawnTrapMinRange, second2SpawnTrapMaxRange);
                Debug.Log("GENERATE");
            }
        }
        
        
    }

    public void generateTrap()
    {
        if(itemsList.Count > 0 ) { 
            int randomPrefab = UnityEngine.Random.Range(0, itemsList.Count);
            Instantiate(itemsList[randomPrefab], this.transform.position, this.transform.rotation);
        }
    }

    public float getRandomSecond2Spawn(float sMin, float sMax)
    {
        return UnityEngine.Random.Range(sMin, sMax);
    }
}
