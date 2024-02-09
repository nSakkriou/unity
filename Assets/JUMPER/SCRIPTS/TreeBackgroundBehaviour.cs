using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBackgroundBehaviour : MonoBehaviour
{
    public GameObject frontTree;
    public GameObject frontTree2; 
    public float frontTreeLength = 100;
    public bool slower = false;

    private GameObject onScreenFrontTree;
    private GameObject offScreenFrontTree;

    public bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isGround)
        {
            frontTreeLength = frontTree.GetComponent<SpriteRenderer>().size.x / 10;
        }
            onScreenFrontTree = frontTree;
        offScreenFrontTree = frontTree2;

        //backTreeStartPos = backTree.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (onScreenFrontTree.transform.position.x <= -1.5)
        {
            offScreenFrontTree.transform.position = new Vector3(onScreenFrontTree.transform.position.x + frontTreeLength, offScreenFrontTree.transform.position.y, offScreenFrontTree.transform.position.z);

            GameObject temp = onScreenFrontTree;
            onScreenFrontTree = offScreenFrontTree;
            offScreenFrontTree = temp;
        }

        float speed = -1;
        if (slower)
        {
            speed += (speed * 0.20f)/100;
        }
        

        frontTree.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        frontTree2.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
