using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(Collider2D))]
public class BossBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
/*    private Rigidbody2D rigidBody;*/
    private BoxCollider2D boxCollider;
    public LayerMask CollisionMask;

    public float timeSinceDead = 0;
    public float deadTime = 10f;
    public bool isDead = false;
    public bool trigerDeadAlreadyActivated = false;

    public int pv = 100;

    public ItemSpawnerBehaviour spawnerBot;
    public ItemSpawnerBehaviour spawnerTop;

    public float secondToHugeAttack = 6f;
    public float timeCount = 0;

    public DestroyableItemBehaviour monster;

    void Start()
    {
/*        rigidBody = GetComponent<Rigidbody2D>();*/
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pv <= 0)
        {
            dead();
        }

        timeCount += Time.deltaTime;
        if(timeCount > secondToHugeAttack )
        {
            if(Random.Range(0, 2) == 0)
            {
                trident();
            }
            else
            {
                spawnMonster();
            }

            timeCount = 0;
        }

        //spawnMonster();
    }

    void dead()
    {
        Anim.SetBool("isDead", true);
        if(!trigerDeadAlreadyActivated)
        {
            Anim.SetTrigger("dead");
            trigerDeadAlreadyActivated = true;
        }
        
        isDead = true;

        GameManagerBehaviour.instance.gameStatus = "win";
        stopSpawners();

        Destroy(gameObject, 5f);
    }

    void hit(int sDamage)
    {
        if(pv-sDamage > 0) {
            pv -= sDamage;
        }
        else
        {
            pv = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            hit(collision.gameObject.GetComponent<BulletBehaviour>().damage);
            Destroy(collision.gameObject);
        }
    }

    void spawnMonster()
    {
        Anim.SetTrigger("SpawnMonster");
        Instantiate(monster, spawnerTop.transform.position, spawnerTop.transform.rotation);
    }

    void trident()
    {
        Anim.SetTrigger("Trident");
    }

    void stopSpawners()
    {
        spawnerBot.isRunning = false;
        spawnerTop.isRunning = false;
    }
}
