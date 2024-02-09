using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public CharacterData Character;

    private bool _isGrounded;
    private Rigidbody2D _rb;
    private SpriteRenderer _sp;
    public LayerMask CollisionMask;
    public Transform LeftSide;
    public Transform RightSide;
    public Animator Anim;

    


    public int LifeTotal = 3;
    public int CurrentLife;
    public bool isAlive;

    private bool isBoost = false;
    private float boostMaxTime = 5;
    private float boostCurrentTime = 0;

    private int jumpForceIncrement = 0;

    private void Awake()
    {
        CurrentLife = LifeTotal;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

        _isGrounded = false;

        CurrentLife = LifeTotal;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        updateForceJump();

        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, Vector2.down, 0.18f, CollisionMask); ;
        RaycastHit2D hit2 = Physics2D.Raycast(LeftSide.position, Vector2.down, 0.18f, CollisionMask);
        RaycastHit2D hit3 = Physics2D.Raycast(RightSide.position, Vector2.down, 0.18f, CollisionMask);

        _isGrounded = hit1.collider != null || hit2.collider != null || hit3.collider != null;

        Anim.SetFloat("VSpeed", _rb.velocity.y);
        _rb.velocity = new Vector2(Character.Speed, _rb.velocity.y);
        _sp.flipX = false;
        Anim.SetBool("isRunning", true);

        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(Character.Speed, _rb.velocity.y);
            _sp.flipX = false;
            Anim.SetBool("isRunning", true);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-Character.Speed, _rb.velocity.y);
            _sp.flipX = true;
            Anim.SetBool("isRunning", true);
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }
        */

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector2.up * Character.JumpForce);
        }
    }

    public void startBoostForceJump(int sIncrementJumpForce)
    {
        Character.JumpForce += sIncrementJumpForce;
        jumpForceIncrement = sIncrementJumpForce;
        isBoost = true;
    }

    public void updateForceJump()
    {
        if (isBoost)
        {
            if(boostCurrentTime >= boostMaxTime)
            {
                isBoost = false;
                Character.JumpForce -= jumpForceIncrement;
                
                boostCurrentTime = 0;
            }
            else
            {
                boostCurrentTime += Time.deltaTime;
            }
        }
    }
}