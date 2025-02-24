using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetectionCajon : MonoBehaviour
{
    public Material defaultMaterial;
    public Material intangibleMaterial;
    public Animator _victoryAnimator; // Assign in Inspector for better performance
    public static bool IsVictory = false;

    private Renderer objRenderer;
    private int objectCount = 0;
    private BlockDetection[] blockDetectors;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        blockDetectors = FindObjectsOfType<BlockDetection>();
        objRenderer.material = defaultMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            objectCount++;
            CheckVictoryCondition();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PuzzlePiece"))
        {
            objectCount--;
            CheckVictoryCondition();
        }
    }

    private void CheckVictoryCondition()
    {
        bool anyIntangible = IsAnyBlockDetectorIntangible();

        if (objectCount >= 8 && !anyIntangible)
        {
            if (!IsVictory) // Prevent re-triggering
            {
                _victoryAnimator.SetBool("ShowVictory", true);
                IsVictory = true;
            }
        }
        else if (IsVictory) // Reset if conditions aren't met
        {
            _victoryAnimator.SetBool("ShowVictory", false);
            IsVictory = false;
        }
    }

    private bool IsAnyBlockDetectorIntangible()
    {
        foreach (var detector in blockDetectors)
        {
           // if (detector.GetObjectCount() >= 1)
            {
                return true;
            }
        }
        return false;
    }
}
