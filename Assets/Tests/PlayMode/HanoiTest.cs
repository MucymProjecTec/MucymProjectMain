using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine;

[TestFixture]
public class HanoiTest
{
    [UnityTest]
    public IEnumerator WinCondition_CheckWinCondition_WithExpectedValue_ShouldReturnTrue()
    {
        // Configuración de prueba
        GameObject gameObj = new GameObject();
        WinCondition winCondition = gameObj.AddComponent<WinCondition>();
        HanoiDisk hanoiDisk = CreateDiskWithSize(5); // Crear un disco con el tamaño esperado
        winCondition.expectedValue = 5;

        // Ejecutar la prueba
        bool result = winCondition.CheckWinCondition();

        // Verificar el resultado
        Assert.IsFalse(result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator WinCondition_CheckWinCondition_WithUnexpectedValue_ShouldReturnFalse()
    {
        // Configuración de prueba
        GameObject gameObj = new GameObject();
        WinCondition winCondition = gameObj.AddComponent<WinCondition>();
        HanoiDisk hanoiDisk = CreateDiskWithSize(3); // Crear un disco con un tamaño diferente al esperado
        winCondition.expectedValue = 5;

        // Ejecutar la prueba
        bool result = winCondition.CheckWinCondition();

        // Verificar el resultado
        Assert.IsFalse(result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator WinCondition_CheckWinCondition_WithNoDisk_ShouldReturnFalse()
    {
        // Configuración de prueba
        GameObject gameObj = new GameObject();
        WinCondition winCondition = gameObj.AddComponent<WinCondition>();
        winCondition.expectedValue = 5;

        // Ejecutar la prueba
        bool result = winCondition.CheckWinCondition();

        // Verificar el resultado
        Assert.IsFalse(result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ConditionCheck_CheckCondition_WithDiskAbove_ShouldReturnTrue()
    {
        // Configuración de prueba
        GameObject gameObj = new GameObject();
        ConditionCheck conditionCheck = gameObj.AddComponent<ConditionCheck>();
        HanoiDisk hanoiDiskAbove = CreateDiskWithSize(5); // Crear un disco con un tamaño superior
        conditionCheck.transform.position = Vector3.zero; // Asegurarse de que la posición de la condición esté en cero

        // Ejecutar la prueba
        bool result = conditionCheck.CheckCondition(3);

        // Verificar el resultado
        Assert.IsFalse(result);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ConditionCheck_CheckCondition_WithDiskBelow_ShouldReturnFalse()
    {
        // Configuración de prueba
        GameObject gameObj = new GameObject();
        ConditionCheck conditionCheck = gameObj.AddComponent<ConditionCheck>();
        HanoiDisk hanoiDiskBelow = CreateDiskWithSize(3); // Crear un disco con un tamaño inferior
        conditionCheck.transform.position = Vector3.zero; // Asegurarse de que la posición de la condición esté en cero

        // Ejecutar la prueba
        bool result = conditionCheck.CheckCondition(5);

        // Verificar el resultado
        Assert.IsFalse(result);

        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        // Limpieza de recursos si es necesario.
    }

    // Función de utilidad para crear un disco con un tamaño específico
    private HanoiDisk CreateDiskWithSize(int size)
    {
        GameObject diskObj = new GameObject();
        HanoiDisk hanoiDisk = diskObj.AddComponent<HanoiDisk>();
        hanoiDisk.size = size;
        diskObj.tag = "Disk";
        return hanoiDisk;
    }
}
