using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactDoor : MonoBehaviour
{
    private int i;
    private char c;
    private string nam;
    private bool ok;
    public Text locked;
    Door Doorul;
    private float cooldown;
    GameObject Doorel;
    public GameObject gm;
    private GameManager manager;
    
    void Awake()
    {
        manager = gm.GetComponent<GameManager>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            Doorel = other.gameObject;
            Doorul = Doorel.GetComponent<Door>();
            ok = true;
            Debug.Log("am inntrat");
        }
    }
    
        
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            ok = false;
            Debug.Log("am iesit");
        }
    }
    void FixedUpdate()
    {
        if (cooldown > 0)
            cooldown -= 0.02f;
        if (ok == true)
        {
           
            if (Input.GetKeyDown(KeyCode.F) && ok == true && Doorul.DoorOpen == false)
            {
                if (cooldown <= 0)
                {
                    nam = Doorel.name;
                    i = 0;
                    while (nam[i] != '1' && nam[i] != '2' && nam[i] != '3' && nam[i] != '4')
                        i++;
                    c = nam[i];
                    if (c == '1' || (c == '2' && manager.keyNumber >= 1) || (c == '3' && manager.keyNumber >= 2) || (c == '4' && manager.keyNumber >= 3))
                    {
                        cooldown = 0.2f;
                        Doorul.OpenDoor();
                        Doorul.DoorOpen = true;
                    }
                    else
                        locked.color = new Color(locked.color.r, locked.color.g, locked.color.b, 1);
                }
            }
            if (Input.GetKeyDown(KeyCode.F) && Doorul.DoorOpen == true && ok == true)
            {
                if (cooldown <= 0)
                {
                    nam = Doorel.name;
                    i = 0;
                    while (nam[i] != '1' && nam[i] != '2' && nam[i] != '3' && nam[i] != '4')
                        i++;
                    c = nam[i];
                    if (c == '1' || (c == '2' && manager.keyNumber >= 1) || (c == '3' && manager.keyNumber >= 2) || (c == '4' && manager.keyNumber >= 3))
                    {
                        cooldown = 0.2f;
                        Doorul.CloseDoor();
                        Doorul.DoorOpen = false;
                    }
                }
            }
        }
    }
}
