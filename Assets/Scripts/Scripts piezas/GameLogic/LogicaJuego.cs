using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaJuego : MonoBehaviour
{
    [SerializeField] private List<GameObject> trianglePieces;
    [SerializeField] private List<GameObject> hexagonPieces;
    [SerializeField] private Collider triangleCollider;
    [SerializeField] private Collider hexagonCollider;
    private List<GameObject> currentPieces;
    private Collider currentCollider;

    private UI_Manager4E _uiManager4E;
    public AudioSource audioFelicidades;
    public Animator _victoryAnimator;

    private int currentStage = 1; // 1: triángulo, 2: hexágono
    private CameraController cameraController;

    void Start()
    {
        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
        _uiManager4E.StartTimer();
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>();

        cameraController = Camera.main.GetComponent<CameraController>();

        SetStage(1);

        // Iniciar animación de aparición de las piezas del triángulo
        StartCoroutine(AppearPieces(trianglePieces));
    }

    void Update()
    {
        // No hay lógica en el Update por el momento.
    }

    public void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!(currentPieces.Contains(other.gameObject)) && FullyContains(other, currentCollider))
        {
            currentPieces.Add(other.gameObject);
        }
        else if ((currentPieces.Contains(other.gameObject)) && !FullyContains(other, currentCollider))
        {
            currentPieces.Remove(other.gameObject);
        }

        // Condición de victoria para triángulo
        if (currentStage == 1 && currentPieces.Count == trianglePieces.Count)
        {
            _uiManager4E.StopTimer();
            SetStage(2);
        }
        // Condición de victoria para hexágono
        else if (currentStage == 2 && currentPieces.Count == hexagonPieces.Count)
        {
            _uiManager4E.StopTimer();
            ShowVictoryScreen();
        }
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
            currentCollider = triangleCollider;
            cameraController.SetTarget(GameObject.Find("TriangleTarget").transform);
        }
        else if (stage == 2)
        {
            currentPieces = hexagonPieces;
            currentCollider = hexagonCollider;
            cameraController.SetTarget(GameObject.Find("HexagonTarget").transform);
            StartCoroutine(AppearPieces(hexagonPieces));
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
