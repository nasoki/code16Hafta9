using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    CharacterController characterController;
    public Transform camTransform;
    public float moveSpeed;
    public bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Move();
    }
    void Look()
    {
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Mathf.Clamp(Input.GetAxis("Mouse Y"), -80, 80);
        transform.eulerAngles += Vector3.up * mouseInputX;
        camTransform.localEulerAngles += Vector3.left * mouseInputY;
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize();
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            isRunning = true;
            moveSpeed = 3f;
        }
        else
        {
            isRunning= false;
            moveSpeed = 2f;
        }
        dir *= moveSpeed * Time.deltaTime;

        characterController.Move(dir);
    }
}
