using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicaJuego : MonoBehaviour
{
    [SerializeField] private List<GameObject> trianglePieces;
    [SerializeField] private List<GameObject> hexagonPieces;
    public GameObject trianglePiecesContainer;  
    private List<GameObject> currentPieces;
    private Collider currentCollider;

    private UI_Manager4E _uiManager4E;
    public AudioSource audioFelicidades;
    public Animator _victoryAnimator;

    private int currentStage = 1; // 1: triángulo, 2: hexágono
    private CameraController cameraController;

    private bool triangleCompleted = false;
    private bool hexagonCompleted = false;

    void Start()
    {
        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
        //_uiManager4E.StartTimer();
        //_victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();

        cameraController = Camera.main.GetComponent<CameraController>();

        SetStage(1);

        // Iniciar animación de aparición de las piezas del triángulo
        StartCoroutine(AppearPieces(trianglePieces));
    }

    void Update()
    {
        if (!triangleCompleted && CheckIfTriangleComplete())
        {
            triangleCompleted = true;
        }
        else if (!hexagonCompleted && CheckIfHexagonComplete())
        {
            hexagonCompleted = true;
        }

        if (triangleCompleted && hexagonCompleted)
        {
            ShowVictoryScreen();
        }
    }


    public void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
    }

    // Verifica si todas las piezas del triángulo están en la posición correcta
    private bool CheckIfTriangleComplete()
    {
        return trianglePieces.All(piece => piece.GetComponent<PieceCheckPosition>().GetIsInCorrectPosition());
    }

    // Verifica si todas las piezas del hexágono están en la posición correcta
    private bool CheckIfHexagonComplete()
    {
        return hexagonPieces.All(piece => piece.GetComponent<PieceCheckPosition>().GetIsInCorrectPosition());
    }

    bool FullyContains(Collider resident, Collider zone, float tolerance = .02f)
    {
        if (zone == null)
        {
            return false;
        }

        Bounds expandedBounds = new Bounds(zone.bounds.center, zone.bounds.size + Vector3.one * tolerance);

        return expandedBounds.Contains(resident.bounds.min) &&
               expandedBounds.Contains(resident.bounds.max) &&
               expandedBounds.Contains(resident.bounds.center);
    }

    void SetStage(int stage)
    {
        currentStage = stage;
        if (stage == 1)
        {
            currentPieces = trianglePieces;
            cameraController.SetTarget(GameObject.Find("TriangleTarget").transform);
            trianglePiecesContainer.SetActive(true);
        }
    }

    IEnumerator AppearPieces(List<GameObject> pieces)
    {
        foreach (var piece in pieces)
        {
            PieceAppearAnimation animationScript = piece.GetComponent<PieceAppearAnimation>();
            if (animationScript != null)
            {
                animationScript.StartAppearAnimation();
                yield return new WaitForSeconds(animationScript.AppearDuration);
            }
        }
    }
}
