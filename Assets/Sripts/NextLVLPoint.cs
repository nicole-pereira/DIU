using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVLPoint : MonoBehaviour
{
    public string lvlName;

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(GameController.instance.totalScore == 60)
            {
                SceneManager.LoadScene(lvlName);
            }
        }


    }
}
