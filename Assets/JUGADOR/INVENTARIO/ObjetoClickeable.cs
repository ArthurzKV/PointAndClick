using UnityEngine;
using System.Collections;

public class ObjetoClickeable : MonoBehaviour
{
    public Controlador controlador;
    public PlayerMovement player;
    private Vector3 playerOriginalPosition;
    private bool Colision = false;

    private void OnMouseDown()
    {

        playerOriginalPosition = player.transform.position;
        player.isMoving = false;
        player.canMove = true;

        // Busca el componente InventarioCanvasScript en el objeto "Inventario"

        InventarioCanvasScript inventarioScript = FindObjectOfType<InventarioCanvasScript>();

        if (inventarioScript != null)
        {
            SpriteRenderer objetoSprite = GetComponent<SpriteRenderer>();

            if (objetoSprite != null)
            {
                // Desactiva el objeto en el mapa (GameObject, no el sprite)

                if (controlador.Coger == true)
                {
                    Colision = true;

                }
                else
                {
                    ReactivateMovementAfterDelay();
                }

            }
            else
            {
                Debug.LogError("El objeto clickeable no tiene un componente SpriteRenderer.");
            }
        }
        else
        {
            Debug.LogError("No se encontró el componente 'InventarioCanvasScript' en el objeto 'Inventario'.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer objetoSprite = GetComponent<SpriteRenderer>();
        InventarioCanvasScript inventarioScript = FindObjectOfType<InventarioCanvasScript>();
        // Aquí puedes realizar acciones específicas cuando hay una colisión 2D
        // Puedes acceder a la información de la colisión a través del parámetro 'collision'
        if(Colision == true){
            inventarioScript.AgregarAlInventario(objetoSprite.sprite);
            gameObject.SetActive(false);
            controlador.Coger = false;
            ReactivateMovementAfterDelay();
            playerOriginalPosition = player.transform.position;
            player.isMoving = false;
            player.canMove = true;
        }
    }

    void Update()
    {
        // if(controlador.Coger == true && tomado == true){
        //             Debug.Log("Inventario");
        // }

        
    }

    private IEnumerator ReactivateMovementAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        player.canMove = true;
        Debug.Log("Reactivado");
    }
}
