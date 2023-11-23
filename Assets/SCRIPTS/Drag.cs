using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    // Rotation speed for the card.
    public float RotationSpeed = 3.0f;

    // Reference to the PlayerMovement component.
    public PlayerMovement jugador;

    // This method is called while the user is dragging the mouse over the GameObject.
    private void OnMouseDrag()
    {
        // Get the change in mouse position along the X and Y axes.
        float deltaX = Input.GetAxis("Mouse X") * RotationSpeed;
        float deltaY = Input.GetAxis("Mouse Y") * RotationSpeed;

        // Rotate the GameObject around the world Y-axis based on the mouse X movement.
        transform.Rotate(Vector3.up, -deltaX, Space.World);

        // Rotate the GameObject around the world X-axis based on the mouse Y movement.
        transform.Rotate(Vector3.right, -deltaY, Space.World);

        // Disable player movement while dragging the card.
        jugador.canMove = false;
        jugador.isMoving = false;
    }
}