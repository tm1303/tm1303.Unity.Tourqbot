using UnityEngine;
using System.Collections;
using System.Linq;

public class InfiniteFloorBehaviour : MonoBehaviour
{
    private GameObject theBot;
    private Transform botTrans;
    private Rigidbody2D botBody;
    private LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {
        theBot = GameObject.Find("TheBot");
        botTrans = theBot.GetComponent<Transform>();

        botBody = theBot.GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();

        //var coliderPoints = GetComponent<EdgeCollider2D>().points.Cast<Vector3>();

        //Debug.Log("in render");

        //lineRenderer.useWorldSpace = false;
        //lineRenderer.SetPositions(coliderPoints.ToArray());

    }

    void OnRenderObject()
    {
        var coliderPoints = GetComponent<EdgeCollider2D>().points.Select(p => new Vector3(p.x, p.y, 0)).ToArray();

        //if (coliderPoints.Length < 2)
        //    return;

        Debug.Log("in render");

        lineRenderer.useWorldSpace = false;
        lineRenderer.SetVertexCount(coliderPoints.Length);
        lineRenderer.SetPositions(coliderPoints.ToArray());

        lineRenderer.SetColors(Color.cyan, Color.green);
        lineRenderer.SetWidth(0.2F, 0.2F);


        //for (var n = 0; n < coliderPoints.Length - 1; n++)
        //{
        //    var firstPoint = coliderPoints[n];
        //    var secondPoint = coliderPoints[n + 1];

        //    var drawFrom = transform.position + new Vector3(firstPoint.x, firstPoint.y, 0);
        //    var drawTo = transform.position + new Vector3(secondPoint.x, secondPoint.y, 0);

        //    Graphics.dr.DrawLine(drawFrom, drawTo);
        //}
    }
}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    botBody.freezeRotation = true;
    //    botBody.angularVelocity = 0;
    //    botBody.velocity = new Vector2(0, 0);

    //    botTrans.position = Restart;
    //    botBody.velocity = new Vector2(0, 4);
    //    botBody.freezeRotation = false;

    //}

