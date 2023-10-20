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
        var gameManager = new GameObject().AddComponent<AllSumsGameManager>();
        var replacementNumbers = new GameObject[10];
        var pivot = new GameObject();
        gameManager.pivot = pivot;

        pivot.SetActive(true);
 

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(true);
        }


        gameManager.replacementNumbers = replacementNumbers;

        gameManager.DisableReplacementNumbers();

        Assert.IsFalse(pivot.activeSelf);
        // Assert
        foreach (var replacementNumber in replacementNumbers)
        {
            Assert.IsFalse(replacementNumber.activeSelf);
        }

    }





    [Test]
    public void EnableReplacementNumbers_EnablesPivotAndReplacementNumbers()
    {

        var gameManager = new GameObject().AddComponent<AllSumsGameManager>();
        var replacementNumbers = new GameObject[10];
        var pivot = new GameObject();
        gameManager.pivot = pivot;

        pivot.SetActive(false);

        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i] = new GameObject();
            replacementNumbers[i].SetActive(false);
        }

        gameManager.replacementNumbers = replacementNumbers;

        // Act
        gameManager.EnableReplacementNumbers();

        Assert.IsTrue(pivot.activeSelf);
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
    var gameManagerObject = new GameObject();
    var gameManager = gameManagerObject.AddComponent<AllSumsGameManager>();

    // Simulate a scenario of victory by setting the necessary values
    gameManager.pivot = new GameObject();
    gameManager.replacementNumbers = new GameObject[3];

    // Initialize replacementNumbers with GameObjects
    for (int i = 0; i < gameManager.replacementNumbers.Length; i++)
    {
        gameManager.replacementNumbers[i] = new GameObject();
    }

    // Initialize _numbers with values that meet the victory conditions
    gameManager._numbers = new int[5, 2]
    {
        { 1, 11 },
        { 2, 10 },
        { 3, 9 },
        { 4, 8 },
        { 5, 7 }
    };

    // Set the pivot value (assuming it's a component of the pivot GameObject)
    var pivotNumbersAllSums = gameManager.pivot.AddComponent<NumbersAllSums>();
    pivotNumbersAllSums.value = 6;

    // Act
    var result = gameManager.CheckIfWin();

    // Assert
    Assert.IsTrue(result);
}
[Test]
public void CheckIfWin_ReturnsFalseForLosingConditions()
{
        // Arrange
        var gameManagerObject = new GameObject();
        var gameManager = gameManagerObject.AddComponent<AllSumsGameManager>();

        // Simulate a scenario where the conditions for victory are not met
        gameManager.pivot = new GameObject();
        gameManager.replacementNumbers = new GameObject[3];

        // Initialize replacementNumbers with GameObjects
        for (int i = 0; i < gameManager.replacementNumbers.Length; i++)
        {
            gameManager.replacementNumbers[i] = new GameObject();
        }

        // Initialize _numbers with values that do not meet the victory conditions
        gameManager._numbers = new int[5, 2]
        {
        { 1, 11 },
        { 2, 10 },
        { 3, 9 },
        { 4, 8 },
        { 6, 7 }
        };

        // Set the pivot value to a value that won't result in a win
        var pivotNumbersAllSums = gameManager.pivot.AddComponent<NumbersAllSums>();
        pivotNumbersAllSums.value = 5; // This value doesn't meet the win condition

        // Act
        var result = gameManager.CheckIfWin();

        // Assert
        Assert.IsFalse(result); // We expect the result to be false
    }
}
