using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Velocidad de rotaci�n
    public float rotationSpeed = 100f;

    // Referencia al joystick (arrastra tu joystick aqu� en el Inspector)
    public Joystick joystick; // Aseg�rate de usar el tipo correcto de joystick

    // Variable est�tica para la pieza seleccionada actualmente
    public static Rotation CurrentSelectedObject; // Cambia a tipo Rotation

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
        // Aqu� puedes agregar l�gica para resaltar la pieza seleccionada
        GetComponent<Renderer>().material.color = Color.yellow; // Ejemplo de resaltado
    }

    public void Deselect()
    {
        // Restablecer el color u otros efectos al deseleccionar
        GetComponent<Renderer>().material.color = Color.white; // Restablecer al color original
    }

    // Actualiza cada frame
    void Update()
    {
        // Verifica si esta pieza est� seleccionada
        if (CurrentSelectedObject == this)
        {
            // Captura la entrada del joystick
            float horizontalInput = joystick.Horizontal; // O el nombre correcto seg�n tu joystick

            // Aplica la rotaci�n en el eje Y basado en la entrada del joystick
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
