using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
            EventManager.CallFreeBallEvent();
        else
            LevelManager.AddScore(other.gameObject.GetComponent<BallController>().GetValue());

        Destroy(other.gameObject);
    }
}
