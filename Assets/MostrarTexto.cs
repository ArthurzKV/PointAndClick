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
    
    public Controlador controlador;

    public TextosMaquinaEscribir LeerTextos;

    private bool isMouseOver = false;



    private void OnMouseDown()
    {
        if (controlador.Usar == true)
        {
            string textoAReproducir = LineaInteraccionUsar;
            LeerTextos.MostrarTexto(textoAReproducir);
            Debug.Log("Interactuando");
            controlador.Usar = false;

        }

        if (controlador.Hablar == true)
        {
            string textoAReproducir = LineaInteraccionHablar;
            LeerTextos.MostrarTexto(textoAReproducir);
            Debug.Log("Hablando");
            controlador.Hablar = false;
        }

        if (controlador.Abrir == true)
        {
            string textoAReproducir = LineaInteraccionAbrir;
            LeerTextos.MostrarTexto(textoAReproducir);
            Debug.Log("Abriendo");
            controlador.Abrir = false;
        }



    }
    private void OnMouseOver()
    {

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
        else if (!isMouseOver){
            isMouseOver = true;
            textoParaMostrar.text = textoAMostrar;
            Debug.Log("Cursor encima del objeto");
        }

    }

    private void OnMouseExit()
    {
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




    // private IEnumerator ReactivateMovementAfterDelay()
    // {
    //     yield return new WaitForSeconds(0.5f); // Espera 1 segundo.
    //     jugador.canMove = true;
    //     jugador.isMoving = true;
    //     Debug.Log("movimientus");
    // }
}



