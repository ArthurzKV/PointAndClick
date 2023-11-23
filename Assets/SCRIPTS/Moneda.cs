using UnityEngine;
using System.Collections;
using TMPro;

public class Moneda : MonoBehaviour
{
    public Controlador controlador;
    public GameObject MonedaObject;
    public GameObject MonedaInventario;
    public PlayerMovement player;
    private Vector3 playerOriginalPosition;
    public bool MonedaCogida = false;

    private void Update()
    {
        if(MonedaCogida == true){
            ReactivateMovementAfterDelay();
            controlador.Coger = false;
        }
    
    }

    private void OnMouseDown()
    {
        if (controlador.Usar == true)
        {
            // Realiza la acción correspondiente al uso.
        }

        if (controlador.Hablar == true)
        {
            // Realiza la acción correspondiente a hablar.
        }

        if (controlador.Abrir == true)
        {

        }

        if (controlador.Coger == true)
        {

            playerOriginalPosition = player.transform.position;

            MonedaObject.SetActive(false);
            MonedaInventario.SetActive(true);
            player.isMoving = false;
            player.canMove = true;
            controlador.Coger = false;
            MonedaCogida = true; 
        }
        else{
            ReactivateMovementAfterDelay();
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con el jugador.
        if (collision.gameObject.CompareTag("Player") && controlador.Abrir == true)
        {
            ReactivateMovementAfterDelay();
            // Realiza acciones específicas cuando hay una colisión con el jugador.
            Debug.Log("Colisión con el jugador");
        }
    }

    private IEnumerator ReactivateMovementAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        player.canMove = true;
        Debug.Log("Reactivado");
    }
}
