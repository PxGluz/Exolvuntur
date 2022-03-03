using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Animator anim;
    private int timer = 15;
    void Awake()
    {
        player = GameObject.Find("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("Running", true);
    }

    void FixedUpdate()
    {
        if(player.GetComponent<Death>().alive == false && timer > 0)
            timer--;
        if (timer > 0)
        {
            if (gameObject.transform.position.x < player.transform.position.x)
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            else
                gameObject.transform.position += new Vector3(-speed, 0f, 0f);
            if (gameObject.transform.position.y < player.transform.position.y)
                gameObject.transform.position += new Vector3(0f, speed / 2, 0f);
            else
                gameObject.transform.position += new Vector3(0f, -speed / 2, 0f);
        }
    }
}
