using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MS = 100f;
    public Transform PB;

    private float xRot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MS * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MS * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRot,0f, 0f);
        
        PB.Rotate(Vector3.up * mouseX);
    }
}
