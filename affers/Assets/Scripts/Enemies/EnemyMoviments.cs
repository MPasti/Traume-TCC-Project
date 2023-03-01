using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviments : MonoBehaviour
{

    float speed;
    Rigidbody2D rb;
    public bool isStatic;
    public bool isWalker;
    public bool walksRight;
    public bool isPatrol;
    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;

    public Transform wallCheck, pitCheck, groundCheck;
    public bool wallDetected, pitDetected, isGround;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform PointA, PointB;
    bool goToA, goToB;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGround = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

        if ((pitDetected || wallDetected) && isGround)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("aff", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("aff", false);
            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed *Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatrol)
        {
            
            if (goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("aff", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                

                if(Vector2.Distance(transform.position, PointA.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }
            if (goToB)
            {
                if (!isWaiting)
                {
                    anim.SetBool("aff", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
                if (Vector2.Distance(transform.position, PointB.position )< 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }
    IEnumerator Waiting()
    {
        anim.SetBool("aff", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        anim.SetBool("aff", false);
        Flip();
    }
    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
