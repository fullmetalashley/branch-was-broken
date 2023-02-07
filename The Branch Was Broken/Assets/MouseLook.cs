using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        /*
         Test this in terms of locking the cursor directly to the center of the screen at the start of play,
         then unlocking it. 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None; 
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Multiple by Time.deltaTime in order to avoid having the frame rate change the speed. 
        //This way, you don't rotate faster with a faster frame rate, or slower with a slower one.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;    //Decrease x rotation every frame. Decrease ensures it isn't flipped.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //Lock rotation so we can't look behind the player
        
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  
        playerBody.Rotate(Vector3.up * mouseX); //Rotate around the y based on mouseX.
    }
}
