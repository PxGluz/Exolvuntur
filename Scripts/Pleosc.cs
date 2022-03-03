using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleosc : MonoBehaviour
{
    private AudioSource s;
    void Awake()
    {
        s = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (s.isPlaying == false)
            Destroy(gameObject);
    }
}
