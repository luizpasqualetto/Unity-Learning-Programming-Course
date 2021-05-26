using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float timeColor;
    public float coolDown;
    public float rotationSpeed;
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSpeedZ;
    public float scaleSize;

    void Start()
    {
        transform.localScale = Vector3.one * scaleSize;
    }

    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ));

        if (timeColor >= coolDown) 
        {
            Material material = Renderer.material;
            material.color = new Color(Random.value, Random.value, Random.value, 0.8f);
            timeColor = 0;
            Debug.Log("Color change Trigered");
        }

        timeColor = timeColor + Time.deltaTime * 10;
    }
}
