using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObjectT : MonoBehaviour
{
    // Variable estática para la pieza seleccionada actualmente
    public static SelectedObjectT CurrentSelectedObject;

    private void OnMouseDown()
    {
        // Al hacer clic, esta pieza se convierte en la seleccionada
        if (CurrentSelectedObject != null)
        {
            CurrentSelectedObject.Deselect(); // Deseleccionar la pieza anterior
        }
        CurrentSelectedObject = this; // Asignar esta pieza como la seleccionada
        Highlight(); // Opcional: Resaltar la pieza seleccionada
    }

    private void Highlight()
    {
        // Aquí puedes agregar lógica para resaltar la pieza seleccionada
        GetComponent<Renderer>().material.color = Color.yellow; // Ejemplo de resaltado
    }

    public void Deselect()
    {
        // Restablecer el color u otros efectos al deseleccionar
        GetComponent<Renderer>().material.color = Color.white; // Restablecer al color original
    }
}
