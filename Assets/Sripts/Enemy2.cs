using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    
    public float speed;
    private Transform posPlayer;
    public GameObject boxCollider;
    
    private Rigidbody2D rig;
    private Animator anim;

    private bool colliding;

    public LayerMask layer;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(posPlayer.gameObject != null)
        // Vira o inimigo
        {
            transform.position = Vector2.MoveTowards(transform.position, posPlayer.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(GameController.instance.totalScore == 60)
            {
                if(col.gameObject.tag == "Bullet")
                {
                    Destroy(gameObject);
                }
            }
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.layer == 8)
        {
            boxCollider.SetActive(false);
        }
    }

}
