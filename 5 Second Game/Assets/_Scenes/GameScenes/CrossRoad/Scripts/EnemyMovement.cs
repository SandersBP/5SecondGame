using UnityEngine;
using System.Collections;

/// <summary>
/// This is the player controller class
/// </summary>
public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    public float movementMultiplyer;
    public float lifeTime = 3;
    public GameObject gameObject;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;

    public string startPoint;


    //private SFXManager sfxMan;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();

        // sfxMan = FindObjectOfType<SFXManager>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        myRigidbody.velocity = new Vector2(1 * moveSpeed * movementMultiplyer, 0);

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision2D collision)
    {
        Debug.Log("Hit Detected");
        Destroy(collision.gameObject);
    }
}
