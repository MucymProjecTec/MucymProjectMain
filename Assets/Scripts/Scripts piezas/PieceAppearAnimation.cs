using System.Collections;
using UnityEngine;

public class PieceAppearAnimation : MonoBehaviour
{
    public float appearHeight = 10.0f;  // Altura desde donde aparecerán las piezas
    public float appearSpeed = 1.0f;
    public float appearDuration = 1.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isAnimating = false;

    void Start()
    {
        // Guardar la posición final como la posición objetivo
        targetPosition = transform.position;

        // Inicializar la posición en una altura específica
        initialPosition = new Vector3(transform.position.x, appearHeight, transform.position.z);
        transform.position = initialPosition;

        Debug.Log($"Iniciando animación de aparición en {initialPosition} hacia {targetPosition} con duración {appearDuration}s");

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
