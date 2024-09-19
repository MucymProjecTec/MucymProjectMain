using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCheckPosition : MonoBehaviour
{
     public int pieceID;  // Identificador único para la pieza (1, 2, 3, etc.)
    private bool isInCorrectPosition = false;

    private void OnTriggerStay(Collider other)
    {
        // Verificar si el collider es el correcto para esta pieza
        ZoneCheckPosition target = other.GetComponent<ZoneCheckPosition>();
        if (target != null && target.colliderID == pieceID && IsCentered(other))
        {
            isInCorrectPosition = true;
            // Opcional: Aquí puedes cambiar el color del collider o deshabilitarlo
            target.ChangeColor(Color.green);
        }
    }

    private bool IsCentered(Collider other)
    {
        // Verifica si la pieza está centrada dentro del collider
        return Vector3.Distance(transform.position, other.transform.position) < 0.1f;
    }

    public bool GetIsInCorrectPosition()
    {
        return isInCorrectPosition;
    }
}
