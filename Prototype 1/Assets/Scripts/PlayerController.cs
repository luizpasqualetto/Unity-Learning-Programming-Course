using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    private float hInput;
    private float vInput;

    void Start()
    {
        
    }

    void Update()
    {
        // This populates the hInput and vInput with the player's input for the Horizontal and Vertical axes respectively
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // This moves the vehicle vertically and horizontally
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * hInput);
    }
}
