using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Aquí puedes agregar más lógica para controlar la cámara
}
