using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlider : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    private RectTransform rectTransform;
    public  static Vector2 endPosition;
    public float PosX;
    private float PosY;

    private void Awake () {
        rectTransform = GetComponent<RectTransform> ();
    }

    public void OnBeginDrag (PointerEventData eventData) {
        //Debug.Log ("OnBeginDrag");
    }

    public void OnDrag (PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta;
        PosY= rectTransform.anchoredPosition.y;

        if (PosY > 400)
            {
                PosY = 400;
                
            }
            else if (PosY < -200)
            {
                PosY = -200;
                
            }
         
        rectTransform.anchoredPosition =new Vector2(PosX, PosY);

        //Debug.Log ("PosY:"+PosY);
    }

    public void OnEndDrag (PointerEventData eventData) {
        //Debug.Log ("OnEndDrag");


        if (PosY< 400&&PosY>=350)
            {
                PosY=400;
                
            }
            else if (PosY< 350&&PosY>=250)
            {
                PosY=300;
                
            }
            else if (PosY< 250&&PosY>=150)
            {
                PosY=200;
            }
            else if (PosY< 150&&PosY>=50)
            {
                PosY=100;
                
            }
            
            else if (PosY< 50&&PosY>=-50)
            {
                PosY=0;
                
            }
             else if (PosY< -50&&PosY>=-150)
            {
                PosY=-100;
                
            }
            else if (PosY< -150&&PosY>=-200)
            {
                PosY=-200;
                
            }
            rectTransform.anchoredPosition =new Vector2(PosX, PosY);


    }

    public void OnPointerDown (PointerEventData eventData) {
        //Debug.Log ("OnPointerDown");
    }

}