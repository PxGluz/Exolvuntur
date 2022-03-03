using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject gm, sonorul;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
        manager = gm.GetComponent<GameManager>();
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Candle")
        {
            manager.keyNumber++;
            Instantiate(sonorul, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        
    }

    void Update()
    {

    }
}
