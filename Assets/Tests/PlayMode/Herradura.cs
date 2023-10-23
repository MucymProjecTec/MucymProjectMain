using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Herradura
{
    [Test]
    public void ReturnEmptySpace_ReturnsCorrectIndexForEmptySpace()
    {
        // Arrange
        GameObject myHoof = new GameObject("MyHoof");
        Algorithm algorithm = myHoof.AddComponent<Algorithm>();
        algorithm.valores = new string[] { "Ball1", "null", "Ball2", "null", "Ball3" };
        int expectedIndex = 1;

        // Act
        int result = algorithm.returnEmptySpace();

        // Assert
        Assert.AreEqual(expectedIndex, result);
    }

    [Test]
    public void ReturnEmptySpace_ReturnsMinusOneWhenNoEmptySpace()
    {
        // Arrange
        GameObject myHoof = new GameObject("MyHoof");
        Algorithm algorithm = myHoof.AddComponent<Algorithm>();
        algorithm.valores = new string[] { "Ball1", "Ball2", "Ball3" };

        // Act
        int result = algorithm.returnEmptySpace();

        // Assert
        Assert.AreEqual(-1, result);
    }

    [Test]
    public void ReturnBallIndex_ReturnsCorrectIndexForExistingBall()
    {
        // Arrange
        GameObject myHoof = new GameObject("MyHoof");
        Algorithm algorithm = myHoof.AddComponent<Algorithm>();
        algorithm.valores = new string[] { "Ball1", "null", "Ball2", "null", "Ball3" };
        string ballName = "Ball2";
        int expectedIndex = 2;

        // Act
        int result = algorithm.returnBallIndex(ballName);

        // Assert
        Assert.AreEqual(expectedIndex, result);
    }

    [Test]
    public void ReturnBallIndex_ReturnsMinusOneForNonExistingBall()
    {
        // Arrange
        GameObject myHoof = new GameObject("MyHoof");
        Algorithm algorithm = myHoof.AddComponent<Algorithm>();
        algorithm.valores = new string[] { "Ball1", "null", "Ball2", "null", "Ball3" };
        string nonExistentBallName = "NonExistentBall";

        // Act
        int result = algorithm.returnBallIndex(nonExistentBallName);

        // Assert
        Assert.AreEqual(-1, result);
    }


}
