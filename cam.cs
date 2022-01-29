using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerbody;

    float xrotation = 0f;
    void Update()
    {
        float xmouse = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float ymouse = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xrotation -= ymouse;
        xrotation = Mathf.Clamp(xrotation,-90f,43f);
        transform.localRotation = Quaternion.Euler(xrotation,0f,0f);
        playerbody.Rotate(Vector3.up*xmouse);
        
        
    }
}
