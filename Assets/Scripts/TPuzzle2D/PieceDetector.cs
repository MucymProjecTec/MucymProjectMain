using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            PieceManager piezaDetectada = other.GetComponent<PieceManager>(); // Obtener el ScriptableObject de la pieza detectada
            Debug.Log("Encontro la pieza");
            // Comprobar si el ScriptableObject de la pieza detectada es igual a "Center"
            if (piezaDetectada.pieceData != null && piezaDetectada.pieceData.name == "Center" && piezaDetectada.pieceData.winCount == 3)
            {
                // Incrementar el contador de victorias de esta pieza
                piezaDetectada.pieceData.Suma();
                Debug.Log("¡Pieza correcta detectada! WinCount: " + piezaDetectada.pieceData.winCount);
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            PieceManager piezaDetectada = other.GetComponent<PieceManager>(); // Obtener el ScriptableObject de la pieza detectada
            Debug.Log("Encontro la pieza");
            // Comprobar si el ScriptableObject de la pieza detectada es igual a "Center"
            if (piezaDetectada.pieceData != null && piezaDetectada.pieceData.name == "Center" && piezaDetectada.pieceData.winCount > 3 )
            {
                // Incrementar el contador de victorias de esta pieza
                piezaDetectada.pieceData.Resta();
                Debug.Log("¡Pieza correcta detectada! WinCount: " + piezaDetectada.pieceData.winCount);
            }
        }
    }
}
