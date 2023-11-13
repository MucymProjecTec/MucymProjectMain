using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSumsGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    public int[,] _numbers;

    public GameObject pivot;

    private UI_ManagerAllSums _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[5, 2];
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerAllSums>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableReplacementNumbers()
    {
        pivot.SetActive(false);
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(false);
        }
        
    }

    public void EnableReplacementNumbers()
    {
        pivot.SetActive(true);
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(true);
        }
       
    }



    
    public bool CheckIfWin()
    {
        bool flag = false;

        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            NumbersAllSums numScript = nums[i].GetComponent<NumbersAllSums>();
     

            if (numScript.row != 5 && numScript.col != 2)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    _numbers[numScript.row, numScript.col] = numScript.value; //Load the value of the piece on it's current position 
            }

            if (numScript.row == 5 && numScript.col == 5)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    pivot.GetComponent<NumbersAllSums>().value = numScript.value; //Load the value of the piece on it's current position 
            }



        }

        int condition1_value = _numbers[0, 0] + _numbers[0, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition2_value = _numbers[1, 0] + _numbers[1, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition3_value = _numbers[2, 0] + _numbers[2, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition4_value = _numbers[3, 0] + _numbers[3, 1] + pivot.GetComponent<NumbersAllSums>().value;
        int condition5_value = _numbers[4, 0] + _numbers[4, 1] + pivot.GetComponent<NumbersAllSums>().value;
        Debug.Log("Condition 1 value:  " + condition1_value);
        Debug.Log("Condition 2 value:  " + condition2_value);
        Debug.Log("Condition 3 value:  " + condition3_value);
        Debug.Log("Condition 4 value:  " + condition4_value);
        Debug.Log("Condition 5 value: " + condition1_value);



        int targetValue = condition1_value;
        if (condition1_value != targetValue ||
            condition2_value != targetValue ||
            condition3_value != targetValue ||
            condition4_value != targetValue ||
            condition5_value != targetValue)
        {
            flag = false;
        }
        if (condition1_value == targetValue &&
           condition2_value == targetValue &&
           condition3_value == targetValue &&
           condition4_value == targetValue &&
           condition5_value == targetValue)
        {
            flag = true;
        }
   
   
        return flag;



    }
    public void CheckLastMovement()
    {

        if (checkGameOver())
        {
            int pivotVal = pivot.GetComponent<NumbersAllSums>().value;
            Debug.Log("Pivot: " + pivotVal);
            if (pivotVal != 0)
            {
                _uiManager.ShowGameOver();
            }

        }

        if (CheckIfWin())
        {

            _uiManager.closeGameOver();
            _uiManager.ShowVictoryScreen();
            _uiManager.StopTimer();
        }

 
        

        

    }


    public bool checkGameOver()
    {
        bool flag = false;
        
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
       
        for (int i = 0; i < nums.Length; i++)
        {
            NumbersAllSums numScript = nums[i].GetComponent<NumbersAllSums>();

            if (numScript.row != 5 && numScript.col != 2)
            {
                if (numScript.value == 0)
                {
                    flag = false;

                }
                   
                if (numScript.value != 0)
                {
                    flag = true;
                }

            }
            if (numScript.row == 5 && numScript.col == 5)
            {
                if (numScript.value == 0) //If there are still clean pieces on the evaluation board: row -> 0,1,2 or col -> 0,1,2
                    return false;
                else
                    pivot.GetComponent<NumbersAllSums>().value = numScript.value; //Load the value of the piece on it's current position 
            }



        }
        Debug.Log("Flag Gamer Over: " + flag);
        return flag;
    }


    public void RestartGame()
    {
        _uiManager.HideVictoryScreen();
        _uiManager.closeGameOver();
        EnableReplacementNumbers();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<NumbersAllSums>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }



    

}

