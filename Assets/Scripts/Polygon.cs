using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Polygon : MonoBehaviour
{
    public Material material;
    public RectTransform point0;
    public RectTransform point1;
    public RectTransform point2;
    public RectTransform point3;
    public RectTransform point4;
    public RectTransform canvas;

    private Mesh mesh;
    private MeshFilter meshFilter;
    private GameObject meshObject;
    private float endY;
    private float worldWidth;
    private float worldHeight;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        meshObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        meshObject.GetComponent<MeshRenderer>().material = material;
        meshObject.transform.position = new Vector3(0f, 0f, -0.1f);
        meshFilter = meshObject.GetComponent<MeshFilter>();

        Vector3[] v = new Vector3[4];
        canvas.GetWorldCorners(v);
        endY = v[0].y;
        worldWidth = v[2].x - v[1].x;
        worldHeight = v[1].y - v[0].y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = new Vector3[10];
        vertices[0] = new Vector3(GetXPos(point0), endY, canvas.position.z);
        vertices[1] = new Vector3(GetXPos(point1), endY, canvas.position.z);
        vertices[2] = new Vector3(GetXPos(point2), endY, canvas.position.z);
        vertices[3] = new Vector3(GetXPos(point3), endY, canvas.position.z);
        vertices[4] = new Vector3(GetXPos(point4), endY, canvas.position.z);

        vertices[5] = new Vector3(GetXPos(point4), GetYPos(point4), canvas.position.z);
        vertices[6] = new Vector3(GetXPos(point3), GetYPos(point3), canvas.position.z);
        vertices[7] = new Vector3(GetXPos(point2), GetYPos(point2), canvas.position.z);
        vertices[8] = new Vector3(GetXPos(point1), GetYPos(point1), canvas.position.z);
        vertices[9] = new Vector3(GetXPos(point0), GetYPos(point0), canvas.position.z);

        int[] triangles = new int[] { 
            5, 4, 3,
            5, 3, 6,
            6, 3, 2,
            6, 2, 7,
            7, 2, 8,
            2, 1, 8,
            8, 1, 0,
            8, 0, 9
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;
    }

    private float GetXPos(RectTransform point)
    {
        return canvas.position.x + point.anchoredPosition.x * (worldWidth / canvas.rect.width);
    }

    private float GetYPos(RectTransform point)
    {
        return canvas.position.y + point.anchoredPosition.y * (worldHeight / canvas.rect.height);
    }
}
