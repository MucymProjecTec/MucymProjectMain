using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AllsumsTest
{
       [Test]
    public void DisableReplacementNumbers_DisablesPivotAndReplacementNumbers()
    {
        // Arrange
        var gameManagerObject = new GameObject();
        var gameManager = gameManagerObject.AddComponent<AllSumsGameManager>();
        var pivot = new GameObject();
        var replacementNumbers = new GameObject[3];

        gameManager.pivot = pivot;
        gameManager.replacementNumbers = replacementNumbers;

        // Act
        gameManager.DisableReplacementNumbers();

        // Assert
        Assert.IsFalse(pivot.activeSelf);
        foreach (var replacementNumber in replacementNumbers)
        {
            Assert.IsFalse(replacementNumber.activeSelf);
        }
    }

    [Test]
    public void EnableReplacementNumbers_EnablesPivotAndReplacementNumbers()
    {
        // Arrange
        var gameManager = new GameObject().AddComponent<AllSumsGameManager>();
        var pivot = new GameObject();
        var replacementNumbers = new GameObject[3];

        pivot.SetActive(false);
        foreach (var replacementNumber in replacementNumbers)
        {
            replacementNumber.SetActive(false);
        }

        gameManager.pivot = pivot;
        gameManager.replacementNumbers = replacementNumbers;

        // Act
        gameManager.EnableReplacementNumbers();

        // Assert
        Assert.IsTrue(pivot.activeSelf);
        foreach (var replacementNumber in replacementNumbers)
        {
            Assert.IsTrue(replacementNumber.activeSelf);
        }
    }
[Test]
public void CheckIfWin_ReturnsTrueForWinningConditions()
{
    // Arrange
    var gameManagerObject = new GameObject();
    var gameManager = gameManagerObject.AddComponent<AllSumsGameManager>();

    // Simula un escenario de victoria estableciendo valores necesarios
    gameManager.pivot = new GameObject();
    gameManager.replacementNumbers = new GameObject[3];

    // Simula un escenario donde todos los números cumplen las condiciones de victoria
    for (int i = 0; i < gameManager.replacementNumbers.Length; i++)
    {
        gameManager.replacementNumbers[i] = new GameObject();
    }

    // Simula un escenario donde _numbers tiene valores que cumplen las condiciones de victoria
    gameManager._numbers = new int[5, 2]
    {
        {1, 2},
        {3, 4},
        {5, 6},
        {7, 8},
        {9, 10}
    };

    // Act
    var result = gameManager.CheckIfWin();

    // Assert
    Assert.IsTrue(result);
}
[Test]
public void CheckIfWin_ReturnsFalseForLosingConditions()
{
    // Arrange
    var gameManager = new GameObject().AddComponent<AllSumsGameManager>();

    // Simular una situación de derrota:
    // Configura _numbers con los valores adecuados para una derrota.
    // Asegúrate de que gameManager.pivot y replacementNumbers estén configurados correctamente.

    // Por ejemplo, configura _numbers y otros componentes para una situación de derrota:
    gameManager.pivot = new GameObject();
    gameManager.replacementNumbers = new GameObject[3];

    // Configura _numbers para que no cumpla con la condición de victoria.
    // Aquí se configuran valores arbitrarios a modo de ejemplo que no cumplen con la condición de victoria.
    gameManager._numbers[0, 0] = 5;
    gameManager._numbers[0, 1] = 3;
    gameManager._numbers[1, 0] = 2;
    gameManager._numbers[1, 1] = 7; // Este valor no cumple con la condición de derrota.

    // ...

    // Act
    var result = gameManager.CheckIfWin();

    // Assert
    Assert.IsFalse(result);
}
}
