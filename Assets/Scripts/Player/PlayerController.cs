using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.12
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("connects")]
    [Tooltip("spawn")]
    public Vector3 respawnPoint;
    public bool checkPointReached = false;

    //-------------------------------------------(Player Config)
    [Header("player audio")]
    [SerializeField]
    AudioClip jumb;

    [Header("player's config")]
    [SerializeField]
    private float _speed = 2.2f;


    [SerializeField]
    private float _jump = 4.1f;

    [SerializeField]
    private GameObject _particle;

    [Tooltip("harm pushing))")]
    [SerializeField]
    Vector2 pushAway = new Vector2(3.7f, 0);

    [Header("collisions sector")]
    [SerializeField]
    private Transform groundCheckPoint;

    [SerializeField]
    private LayerMask whatIsGround;
    Vector2 direction;

    public bool isGrounded;
    private bool canJump;
    private bool canMove;
    private bool facinRight = true;  //for flipping player
    public bool isMoving; //for animation states.. && moving behavior

    //catche
    public Rigidbody2D rb2D;
    private Animator animator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Movement();
        GameSession.Instance.PauseGame();
        Jump();
    }

    private void FixedUpdate()
    {
        PlayerMovements();
    }

    void LateUpdate()
    {
       // coinMagnet.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        //if (true)
        //{
        //    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        //    rb2D.AddForce(transform.up * 6.2f, ForceMode2D.Impulse);
          //  _particle.SetActive(true);
        //}
        if (c.gameObject.CompareTag("rock"))
        {
            GetComponent<Rigidbody2D>().velocity = pushAway;
        }
        if(c.gameObject.CompareTag("goal"))
        {
            GameSession.Instance.Win();
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
       // _particle.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        
    }

    private void PlayerMovements()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * _speed, rb2D.velocity.y);
        animator.SetBool("run",true);
        //  animator.SetFloat("runing",2);
       // animator.SetTrigger("run");

        if (move < 0 && facinRight)
        {
            Flip();
        }
        else if (move > 0 && !facinRight)
        {
            Flip();
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            Flip();
           // moveInput = Input.GetAxis("Horizontal");
           // echoEffict.PlayEcho(); //Turn on to create double Lyer
           // rb2D.velocity = new Vector2(moveInput * _speed, rb2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * -_speed * Time.deltaTime);
            Flip();
           // moveInput = Input.GetAxis("Horizontal");
           // echoEffict.PlayEcho(); //Turn on to create double Lyer
           // rb2D.velocity = new Vector2(- moveInput * _speed, rb2D.velocity.y);
        }
    }

    private void Jump()
    {
      
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            print("pressed");
            audioSource.PlayOneShot(jumb);
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(transform.up * _jump, ForceMode2D.Impulse);
           // animator.SetBool("jump", true);
            //  animator.SetBool("jump", false);
            animator.SetTrigger("jump");
        }
        //else if (!isGrounded)
        //{
        //    animator.SetBool("jump", false);
        //    canJump = false;
        //}
    }

    void Flip()
    {
        //for wall jump
       // wallJumpDirection *= -1;
        facinRight = !facinRight;
        transform.rotation = Quaternion.Euler(0, facinRight ? 0 : 180, 0);
    }
}
