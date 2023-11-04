using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceRotation : MonoBehaviour
{
    public GameObject currentPiece;
    public Dictionary<int,Vector3> axisMap = new() {
        { 0, Vector3.right},
        { 1, Vector3.up},
        { 2, Vector3.forward},
    };
    public int currentAxis = 0;
    public List<Image> axisImages = new();
    public Button AxisImage; 

    public void SetCurrentPiece(GameObject piece)
    {
        currentPiece = piece;
    }

    public void NextAxis()
    {
        currentAxis += 1;
        if (currentAxis > 2) {
            currentAxis = 0;
        }
    }

    public void UpdatePanel()
    {
        AxisImage.image = axisImages[currentAxis];
    }

    public void IncreaseAxisRotation()
    {
        if(currentPiece != null)
            currentPiece.transform.Rotate(axisMap[currentAxis]);
    }

    public void DecreaseAxisRotaion()
    {
        if (currentPiece != null)
            currentPiece.transform.Rotate(-axisMap[currentAxis]);
    }
}
