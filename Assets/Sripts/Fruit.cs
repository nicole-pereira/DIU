using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private SpriteRenderer sr;
    private CapsuleCollider2D capsule;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            capsule.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;

            GameController.instance.UpdateScoreText();
            
            Destroy(gameObject, 0.3f);
        }
    }
}