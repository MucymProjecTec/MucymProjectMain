﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    public int[,] _numbers;

    public UI_ManagerMagicSquare _uiManager;

    bool flagOver;
    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[3, 3];
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerMagicSquare>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(false);
        }
    }

    public void EnableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(true);
        }
    }

    public bool CheckIfWin()
    {
        bool checkColumnSum, checkRowSum, checkDiagonalSum, checkAntiDiagonalSum;
        int counterRowSum, counterColumnSum;
        checkColumnSum = false;
        counterColumnSum = 0;
        checkRowSum = false;
        counterRowSum = 0;
        checkDiagonalSum = false;
        checkAntiDiagonalSum = false;

        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        int size = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            OptionsNumbers numScript = nums[i].GetComponent<OptionsNumbers>();

            if (numScript.row != 4 && numScript.col != 4)
            {
                if (numScript.value == 0) // If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    _numbers[numScript.row, numScript.col] = numScript.value; // Load the value of the piece in its current position
            }
        }

        for (int i = 0; i < 3; i++)
        {
            // Verificar las filas
            if ((_numbers[i, 0] + _numbers[i, 1] + _numbers[i, 2]) == 15)
            {
    
                counterRowSum += 1;

            }


            // Verificar las columnas
            if ((_numbers[0, i] + _numbers[1, i] + _numbers[2, i]) == 15)
            {
                counterColumnSum += 1;

            }
   
        }
        if (counterRowSum.Equals(3))
        {
            checkRowSum = true;
        }
        if (counterColumnSum.Equals(3))
        {
            checkColumnSum = true;
        }


        // Verificar las diagonales
        if ((_numbers[0, 0] + _numbers[1, 1] + _numbers[2, 2]) == 15)
        {
            checkDiagonalSum = true;
          
        }

        if ((_numbers[0, 2] + _numbers[1, 1] + _numbers[2, 0]) == 15)
        {
            checkAntiDiagonalSum = true;
            
        }
        bool flagv = checkColumnSum && checkRowSum && checkDiagonalSum && checkAntiDiagonalSum;
        Debug.Log("CheckiF Win Prueba: " + flagv);
        return checkColumnSum && checkRowSum && checkDiagonalSum && checkAntiDiagonalSum;
    }

 



    public void CheckLastMovement()
    {

        flagOver = checkGameOver();
        if (flagOver == true)
        {
            _uiManager.ShowGameOver();
        }
        if (flagOver == false)
        {
            if (_uiManager.losePanel.activeSelf == true)
            {
                _uiManager.closeGameOver();

            }
        }


        if (CheckIfWin())
        {
            if (_uiManager.losePanel.activeSelf == true)
            {
                _uiManager.closeGameOver();
                _uiManager.ShowVictoryScreen();
                _uiManager.StopTimer();

            }
            else
            {
                _uiManager.ShowVictoryScreen();
                _uiManager.StopTimer();
            }
  
        }









    }


    public bool checkGameOver()
    {
        bool flag = false;

        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            OptionsNumbers numScript = nums[i].GetComponent<OptionsNumbers>();

            if (numScript.row != 4 && numScript.col != 4)
            {
              if (numScript.value == 0)
                {
                    flag= false;
                }


                else
                {
                    flag = true;
                }

            }
        }
        return flag;

    }

    public void RestartGame()
    {
        _uiManager.HideVictoryScreen();
        EnableReplacementNumbers();
        _uiManager.closeGameOver();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<OptionsNumbers>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }
}
