using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private bool onScreen = false, ok = false;
    private int cooldown = 0;
    public GameObject paper, player;
    private PlayerMovement plm;
    private AudioSource s;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ok = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ok = false;
        }
    }

    void Awake()
    {
        plm = player.GetComponent<PlayerMovement>();
        s = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (cooldown > 0)
            cooldown--;
        if(ok == true)
        {
            if(Input.GetKey("f"))
            {
                if(cooldown <= 0)
                {
                    if (onScreen == false)
                        s.Play();
                    cooldown = 60;
                    onScreen = onScreen == true ? false : true;
                    plm.enabled = !onScreen;
                    plm.steps.Stop();
                    paper.SetActive(onScreen);
                }
            }
        }
    }
}
