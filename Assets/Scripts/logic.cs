using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic : MonoBehaviour
{
    // Define the color of the piece
    public Color pieceColor;

    //To check if the piece is in the correct position to add to the count
    bool FullyContains(Collider resident, Collider zone, Color zoneColor, float tolerance = .01f)
    {
        if (zone == null)
        {
            return false;
        }

        //To Expand the zone bounds by the tolerance value
        Bounds expandedBounds = new Bounds(zone.bounds.center, zone.bounds.size + Vector3.one * tolerance);

        //To check if the expanded bounds contain the resident collider's bounds
        bool contains = expandedBounds.Contains(resident.bounds.min) &&
                        expandedBounds.Contains(resident.bounds.max) &&
                        expandedBounds.Contains(resident.bounds.center);

        // Check if the zone's color matches the piece's color
        if (contains && zoneColor == pieceColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Function to handle collision detection
    private void OnTriggerEnter(Collider other)
    {
        // Assuming the zone has a tag "Zone" and stores the color in its material
        if (other.CompareTag("Zone"))
        {
            // Get the color of the zone
            Color zoneColor = other.GetComponent<Renderer>().material.color;

            // Check if the piece fully contains the zone and if their colors match
            if (FullyContains(this.GetComponent<Collider>(), other, zoneColor))
            {
                // Do something when the piece is in the correct position
                Debug.Log("Piece is in the correct position!");
                // You can add your win condition logic here
            }
        }
    }
}
