using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPieceEvents : MonoBehaviour
{

    public Renderer renderer;
    public Material originalMaterial;
    public Material selectedMaterial; //Two different materials: one when is selected and the other when is not available

    public void ChangeToSelecteMaterial()
    {
        renderer.material = selectedMaterial; //Change into selected mode, wood material
    }

    public void ChangeToUnelectedMaterial()
    {
        renderer.material = originalMaterial; //Changes the block selected back to its original form, disk wood material
    }
}
