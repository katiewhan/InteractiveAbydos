using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public RectTransform point1;
    public RectTransform point2;
    public RectTransform backgroundCanvas;
    public float xPos;

    private float threshold;
    private float increment;
    private Image deacImage;
    private Image highlightImage;
    private Image textToShow;

    void Start()
    {
        float x = Mathf.Lerp(point1.anchoredPosition.x, point2.anchoredPosition.x, xPos);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);

        RectTransform timePeriod = this.transform.parent.gameObject.GetComponent<RectTransform>();
        threshold = timePeriod.anchoredPosition.y;
        increment = backgroundCanvas.rect.height / 6;
        deacImage = this.transform.GetChild(0).GetComponent<Image>();
        highlightImage = this.transform.GetChild(1).GetComponent<Image>();
        textToShow = this.transform.GetChild(2).GetComponent<Image>();
        textToShow.enabled = false;
    }

    void Update()
    {
        float y = Mathf.Lerp(point1.anchoredPosition.y, point2.anchoredPosition.y, xPos);
        if (y < threshold - increment)
        {
            deacImage.enabled = true;
            highlightImage.enabled = false;
        }
        else if (y < threshold)
        {
            deacImage.enabled = false;
            highlightImage.enabled = true;
        }
        else
        {
            deacImage.enabled = false;
            highlightImage.enabled = false;
        }
    }

    void OnMouseOver()
    {
        if (highlightImage.enabled) textToShow.enabled = true;
    }

    void OnMouseExit()
    {
        textToShow.enabled = false;
    }
}
