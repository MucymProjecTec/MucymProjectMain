using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionPieces : MonoBehaviour
{
    public GameObject imageTarget;
    public List<GameObject> pieces;
    public float heightAboveTarget = 0.1f; // Altura a la que se deben colocar las piezas sobre el Image Target

    void Start()
    {
        foreach (GameObject piece in pieces)
        {
            // Ajustar la posición de cada pieza en relación al Image Target
            piece.transform.SetParent(imageTarget.transform);
            Vector3 localPosition = piece.transform.localPosition;
            localPosition.y = heightAboveTarget;
            piece.transform.localPosition = localPosition;
        }
    }
}
