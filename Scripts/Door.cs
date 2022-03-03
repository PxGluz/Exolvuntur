using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//6.97,6,25
public class Door : MonoBehaviour
{
    public Sprite doorClosed, doorOpen;
    public bool DoorOpen;
    public AudioSource open, close;

    public void OpenDoor()
    {
        open.Play();
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
        this.transform.position = new Vector2(this.transform.position.x + 0.72f,this.transform.position.y);
    }
    public void CloseDoor()
    {
        close.Play();
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
        this.transform.position = new Vector2(this.transform.position.x - 0.72f, this.transform.position.y);
    }
}
