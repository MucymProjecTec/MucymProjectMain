using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    public Material defaultMaterial;     // Material when no object is nearby
    public Material intangibleMaterial;  // Material when one or more objects are detected

    private Renderer objRenderer;
    private int objectCount = 0;         // Counter to track how many objects are in the trigger zone

    void Start()
    {
        // Get the Renderer component to access the material
        objRenderer = GetComponent<Renderer>();

        // Initialize material to default
        SetMaterial(defaultMaterial);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            objectCount++;
            UpdateMaterial();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            objectCount--;
            UpdateMaterial();
        }
    }

    // Updates material based on the object count
    private void UpdateMaterial()
    {
        if (objectCount > 0)
        {
            SetMaterial(intangibleMaterial);
        }
        else
        {
            SetMaterial(defaultMaterial);
        }
    }

    // Sets the material only if it differs from the current one
    private void SetMaterial(Material newMaterial)
    {
        if (objRenderer.material != newMaterial)
        {
            objRenderer.material = newMaterial;
        }
    }

    // Method to check the number of objects in the trigger zone
    public int GetObjectCount()
    {
        return objectCount;
    }
}
