using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    [SerializeField] float turnSpeed;
    private float hInput;
    private float vInput;
    private Rigidbody playerRb;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] float rpm;
    [SerializeField] float speed;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelIsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {

        // This populates the hInput and vInput with the player's input for the Horizontal and Vertical axes respectively
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (IsOnGround()) 
        {

            // This moves the vehicle vertically and horizontally
            playerRb.AddRelativeForce(Vector3.forward * vInput * horsePower);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * hInput);

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "(KPH)");
        }
    }
    bool IsOnGround()
    {
        wheelIsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelIsOnGround++;
            }
        }
        if (wheelIsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
