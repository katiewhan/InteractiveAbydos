using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public RectTransform point1;
    public RectTransform point2;
    public RectTransform backgroundCanvas;
    public GameObject textToShow;
    public Sprite detail;
    public float xPos;

    private float threshold;
    private float increment;
    private Image deacImage;
    private Image highlightImage;
    private RectTransform highlightObject;
    private RectTransform timePeriod;
    private Image detailImage;
    private RectTransform detailOverlay;

    void Start()
    {
        float x = Mathf.Lerp(point1.anchoredPosition.x, point2.anchoredPosition.x, xPos);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);

        timePeriod = this.transform.parent.gameObject.GetComponent<RectTransform>();
        threshold = timePeriod.anchoredPosition.y;
        increment = backgroundCanvas.rect.height / 6;
        deacImage = this.transform.GetChild(0).GetComponent<Image>();
        highlightImage = this.transform.GetChild(1).GetComponent<Image>();
        highlightObject = this.transform.GetChild(1).GetComponent<RectTransform>();

        detailOverlay = textToShow.GetComponent<RectTransform>();
        detailImage = textToShow.GetComponent<Image>();
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
        if (highlightImage.enabled)
        {
            Vector2 objectPos = GetComponent<RectTransform>().anchoredPosition;
            Vector2 periodPos = timePeriod.anchoredPosition;
            detailOverlay.anchoredPosition = new Vector2(objectPos.x, periodPos.y);
            detailImage.sprite = detail;
            detailImage.enabled = true;
            highlightObject.localScale = new Vector3(2, 2, 2);
        }
    }

    void OnMouseExit()
    {
        detailImage.enabled = false;
        highlightObject.localScale = new Vector3(1, 1, 1);
    }
}
