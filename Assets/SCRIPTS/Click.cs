using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public PlayerMovement jugador;

    // Llama a esta función cuando se hace clic en el objeto
    public void OnMouseDown()
    {
        jugador.canMove = false;

        // Llama a una función que reactive el movimiento después de 0.1 segundos
        Invoke("ReactivateMovement", 0.05f);
    }

    // Esta función se llama después de 0.1 segundos
    private void ReactivateMovement()
    {
        jugador.canMove = true;
    }
}
