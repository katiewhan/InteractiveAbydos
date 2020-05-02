using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private Shader outlineShader;
    private Shader objectShader;
    private MeshRenderer rend;
    private RotateTable table;
    private BoxCollider collider;

    private float timeCount = 0f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool manualDrag = false;

    public int objectIndex;
    public Sprite objectDescription;
    public float rotateSpeed = 1f;
    public float dragSpeed = 5f;

    public bool canActivate = true;
    public bool activated = false;

    void OnMouseOver()
    {
        if (canActivate)
        {
            rend.material.shader = outlineShader;
        }
    }

    void OnMouseExit()
    {
        if (canActivate)
        {
            rend.material.shader = objectShader;
        }
    }

    void OnMouseUp()
    {
        if (canActivate)
        {
            rend.material.shader = objectShader;
            activated = true;
            startPosition = this.transform.position;
            startRotation = this.transform.rotation;
            timeCount = 0f;
            foreach (Transform childCard in this.transform)
            {
                childCard.gameObject.SetActive(true);
            }
            collider.enabled = false;

            table.ActivateObject(objectIndex, objectDescription);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        outlineShader = Shader.Find("Custom/DiffuseOutlineShader");
        objectShader = Shader.Find("Custom/NoCullShader");

        table = this.transform.parent.GetComponent<RotateTable>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            this.transform.position = Vector3.Lerp(startPosition, new Vector3(0f, 1.4f, -2.2f), timeCount);
            timeCount += Time.deltaTime;
            if (!manualDrag) this.transform.Rotate(Vector3.up, rotateSpeed, Space.World);

            if (Input.GetMouseButton(0))
            {
                manualDrag = true;
                float h = dragSpeed * Input.GetAxis("Mouse X");
                float v = dragSpeed * Input.GetAxis("Mouse Y");

                this.transform.Rotate(v, -h, 0, Space.World);
            }
        }
    }

    public void Deactivate()
    {
        activated = false;
        manualDrag = false;
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        foreach (Transform childCard in this.transform)
        {
            childCard.gameObject.SetActive(false);
        }
        collider.enabled = true;
    }
}
