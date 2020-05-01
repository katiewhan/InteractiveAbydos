using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateTable : MonoBehaviour
{
    private Vector3 lastMousePosition;
    private int currentObj = 0;
    private float timeCount = 0f;
    private Quaternion startRotation;
    private bool manualTurn = false;

    private SelectObject currentActive;

    public GameObject canvas;
    public float dragSensitivity = 0.08f;

    void OnMouseDown()
    {
        if (currentActive == null)
        {
            manualTurn = true;
            lastMousePosition = Input.mousePosition;
        }
    }

    void OnMouseDrag()
    {
        if (currentActive == null)
        {
            this.transform.Rotate(this.transform.up, (lastMousePosition.x - Input.mousePosition.x) * dragSensitivity);
            lastMousePosition = Input.mousePosition;
            float currentRot = this.transform.eulerAngles.y;
            if (currentRot < 0) currentRot = 360 - currentRot;
            currentObj = (int)Mathf.Round(currentRot / 72f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manualTurn)
        {
            this.transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(0, currentObj * 72f, 0), timeCount);
            timeCount += Time.deltaTime;
        }
    }

    public void NextObject(bool reverse = false)
    {
        int target = !reverse ? currentObj + 1 : currentObj - 1;
        if (target > 4) target = 0;
        if (target < 0) target = 4;

        TurnTo(target);
    }

    public void TurnTo(int obj)
    {
        manualTurn = false;
        currentObj = obj;
        startRotation = this.transform.rotation;
        timeCount = 0f;
    }

    public void ActivateObject(int obj, string description)
    {
        //TurnTo(obj);
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.tag == "object")
            {
                SelectObject so = child.gameObject.GetComponent<SelectObject>();
                so.canActivate = false;
                if (so.objectIndex == obj)
                {
                    currentActive = so;
                }
            }
        }

        foreach (Transform canvasChild in canvas.transform)
        {
            if (canvasChild.gameObject.name == "Panel")
            {
                canvasChild.gameObject.SetActive(true);

                foreach (Transform panelChild in canvasChild)
                {
                    if (panelChild.gameObject.name == "ObjectDescription")
                    {
                        panelChild.gameObject.GetComponent<TextMeshProUGUI>().SetText(description);
                    }
                }
            }

            if (canvasChild.gameObject.tag == "navButton")
            {
                canvasChild.gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void ExitObject()
    {
        currentActive.Deactivate();
        currentActive = null;
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.tag == "object")
            {
                SelectObject so = child.gameObject.GetComponent<SelectObject>();
                so.canActivate = true;
            }
        }
        foreach (Transform canvasChild in canvas.transform)
        {
            if (canvasChild.gameObject.name == "Panel")
            {
                canvasChild.gameObject.SetActive(false);
            }

            if (canvasChild.gameObject.tag == "navButton")
            {
                canvasChild.gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }
}
