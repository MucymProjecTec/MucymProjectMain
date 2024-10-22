using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleZoneDetection : MonoBehaviour
{
    public string pieceTag = "PuzzlePiece";   // Tag to identify the puzzle pieces
    public BoxCollider puzzleZoneCollider;    // BoxCollider that acts as the puzzle zone
    private List<GameObject> piecesInZone = new List<GameObject>(); // List to track pieces inside the zone
    public int totalPieces = 4;               // Total number of pieces needed

    void Start()
    {
        // Ensure the BoxCollider is set to be a trigger
        if (puzzleZoneCollider != null)
        {
            puzzleZoneCollider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Puzzle Zone Collider is not assigned!");
        }
    }

    // Called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object is a puzzle piece and ensure it is not already in the list
        if (other.CompareTag(pieceTag) && !piecesInZone.Contains(other.gameObject))
        {
            piecesInZone.Add(other.gameObject); // Add the piece to the list
            InformCurrentPieceCount();          // Inform current count
            CheckAllPiecesInside();             // Check if all pieces are in the zone
        }
    }

    // Called when another collider exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        // Remove the piece from the list when it leaves the zone
        if (other.CompareTag(pieceTag) && piecesInZone.Contains(other.gameObject))
        {
            piecesInZone.Remove(other.gameObject);
            InformCurrentPieceCount();          // Inform current count
        }
    }

    // This function checks if all the pieces are inside the zone
    private void CheckAllPiecesInside()
    {
        // If the number of pieces in the zone equals the total required pieces
        if (piecesInZone.Count == totalPieces)
        {
            Debug.Log("All pieces are inside the puzzle zone!");
            // Trigger any puzzle-solved event here
        }
    }

    // This function informs the current number of pieces in the zone, including when it is 0
    private void InformCurrentPieceCount()
    {
        Debug.Log($"Current pieces in the zone: {piecesInZone.Count}/{totalPieces}");

        // Extra log if there are no pieces in the zone
        if (piecesInZone.Count == 0)
        {
            Debug.Log("The puzzle zone is empty.");
        }
    }
}
