using System.Collections;
using UnityEngine;

public class PieceAppearAnimation : MonoBehaviour
{
    public float appearHeight = 10.0f;  // Height from where pieces appear
    public float appearSpeed = 1.0f;    // This parameter is defined but not used in the logic
    public float appearDuration = 1.0f; // Duration of the animation

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isAnimating = false;

    void Start()
    {
        // Save the final position as the target position
        targetPosition = transform.position;

        // Initialize the starting position at a specific height
        initialPosition = new Vector3(transform.position.x, appearHeight, transform.position.z);
        transform.position = initialPosition;

        Debug.Log($"Initial Position set to {initialPosition}");
        Debug.Log($"Target Position set to {targetPosition}");

        //StartAppearAnimation();
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
            // Lerp between initial and target positions over the duration
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / appearDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the position is set to the target at the end
        transform.position = targetPosition;
        isAnimating = false;

        Debug.Log($"Animation complete. Final position: {transform.position}");
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
