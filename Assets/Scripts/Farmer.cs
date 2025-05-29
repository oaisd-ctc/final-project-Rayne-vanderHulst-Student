using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Farmer : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("you win!");



            gameManager.NextLevel1();
            gameManager.NextLevel2();
            print("Next");
           


        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            print("you win!");
            gameManager.NextLevel2();
            gameManager.NextLevel1();

        }
    }
}
