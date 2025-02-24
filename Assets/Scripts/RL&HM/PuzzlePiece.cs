using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    LeanSelectableByFinger selectable;
    Rigidbody rb;

    void Start()
    {
        selectable = GetComponent<LeanSelectableByFinger>();
        rb = transform.GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (!selectable.IsSelected || BlockDetectionCajon.IsVictory) // Check for victory state
        {
            rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze all the axes
        }
    }
}

