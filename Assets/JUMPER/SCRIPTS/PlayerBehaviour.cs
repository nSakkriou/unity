using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerBehaviour : MonoBehaviour
{

    private bool _isGrounded;
    public LayerMask CollisionMask;
    public Transform LeftSide;
    public Transform RightSide;
    public Camera camera;
    public Animator Anim;
    public float clickdelay = 0.5f;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    public Vector2 originalColliderSize;
    public Vector2 sitColliderSize;

    private float playerHalfWidth;

    public BulletBehaviour bullet = GameManagerBehaviour.instance.bulletBehaviour;
    public Transform bulletPosition;



    public float jumpForce = 150;
    private float botRayCastValue = 0.20f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        playerHalfWidth = GetComponent<Collider2D>().bounds.extents.x; // half width of the player
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = boxCollider.size;
        sitColliderSize = boxCollider.size;
        sitColliderSize.y = sitColliderSize.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.down, botRayCastValue, CollisionMask); ;
        RaycastHit2D hit2 = Physics2D.Raycast(LeftSide.position, Vector2.down, botRayCastValue, CollisionMask);
        RaycastHit2D hit3 = Physics2D.Raycast(RightSide.position, Vector2.down, botRayCastValue, CollisionMask);

        _isGrounded = hit1.collider != null || hit2.collider != null || hit3.collider != null;
        Anim.SetFloat("VSpeed", rigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && PauseResumeBehaviour.isStart)
        {
            rigidBody.AddForce(Vector2.up * jumpForce);  
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(-speed);
        }

        // Dash
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Anim.SetTrigger("dash");
            MovePlayer(-(speed * 2));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Anim.SetTrigger("dash");
            MovePlayer(speed * 2);
        }*/


        // -- 

        // Sit

        if(Input.GetKey(KeyCode.LeftShift)) {
            Anim.SetBool("isSit", true);
            sitPlayer();
        }
        else
        {
            unSitPlayer();
            Anim.SetBool("isSit", false);
        }

        // --

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            // Shoot
            Anim.SetTrigger("shoot");
            Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
        }
    }

    void MovePlayer(float move)
    {
        float newXPos = transform.position.x + move * Time.deltaTime;
        float minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerHalfWidth;
        float maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerHalfWidth;

        // Limit movement within camera bounds
        newXPos = Mathf.Clamp(newXPos, minX, maxX);

        // Apply new position
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }

    void sitPlayer()
    {
        boxCollider.size = sitColliderSize;
    }

    void unSitPlayer()
    {
        boxCollider.size = originalColliderSize;
    }
}
