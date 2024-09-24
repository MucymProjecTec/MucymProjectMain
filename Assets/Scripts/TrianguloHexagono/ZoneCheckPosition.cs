using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheckPosition : MonoBehaviour
{
    public int colliderID;  // Identificador único para el collider (1, 2, 3, etc.)
    private MeshRenderer meshRenderer;  // Referencia al MeshRenderer del collider

    private void Start()
    {
        // Obtén el MeshRenderer del objeto al iniciar
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor(Color newColor)
    {
        // Cambia el color del material asociado al MeshRenderer
        if (meshRenderer != null)
        {
            meshRenderer.material.color = newColor;
        }
    }
}
