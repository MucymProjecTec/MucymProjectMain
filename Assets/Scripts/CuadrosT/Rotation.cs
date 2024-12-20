using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private int tapCount = 0; // Cuenta los toques
    private float tapResetTime = 0.5f; // Tiempo permitido entre los toques
    private float lastTapTime = 0f; // Registro del tiempo del �ltimo toque
    private bool isSelected = false; // Indica si la pieza est� seleccionada
    private int currentPosition = 1; // Posici�n inicial

    void Update()
    {
        // Resetea el contador de toques si pasa el tiempo l�mite
        if (Time.time - lastTapTime > tapResetTime)
        {
            tapCount = 0;
        }
    }

    public void OnSelect()
    {
        isSelected = true; // Marca la pieza como seleccionada
        HandleTap();
    }

    public void OnDeselect()
    {
        isSelected = false; // Desmarca la pieza como seleccionada
    }

    private void HandleTap()
    {
        if (!isSelected) return; // Solo rota si la pieza est� seleccionada

        tapCount++;
        lastTapTime = Time.time;

        if (tapCount == 2) // Si hay dos toques consecutivos
        {
            RotatePiece();
            tapCount = 0; // Reinicia el contador
        }
    }

    private void RotatePiece()
    {
        Debug.Log("Rotating piece...");
        // Obt�n la rotaci�n actual
        Vector3 currentRotation = transform.eulerAngles;

        // Cambia �nicamente el valor de Y (suma 90 grados)
        currentRotation.y += 90f;

        // Aplica la nueva rotaci�n
        transform.eulerAngles = currentRotation;

        // Actualiza la posici�n actual (si se necesita para l�gica futura)
        currentPosition = (currentPosition % 4) + 1;
        Debug.Log("New position: " + currentPosition);
    }

    public int GetPosition()
    {
        return currentPosition;
    }
}