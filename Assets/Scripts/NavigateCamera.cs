using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigateCamera : MonoBehaviour
{
    public float stride = 0.5f;
    public float strideSpeed = 2f;
    public float dragSpeed = 2f;
    public float keySpeed = 0.05f;
    public GameObject RFIDCamera;
    public GameObject Canvas;

    private bool isDrag;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeCount;
    private float fadeCount;

    private RawImage mainFade;
    private Color startColor;

    private float yaw;
    private float pitch;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0f;
        startPosition = this.transform.position;
        targetPosition = this.transform.position;
        yaw = this.transform.eulerAngles.y;
        pitch = this.transform.eulerAngles.x;
        fadeCount = -1f;
        mainFade = Canvas.transform.GetChild(0).GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount * strideSpeed < 1.5f)
        {
            this.transform.position = Vector3.Lerp(startPosition, targetPosition, timeCount * strideSpeed);
            timeCount += Time.deltaTime;
        }

        // Mouse navigation
        if ((Input.GetMouseButtonUp(0) && !isDrag))
        {
            startPosition = this.transform.position;
            targetPosition = this.transform.position + this.transform.forward * stride;
            timeCount = 0f;
        }
        if (Input.GetMouseButton(0))
        {
            float inputX = Input.GetAxis("Mouse X");
            float inputY = Input.GetAxis("Mouse Y");
            yaw -= dragSpeed * inputX;
            pitch += dragSpeed * inputY;
            this.transform.eulerAngles = new Vector3(pitch, yaw, 0f);

            if (Mathf.Abs(inputX) > 0.01f || Mathf.Abs(inputY) > 0.01f)
            {
                isDrag = true;
            }
        }
        else
        {
            isDrag = false;
        }

        // Key navigation

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            int direction = Input.GetKey(KeyCode.DownArrow) ? -1 : 1;
            this.transform.position = this.transform.position + this.transform.forward * direction * keySpeed;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            fadeCount = 0f;
            startColor = mainFade.color;
        }

        if (fadeCount > -1f && fadeCount < 2.5f)
        {
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

            if (fadeCount < 1.5f)
            {
                mainFade.color = Color.Lerp(startColor, targetColor, fadeCount);
            }
            if (fadeCount > 1f)
            {
                RFIDCamera.GetComponent<Camera>().enabled = true;
                this.GetComponent<Camera>().enabled = false;
                Canvas.transform.GetChild(1).gameObject.SetActive(true);

                mainFade.color = Color.Lerp(targetColor, startColor, fadeCount - 1f);
            }
            fadeCount += Time.deltaTime;
        }
        
    }
}
