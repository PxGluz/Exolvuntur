using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed, jumpSpeed, initialSpeed;
    public bool jump = false, canjump = true, ableToGoThrough = false, ok = false;
    private Vector3 initial, initialReverse;
    public GameObject stairs1, v11, v12, candleBody, stairs2, v21, v22;
    private Animator anim;
    public bool moving = false;
    public AudioSource steps;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dulap")
            other.gameObject.GetComponent<Dulap>().ok = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dulap")
            collision.gameObject.GetComponent<Dulap>().ok = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Door")
        {
            jump = false;
            canjump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            canjump = false;
    }

    void Awake()
    {
        speed = initialSpeed;
        initial = this.gameObject.transform.localScale;
        initialReverse = new Vector3(-initial.x, initial.y, initial.z);
    }

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            moving = true;
            if (Input.GetKey("d") && Input.GetKey("a"))
            {
                anim.SetBool("Running", false);
                steps.Stop();
            }
            else
            {
                anim.SetBool("Running", true);
                if (jump == false && !Input.GetKey(KeyCode.LeftShift))
                    if (steps.isPlaying == false)
                        steps.Play();
            }
        }
        else
        {
            steps.Stop();
            anim.SetBool("Running", false);
            moving = false;
        }
        candleBody.transform.position = new Vector3(candleBody.transform.position.x, this.transform.position.y + 0.093f, -1);
        if(Input.GetKey("a"))
        {
            this.gameObject.transform.position += new Vector3(-speed, 0, 0);
            this.gameObject.transform.localScale = initial;
            candleBody.transform.position = new Vector3(this.transform.position.x - 0.808f, candleBody.transform.position.y, -1);
        }
        if (Input.GetKey("d"))
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
            this.gameObject.transform.localScale = initialReverse;
            candleBody.transform.position = new Vector3(this.transform.position.x + 0.808f, candleBody.transform.position.y, -1);
        }
        if (Input.GetKey("w"))
        {
            if(canjump == true)
                if (jump == false)
                    jump = true;
        }
        if ((this.gameObject.transform.position.x - 0.613f < v11.transform.position.x && this.gameObject.transform.position.x - 0.613f > v12.transform.position.x) || (this.gameObject.transform.position.x - 0.613f < v21.transform.position.x && this.gameObject.transform.position.x - 0.613f > v22.transform.position.x))
        {
            if (Input.GetKey("s") || ok == true)
                ableToGoThrough = true;
        }
        else
            ableToGoThrough = false;
        if (ableToGoThrough == true)
        {
            stairs1.GetComponent<EdgeCollider2D>().enabled = false;
            stairs2.GetComponent<EdgeCollider2D>().enabled = false;
        }
        else
        {
            stairs1.GetComponent<EdgeCollider2D>().enabled = true;
            stairs2.GetComponent<EdgeCollider2D>().enabled = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            steps.Stop();
            speed = 3 * initialSpeed / 5;
            anim.SetBool("Sneaking",true);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("Sneaking", false);
        }
        if (jump == true)
        {
            steps.Stop();
            this.gameObject.transform.position += new Vector3(0, jumpSpeed, 0);
            anim.SetBool("Falling", true);
        }
        else
            anim.SetBool("Falling", false);
    }
}
