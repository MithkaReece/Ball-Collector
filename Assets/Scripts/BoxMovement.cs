using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float min;
    [SerializeField] private float max;
    [SerializeField] private float frequency;
    [SerializeField] private float maxSpeed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, frequency * (max - min) / 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float A = (max - min) / 2;
        float B = 2 * Mathf.PI * frequency;
        float C = (max + min) / 2;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, A * Mathf.Sin(Time.time * B) + C);


        // Calculate the desired velocity
        Vector3 desiredVelocity = (targetPosition - transform.position) / Time.deltaTime;
        desiredVelocity.z = Mathf.Clamp(desiredVelocity.z, -maxSpeed, maxSpeed);
        rb.velocity = desiredVelocity;
    }
}
