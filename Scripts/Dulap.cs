using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Dulap : MonoBehaviour
{
    public bool ok = false, inside = false;
    private int cooldown = 0;
    public GameObject player;
    private PlayerMovement plm;
    public Light2D candle;
    private AudioSource s;
    void Start()
    {
        plm = player.GetComponent<PlayerMovement>();
        s = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (cooldown > 0)
            cooldown--;
        if(ok == true || inside == true)
        {
            if(Input.GetKey("f"))
            {
                if (cooldown <= 0)
                {
                    cooldown = 70;
                    s.Play();
                    if (inside == false)
                    {
                        inside = true;
                        player.GetComponent<SpriteRenderer>().enabled = false;
                        player.GetComponent<CapsuleCollider2D>().enabled = false;
                        player.GetComponent<Rigidbody2D>().simulated = false;
                        plm.candleBody.GetComponent<CapsuleCollider2D>().enabled = false;
                        plm.steps.Stop();
                        candle.enabled = false;
                        plm.enabled = false;
                        player.transform.position = gameObject.transform.position + new Vector3(0, -1.5f, -1.2f);
                    }
                    else
                    {
                        inside = false;
                        player.GetComponent<SpriteRenderer>().enabled = true;
                        player.GetComponent<CapsuleCollider2D>().enabled = true;
                        player.GetComponent<Rigidbody2D>().simulated = true;
                        plm.candleBody.GetComponent<CapsuleCollider2D>().enabled = true;
                        candle.enabled = true;
                        plm.enabled = true;
                    }
                }
            }
        }
    }
}
