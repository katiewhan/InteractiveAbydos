using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Polygon : MonoBehaviour
{
    public Material material;
    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    //public float scaleX = 1;
    private float endY = 7;


    Mesh mesh;
    GameObject gameObject;
    // Start is called before the first frame update


    private void Start()
    {
        mesh = new Mesh();
        gameObject=new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = new Vector3[10];
        Vector2[] uv = new Vector2[10];
        int[] triangles = new int[24];

        vertices[0] = new Vector2(point0.position.x, endY);
        vertices[1] = new Vector2(point1.position.x, endY);
        vertices[2] = new Vector2(point2.position.x, endY);
        vertices[3] = new Vector2(point3.position.x, endY);
        vertices[4] = new Vector2(point4.position.x, endY);
        var scale = point0.position.x - point1.position.x;

        vertices[5] = point4.position;
        vertices[6] = point3.position;
        vertices[7] = point2.position;
        vertices[8] = point1.position;
        vertices[9] = point0.position;

        uv[0] = new Vector2(point0.position.x, endY);
        uv[1] = new Vector2(point1.position.x, endY);
        uv[2] = new Vector2(point2.position.x, endY);
        uv[3] = new Vector2(point3.position.x, endY);
        uv[4] = new Vector2(point4.position.x, endY);
        uv[5] = point4.position;
        uv[6] = point3.position;
        uv[7] = point2.position;
        uv[8] = point1.position;
        uv[9] = point0.position;


        triangles[0] = 9;
        triangles[1] = 0;
        triangles[2] = 8;

        triangles[3] = 0;
        triangles[4] = 1;
        triangles[5] = 8;

        triangles[6] = 8;
        triangles[7] = 1;
        triangles[8] = 2;

        triangles[9] = 8;
        triangles[10] = 2;
        triangles[11] = 7;

        triangles[12] = 7;
        triangles[13] = 2;
        triangles[14] = 6;

        triangles[15] = 2;
        triangles[16] = 3;
        triangles[17] = 6;

        triangles[18] = 6;
        triangles[19] = 3;
        triangles[20] = 5;

        triangles[21] = 3;
        triangles[22] = 4;
        triangles[23] = 5;
 

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        //GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        //
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
        //Debug.Log ("Polygon");

    }
}
