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
        rb = transform.GetComponent<Rigidbody>();               //to transform it into a rigidbody
    }

    void Update()
    {
        if (!selectable.IsSelected)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;    //Freeze all the axis, the piece becomes 
        }
    }
}
