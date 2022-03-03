using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FinalTable : MonoBehaviour
{
    private bool onScreen = false, ok = false;
    private int cooldown = 0;
    public GameObject paper, player;
    private PlayerMovement plm;
    public Light2D lighting;
    private AudioSource s;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
        if (ok == true)
        {
            if (Input.GetKey("f"))
            {
                if (cooldown <= 0)
                {
                    if (onScreen == true)
                        lighting.intensity = 0.01f;
                    else
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
