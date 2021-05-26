using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public float sideSpeed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectile;

    void Start()
    {
        
    }

    void Update()
    {

        // This keeps the player within the map boundry we have set in xRange
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }    
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // This will check for input from the player (in this case we want space which is assigned to Jump) and fire a projectile
        if (Input.GetButtonDown("Jump"))
        { 
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }

        // This moves the player sideways depending on his key input (A or D)
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * sideSpeed);
    }
}
