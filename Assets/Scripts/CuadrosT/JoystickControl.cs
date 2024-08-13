using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickControl : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the object moves
    public InputActionReference movementControl; // Reference to the joystick input

    private Vector2 movementInput;

    void Update()
    {
        // Read the joystick input
        movementInput = movementControl.action.ReadValue<Vector2>();

        // Apply the movement to the object
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
