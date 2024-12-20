using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private int tapCount = 0; // Cuenta los toques
    private float tapResetTime = 0.5f; // Tiempo permitido entre los toques
    private float lastTapTime = 0f; // Registro del tiempo del último toque
    private bool isSelected = false; // Indica si la pieza está seleccionada
    private int currentPosition = 1; // Posición inicial

    void Update()
    {
        // Resetea el contador de toques si pasa el tiempo límite
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
        if (!isSelected) return; // Solo rota si la pieza está seleccionada

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
        // Obtén la rotación actual
        Vector3 currentRotation = transform.eulerAngles;

        // Cambia únicamente el valor de Y (suma 90 grados)
        currentRotation.y += 90f;

        // Aplica la nueva rotación
        transform.eulerAngles = currentRotation;

        // Actualiza la posición actual (si se necesita para lógica futura)
        currentPosition = (currentPosition % 4) + 1;
        Debug.Log("New position: " + currentPosition);
    }

    public int GetPosition()
    {
        return currentPosition;
    }
}