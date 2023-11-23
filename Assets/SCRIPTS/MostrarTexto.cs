using UnityEngine;
using TMPro;
using System.Collections;

public class MostrarTexto : MonoBehaviour
{

    public PlayerMovement jugador;
    public TextMeshProUGUI textoParaMostrar; 

    public string textoAMostrar = "Texto que aparecerá"; 
    public string textoAMostrarPorUsar = "Texto que aparecerá2";
    public string LineaInteraccionUsar = "Texto de interaccion";

    public string textoAMostrarPorHablar = "Texto que aparecerá2";
    public string LineaInteraccionHablar = "Texto de interaccion";

    public string textoAMostrarPorAbrir = "Texto que aparecerá2";
    public string LineaInteraccionAbrir = "Texto de interaccion";

    public string textoAMostrarPorCoger = "Texto que aparecerá2";
    public string LineaInteraccionCoger = "Texto de interaccion";
    
    public Controlador controlador;

    public TextosMaquinaEscribir LeerTextos;

    private bool isMouseOver = false;
    private bool isColliding = false;
    private Vector3 interactionPosition;

    



    private void OnMouseDown()
    {
        if (controlador.Usar == true)
        {
            // string textoAReproducir = LineaInteraccionUsar;
            // LeerTextos.MostrarTexto(textoAReproducir);
            StartCoroutine(ReproducirTexto(LineaInteraccionUsar, 1.3f));
            Debug.Log("Interactuando");
            controlador.Usar = false;

        }

        if (controlador.Hablar == true)
        {
            // string textoAReproducir = LineaInteraccionHablar;
            // LeerTextos.MostrarTexto(textoAReproducir);
            StartCoroutine(ReproducirTexto(LineaInteraccionHablar, 1.3f));
            Debug.Log("Hablando");
            // controlador.Hablar = false;
        }

        if (controlador.Abrir == true)
        {
            // string textoAReproducir = LineaInteraccionAbrir;
            // LeerTextos.MostrarTexto(textoAReproducir);
            StartCoroutine(ReproducirTexto(LineaInteraccionAbrir, 1.3f));
            Debug.Log("Abriendo");
            controlador.Abrir = false;
        }

        if (controlador.Coger == true)
        {
            // string textoAReproducir = LineaInteraccionAbrir;
            // LeerTextos.MostrarTexto(textoAReproducir);
            StartCoroutine(ReproducirTexto(LineaInteraccionCoger, 1.3f));
            Debug.Log("cogiendo");
            controlador.Abrir = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPosition = other.transform.position;
            jugador.transform.position = interactionPosition;
            isColliding = true;
            // jugador.isMoving = false;

        }
        else{
            isColliding = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            textoParaMostrar.text = string.Empty;
        }
    }

    private void OnMouseOver()
    {
        if (isColliding)
        {
            if (controlador.Usar)
            {
                if (controlador.Usar == true)
                {
                    textoParaMostrar.text = textoAMostrarPorUsar;
                    Debug.Log("Cursor encima del objeto y bool USAR activado");
                }
            }

            if (controlador.Abrir)
            {
                if (controlador.Abrir == true)
                {
                    textoParaMostrar.text = textoAMostrarPorAbrir;
                    Debug.Log("Cursor encima del objeto y bool Abrir activado");
                }
            }

            if (controlador.Usar == true)
            {
                if (controlador.Usar == true)
                {
                    textoParaMostrar.text = textoAMostrarPorUsar;
                    Debug.Log("Cursor encima del objeto y bool USAR activado");
                }
            }

            if (controlador.Coger == true)
            {
                if (controlador.Coger == true)
                {
                    textoParaMostrar.text = textoAMostrarPorCoger;
                    Debug.Log("Cursor encima del objeto y bool COGER activado");
                }
            }
        }



         if (!isMouseOver && controlador.Usar == true)
         {
             isMouseOver = true;
             textoParaMostrar.text = textoAMostrarPorUsar;
             Debug.Log("Cursor encima del objeto y bool USAR activado");
         }
         else if (!isMouseOver && controlador.Hablar == true){
             isMouseOver = true;
             textoParaMostrar.text = textoAMostrarPorHablar;
             Debug.Log("Cursor encima del objeto y bool HABLAR activado");
         }
         else if (!isMouseOver && controlador.Abrir == true){
             isMouseOver = true;
             textoParaMostrar.text = textoAMostrarPorAbrir;
             Debug.Log("Cursor encima del objeto y bool ABRIR activado");
         }
        else if (!isMouseOver && controlador.Coger == true){
             isMouseOver = true;
             textoParaMostrar.text = textoAMostrarPorCoger;
             Debug.Log("Cursor encima del objeto y bool Coger activado");
         }
         else if (!isMouseOver){
             isMouseOver = true;
             textoParaMostrar.text = textoAMostrar;
             Debug.Log("Cursor encima del objeto");
         }

    }

    private void OnMouseExit()
    {

        if (isColliding)
        {
            textoParaMostrar.text = string.Empty;
        }


        isMouseOver = false;
        textoParaMostrar.text = string.Empty;

        if (controlador.Abrir == true){
            textoParaMostrar.text = "Abrir";
        }
        if (controlador.Cerrar == true){
            textoParaMostrar.text = "Cerrar";
        }
        if (controlador.Dar == true){
            textoParaMostrar.text = "Dar";
        }
        if (controlador.Usar == true){
            textoParaMostrar.text = "Usar";
        }
        if (controlador.Coger == true){
            textoParaMostrar.text = "Coger";
        }
        if (controlador.Pulsar == true){
            textoParaMostrar.text = "Pulsar";
        }
        if (controlador.Hablar == true){
            textoParaMostrar.text = "Hablar";
        }
        if (controlador.Leer == true){
            textoParaMostrar.text = "Leer";
        }
        if (controlador.Empujar == true){
            textoParaMostrar.text = "Empujar";
        }
    
    }

    private IEnumerator ReproducirTexto(string texto, float tiempoDeEspera)
    {
        yield return new WaitForSeconds(tiempoDeEspera);

        LeerTextos.MostrarTexto(texto);
    }

    private IEnumerator MoverJugadorEInteractuar(string texto, float tiempoDeEspera)
    {
        // Mueve al jugador hacia la posición de interacción antes de interactuar
        while (Vector3.Distance(jugador.transform.position, interactionPosition) > 0.1f)
        {
            jugador.MoveTowardsPosition(interactionPosition);
            yield return null;
        }

        // Espera un tiempo antes de mostrar el texto y realizar la interacción
        yield return new WaitForSeconds(tiempoDeEspera);

        textoParaMostrar.text = texto;
        LeerTextos.MostrarTexto(texto);
    }



    // private IEnumerator ReactivateMovementAfterDelay()
    // {
    //     yield return new WaitForSeconds(0.5f); // Espera 1 segundo.
    //     jugador.canMove = true;
    //     jugador.isMoving = true;
    //     Debug.Log("movimientus");
    // }
}



