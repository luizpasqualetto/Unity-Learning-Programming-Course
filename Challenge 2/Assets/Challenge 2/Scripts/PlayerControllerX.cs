using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeElapsed = 0f;
    private float delay = 0.0f;
    public float coolDown = 0.0f;
    
    // Update is called once per frame

    
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && delay= coolDown)
            {
          Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
          delay = 0;
            }
        delay = delay + Time.deltaTime * 10;
    }   
}
