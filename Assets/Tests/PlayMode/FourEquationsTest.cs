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
        var replacementNumbers = new GameObject[3];

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
        var replacementNumbers = new GameObject[3];

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
        gameManager.replacementNumbers = new GameObject[3];
        gameManager._numbers = new int[4, 3]; // Cambiar el tamaño de la matriz a 4x3
        var number1 = new GameObject();
        var number2 = new GameObject();
        var number3 = new GameObject();
        var number4 = new GameObject();

        // Set up the Numbers components with values to satisfy the equations
        number1.AddComponent<Numbers>().value = 2;
        number2.AddComponent<Numbers>().value = 3;
        number3.AddComponent<Numbers>().value = 6; // Cumple la ecuación: 2 - 3 = 6
        number4.AddComponent<Numbers>().value = 9; // Cumple la ecuación: 3 / 2 = 9

        number1.GetComponent<Numbers>().row = 0;
        number1.GetComponent<Numbers>().col = 0;
        number2.GetComponent<Numbers>().row = 0;
        number2.GetComponent<Numbers>().col = 1;
        number3.GetComponent<Numbers>().row = 0;
        number3.GetComponent<Numbers>().col = 2;
        number4.GetComponent<Numbers>().row = 1;
        number4.GetComponent<Numbers>().col = 1;
    }

    [Test]
    public void CheckIfWin_ReturnsFalseForLosingConditions()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<FourEquationsGameManager>();
        gameManager.replacementNumbers = new GameObject[3];
        gameManager._numbers = new int[3, 3];
        var number1 = new GameObject();
        var number2 = new GameObject();
        var number3 = new GameObject();
        var number4 = new GameObject();

        // Set up the Numbers components with values that do not meet the winning conditions
        number1.AddComponent<Numbers>().value = 2;
        number2.AddComponent<Numbers>().value = 3;
        number3.AddComponent<Numbers>().value = 7; // Incorrect value
        number4.AddComponent<Numbers>().value = 0;

        number1.GetComponent<Numbers>().row = 0;
        number1.GetComponent<Numbers>().col = 0;
        number2.GetComponent<Numbers>().row = 0;
        number2.GetComponent<Numbers>().col = 1;
        number3.GetComponent<Numbers>().row = 0;
        number3.GetComponent<Numbers>().col = 2;
        number4.GetComponent<Numbers>().row = 1;
        number4.GetComponent<Numbers>().col = 1;

        // Act
        var result = gameManager.CheckIfWin();

        // Assert
        Assert.IsFalse(result);
    }
    // Add more test methods for other functions as needed
}