using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float stopFactor = 8;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += playerCamera.transform.forward / stopFactor;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= playerCamera.transform.forward / stopFactor;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += playerCamera.transform.right / stopFactor;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= playerCamera.transform.right / stopFactor;
        }
    }
}
