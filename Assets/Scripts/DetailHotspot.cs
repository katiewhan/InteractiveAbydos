using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailHotspot : MonoBehaviour
{
    public Sprite detail;
    public GameObject detailOverlay;

    private Image detailImage;

    // Start is called before the first frame update
    void Start()
    {
        detailImage = detailOverlay.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("click hotspot");
        detailImage.sprite = detail;
        detailOverlay.SetActive(true);
    }
}
