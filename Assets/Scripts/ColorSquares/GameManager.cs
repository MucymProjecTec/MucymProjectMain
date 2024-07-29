using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] squares;
    public UI_Manager4E uiManager;
    public bool playerWon = false;

    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        if (squares == null || squares.Length == 0)
        {
            Debug.LogError("No PuzzlePieces found!");
            return;
        }

        Debug.Log("Found " + squares.Length + " puzzle pieces.");
        //uiManager = canvas.GetComponent<UI_Manager4E>();

        if (uiManager == null)
        {
            Debug.LogError("UI_Manager4E not found on Canvas!");
            return;
        }

        uiManager.HideVictoryScreen();
        uiManager.StartTimer();

        // Check for the win condition at the start
        checkAllPositions();
        if (playerWon)
        {
            endGame();
        }
    }

    void Update()
    {
        if (!playerWon)
        {
            checkAllPositions();
        }
    }

    public void checkAllPositions()
    {
        bool won = true;
        foreach (GameObject square in squares)
        {
            var movementSquares = square.GetComponent<MovementSquares>();
            int position = movementSquares.GetPosition();
            Debug.Log($"Square {square.name} is in position {position}");
            if (position != 1)
            {
                won = false;
                break;
            }
        }
        if (won)
        {
            playerWon = true;
            Debug.Log("Player has won!");
            endGame();
        }
    }

    private void endGame()
    {
        Debug.Log("Ending game and showing victory screen.");
        if (uiManager != null)
        {
            uiManager.StopTimer();
            uiManager.ShowVictoryScreen();
        }
        else
        {
            Debug.LogError("UI_Manager4E is not assigned in GameManager!");
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
