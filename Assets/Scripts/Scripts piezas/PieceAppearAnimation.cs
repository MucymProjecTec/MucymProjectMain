using System.Collections;
using UnityEngine;

public class PieceAppearAnimation : MonoBehaviour
{
    public float appearHeight = 10.0f;  // Altura desde donde aparecer�n las piezas
    public float appearSpeed = 1.0f;
    public float appearDuration = 1.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isAnimating = false;

    void Start()
    {
        // Guardar la posici�n final como la posici�n objetivo
        targetPosition = transform.position;

        // Inicializar la posici�n en una altura espec�fica
        initialPosition = new Vector3(transform.position.x, appearHeight, transform.position.z);
        transform.position = initialPosition;

        Debug.Log($"Iniciando animaci�n de aparici�n en {initialPosition} hacia {targetPosition} con duraci�n {appearDuration}s");

    }

    public void StartAppearAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(AppearAnimation());
        }
    }

    IEnumerator AppearAnimation()
    {
        isAnimating = true;
        float elapsedTime = 0f;

        while (elapsedTime < appearDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, (elapsedTime / appearDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isAnimating = false;
    }

    public bool IsAnimating()
    {
        return isAnimating;
    }

    public float AppearDuration
    {
        get { return appearDuration; }
    }
}
