using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    public bool isWalking;

    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int WalkDirection;

    private Animator anim;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
   



    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       

        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f); ;
        walkCounter = Random.Range(walkTime * 0.75f, walkTime * 1.25f);

        ChooseDirection();

        //if there is even a box collider for the constraint
        if (walkZone != null)
        { 
            //Is for finding move contraint area by cords
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
        //Stops the movement and the update method
        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        //When the NPC is walking countdown to stop again
        if(isWalking)
        {
            anim.SetBool("isWalking", true);
            walkCounter -= Time.deltaTime;
            

            //Current Possible directions for NPC movement, this will never make NPC walk diagonall, for this option refer to slime movement
            switch(WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", 1);

                    if (hasWalkZone && transform.position.y > maxWalkPoint.y) 
                    {
                        isWalking = false;
                        anim.SetBool("isWalking", false);
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);

                    if (hasWalkZone && transform.position.x > maxWalkPoint.x) 
                    {
                        isWalking = false;
                        anim.SetBool("isWalking", false);
                        waitCounter = waitTime;
                    }
                    break;

                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    anim.SetFloat("MoveX", 0);
                    anim.SetFloat("MoveY", -1);

                    if (hasWalkZone && transform.position.y < minWalkPoint.y) 
                    {
                        isWalking = false;
                        anim.SetBool("isWalking", false);
                        waitCounter = waitTime;
                    }
                    break;

                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);

                    if (hasWalkZone && transform.position.x < minWalkPoint.x) 
                    {
                        isWalking = false;
                        anim.SetBool("isWalking", false);
                        waitCounter = waitTime;
                    }
                    break;
            }
            // Check if time is up
            if (walkCounter <= 0)
            {
                isWalking = false;
                anim.SetBool("isWalking", false);
                waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f); ;
            }
        }
        //When not moving start wait countdown
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
	}

    //Choosing direction of npc movement randomly
    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = Random.Range(walkTime * 0.75f, walkTime * 1.25f); ;
    }
}
