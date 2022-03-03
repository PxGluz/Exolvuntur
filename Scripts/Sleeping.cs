using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : MonoBehaviour
{
    public bool isInside = false;
    public GameObject player, monster, gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            isInside = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInside = false;
            if (gm.GetComponent<GameManager>().keyNumber >= 3)
            {
                monster.GetComponent<Rigidbody2D>().simulated = true;
                monster.GetComponent<Monster>().enabled = true;
            }
        }
    }
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(isInside == true)
        {
            if(player.GetComponent<PlayerMovement>().speed == player.GetComponent<PlayerMovement>().initialSpeed && player.GetComponent<PlayerMovement>().moving == true)
            {
                monster.GetComponent<Rigidbody2D>().simulated = true;
                monster.GetComponent<Monster>().enabled = true;
            }
        }
    }
}
