using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Candle : MonoBehaviour
{
    private Light2D lighting;
    private int y;
    private bool dark = false;
    public bool ok = false;
    public float reduceIntensity, droplet;
    public GameObject darkness;
    public AudioSource sufl;

    void Awake()
    {
        lighting = this.gameObject.GetComponent<Light2D>();
    }

    void Start()
    {
        y = 0;
    }

    void FixedUpdate()
    {
        if(lighting.intensity <= 0)
            if(dark == false)
            {
                sufl.Play();
                Instantiate(darkness, gameObject.transform.position + new Vector3(16f, 10f, 0f), new Quaternion());
                dark = true;
            }
        if(ok == true)
        {
            lighting.intensity -= droplet;
            ok = false;
        }
        if(y != (int)Time.time)
        {
            if(lighting.intensity > 0)
                lighting.intensity -= reduceIntensity;
        }
        y = (int)Time.time;
    }
}
