using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCameraMovement : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;

    [Header("Clamping")]
    public float minY;
    public float maxY;

    [Header("Spectator")]
    public float spectatorMoveSpeed;

    private float rotX;
    private float rotY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Panel.activeSelf == false) 
        {
            rotX += Input.GetAxis("Mouse X") * sensX;
            rotY += Input.GetAxis("Mouse Y") * sensY;

            rotY = Mathf.Clamp(rotY, minY, maxY);

            transform.rotation = Quaternion.Euler(-rotY, rotX, 0);

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                y = 1;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                y = -1;
            }

            Vector3 dir = transform.right * x + transform.up * y + transform.forward * z;
            transform.position += dir * spectatorMoveSpeed * Time.deltaTime;
        }

        else if (Panel.activeSelf == true) 
        {
            return;
        }
    }
}
