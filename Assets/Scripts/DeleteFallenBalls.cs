using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFallenBalls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OrangePeg") || collision.gameObject.CompareTag("BlackPeg") || collision.gameObject.CompareTag("PurplePeg") || collision.gameObject.CompareTag("Ball"))
            Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        if (collider.gameObject.CompareTag("OrangePeg") || collider.gameObject.CompareTag("BlackPeg") || collider.gameObject.CompareTag("PurplePeg") || collider.gameObject.CompareTag("Ball"))
            Destroy(collider.gameObject);
    }

    }
