using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    private bool left;
    private bool isGoing = false;
    private int timer = 0;
    public int movingDistance;
    public float distance, speed;
    private Death death;
    public AudioSource s1, s2;
    private Animator anim;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Candle")
            death.Die(gameObject);
    }

    void Awake()
    {
        death = player.GetComponent<Death>();
    }

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isGoing)
            anim.SetBool("Running", true);
        else
            anim.SetBool("Running", false);
        if(timer > 0)
        {
            this.transform.position += new Vector3(left == true ? -speed : speed, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, left == true ? 0 : 180, 0);
            if(s1.isPlaying == false)
            {
                if (s2.isPlaying == false)
                    s2.Play();
                s2.loop = true;
            }
            timer--;
        }
        if (timer <= 0)
        {
            isGoing = false;
            s2.loop = false;
        }
        if (Mathf.Abs(this.transform.position.y - player.transform.position.y) < 8)
        {
            if (isGoing == false)
            {
                if (player.transform.position.x < this.transform.position.x)
                    left = true;
                else
                    left = false;
            }
            if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < distance)
            {
                if (isGoing == false)
                {
                    isGoing = true;
                    s1.Play();
                    timer = movingDistance;
                }
            }
        }
    }
}
