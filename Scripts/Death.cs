using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject candle, candleBody;
    public bool alive = true;
    private Animator anim;
    public Image fadeOut, fadeIn;
    public Text exol;
    public AudioSource s;
    private int t = 140;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
            Die(collision.gameObject);
    }

    public void Die(GameObject killer)
    {

        Debug.Log("Ai murit de la " + killer.name);
        alive = false;
        s.Play();
        gameObject.transform.position += new Vector3(0, -0.5f, 0);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        candle.GetComponent<Light2D>().enabled = false;
        candle.GetComponent<Candle>().enabled = false;
        candleBody.GetComponent<CapsuleCollider2D>().enabled = false;
        anim.SetBool("Dead", true);
    }

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (alive == false)
        {
            if (t <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if (fadeOut.color.a < 1)
            {
                fadeOut.color += new Color(0, 0, 0, 0.01f);
                exol.color += new Color(0, 0, 0, 0.01f);
            }
            t--;
        }
        if (fadeIn.color.a > 0)
            fadeIn.color += new Color(0, 0, 0, -0.01f);
        if (fadeIn.color.a <= 0)
            fadeIn.gameObject.SetActive(false);
    }
}
