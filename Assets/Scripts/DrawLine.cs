using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    
    private LineRenderer LineRenderer;
    

    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    

    // Start is called before the first frame update
    void Start()
    {
        
        LineRenderer =GetComponent<LineRenderer>();
       
        LineRenderer.SetWidth(1.5f,1.5f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
            LineRenderer.SetPosition(0, new Vector3(point0.position.x, point0.position.y, -5.5f));
            //Debug.Log("point0.position " + point0.position);
            LineRenderer.SetPosition(1, new Vector3(point1.position.x, point1.position.y, -5.5f));
            LineRenderer.SetPosition(2, new Vector3(point2.position.x, point2.position.y, -5.5f));
            LineRenderer.SetPosition(3, new Vector3(point3.position.x, point3.position.y, -5.5f));
            LineRenderer.SetPosition(4, new Vector3(point4.position.x, point4.position.y, -5.5f));
    }
}
