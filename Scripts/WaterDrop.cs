using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject candle;
    private Candle c;
    public Sprite drop;
    public GameObject pleosc;

    private int cooldown = 90;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Candle")
            c.ok = true;
        Instantiate(pleosc, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }

    void Start()
    {
    }

    void Awake()
    {
        candle = GameObject.Find("Candle");
        c = candle.GetComponent<Candle>();
    }

    void FixedUpdate()
    {
        cooldown--;
        if (cooldown < 0)
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (cooldown <= 30)
        {
            this.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = drop;
            this.gameObject.GetComponent<Animator>().enabled = false;
        }
    }
}
