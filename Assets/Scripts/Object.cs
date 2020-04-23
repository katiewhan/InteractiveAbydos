using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float threshold;
    private float posAve;
    Image image;


    public GameObject textToShow;

    void Update()
    {
        image = GetComponent<Image>();
          //image.color = new Color(image.color.r, image.color.g, image.color.b, 10f);
          //Debug.Log("point0.position.z " + point0.position.z);
         posAve= (point1.position.y+point2.position.y)/2;
          //Debug.Log("posAve"+posAve);
        if(posAve<threshold){
            Debug.Log("hiding");
            Color c = image.color;
            c.a = 0;
            image.color = c;
             }
             else if(((posAve-1.19)>threshold)){
                 Color c = image.color;
                 c.a = 0.5f;
                image.color = c;
                Debug.Log("dead");

             }
             else
             {
                 Color c = image.color;
                 c.a = 1;
                image.color = c;
                Debug.Log("Showing");
                 
             }   

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
