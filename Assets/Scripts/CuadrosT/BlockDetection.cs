using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    // Assign these materials from the Inspector
    public Material defaultMaterial;     // Material when no object is nearby
    public Material intangibleMaterial;  // Material when another object is detected

    private Renderer objRenderer;

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
        // Change to intangible material when an object is detected
        objRenderer.material = intangibleMaterial;
    }

    // Called when another object exits the trigger
    void OnTriggerExit(Collider other)
    {
        // Change back to the default material when the object leaves the trigger
        objRenderer.material = defaultMaterial;
    }
}
