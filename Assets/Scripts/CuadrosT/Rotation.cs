using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Velocidad de rotación
    public float rotationSpeed = 100f;

    // Referencia al joystick (arrastra tu joystick aquí en el Inspector)
    public Joystick joystick; // Asegúrate de usar el tipo correcto de joystick

    // Variable estática para la pieza seleccionada actualmente
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
        // Aquí puedes agregar lógica para resaltar la pieza seleccionada
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
        // Verifica si esta pieza está seleccionada
        if (CurrentSelectedObject == this)
        {
            // Captura la entrada del joystick
            float horizontalInput = joystick.Horizontal; // O el nombre correcto según tu joystick

            // Aplica la rotación en el eje Y basado en la entrada del joystick
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}
