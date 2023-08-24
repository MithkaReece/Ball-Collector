using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private int value;

    public int GetValue() { return value; }

    public void SetType(string type)
    {
        switch (type)
        {
            case "Orange":
                value = 5;
                gameObject.tag = "OrangePeg";
                break;
            case "Purple":
                value = 25;
                gameObject.tag = "PurplePeg";
                break;
            case "Black":
                value = -50;
                gameObject.tag = "BlackPeg";
                break;
        }
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        // Enable gravity for the sphere's Rigidbody
        if (!rb.useGravity)
        {
            rb.useGravity = true;
            EventManager.CallBallActiveEvent();
        }
    }

    private void OnDestroy()
    {
        EventManager.CallBallDeletedEvent();
    }

}
