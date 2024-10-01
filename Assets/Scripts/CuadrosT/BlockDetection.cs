using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    // Assign these materials from the Inspector
    public Material defaultMaterial;     // Material when no object is nearby
    public Material intangibleMaterial;  // Material when two or more objects are detected

    private Renderer objRenderer;
    private int objectCount = 0;         // Counter to track how many objects are in the trigger zone

    void Start()
    {
        // Get the Renderer component to access the material
        objRenderer = GetComponent<Renderer>();

        // Set the object's material to the default at the start
        objRenderer.material = defaultMaterial;
    }

    // Called when another object enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Increment object count when an object enters the trigger
        objectCount++;

        // If two or more objects are in the trigger zone, change to the intangible material
        if (objectCount >= 2)
        {
            objRenderer.material = intangibleMaterial;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Maintain the intangible material if two or more objects are still inside
        if (objectCount >= 2)
        {
            objRenderer.material = intangibleMaterial;
        }
    }

    // Called when another object exits the trigger
    void OnTriggerExit(Collider other)
    {
        // Decrement object count when an object leaves the trigger
        objectCount--;

        // If fewer than two objects are inside, change back to the default material
        if (objectCount < 2)
        {
            objRenderer.material = defaultMaterial;
        }
    }
}
