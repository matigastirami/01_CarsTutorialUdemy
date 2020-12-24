using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed, rudderSpeed = 15;
    private float verticalInput, horizontalInput, rudderLeft, rudderRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rudderLeft = Input.GetAxis("Fire1");
        rudderRight = Input.GetAxis("Fire2");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        // Rotate right left
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime * horizontalInput);

        // Control plane rudder
        transform.Rotate(Vector3.down * rudderSpeed * Time.deltaTime * rudderLeft);
        transform.Rotate(Vector3.up * rudderSpeed * Time.deltaTime * rudderRight);
    }
}
