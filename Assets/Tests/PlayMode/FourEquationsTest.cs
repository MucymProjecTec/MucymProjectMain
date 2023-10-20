using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FourEquationsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DisableReplacementNumbers_DisablesAllReplacementNumbers()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<FourEquationsGameManager>();
        var replacementNumbers = new GameObject[9];

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(true);
        }


        gameManager.replacementNumbers = replacementNumbers;

        // Act
        gameManager.DisableReplacementNumbers();

        // Assert
        foreach (var replacementNumber in replacementNumbers)
        {
            Assert.IsFalse(replacementNumber.activeSelf);
        }
    }

    [Test]
    public void EnableReplacementNumbers_EnablesAllReplacementNumbers()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<FourEquationsGameManager>();
        var replacementNumbers = new GameObject[9];

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(false);
        }

        gameManager.replacementNumbers = replacementNumbers;

        // Act
        gameManager.EnableReplacementNumbers();

        // Assert
        foreach (var replacementNumber in replacementNumbers)
        {
            Assert.IsTrue(replacementNumber.activeSelf);
        }
    }

    [Test]
    public void CheckIfWin_ReturnsTrueForWinningConditions()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<FourEquationsGameManager>();
        gameManager.replacementNumbers = new GameObject[9];
        gameManager._numbers = new int[3, 3];
        var number1 = new GameObject();
        var number2 = new GameObject();
        var number3 = new GameObject();
        var number4 = new GameObject();
        var number5 = new GameObject();
        var number6 = new GameObject();
        var number7 = new GameObject();
        var number8 = new GameObject();
        var number9 = new GameObject();

        // Set values for each number
        number1.AddComponent<Numbers>().value = 9;
        number2.AddComponent<Numbers>().value = 5;
        number3.AddComponent<Numbers>().value = 4;
        number4.AddComponent<Numbers>().value = 6;
        number5.AddComponent<Numbers>().value = 3;
        number6.AddComponent<Numbers>().value = 2;
        number7.AddComponent<Numbers>().value = 7;
        number8.AddComponent<Numbers>().value = 1;
        number9.AddComponent<Numbers>().value = 8;

        // Set the row and column for each number
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject numberObject = null;
                switch (row * 3 + col)
                {
                    case 0: numberObject = number1; break;
                    case 1: numberObject = number2; break;
                    case 2: numberObject = number3; break;
                    case 3: numberObject = number4; break;
                    case 4: numberObject = number5; break;
                    case 5: numberObject = number6; break;
                    case 6: numberObject = number7; break;
                    case 7: numberObject = number8; break;
                    case 8: numberObject = number9; break;
                }

                numberObject.GetComponent<Numbers>().row = row;
                numberObject.GetComponent<Numbers>().col = col;
                gameManager._numbers[row, col] = numberObject.GetComponent<Numbers>().value;
            }
        }

        // Act
        var result = gameManager.CheckIfWin();

        // Assert
        Assert.IsTrue(result);
    }


    [Test]
    public void CheckIfWin_ReturnsFalseForLosingConditions()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<FourEquationsGameManager>();
        gameManager.replacementNumbers = new GameObject[9];
        gameManager._numbers = new int[3, 3]; // Cambiar el tamaño de la matriz a 4x3
        var number1 = new GameObject();
        var number2 = new GameObject();
        var number3 = new GameObject();
        var number4 = new GameObject();
        var number5 = new GameObject();
        var number6 = new GameObject();
        var number7 = new GameObject();
        var number8 = new GameObject();
        var number9 = new GameObject();

        number1.AddComponent<Numbers>().value = 7;
        number2.AddComponent<Numbers>().value = 5;
        number3.AddComponent<Numbers>().value = 2;

        number4.AddComponent<Numbers>().value = 6;
        number5.AddComponent<Numbers>().value = 3;
        number6.AddComponent<Numbers>().value = 9;

        number7.AddComponent<Numbers>().value = 4;
        number8.AddComponent<Numbers>().value = 1;
        number9.AddComponent<Numbers>().value = 8;

        number1.GetComponent<Numbers>().row = 0;
        number1.GetComponent<Numbers>().col = 0;

        number2.GetComponent<Numbers>().row = 0;
        number2.GetComponent<Numbers>().col = 1;

        number3.GetComponent<Numbers>().row = 0;
        number3.GetComponent<Numbers>().col = 2;

        number4.GetComponent<Numbers>().row = 1;
        number4.GetComponent<Numbers>().col = 0;

        number5.GetComponent<Numbers>().row = 1;
        number5.GetComponent<Numbers>().col = 1;

        number6.GetComponent<Numbers>().row = 1;
        number6.GetComponent<Numbers>().col = 2;

        number7.GetComponent<Numbers>().row = 2;
        number7.GetComponent<Numbers>().col = 0;

        number8.GetComponent<Numbers>().row = 2;
        number8.GetComponent<Numbers>().col = 1;

        number9.GetComponent<Numbers>().row = 2;
        number9.GetComponent<Numbers>().col = 2;

        var result = gameManager.CheckIfWin();
     

        // Assert
        Assert.IsFalse(result);
    }
    // Add more test methods for other functions as needed
}