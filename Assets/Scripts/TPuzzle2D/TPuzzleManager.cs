using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPuzzleManager : MonoBehaviour
{
    [SerializeField]    private List<GameObject> pieces;
    private UI_Manager4E _uiManager4E;
    public  PieceManager piezaDetectada;
    public AudioSource audioFelicidades;
    public Animator _victoryAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager4E = GameObject.Find("Canvas").GetComponent<UI_Manager4E>();
        
        _victoryAnimator = GameObject.Find("VictoryPanel").GetComponent<Animator>(); //Victory Panel Calling
        piezaDetectada = GetComponent<PieceManager>();

        if (_uiManager4E != null) {
            _uiManager4E.StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Victory Condition
        if (piezaDetectada.pieceData.winCount == 3) {    
            piezaDetectada.pieceData.winCount = 0;               
            //_uiManager4E.StopTimer();
            ShowVictoryScreen();
        }
    }

    void OnApplicationQuit()
    {
        // Asigna un valor a la variable justo antes de que el juego se cierre
        piezaDetectada.pieceData.winCount = 0;
    }

    public void ShowVictoryScreen()
    {
        _victoryAnimator.SetBool("ShowVictory", true);
        
    }
}
