using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    public bool openable = false;
    public GameObject ceSpawnezAzi, player;
    public bool haveKey = true;
    private AudioSource s;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            openable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            openable = false;
    }

    void Awake()
    {
        s = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(openable == true)
        {
            if(Input.GetKey("f"))
                if(haveKey == true)
                {
                    Instantiate(ceSpawnezAzi, player.transform.position + new Vector3(-1.5f, 0f, 0f), transform.rotation);
                    haveKey = false;
                    s.Play();
                }
        }
    }
}
