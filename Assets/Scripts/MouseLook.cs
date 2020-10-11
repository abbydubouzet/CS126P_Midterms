using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Camera Values")]
    public float MouseSensitivity = 200f;
    float XRotation = 0f;
    float ZRotation = 0f;
    private float MouseX;
    private float MouseY;

    // Start is called before the first frame update
    void Start()
    {
        // Hiding and Locking Cursor when in game
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update()
    {
        // Gather Mouse Position Transform Data
        MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        // Deduct value to rotation placeholder
        XRotation -= MouseY;
        ZRotation -= MouseX;

        // Control the max and min value of the XRotation Camera
        XRotation = Mathf.Clamp(XRotation, -10f,10f);        

        // Apply Mouse Input to the camera transform
        transform.localRotation = Quaternion.Euler(-XRotation, -ZRotation, 0f);
    }
}
