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
        
            LineRenderer.SetPosition(0, point0.position);
            //Debug.Log("point0.position " + point0.position);
            LineRenderer.SetPosition(1, point1.position);
            LineRenderer.SetPosition(2, point2.position);
            LineRenderer.SetPosition(3, point3.position);
            LineRenderer.SetPosition(4, point4.position);
    }
}
