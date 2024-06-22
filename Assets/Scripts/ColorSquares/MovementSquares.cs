using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSquares : MonoBehaviour
{
    private GameManager manager;
    private int currentPosition = 1;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("No GameManager found!");
        }

        // Initialize position randomly
        ///SetPosition(Random.Range(1, 5));
        Debug.Log("Initial position set to: " + currentPosition);
    }

    void Update()
    {
        // Optionally, place any necessary update logic here
    }

    public void rotate()
    {
        Debug.Log("Rotating piece from position: " + currentPosition);
        this.transform.Rotate(0, 0, 90);

        // Update the current position
        currentPosition = (currentPosition % 4) + 1;
        Debug.Log("New position is: " + currentPosition);
    }

    public void SetPosition(int position)
    {
        currentPosition = position;
        Vector3 euler = transform.eulerAngles;
        euler.z = 90 * (currentPosition - 1);
        transform.eulerAngles = euler;
        Debug.Log("SetPosition called: New position is " + currentPosition);
    }

    public int GetPosition()
    {
        return currentPosition;
    }
}
