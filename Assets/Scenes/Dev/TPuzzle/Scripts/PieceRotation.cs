using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
    public List<Sprite> axisImages = new();
    public Image AxisImage;
    public PuzzleFigure puzzle;
    public bool increasehold;
    public bool decreasehold;
    public float rotationSpeed;

    private void Update()
    {
        if(increasehold)
            currentPiece.transform.Rotate(axisMap[currentAxis] * Time.deltaTime*rotationSpeed);
        if(decreasehold)
            currentPiece.transform.Rotate(-axisMap[currentAxis]*Time.deltaTime* rotationSpeed);
    }
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
        UpdatePanel();
    }

    public void UpdatePanel()
    {
        AxisImage.sprite = axisImages[currentAxis];
    }

    public void IncreaseAxisRotationHold()
    {
        if (currentPiece != null)
            increasehold = true;
    }

    public void DecreaseAxisRotationHold()
    {
        if (currentPiece != null)
            decreasehold = true;
    }

    public void Release()
    {
        decreasehold = false;
        increasehold = false;
        puzzle.CheckFigureIsComplete();
    }
}
