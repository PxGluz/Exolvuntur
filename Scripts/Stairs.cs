using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement plm;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stairs")
        {
            plm.ok = true;
            Debug.Log("romanesc");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stairs")
        {
            plm.ok = false;
            Debug.Log("betbox");
        }
    }

    void Awake()
    {
        plm = player.GetComponent<PlayerMovement>();
    }
}
