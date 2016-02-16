using UnityEngine;
using System.Collections;
using System.Linq;

public class InfiniteFloorBehaviour : MonoBehaviour
{
    private GameObject theBot;
    //private Transform botTrans;
    //private Rigidbody2D botBody;
    private LineRenderer lineRenderer;
    private MeshRenderer meshRenderer;
    private EdgeCollider2D edge;

    // Use this for initialization
    void Start()
    {
        //theBot = GameObject.Find("TheBot");
        //botTrans = theBot.GetComponent<Transform>();

        //botBody = theBot.GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        meshRenderer = GetComponent<MeshRenderer>();
        edge = GetComponent<EdgeCollider2D>();


        setUpFill();
        setUpLines();
    }

    private void setUpLines()
    {
        var coliderPoints = GetComponent<EdgeCollider2D>().points.Select(p => new Vector3(p.x, p.y, 0)).ToArray();

        lineRenderer.useWorldSpace = false;
        lineRenderer.SetVertexCount(coliderPoints.Length);
        lineRenderer.SetPositions(coliderPoints.ToArray());

        lineRenderer.SetColors(Color.green, Color.green);
        lineRenderer.SetWidth(0.2F, 0.2F);

        //Material mat = new Material(Shader.Find("Particles/Additive"));
        //mat.color = Color.green;
        //lineRenderer.material = mat;
    }

    private void OnDestroy()
    {
        Destroy(GetComponent<Renderer>().material);
    }

    private void setUpFill()
    {
        var point = GetComponent<EdgeCollider2D>().points.Select(p => new Vector3(p.x, p.y, 0)).ToArray();

        const int ySize = 5;
        var xSize = point.Length - 1;

        var mesh = GetComponent<MeshFilter>().mesh = new Mesh();
        mesh.name = "Procedural Grid";

		var vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		for (int i = 0, y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++, i++) {
				vertices[i] = point[x] + new Vector3(0, (y-ySize)*3); 
			}
		}
		mesh.vertices = vertices;

		int[] triangles = new int[xSize * ySize * 6];
		for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
			for (int x = 0; x < xSize; x++, ti += 6, vi++) {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
				triangles[ti + 5] = vi + xSize + 2;
			}
		}
		mesh.triangles = triangles;
        
    }
}
