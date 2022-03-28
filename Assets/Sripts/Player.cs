using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed;
    public float JumpForce;
    
    public bool isJumping;
    public bool dubleJumping;

    private Rigidbody2D rig;
    private Animator anim;

    public Bullet BulletPrefab;
    public Transform LaunchOffset;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, LaunchOffset.position, transform.rotation);
        }
    } 

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position +=movement * Time.deltaTime * Speed;
        
        if((Input.GetAxis("Horizontal") > 0f))
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if ((Input.GetAxis("Horizontal") < 0f))
        {
            anim.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }


        if ((Input.GetAxis("Horizontal") == 0f))
        {
            anim.SetBool("Walk", false);
        }
    } 

     void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                dubleJumping = true;
                anim.SetBool("Jump", true);
            }
            else
            {
                if(dubleJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    dubleJumping = false;
                }
            }
            
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        if(collision.gameObject.tag == "Spike")
        {
           GameController.instance.ShowGameOver();
           Destroy(gameObject);
        }

        if(GameController.instance.totalScore == 70)
        {
           GameController.instance.ShowWin();
           Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;

        }
    }
}