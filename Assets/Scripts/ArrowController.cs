using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float minRotation; // Maximum rotation angle in degrees

    public Vector3 TouchPosition;

    // Update is called once per frame
    void Update()
    {
        // Get the cursor position in world coordinates
        //Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(TouchPosition);
        cursorPosition.x = transform.position.x;


        // Rotate the arrow to look at the cursor
        transform.LookAt(cursorPosition);

        // Reset the y rotation to 0 to restrict rotation around that axis
        transform.eulerAngles = new Vector3(Mathf.Max(transform.eulerAngles.x, minRotation), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
