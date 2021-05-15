using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float looksensitivity;
    public float minX;
    public float maxX;
    public Transform camAnchor;
    public float curX;
    public bool lockCursor;
    
    void Start() {
        lockCursor = true;
    }
    void LateUpdate()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * looksensitivity;
    
        curX -= y * looksensitivity;
        curX = Mathf.Clamp(curX,minX,maxX);
        camAnchor.eulerAngles =new Vector3(curX,camAnchor.eulerAngles.y,camAnchor.eulerAngles.z);
    }
    void Update ()
    {
 
        // pressing esc toggles between hide/show
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
        }
 
        Cursor.lockState = lockCursor?CursorLockMode.Locked:CursorLockMode.None;
        Cursor.visible = !lockCursor;
    }
}
