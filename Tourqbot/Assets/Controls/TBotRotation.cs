using UnityEngine;
using System.Collections;

public class TBotRotation : MonoBehaviour
{
    public float torque = 1;
    public float maxVelocity = 100;
    public float brakeStrength = 0.9f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity );

        if (Input.GetButton("Horizontal"))
            Rotate();
        if (Input.GetButton("Vertical"))
            Stop();
    }

    void Rotate()
    {
        var turn = -Input.GetAxis("Horizontal");
        var localVel = rb.velocity;

     //   Debug.Log("turn " + turn);

        if (turn == 0)
            return;

        if (turn > 0 && rb.angularVelocity + turn > maxVelocity && localVel.y >= 0)
        {
            //rb.angularVelocity = maxVelocity;
            return;
        }

        if (turn < 0 && rb.angularVelocity - turn < -maxVelocity && localVel.y >= 0)
        {

            //Debug.Log(rb.angularVelocity + " + " + turn + " > " + maxVelocity);
            //rb.angularVelocity = -maxVelocity;
            return;
        }

        //Debug.Log(rb.angularVelocity + " + " + turn + " < " + maxVelocity);
        rb.AddTorque(torque * turn, ForceMode2D.Force);
    }


    void Stop()
    {
        rb.angularVelocity = rb.angularVelocity * brakeStrength;
        //Debug.Log(rb.angularVelocity);
    }
}