using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MagicSquare
{
    [Test]
    public void DisableReplacementNumbers_DisablesAllReplacementNumbers()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<MagicSquareGameManager>();
        var replacementNumbers = new GameObject[9];

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(true); // Asegurarse de que estén activos
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
        var gameManager = new GameObject().AddComponent<MagicSquareGameManager>();
        var replacementNumbers = new GameObject[9];

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(false); // Asegurarse de que estén desactivos
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
        var gameManager = new GameObject().AddComponent<MagicSquareGameManager>();
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

        number1.AddComponent<OptionsNumbers>().value = 2;
        number2.AddComponent<OptionsNumbers>().value = 9;
        number3.AddComponent<OptionsNumbers>().value = 4;
        number4.AddComponent<OptionsNumbers>().value = 7;
        number5.AddComponent<OptionsNumbers>().value = 5;
        number6.AddComponent<OptionsNumbers>().value = 3;
        number7.AddComponent<OptionsNumbers>().value = 6;
        number8.AddComponent<OptionsNumbers>().value = 1;
        number9.AddComponent<OptionsNumbers>().value = 8;

        // Configurar la ubicación de los números en la matriz _numbers
        gameManager._numbers[0, 0] = number1.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[0, 1] = number2.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[0, 2] = number3.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 0] = number4.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 1] = number5.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 2] = number6.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 0] = number7.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 1] = number8.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 2] = number9.GetComponent<OptionsNumbers>().value;

        // Luego, puedes llamar a la función CheckIfWin para verificar si la matriz cumple con las condiciones de victoria
        var result = gameManager.CheckIfWin();
        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CheckIfWin_ReturnsFalseForLosingConditions()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<MagicSquareGameManager>();
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

        // Set up the OptionsNumbers components with values that do not meet the winning conditions
        number1.AddComponent<OptionsNumbers>().value = 1;
        number2.AddComponent<OptionsNumbers>().value = 9;
        number3.AddComponent<OptionsNumbers>().value = 7;
        number4.AddComponent<OptionsNumbers>().value = 8;
        number5.AddComponent<OptionsNumbers>().value = 6;
        number6.AddComponent<OptionsNumbers>().value = 2;
        number7.AddComponent<OptionsNumbers>().value = 3;
        number8.AddComponent<OptionsNumbers>().value = 4;
        number9.AddComponent<OptionsNumbers>().value = 5;

        gameManager._numbers[0, 0] = number1.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[0, 1] = number2.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[0, 2] = number3.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 0] = number4.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 1] = number5.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[1, 2] = number6.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 0] = number7.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 1] = number8.GetComponent<OptionsNumbers>().value;
        gameManager._numbers[2, 2] = number9.GetComponent<OptionsNumbers>().value;

        // Act
        var result = gameManager.CheckIfWin();

        // Assert
        Assert.IsFalse(result);
    }
}
