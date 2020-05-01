using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePeriod : MonoBehaviour
{
    public RectTransform backgroundCanvas;
    public float pos;
    
    // Start is called before the first frame update
    void Start()
    {
        float inc = backgroundCanvas.rect.height / 6;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, pos * inc);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
