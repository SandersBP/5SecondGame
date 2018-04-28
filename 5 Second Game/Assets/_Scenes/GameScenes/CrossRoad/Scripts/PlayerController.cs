using UnityEngine;
using System.Collections;

/// <summary>
/// This is the player controller class
/// </summary>
public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    public string startPoint;

    public bool canMove;

    private SceneManagement scene;

    //private SFXManager sfxMan;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
    
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

       // sfxMan = FindObjectOfType<SFXManager>();

        //This is to not make anymore player duplicate
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } 
        else //If there is already a player dont make a dup
        {
            Destroy(gameObject);
        }

        canMove = true;

        lastMove = new Vector2(0, -1f);
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        //Every loop checks for input
        playerMoving = false;

        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;

        }

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if(moveInput != Vector2.zero)
            {
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed); 
                playerMoving = true;
                anim.SetBool("PlayerMoving", true);
                 anim.SetFloat("MoveX", myRigidbody.velocity.x);
                anim.SetFloat("MoveY", myRigidbody.velocity.y);
            anim.SetFloat("LastMoveX", myRigidbody.velocity.x);
            anim.SetFloat("LastMoveY", myRigidbody.velocity.y);

            lastMove = moveInput;
            }
            else
            {
            
            myRigidbody.velocity = Vector2.zero;
                 anim.SetBool("PlayerMoving", false);
                
             }
        }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "NextGame")
        {
            scene = FindObjectOfType<SceneManagement>();
            scene.LoadGameScene();
        }
    }
}


    

    
