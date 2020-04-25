using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public RectTransform point1;
    public RectTransform point2;
    public GameObject textToShow;

    private float threshold;
    private Image image;

    void Start()
    {
        RectTransform timePeriod = this.transform.parent.gameObject.GetComponent<RectTransform>();
        threshold = timePeriod.anchoredPosition.y;
        image = GetComponent<Image>();
    }
    void Update()
    {
        float posAvg = (point1.anchoredPosition.y + point2.anchoredPosition.y) / 2;
        Color c = image.color;
        if (posAvg < threshold - 100){
            c.a = 0.5f;
        }
        else if (posAvg <threshold){
            c.a = 1;
        }
        else
        {
            c.a = 0;
        }
        image.color = c;
    }

    void OnMouseOver()
    {
        textToShow.SetActive(true);
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        textToShow.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
