using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

    public Transform trans;

    private GameObject theBot;

    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        theBot = GameObject.Find("TheBot");
    }

    void Update()
    {
        //Debug.Log(theBot.transform.position.x);
        var newPos = new Vector3(theBot.transform.position.x, theBot.transform.position.y, -10);
        trans.position = newPos;
    }
}
