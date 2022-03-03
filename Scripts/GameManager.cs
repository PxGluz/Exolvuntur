using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool ok = false, okp = false;
    public float[] x = new float[59];
    public float[] y = new float[59];
    private int r, t, timer;
    public int keyNumber = 0;
    public GameObject droplet, player, candle;
    public Button play, quit;
    public Text locked, ptext, qtext, credits;
    public Image fadeOut, logo;
    private Candle c;
    public AudioSource[] sunete = new AudioSource[6];

    void OnEnable()
    {
        play.onClick.RemoveAllListeners();
        play.onClick.AddListener(Play);
        quit.onClick.RemoveAllListeners();
        quit.onClick.AddListener(Quit);
    }

    void Play()
    {
        c.enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        okp = true;
        play.interactable = false;
        quit.interactable = false;

    }

    void Quit()
    {
        if (fadeOut.color.a >= 1)
        {
            Debug.Log("s-a inchis :(");
            Application.Quit();
        }
        else
            ok = true;
    }

    void Awake()
    {
        c = candle.GetComponent<Candle>();
    }

    void Start()
    {
        t = 0;
        timer = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void FixedUpdate()
    {
        if(okp == true)
        {
            if(logo.color.a > 0)
            {
                logo.color += new Color(0, 0, 0, -0.01f);
                ptext.color += new Color(0, 0, 0, -0.01f);
                qtext.color += new Color(0, 0, 0, -0.01f);
                credits.color += new Color(0, 0, 0, -0.01f);
            }
            else
            {
                logo.gameObject.SetActive(false);
                play.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
                credits.gameObject.SetActive(false);
            }
        }
        if(ok == true)
        {
            fadeOut.gameObject.SetActive(true);
            if(fadeOut.color.a < 1)
                fadeOut.color += new Color(0, 0, 0, 0.01f);
            else
                Quit();
        }
        if (locked.color.a > 0)
            locked.color += new Color(0, 0, 0, -0.02f);
        if(t != (int)Time.time)
        {
            timer++;
            r = Random.Range(0, 58);
            Instantiate(droplet, new Vector3(x[r], y[r] - 0.5f, 0), new Quaternion(0, 0, 0, 0));
            if(timer >= 10)
            {
                timer = 0;
                r = Random.Range(0, 5);
                sunete[r].Play();
            }
        }
        t = (int)Time.time;
    }

}
