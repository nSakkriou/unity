using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraBehaviour : MonoBehaviour
{

    public GameObject frontTree;
    public GameObject frontTree2;
    private float frontTreeLength;

    public float frontTreeSpeed = 1f;
    private GameObject onScreenFrontTree;
    private GameObject offScreenFrontTree;


    // Start is called before the first frame update
    void Start()
    {
        frontTreeLength = frontTree.GetComponent<SpriteRenderer>().size.x / 10;
        onScreenFrontTree = frontTree;
        offScreenFrontTree = frontTree2;

        //backTreeStartPos = backTree.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (onScreenFrontTree.transform.position.x <= -1)
        {
            offScreenFrontTree.transform.position = new Vector3(onScreenFrontTree.transform.position.x + frontTreeLength, 0, 0);

            GameObject temp = onScreenFrontTree;
            onScreenFrontTree = offScreenFrontTree;
            offScreenFrontTree = temp;
        }
        
        frontTree.transform.Translate(new Vector3(-frontTreeSpeed * Time.deltaTime, 0, 0));
        frontTree2.transform.Translate(new Vector3(-frontTreeSpeed * Time.deltaTime, 0, 0));
    }
}
