using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteraF : MonoBehaviour
{
    public GameObject f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door" || collision.tag == "Dulap" || collision.tag == "Wardrobe" || collision.tag == "Table")
            f.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        f.SetActive(false);
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        f.transform.position = gameObject.transform.position + new Vector3(0, 2.5f, -5);
    }
}
