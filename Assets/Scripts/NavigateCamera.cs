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
    public GameObject SliderCamera;
    public GameObject Canvas;

    private bool isDrag;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timeCount;
    private float fadeCount;

    private RawImage mainFade;
    private Color startColor;
    private int activeSection = 0; // 1: RFID, 2: Slider

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

        if (activeSection == 0)
        {
            // Mouse navigation
            if (Input.GetMouseButtonUp(0) && !isDrag)
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

                if (Mathf.Abs(inputX) > 0.03f || Mathf.Abs(inputY) > 0.03f)
                {
                    isDrag = true;
                }
            }
            else
            {
                isDrag = false;
            }

            // Key navigation
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
            {
                int direction = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ? -1 : 1;
                this.transform.position = this.transform.position + this.transform.forward * direction * keySpeed;
            }
        }
        

        // Transition to other section
        if (fadeCount > -1f && fadeCount < 2.5f)
        {
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

            if (fadeCount < 1.5f)
            {
                mainFade.color = Color.Lerp(startColor, targetColor, fadeCount);
            }
            if (fadeCount > 1f)
            {
                this.GetComponent<Camera>().enabled = false;

                if (activeSection == 1)
                {
                    RFIDCamera.GetComponent<Camera>().enabled = true;
                }
                else if (activeSection == 2)
                {
                    SliderCamera.GetComponent<Camera>().enabled = true;
                }

                Canvas.transform.GetChild(activeSection).gameObject.SetActive(true);
                Canvas.transform.GetChild(3).gameObject.SetActive(true); // button

                mainFade.color = Color.Lerp(targetColor, startColor, fadeCount - 1f);
            }
            fadeCount += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "roomBound")
        {
            startPosition = this.transform.position;
            targetPosition = this.transform.position - this.transform.forward * 0.1f;
            timeCount = 0f;
        }
        if (collision.collider.gameObject.tag == "enterRFID")
        {
            activeSection = 1;
            fadeCount = 0f;
            startColor = mainFade.color;
        }
        if (collision.collider.gameObject.tag == "enterSlider")
        {
            activeSection = 2;
            fadeCount = 0f;
            startColor = mainFade.color;
        }
    }

    public void ReturnHome()
    {
        this.transform.position -= this.transform.forward * stride;
        this.GetComponent<Camera>().enabled = true;

        if (activeSection == 1)
        {
            RFIDCamera.GetComponent<Camera>().enabled = false;
        }
        else if (activeSection == 2)
        {
            SliderCamera.GetComponent<Camera>().enabled = false;
        }

        Canvas.transform.GetChild(activeSection).gameObject.SetActive(false);
        Canvas.transform.GetChild(3).gameObject.SetActive(false); // button

        Invoke("ReturnNavControls", 0.5f);
    }

    private void ReturnNavControls()
    {
        activeSection = 0;
    }
}
