using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Wardrobe w;
    public GameObject monster;
    private bool moved = false;

    void Start()
    {
        w = gameObject.GetComponent<Wardrobe>();
    }

    void Update()
    {
        if(w.haveKey == false && moved == false)
        {
            monster.transform.position = new Vector3(11.43f, -1.76f, -0.5f);
            moved = true;
        }
    }
}
