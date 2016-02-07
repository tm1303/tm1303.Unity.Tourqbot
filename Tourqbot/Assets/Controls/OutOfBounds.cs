using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

    private GameObject theBot;
    private Transform botTrans;
    private Rigidbody2D botBody;

    // Use this for initialization
    void Start()
    {
        theBot = GameObject.Find("TheBot");
        botTrans = theBot.GetComponent<Transform>();
        botBody = theBot.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        botBody.freezeRotation = true;
        botBody.angularVelocity = 0;
        botBody.velocity = new Vector2(0, 0);
        
        botTrans.position = new Vector3(0, 2, 0);
        botBody.velocity = new Vector2(0, 4);
        botBody.freezeRotation = false;

    }
}
