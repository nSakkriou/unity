using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementItemBehaviour : ItemBehaviour
{

    
    public GameObject item;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAction();

        
        item.transform.Translate(new Vector3(-GameManagerBehaviour.getSpeed() * Time.deltaTime, 0, 0));
    }

    public virtual void UpdateAction()
    {

    }
}
