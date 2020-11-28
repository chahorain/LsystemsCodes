using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 tmpV = GetBaseInput();
        tmpV = tmpV * speed*Time.deltaTime;
        Vector3 newPosition = transform.position;
        transform.Translate(tmpV);


    }

    private Vector3 GetBaseInput()
    { 
        Vector3 camvelocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            camvelocity += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            camvelocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            camvelocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            camvelocity += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            camvelocity += Vector3.up;
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            camvelocity += Vector3.down;
        }
        return camvelocity;
    }
}
