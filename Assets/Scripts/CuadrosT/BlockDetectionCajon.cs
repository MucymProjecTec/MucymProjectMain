using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetectionCajon : MonoBehaviour
{
    // Assign these materials from the Inspector
    public Material defaultMaterial;     // Material when no object is nearby
    public Material intangibleMaterial;  // Material when four pieces are detected

    private Renderer objRenderer;
    private int objectCount = 0;         // Counter to track how many objects are in the trigger zone
    public Animator _victoryAnimator;     // Reference to the victory animator
    private BlockDetection[] blockDetectors; // Array to hold references to all BlockDetection scripts
    public static bool IsVictory = false; // Track the victory state

    void Start()
    {
        // Get the Renderer component to access the material

        objRenderer = GetComponent<Renderer>();
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>(); // Victory Panel Calling

        // Find all instances of BlockDetection in the scene
        blockDetectors = FindObjectsOfType<BlockDetection>();

        // Set the object's material to the default at the start
        objRenderer.material = defaultMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        // Only count objects with the tag "PuzzlePiece"
        if (other.CompareTag("PuzzlePiece"))
        {
            // Increment object count when a valid piece enters the trigger
            objectCount++;

          
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Log the current count of pieces
        Debug.Log("Current pieces in the zone: " + objectCount);

        // Check the state of the BlockDetection instances and log the result
        bool anyIntangible = IsAnyBlockDetectorIntangible();

        // Log the current intangible state
        Debug.Log("Is any block detector intangible?: " + anyIntangible);

        // Check if we can trigger the victory condition
        if (objectCount >= 8)
        {
            if (!anyIntangible) // Check intangible flag
            {
                Debug.Log("¡Las 4 piezas han sido colocadas correctamente!");
                _victoryAnimator.SetBool("ShowVictory", true);
                IsVictory = true; // Set victory state to true
            }
            else
            {
                Debug.Log("Cannot show victory; at least one block is intangible.");
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        // Only decrement the counter if the piece has the tag "PuzzlePiece"
        if (other.CompareTag("PuzzlePiece"))
        {
            objectCount--;
        }
    }

    // Method to check if any BlockDetection is intangible
    private bool IsAnyBlockDetectorIntangible()
    {
        foreach (var detector in blockDetectors)
        {
            if (detector.GetObjectCount() >= 1) // Check each detector's intangible state
            {
                return true; // Return true if any are intangible
            }
        }
        Debug.Log("It's FALSE");
        return false; // Return false if none are intangible
    }
}
