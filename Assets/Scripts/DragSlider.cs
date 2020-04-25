using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlider : MonoBehaviour, IEndDragHandler, IDragHandler {
    public float PosX;

    private RectTransform rectTransform;
    private float PosY;
    private float periodIncrement;

    private void Awake () {
        rectTransform = GetComponent<RectTransform>();
        RectTransform canvas = this.transform.parent.gameObject.GetComponent<RectTransform>();
        periodIncrement = canvas.rect.height / 6;
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