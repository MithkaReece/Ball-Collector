using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UNUSUED
public class DeleteFallenBalls : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OrangePeg") || collision.gameObject.CompareTag("BlackPeg") || collision.gameObject.CompareTag("PurplePeg") || collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }

}
