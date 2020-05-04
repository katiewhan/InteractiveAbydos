using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlider : MonoBehaviour, IEndDragHandler, IDragHandler {
    public float X;
    public float Y;

    private RectTransform rectTransform;
    private float PosY;
    private float PosX;
    private float periodIncrement;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        RectTransform canvas = this.transform.parent.GetComponent<RectTransform>();
        periodIncrement = canvas.rect.height / 6;
        float widthIncrement = canvas.rect.width / 4;
        PosX = X * widthIncrement;
        PosY = Y * periodIncrement;
        rectTransform.anchoredPosition = new Vector2(PosX, PosY);
    }

    public void OnDrag(PointerEventData eventData) {
        PosY = rectTransform.anchoredPosition.y + eventData.delta.y;

        float max = periodIncrement * 3;
        if (PosY > max)
        {
            PosY = max;
        }
        else if (PosY < -max)
        {
            PosY = -max;
        }
         
        rectTransform.anchoredPosition = new Vector2(PosX, PosY);
    }

    public void OnEndDrag (PointerEventData eventData) {
        PosY = Mathf.Round(PosY / periodIncrement) * periodIncrement;
        rectTransform.anchoredPosition = new Vector2(PosX, PosY);
    }
}